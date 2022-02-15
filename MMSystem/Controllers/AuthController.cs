using Microsoft.AspNetCore.Mvc;
using MMSystem.Model;
using MMSystem.Model.Dto;
using MMSystem.Model.ViewModel;
using MMSystem.Services;
using MMSystem.Services.Histor;
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
       public  AuthController(IAdministratorInterface users, IHistory hstory)
        {
            _data = users;
            _hstory = hstory;
        }
      private IAdministratorInterface _data { get; }

        private readonly IHistory _hstory;

        [HttpPost]
        [Route("LoginUser")]
        public async Task<IActionResult> LoginUser([FromBody] Login user)
        {
            
              UserView find = await _data.login(user);

                if (find != null) {

                Historyes historyes = new Historyes();  
                historyes.Time = System.DateTime.Now;
                historyes.HistortyNameID = 19;
                historyes.currentUser = find.Administrator.UserId;
                historyes.changes = "تم تسجيل الدخول";
                await _hstory.Add(historyes);
                return Ok(find);
            }
            return NotFound(new Result() { message = "رقم المستخدم او كلمة المرور غير صحيحة", statusCode = 404 });
        }
    }
}
