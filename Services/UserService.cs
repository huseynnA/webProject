using AutoMapper;
using DataAccess;
using DataAccess.Entity;
using DTO;
using Services.Abstract;
using Services.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UserService:BaseService<UserDTO,User,UserDTO>,IUserService
    {
        public UserService(IMapper mapper,AppDbContext appDbContext):base(appDbContext,mapper)
        {

        }

        public UserDTO Login(UserDTO model)
        {

            var res = _db.Users.Where(x => x.Username == model.Username);

            if (res.Count() == 1)
            {
                var user = res.FirstOrDefault();
                var hash = Crypto.GenerateSHA256Hash(model.Password, user.Salt);

                if (hash == user.PasswordHash)
                {
                    var dto = _mapper.Map<User, UserDTO>(res.First());
                    return dto;
                }
                else
                {
                    throw new Exception("Wrong password!");
                }
            }
            else
            {
                throw new Exception("User not found");
            }

        }

        public virtual UserDTO Create(UserDTO model)
        {
            model.Salt = Crypto.GenerateSalt();
            model.PasswordHash = Crypto.GenerateSHA256Hash(model.Password, model.Salt);

            return base.Create(model);
        }

        

    }
}
