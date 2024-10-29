using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserRoleIdentity.Model.DTO;
using UserRoleIdentity.Service;

namespace UserRoleIdentity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }
        [HttpPost]
        public async Task<IActionResult> Create(PorductCreateDTO porductCreateDTO)
        {
            await productService.Create(porductCreateDTO);
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetProductById(int id)
        {
            var result = await productService.GetProductById(id);
            return Ok(result);
        }
    }
}
