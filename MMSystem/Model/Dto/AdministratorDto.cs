﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Model.Dto
{
    public class AdministratorDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FirstMACAddress { get; set; }
        public string SecandMACAddress { get; set; }
        public string nationalNumber { get; set; }
        public int DepartmentId { get; set; }

       // public List<UserRoles> UserRoles { get; set; }
    }
}
