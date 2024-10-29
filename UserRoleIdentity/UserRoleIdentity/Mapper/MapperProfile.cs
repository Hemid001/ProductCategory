using AutoMapper;
using UserRoleIdentity.Data.Entity;
using UserRoleIdentity.Model.DTO;

namespace UserRoleIdentity.Mapper
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<User, UserGetDTO>().ReverseMap();
            CreateMap<User, UserCreateDTO>().ReverseMap().ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email));
            CreateMap<Category, CategoryCreateDTO>().ReverseMap();
            CreateMap<Category, GetCategoryByidDTO>().ReverseMap();
            CreateMap<Category, UpdateDTO>().ReverseMap();
            CreateMap<Product, PorductCreateDTO>().ReverseMap();
            CreateMap<Product, GetProductByIdDTO>().ReverseMap();


        }
    }
}
