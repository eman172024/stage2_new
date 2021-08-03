using Microsoft.AspNetCore.Mvc;

using MMSystem.Model;
using MMSystem.Model.Dto;
using MMSystem.Services;
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
       public  AuthController(IAdministratorInterface users)
        {
            _data = users;
        }
      private IAdministratorInterface _data { get; }
        [HttpPost]
        [Route("LoginUser")]
        public async Task<ActionResult<AdministratorDto>> LoginUser([FromBody] Login user)
        {
         
            var find = await _data.login(user);

                if (find != null)
            
                return Ok(find);
        
                return NotFound(new Result() { message = "رقم المستخدم او كلمة المرور غير صحيحة", statusCode = 404 });
        }
    }
}
