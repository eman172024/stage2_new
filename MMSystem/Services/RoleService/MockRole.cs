using AutoMapper;
using MMSystem.Model;
using MMSystem.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Services.RoleService
{
    public class MockRole : GenericInterface<Role,RoleDto>
    {
        public MockRole(AppDbCon data, IMapper mapper)
        {
            _data = data;

            _mapper = mapper;

        }

        private AppDbCon _data { get; }
        private IMapper _mapper { get; }

        public async Task<bool> Add(Role t)
        {

            try
            {
              Role role = new Role();

              await _data.Roles.AddAsync(t);

              await _data.SaveChangesAsync();

                return true;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                Role FIndRoles = await _data.Roles.FindAsync(id);

                if (FIndRoles != null)
                {

                   FIndRoles.state = false;
                    _data.Roles.Update(FIndRoles);
                    await _data.SaveChangesAsync();
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

        public async Task<RoleDto> Get(int id)
        {
            try
            {
                Role role = await _data.Roles.FindAsync(id);

                RoleDto roledto = _mapper.Map<Role, RoleDto>(role);

                return roledto;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<RoleDto>> GetAll()
        {
            try
            {
               List<Role> listOfRole =  _data.Roles.OrderBy(x => x.RoleId).Where(x => x.state == true).ToList();

                List<RoleDto> list = new List<RoleDto>();

                    list.Add(new RoleDto
                {
                    Name = "الكل",
                    RoleId = 100,
                    state = true
                });

                foreach (var item in listOfRole)
                {

                    list.Add(new RoleDto
                    {
                        Name =item.Name,
                        RoleId = item.RoleId,
                        state = true
                    });


                }
                //list = _mapper.Map<List<Role>, List<RoleDto>>(listOfRole);
                
                return list;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> Update(Role model)
        {
           
            try
            {
               Role role = new Role();

               role = await _data.Roles.FindAsync(model.RoleId);


                if (role != null)
                {
                   
                    role.Name = model.Name;
                    role.state = model.state;
                   
                    _data.Roles.Update(role);

                    await _data.SaveChangesAsync();


                    return true;

                }
                return false;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
