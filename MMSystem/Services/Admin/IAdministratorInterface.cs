using MMSystem.Model;
using MMSystem.Model.Dto;
using MMSystem.Model.ViewModel;

//
//
//using passport_aca.Model;

//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Services
{
     public interface IAdministratorInterface : GenericInterface<Administrator,AdministratorDto>
    {
        Task<Administrator> login(Login user1);
        Task<PageintoinAdmin> GetAdministrator(int page, int pageSize);
    }
}
