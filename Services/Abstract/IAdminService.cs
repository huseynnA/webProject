using DataAccess.Entity;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstract
{

    public interface IAdminService: IBaseService<AdminDTO, Admin, AdminDTO> 
    {
        public ProductDTO CreateProduct(ProductDTO product);
        public void DeleteProduct(int id);
        public UserDTO CreateUser(UserDTO user);
    }
}
