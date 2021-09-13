using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Model.Dto
{
    public class DepartmentDto
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }


        public int perent { get; set; }
        public bool state { get; set; }
    }
}
