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

        /// <summary>
        /// إضافة المستخدم مع الصلاحيات
        /// </summary>
        /// <param name="user"> بيانات المستخدم مع مصفوفة من الارقام تعبر عن الصلاحيات والشخص الذي أضاف هذا المستخدم </param>
        /// <returns> true او false </returns>
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

       
        /// <summary>
        /// إلغاء تفعيل المستخدم او إعادة تفعيل المستخدم
        /// </summary>
        /// <param name="id"> رقم المستخدم</param>
        /// <returns>true او false </returns>
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
        /// <summary>
        /// البحث عن مستخدم معين 
        /// </summary>
        /// <param name="id"> رقم المستخدم</param>
        /// <returns> المستخدم مع الصلاحيات</returns>
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
        
        /// <summary>
        ///  تبحث علي المستخدمين و تقسمهم علي حسب عدد الصفحات 
        /// </summary>
        /// <param name="page">رقم الصفحة </param>
        /// <param name="pageSize">عدد المستخدمي اللي تبي تعرضهم في كل صفحة</param>
        /// <returns> مستخدمين</returns>
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

        /// <summary>
        /// تبحث علي جميع المستخدمين
        /// </summary>
        /// <returns>  جميع المستخدمين</returns>
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
              /// <summary>
              /// ترجع صلاحيات مستخدم معين
              /// </summary>
              /// <param name="id"> رقم المستخدم</param>
              /// <returns> مصفوفة من ارقام الصلاحيات</returns>
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
        /// <summary>
        ///  تسجيل الدخول
        /// </summary>
        /// <param name="user1"> اسم المستخدم وكلمة المرور</param>
        /// <returns>بيانات المستخدم </returns>
        public async Task<UserWithOnlyRoleNum> login(Login user1)
        {
            try
            {
                UserWithOnlyRoleNum view = new UserWithOnlyRoleNum();
                //***** 21/12/2022
                 Administrator user = await _data.Administrator.FirstOrDefaultAsync(x => x.UserId == user1.UserId && x.state == true && x.DepartmentId == user1.DepartmentId);
               // Administrator user = await _data.Administrator.FirstOrDefaultAsync(x => x.UserId == user1.UserId && x.state == true && x.DepartmentId == user1.DepartmentId && (x.FirstMACAddress == user1.Mac || x.SecandMACAddress == user1.Mac));
                //*****end 21/12/2022
                if (user != null)
                {
                    bool isValid = BCrypt.Net.BCrypt.Verify(user1.Password, user.password);

                    if (isValid)
                    {
                        view.Administrator = _mapper.Map<Administrator, AdministratorDto>(user);

                        view.Listrole = await (from userrole in _data.userRoles.Where(x => x.UserId == user.UserId)
                                               join
                                               role in _data.Roles on userrole.RoleId equals role.RoleId
                                               select role.code).ToListAsync();
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
        /// <summary>
        /// *****تبحث علي المستخدمين الموجودين تحت إدارة معينة التي ***حالتهم مفعلة فقط
        /// </summary>
        /// <param name="DepartmentId"> رقم الادارة</param>
        /// <returns>قائمة من المستخدمين</returns>
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
        /// <summary>
        /// تبحث علي جميع المستخدمين الموجودين تحت إدارة معينة 
        /// </summary>
        /// <param name="DepartmentId"> رقم الادارة</param>
        /// <returns>قائمة من المستخدمين</returns>
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

        /// <summary>
        /// تبحث علي المستخدم بإسمه
        /// </summary>
        /// <param name="user"> إسم المستخدم</param>
        /// <returns>ترجع المستخدم</returns>

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

        /// <summary>
        /// تعديل علي مستخدم معين
        /// </summary>
        /// <param name="user"> بينات المستخدم التي تم تعديلها </param>
        /// <returns> true او false</returns>
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



        /// <summary>
        /// الدوال اللي تحت تبع genericInterface لم تتم إستخدامهم لكن تم إستخدام نفس الاسم في الدوال الاخري 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Task<bool> Update(Administrator model)
        {
            throw new NotImplementedException();
        }
        public Task<bool> Add(Administrator t)
        {
            throw new NotImplementedException();
        }

        Task<AdministratorDto> GenericInterface<Administrator, AdministratorDto>.Get(int id)
        {
            throw new NotImplementedException();
        }
      
    }
}
