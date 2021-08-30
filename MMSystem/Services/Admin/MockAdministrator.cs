using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MMSystem.Model;
using MMSystem.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Services { 
    public class MockAdministrator : IAdministratorInterface 
    {

        public MockAdministrator(AppDbCon data, IMapper mapper)
        {
            _data = data;

            _mapper = mapper;

        }

        private AppDbCon _data { get; }
        private IMapper _mapper { get; }

        public async Task<bool> Add(Administrator user)
        {
           
            try
            {
                if (user != null)
                {
                    user.state = true;
                    await _data.Administrator.AddAsync(user);
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

        public async Task<bool> Delete(int id)
        {
          
            try
            {
                Administrator FIndUsers = await _data.Administrator.FindAsync(id);

                if (FIndUsers != null)
                {

                    FIndUsers.state = false;
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

        public async Task<AdministratorDto> Get(int id)
        {

            try
            {
                Administrator user = await _data.Administrator.FindAsync(id);

                AdministratorDto userdto = _mapper.Map<Administrator, AdministratorDto>(user);

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

                List<Administrator> ListOfAdministrator = await _data.Administrator.OrderByDescending(x => x.UserId).Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
                pageing.total = _data.Administrator.Count();

                pageing.listofUser =  _mapper.Map<List<Administrator>, List<AdministratorDto>>(ListOfAdministrator);
                

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

        public async Task<bool> Update(Administrator user)
        {

            try
            {
                Administrator UpdateUser = await _data.Administrator.FindAsync(user.UserId);


                if (UpdateUser != null)
                {
                    UpdateUser.UserName = user.UserName;
                    UpdateUser.password = user.password;
                    UpdateUser.FirstMACAddress = user.FirstMACAddress;
                    UpdateUser.SecandMACAddress = user.SecandMACAddress;
                    UpdateUser.DepartmentId = user.DepartmentId;
                    UpdateUser.state = user.state;
                    _data.Administrator.Update(UpdateUser);
                    await _data.SaveChangesAsync();
                    //massageInfo.Massage = "تمت عملية التحديث ";
                    //massageInfo.statuscode = 200;
                    return true;

                }
                else
                {
                    //massageInfo.Massage = "لم تتم عملية التحديث ";
                    //massageInfo.statuscode = 304;
                    return false;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
