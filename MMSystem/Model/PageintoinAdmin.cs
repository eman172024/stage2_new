using MMSystem.Model;
using MMSystem.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Model
{
    public class PageintoinAdmin
    {
        public int total { get; set; }
        public List<AdministratorDto> listofUser { get; set; } = new List<AdministratorDto>();
    }
}
