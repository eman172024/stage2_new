using MMSystem.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Services.DashBords
{
   public interface IDashBord
    {
        Task<Dashbord> GetDashbord(int ManagementId);

    }


}
