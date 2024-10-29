using UserRoleIdentity.Model.DTO;

namespace UserRoleIdentity.Service
{
    public interface ICategoryService
    {
        Task Create(CategoryCreateDTO categoryCreateDTO);
        Task<GetCategoryByidDTO> GetCategoryByid(int id);
       Task Update(UpdateDTO updateDTO, int id);
        Task Delete(int id);
    }
}
