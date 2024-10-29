using UserRoleIdentity.Data;
using UserRoleIdentity.Data.Entity;

namespace UserRoleIdentity.Repository.impl
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext context;

        public CategoryRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task Create(Category category)
        {
            await context.AddAsync(category);
        }

        public void Delete(Category category)
        {
            context.Categories.Remove(category);
        }

        public async Task<Category> GetCategoryByid(int id)
        {
            return await context.Categories.FindAsync(id);
        }


        public async Task<int> Submit()
        {
            return await context.SaveChangesAsync();
        }

        public void Update(Category category)
        {
            context.Categories.Update(category);
        }
    }
}