using MMSystem.Model;
using MMSystem.Model.Dto;
using MMSystem.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Services
{
     public interface IAdministratorInterface : GenericInterface<Administrator,AdministratorDto>
    {

        Task<UserView> Get(int id);
        Task<UserView> login(Login user);
        Task<bool> Update(UserAddORUpdate user);
        Task<bool> Add(UserAddORUpdate user);
        Task<PageintoinAdmin> GetAdministrator(int page, int pageSize);
        Task<List<UserFind>> SearchByName(string user);
        Task <List<AdministratorDto>> SearchByDepartmentId(int Department);
    }
}
