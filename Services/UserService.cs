using Services.Abstract;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using DTO;
using AutoMapper;

namespace Services
{
    public class UserService : BaseService<UserDTO,User, UserDTO>, IUserService
    {
        public UserService(AppDbContext db, IMapper mapper) : base(db, mapper)
        {
        }

        public UserDTO Login(string ps, string us)
        {
           
            var res = _db.Users.Where(x => x.Name == us && x.Password == ps);
            if (res.Count() == 1)
            {
                var dto  = _mapper.Map<User,UserDTO> (res.First());
                return dto;
            }
            else
            {
                throw new Exception("User tapilmadi");
            }

        }
    }
}
