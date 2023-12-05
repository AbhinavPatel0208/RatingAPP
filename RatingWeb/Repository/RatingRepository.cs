using Microsoft.EntityFrameworkCore;

using RatingWeb.Models;
using RatingWeb.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace RatingWeb.Repository
{
    public class RatingRepository : Repository<Rating>, IRatingRepository
    {
        private readonly ApplicationDbContext _db;

        public RatingRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<Rating> GetAll(Expression<Func<Rating, bool>> filter = null, Func<IQueryable<Rating>, IOrderedQueryable<Rating>> orderBy = null, string includeProperties = null)
        {
            IQueryable<Rating> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            // Include properties logic if needed
            // if (!string.IsNullOrEmpty(includeProperties))
            // {
            //     foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            //     {
            //         query = query.Include(includeProperty);
            //     }
            // }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return query.ToList();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
