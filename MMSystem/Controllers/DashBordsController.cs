using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MMSystem.Model.ViewModel;
using MMSystem.Services.DashBords;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashBordsController : ControllerBase
    {
        private readonly IDashBord DashBord;

      public   DashBordsController(IDashBord dashBord)
        {
            DashBord = dashBord;
        }
        [HttpGet]
        [Route("GetTotal")]
       public async Task<IActionResult> GetDashbord(int ManagementId)
        {

         var GetTotal =  await DashBord.GetDashbord(ManagementId);
           
                return Ok(GetTotal);
     
        }
    }
}
