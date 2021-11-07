using MMSystem.Model;
using MMSystem.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Services.Depart
{
    public interface Idepartment : GenericInterface<Department, DepartmentDto>
       

    {
        Task<List<DepartmentDto>> getsub(int par);


        Task<bool> addsub(int par, Department department);

        Task<Department> find(int id);

        Task<List<DepartmentDto>> GetDepartment(int id);

    }
}
