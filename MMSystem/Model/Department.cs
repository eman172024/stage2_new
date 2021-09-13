using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Model
{
    public class Department
    {
        [Key]

        public int Id { get; set; }
        public string DepartmentName { get; set; }


        public int perent { get; set; }


        public bool state { get; set; }


        public List<Administrator> Users { get; set; }


    }
}
