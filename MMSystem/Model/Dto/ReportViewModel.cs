using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Model.Dto
{
    public class ReportViewModel
    {

        public string DepartmentName { get; set; }

        public int total { get; set; }
        public List<DepartmentViewModelDto> data { get; set; }


    }
}
