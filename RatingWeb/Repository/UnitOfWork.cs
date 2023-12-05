
using RatingWeb.Repository.IRepository;

namespace RatingWeb.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        private ApplicationDbContext _db;
        public ICategoryRepository Category { get; private set; }
        public IRatingRepository Rating { get; private set; }

        public IProductRepository Product { get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            Product = new ProductRepository(_db);
        }

        public void Save()
        {
            try
            {
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                // Log or print exception details for debugging
                Console.WriteLine(ex.Message);
                throw; // Re-throw the exception to preserve the original stack trace
            }
        }

    }
}
