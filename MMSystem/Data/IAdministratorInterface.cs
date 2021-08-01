using MMSystem.Model;
using passport_aca.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Data
{
    interface IAdministratorInterface 
    {
        Task<AdministratorDto> login(Login user);

        Task<MassageInfo> Add(Administrator user);

        Task<List<AdministratorDto>> GetAll();

        Task<MassageInfo> Update(Administrator user);

        Task<MassageInfo> Delete(int id);

        Task<AdministratorDto> Get(int id);
        Task<PageintoinAdmin> GetAdministrator(int page, int pageSize);
    }
}
