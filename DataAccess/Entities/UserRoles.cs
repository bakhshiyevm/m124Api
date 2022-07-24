﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class UserRoles : BaseEntity
    {
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
