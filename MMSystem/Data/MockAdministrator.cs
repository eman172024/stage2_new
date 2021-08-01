using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MMSystem.Model;
using passport_aca.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Data
{
    public class MockAdministrator : IAdministratorInterface
    {

        public MockAdministrator(AppDbCon data)
        {
            _data = data;

        }

        public AppDbCon _data { get; }
        public async Task<MassageInfo> Add(Administrator user)
        {
            MassageInfo massageInfo = new MassageInfo();
            try
            {
                if (user != null)
                {
                    user.state = true;
                    await _data.Administrator.AddAsync(user);
                    await _data.SaveChangesAsync();
                    massageInfo.Massage = "تمت عملية الأضافة ";
                    massageInfo.statuscode = 201;
                    return massageInfo;
                }
                else
                {

                    massageInfo.statuscode = 404;
                    return massageInfo;
                }

            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<MassageInfo> Delete(int id)
        {
            MassageInfo massageInfo = new MassageInfo();
            try
            {
                Administrator FIndUsers = await _data.Administrator.FindAsync(id);

                if (FIndUsers != null)
                {

                    FIndUsers.state = false;
                    _data.Administrator.Update(FIndUsers);
                    await _data.SaveChangesAsync();
                    massageInfo.Massage = "تمت عملية المسح ";
                    massageInfo.statuscode = 202;
                    return massageInfo;

                }
                else
                {
                    massageInfo.Massage = "لم تتم عملية المسح هذا المستخدم غير موجود ";
                    massageInfo.statuscode = 404;
                    return massageInfo;

                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<AdministratorDto> Get(int id)
        {

            try
            {
                Administrator user = await _data.Administrator.FindAsync(id);
                var config = new MapperConfiguration(mc => mc.CreateMap<Administrator, AdministratorDto>());

                var maper = new Mapper(config);

                var userdto = maper.Map<Administrator, AdministratorDto>(user);

                return userdto;

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

                List<Administrator> d = await _data.Administrator.OrderByDescending(x => x.UserId).Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
                pageing.total = _data.Administrator.Count();

                foreach (var item in d)
                {
                    pageing.listofUser.Add(new AdministratorDto()
                    {
                      //  UserId = item.UserId,
                        UserName = item.UserName,
                    //    password = item.password,
                        FirstMACAddress = item.FirstMACAddress,
                        SecandMACAddress = item.SecandMACAddress,
                        Role = item.Role,
                        DepartmentId = item.DepartmentId,
                        state = item.state
                    });

                }

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
                List<Administrator> listOfuser = await _data.Administrator.OrderByDescending(x => x.UserId ).Where(x => x.state == true).ToListAsync(); 


                var config = new MapperConfiguration(mc => mc.CreateMap<Administrator, AdministratorDto>());

                var maper = new Mapper(config);

                var list = maper.Map<List<Administrator>, List<AdministratorDto>>(listOfuser);

                return list;
            }
            catch (Exception)
            {

                throw;
            }

        }

        

        public async Task<AdministratorDto> login(Login user1)
        {
            try
            {
                Administrator user = await _data.Administrator.FirstOrDefaultAsync(x => x.UserName == user1.UserName && x.state == true);


                if (user != null)
                {
                 
                    bool isValid = BCrypt.Net.BCrypt.Verify(user1.Password, user.password);
                    if (isValid)
                    {

                        var config = new MapperConfiguration(mc => mc.CreateMap<Administrator, AdministratorDto>());

                        var maper = new Mapper(config);

                        var userDto = maper.Map<Administrator, AdministratorDto>(user);

                        return userDto;


                    }
                    else
                    {


                    }

                }

                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<MassageInfo> Update(Administrator user)
        {

            MassageInfo massageInfo = new MassageInfo();
            try
            {
                Administrator UpdateUser = await _data.Administrator.FindAsync(user.UserId);


                if (UpdateUser != null)
                {
                    UpdateUser.UserName = user.UserName;
                    UpdateUser.password = user.password;
                    UpdateUser.FirstMACAddress = user.FirstMACAddress;
                    UpdateUser.SecandMACAddress = user.SecandMACAddress;
                    UpdateUser.Role = user.Role;
                    UpdateUser.DepartmentId = user.DepartmentId;
                    UpdateUser.state = user.state;
                    _data.Administrator.Update(UpdateUser);
                    await _data.SaveChangesAsync();
                    massageInfo.Massage = "تمت عملية التحديث ";
                    massageInfo.statuscode = 200;
                    return massageInfo;

                }
                else
                {
                    massageInfo.Massage = "لم تتم عملية التحديث ";
                    massageInfo.statuscode = 304;
                    return massageInfo;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
