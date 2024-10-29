using Microsoft.AspNetCore.Mvc;
using UserRoleIdentity.Model.DTO;
using UserRoleIdentity.Service;

namespace UserRoleIdentity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateDTO categoryCreateDTO)
        {
            await categoryService.Create(categoryCreateDTO);
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetCategoryByid(int id)
        {
            var result = await categoryService.GetCategoryByid(id);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateDTO updateDTO, int id)
        {
            await categoryService.Update(updateDTO, id);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await categoryService.Delete(id);
            return Ok();
        }
    }
}
