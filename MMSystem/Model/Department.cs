using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Model
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        public int numberOfMail { get; set; }

        public string Section { get; set; }

        public int NumberOfPhotos { get; set; }

        public List<Administrator> Users { get; set; }


    }
}
