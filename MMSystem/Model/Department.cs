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

        public int numberOfMail { get; set; }

        public string Section { get; set; }

        public int NumberOfPhotos { get; set; }

        public List<Administrator> Users { get; set; }


    }
}
