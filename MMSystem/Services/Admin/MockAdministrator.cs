using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MMSystem.Model;
using MMSystem.Model.Dto;
using MMSystem.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Services
{
    public class MockAdministrator : IAdministratorInterface
    {

        public MockAdministrator(AppDbCon data, IMapper mapper)
        {
            _data = data;

            _mapper = mapper;

        }

        private AppDbCon _data { get; }
        private IMapper _mapper { get; }

        public async Task<bool> Add(UserAddORUpdate user)
        {

            try
            {
                UserRoles role = new UserRoles();

                if (user != null)
                {
                    Administrator FIndUsers = await _data.Administrator.FirstOrDefaultAsync(x => x.nationalNumber == user.Administrator.nationalNumber);

                    if (FIndUsers == null)
                    {

                        await _data.Administrator.AddAsync(user.Administrator);
                        await _data.SaveChangesAsync();

                        foreach (var item in user.Listrole)
                        {
                            await _data.userRoles.AddAsync(new UserRoles
                            {
                                RoleId = item,
                                UserId = user.Administrator.UserId
                            });
                            await _data.SaveChangesAsync();
                        }

                    }
                    else
                    {
                        return false;
                    }

                    return true;
                }
                return false;

            }
            catch (Exception)
            {
                throw;
            }

        }

        public Task<bool> Add(Administrator t)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(int id)
        {

            try
            {
                Administrator FIndUsers = await _data.Administrator.FindAsync(id);

                if (FIndUsers != null)
                {
                    FIndUsers.state = !FIndUsers.state;
                    _data.Administrator.Update(FIndUsers);
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

        public async Task<UserView> Get(int id)
        {

            try
            {
                UserView view = new UserView();

                Administrator user = await _data.Administrator.FirstOrDefaultAsync(x => x.UserId == id);


                view.Administrator = _mapper.Map<Administrator, AdministratorDto>(user);

                view.Listrole = await (from userrole in _data.userRoles.Where(x => x.UserId == user.UserId)
                                       join
                                       role in _data.Roles on userrole.RoleId equals role.RoleId
                                       select role).ToListAsync();



                return view;

            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<PageintoinAdmin> GetAdministrator(int page, int pageSize)
        {
            try
            {
                PageintoinAdmin pageing = new PageintoinAdmin();

                List<Administrator> ListOfAdministrator = await _data.Administrator.OrderByDescending(x => x.UserId).Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
                pageing.total = _data.Administrator.Count();

                pageing.listofUser = _mapper.Map<List<Administrator>, List<AdministratorDto>>(ListOfAdministrator);


                return pageing;
            }
            catch (Exception)
            {

                throw;
            }

        }


        public async Task<List<AdministratorDto>> GetAll()
        {
            try
            {
                List<Administrator> listOfuser = await _data.Administrator.OrderByDescending(x => x.UserId).Where(x => x.state == true).ToListAsync();



                var list = _mapper.Map<List<Administrator>, List<AdministratorDto>>(listOfuser);

                return list;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<List<int>> GetJustRole(int id)
        {
            try
            {
                List<int> oldRole = await (from userrole in _data.userRoles.Where(x => x.UserId == id)
                                     select userrole.RoleId).ToListAsync();


                return oldRole;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<UserView> login(Login user1)
        {
            try
            {
                UserView view = new UserView();

                Administrator user = await _data.Administrator.FirstOrDefaultAsync(x => x.UserName == user1.UserName && x.state == true);

                if (user != null)
                {

                    bool isValid = BCrypt.Net.BCrypt.Verify(user1.Password, user.password);

                    if (isValid)
                    {

                        view.Administrator = _mapper.Map<Administrator, AdministratorDto>(user);

                        view.Listrole = await (from userrole in _data.userRoles.Where(x => x.UserId == user.UserId)
                                               join
                                               role in _data.Roles on userrole.RoleId equals role.RoleId
                                               select role).ToListAsync();
                        return view;
                    }
                    return null;

                }
                return null;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<AdministratorDto>> SearchByDepartmentId(int DepartmentId)
        {
            try
            {
                List<Administrator> users = await _data.Administrator.OrderByDescending(x => x.UserName).Where(x => x.DepartmentId == DepartmentId && x.state==true).ToListAsync();

                List<AdministratorDto> usersDto = _mapper.Map<List<Administrator>, List<AdministratorDto>>(users);

                return usersDto;
            }
            catch
            {
                throw;
            }
        }
        public async Task<List<AdministratorDto>> SearchByDepartmentIdControl(int DepartmentId)
        {
            try
            {
                List<Administrator> users = await _data.Administrator.OrderByDescending(x => x.UserName).Where(x => x.DepartmentId == DepartmentId).ToListAsync();

                List<AdministratorDto> usersDto = _mapper.Map<List<Administrator>, List<AdministratorDto>>(users);

                return usersDto;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<UserFind>> SearchByName(string user)
        {
            try
            {

                List<UserFind> userfind1 = new List<UserFind>();
                List<Administrator> users = await _data.Administrator.Where(x => x.UserName.Contains(user)).ToListAsync();

                List<AdministratorDto> usersDto = _mapper.Map<List<Administrator>, List<AdministratorDto>>(users);

                foreach (var item in usersDto)
                {
                    Department Dp = _data.Departments.FirstOrDefault(x => x.Id == item.DepartmentId);

                    userfind1.Add(new UserFind
                    {
                        state = item.state,
                        UserId = item.UserId,
                        department_name = Dp.DepartmentName,
                        UserName = item.UserName
                    });

                }

                return userfind1;





            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Update(UserAddORUpdate user)
        {

            try
            {
                UserRoles role = new UserRoles();

                UserAddORUpdate view = new UserAddORUpdate();

                view.Administrator = await _data.Administrator.FindAsync(user.Administrator.UserId);


                if (view.Administrator != null)
                {

                    view.Administrator.UserName = user.Administrator.UserName;
                    if (view.Administrator.password != user.Administrator.password) { 
                    view.Administrator.password = BCrypt.Net.BCrypt.HashPassword(user.Administrator.password);
                    }
                    view.Administrator.FirstMACAddress = user.Administrator.FirstMACAddress;
                    view.Administrator.SecandMACAddress = user.Administrator.SecandMACAddress;
                    view.Administrator.DepartmentId = user.Administrator.DepartmentId;
                    view.Administrator.nationalNumber = user.Administrator.nationalNumber;
                    view.Administrator.state = user.Administrator.state;
                    view.Administrator.userNetwork = user.Administrator.userNetwork;
                    _data.Administrator.Update(view.Administrator);
                    await _data.SaveChangesAsync();


                    List<UserRoles> Listrol = await _data.userRoles.Where(x => x.UserId == user.Administrator.UserId).ToListAsync();

                    foreach (var item in Listrol)
                    {
                        _data.userRoles.Remove(item);
                        await _data.SaveChangesAsync();
                    }


                    if (user.Listrole.Count > 0)
                    {
                        foreach (var item in user.Listrole)
                        {

                            await _data.userRoles.AddAsync(new UserRoles
                            {
                                RoleId = item,
                                UserId = user.Administrator.UserId
                            });
                            await _data.SaveChangesAsync();
                        }
                        return true;

                    }


                    return false;

                }
                return false;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<bool> Update(Administrator model)
        {
            throw new NotImplementedException();
        }

        Task<AdministratorDto> GenericInterface<Administrator, AdministratorDto>.Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
