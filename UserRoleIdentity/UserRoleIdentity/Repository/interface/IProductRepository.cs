using UserRoleIdentity.Data.Entity;

namespace UserRoleIdentity.Repository
{
    public interface IProductRepository
    {
        Task Create(Product product);
        Task<int> Submit();
        Task<Product> GetProductById(int id);
    }
}
