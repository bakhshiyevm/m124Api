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
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public class UserRoleService : BaseService<UserRoleDTO, UserRoles, UserRoleDTO>, IUserRoleService
    {
        public UserRoleService(AppDbContext db, IMapper mapper) : base(db, mapper)
        {

        }

        public override IEnumerable<UserRoleDTO> Get()
        {
            var ent = _dbSet.Include(x=>x.User).Include(x=>x.Role);

            var res = _mapper.Map<IEnumerable<UserRoleDTO>>(ent);

            //var res = new List<UserRoleDTO>();

            //foreach (var ur in ent) 
            //{
            //    var dto = new UserRoleDTO()
            //    {
            //        RoleId = ur.RoleId,
            //        RoleName = ur.Role.Name,
            //        UserId = ur.UserId,
            //        UserName = ur.User.Name
            //    };

            //    res.Add(dto);

            //}


            return res;
        }
    }
}
