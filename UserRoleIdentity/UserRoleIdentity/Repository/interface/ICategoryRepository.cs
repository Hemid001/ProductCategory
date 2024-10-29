using UserRoleIdentity.Data.Entity;

namespace UserRoleIdentity.Repository
{
    public interface ICategoryRepository
    {
        Task Create(Category category);
        Task<Category> GetCategoryByid(int id);
        public void Update(Category category);
        Task<int> Submit();
        public void Delete(Category category);
    }
}
