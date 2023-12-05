using RatingWeb.Models;

namespace RatingWeb.Repository.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        void Update(Product obj);
        void Save();
    }
}
