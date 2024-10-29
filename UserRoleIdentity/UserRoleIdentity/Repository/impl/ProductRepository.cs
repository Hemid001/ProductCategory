using Microsoft.EntityFrameworkCore;
using UserRoleIdentity.Data;
using UserRoleIdentity.Data.Entity;

namespace UserRoleIdentity.Repository.impl
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext context;

        public ProductRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task Create(Product product)
        {
            await context.AddAsync(product);

        }

        public Task<Product> GetProductById(int id)
        {
            return context.Products.Include(m=>m.Category).FirstOrDefaultAsync(m=>m.id == id);
        }

        public async Task<int> Submit()
        {
            return await context.SaveChangesAsync();
        }
    }
}
