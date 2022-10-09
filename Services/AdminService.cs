using AutoMapper;
using DataAccess;
using DataAccess.Entities;
using DataAccess.Entity;
using DTO;
using Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AdminService:BaseService<AdminDTO,Admin,AdminDTO>,IAdminService
    {
        public AdminService(AppDbContext appDb, IMapper imapper):base(appDb,imapper)
        {

        }

        public ProductDTO CreateProduct(ProductDTO product )
        {
            var dto = _mapper.Map<ProductDTO, Product>(product);
            var ent = _db.Products.Add(dto);
            _db.SaveChanges();

            var res = _mapper.Map<Product, ProductDTO>(dto);
            return res;
        }

        public UserDTO CreateUser(UserDTO user)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }
    }

}
