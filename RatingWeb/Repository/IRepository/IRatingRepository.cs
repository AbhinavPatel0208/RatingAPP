using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using RatingWeb.Models;

namespace RatingWeb.Repository.IRepository
{
    public interface IRatingRepository : IRepository<Rating>
    {
        IEnumerable<Rating> GetAll(
            Expression<Func<Rating, bool>> filter = null,
            Func<IQueryable<Rating>, IOrderedQueryable<Rating>> orderBy = null,
            string includeProperties = null
        );

        // Remove the Save method from the interface
        // void Save();

        // Add any additional methods specific to rating operations if needed
    }
}
