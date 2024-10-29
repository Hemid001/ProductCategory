using AutoMapper;
using UserRoleIdentity.Data.Entity;
using UserRoleIdentity.Model.DTO;
using UserRoleIdentity.Repository;

namespace UserRoleIdentity.Service.impl
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper mapper;
        private readonly ICategoryRepository categoryRepository;

        public CategoryService(IMapper mapper, ICategoryRepository categoryRepository)
        {
            this.mapper = mapper;
            this.categoryRepository = categoryRepository;
        }
        public async Task Create(CategoryCreateDTO categoryCreateDTO)
        {
            var categoryEntity = mapper.Map<Category>(categoryCreateDTO);
            await categoryRepository.Create(categoryEntity);
            _ = await categoryRepository.Submit();
        }

        public async Task Delete(int id)
        {
            var existingCategory = await categoryRepository.GetCategoryByid(id);
            categoryRepository.Delete(existingCategory);
            await categoryRepository.Submit();
        }

        public async Task<GetCategoryByidDTO> GetCategoryByid(int id)
        {
            var categoryEntity = await categoryRepository.GetCategoryByid(id);
            var categoryDto = mapper.Map<GetCategoryByidDTO>(categoryEntity);
            return categoryDto;
        }

        public async Task Update(UpdateDTO updateDTO, int id)
        {
            var existingCategory = await categoryRepository.GetCategoryByid(id);
            var updatedCategory = mapper.Map(updateDTO, existingCategory);
            categoryRepository.Update(updatedCategory);
            await categoryRepository.Submit();
        }

    }
}
