using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MMSystem.Model;
using MMSystem.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Services.Depart
{
    public class MocDepartment : Idepartment
    {

        public MocDepartment(AppDbCon db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;

        }
        private AppDbCon _db { get; }
        private IMapper _mapper { get; }
        public Task<bool> Add(Department t)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> addsub(int par, Department department)
        {
              if (department != null)
           
            {
                
                department.perent = par;
                department.state = true;
                await _db.Departments.AddAsync(department);
                await _db.SaveChangesAsync();
                return true;
            }
           
            else
                return false;
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var d = await find(id);

                if (d != null)
                {
                    d.state = false;
                    _db.Departments.Update(d);
                    await _db.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Department> find(int id)

        {
           var dep = await _db.Departments.FindAsync(id);
           
            return dep;
        }

        public async Task<DepartmentDto> Get(int id)
        {
            try
            {
                Department t = await _db.Departments.FindAsync(id);
                DepartmentDto dt = _mapper.Map<DepartmentDto>(t);
                return dt;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<DepartmentDto>> GetAll()
        {
            try
            {
                //  List<Department> dep = await _db.Departments.ToListAsync();
                List<Department> dep = await _db.Departments.Where(x => x.perent == 0 && x.state==true).ToListAsync();

                var depdto = _mapper.Map<List<Department>, List<DepartmentDto>>(dep);
                return depdto;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<DepartmentDto>> GetDepartment(int id)
        {
            try
            {

                List<Department> departs = await _db.Departments.Where(x => x.Id != id).ToListAsync();
                var list = _mapper.Map<List<Department>, List<DepartmentDto>>(departs);

                return list;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<DepartmentDto>> getsub(int par)
        {
            try
            {
               
                var t1 = await _db.Departments.Where(pa => pa.perent == par).ToListAsync();


                List<DepartmentDto> dt = _mapper.Map<List<DepartmentDto>>(t1);
                return dt;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> Update(Department depart)
        {
            var dep = await find(depart.Id);
            if (dep != null)
            {
                dep.perent = depart.perent;
                dep.state = depart.state;
                dep.DepartmentName = depart.DepartmentName;
                await _db.SaveChangesAsync();
                return true;
            }
            else
                return false;
        }
    }
}
