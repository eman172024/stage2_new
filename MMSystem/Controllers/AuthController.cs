using Microsoft.AspNetCore.Mvc;
using MMSystem.Data;
using MMSystem.Model;
//
//using passport_aca.Model;

//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
         AuthController(IAdministratorInterface users)
        {
            _data = users;
        }
      private IAdministratorInterface _data { get; }
        [HttpPost]
        [Route("LoginUser")]
        public async Task<ActionResult<AdministratorDto>> LoginUser([FromBody] Login user)
        {
            MassageInfo massages = new MassageInfo();
            var find = await _data.login(user);

            if (find != null)
            {
                return Ok(find);
            }
            else
            {
                massages.Massage = "رقم المستخدم او كلمة المرور غير صحيحة";
                massages.statuscode = 404;
                return NotFound(massages);
            }
        }
    }
}
