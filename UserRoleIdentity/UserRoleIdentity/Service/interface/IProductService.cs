using UserRoleIdentity.Model.DTO;

namespace UserRoleIdentity.Service
{
    public interface IProductService
    {
        Task Create(PorductCreateDTO porductCreateDTO);
        Task<GetProductByIdDTO> GetProductById(int id);
    }
}
