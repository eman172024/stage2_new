using Microsoft.AspNetCore.Mvc;
using MMSystem.Model;
using MMSystem.Model.Dto;
using MMSystem.Model.ViewModel;
using MMSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
       public  AuthController(IAdministratorInterface users)
        {
            _data = users;
        }
      private IAdministratorInterface _data { get; }
        [HttpPost]
        [Route("LoginUser")]
        public async Task<IActionResult> LoginUser([FromBody] Login user)
        {
         
              UserView find = await _data.login(user);

                if (find != null)
            
                return Ok(find);
                
        
                return NotFound(new Result() { message = "رقم المستخدم او كلمة المرور غير صحيحة", statusCode = 404 });
        }
    }
}
