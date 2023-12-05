namespace RatingWeb.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category { get; }
        IProductRepository Product { get; }
        IRatingRepository Rating { get; }
        void Save();
    }
}
