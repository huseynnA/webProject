using AutoMapper;
using DataAccess.Entities;
using DataAccess.Entity;
using DTO;

namespace Presentation.Config
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();

            CreateMap<Admin, AdminDTO>();
            CreateMap<AdminDTO, Admin>();

            CreateMap<Product, ProductDTO>();
            CreateMap<ProductDTO, Product>();
        }
    }
}
