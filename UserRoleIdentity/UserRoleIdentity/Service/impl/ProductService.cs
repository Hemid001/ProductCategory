using AutoMapper;
using UserRoleIdentity.Data.Entity;
using UserRoleIdentity.Model.DTO;
using UserRoleIdentity.Repository;

namespace UserRoleIdentity.Service.impl
{
    public class ProductService : IProductService
    {
        private readonly IMapper mapper;
        private readonly IProductRepository productRepository;

        public ProductService(IMapper mapper, IProductRepository productRepository)
        {
            this.mapper = mapper;
            this.productRepository = productRepository;
        }

        public async Task Create(PorductCreateDTO porductCreateDTO)
        {
            var productEntity = mapper.Map<Product>(porductCreateDTO);
            await productRepository.Create(productEntity);
            _= await productRepository.Submit();
        }

        public async Task<GetProductByIdDTO> GetProductById(int id)
        {
            var productEntity = await productRepository.GetProductById(id);
            var productDto = mapper.Map<GetProductByIdDTO>(productEntity);   
            return productDto;
           _ = await productRepository.Submit();  
        }

       
    }
}
