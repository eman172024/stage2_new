using Microsoft.AspNetCore.Mvc;
using MMSystem.Data;
using MMSystem.Model;
using MMSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Controllers
{

    [ApiController]
    [Route("[controller]")]

    public class AdministratorController : Controller
    {


        AdministratorController(IAdministratorInterface Users)
        {
            _data = Users;
                
        }
        private readonly IAdministratorInterface _data;


        [HttpGet]
        [Route("GetAllAdministrators")]
        public async Task<ActionResult<List<Administrator>>> GetAllUsers()
        {
            var users = await _data.GetAll();
            if (users != null)
            {
                return Json(users);
            }
            else
            {
                return NotFound();

            }
        }


        [HttpGet]
        [Route("GetAllAdministrator")]
        public async Task<ActionResult<PageintoinAdmin>> GetAllAdministrator(int page, int pageSize)
        {
            var users = await _data.GetAdministrator(page, pageSize);
            if (users != null)
            {
                return Json(users);
            }
            else
            {
                return NotFound();

            }
        }

        [HttpGet]
        [Route("GetAdministrator/{id}")]
        public async Task<ActionResult<AdministratorDto>> GetUser(int id)
        {
            var user = await _data.Get(id);


            if (user != null)
            {
                return Json(user);
            }
            else
            {
                return NotFound();

            }
        }
        [HttpPut]
        [Route("UpdateAdministrator")]
        public async Task<ActionResult<MassageInfo>> UpdateAdministrator([FromBody] Administrator id)
        {
            MassageInfo massages = await _data.Update(id);
            if (massages.statuscode == 200)
                return Ok(massages);
            else if (massages.statuscode == 300)
            {
                return StatusCode(304, massages);
            }
            return BadRequest();
        }

        [HttpPut]
        [Route("DeleteAdministrator/{id}")]
        public async Task<ActionResult<MassageInfo>> DeleteAdministrator(int id)
        {
            MassageInfo massages = await _data.Delete(id);
            if (massages.statuscode == 202)
                return Accepted(massages);
            else if (massages.statuscode == 404)
            {
                return NotFound(massages);
            }
            return BadRequest();
        }


        [HttpGet]
        [Route("LoginAdministrator")]
        public async Task<ActionResult<AdministratorDto>> LoginAdministrator([FromBody] Login user)
        {
            MassageInfo massages = new MassageInfo();
            AdministratorDto find = await _data.login(user);

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

        [HttpPost]
        [Route("AddAdministrator")]

        public async Task<ActionResult<MassageInfo>> AddAdministrator([FromBody] Administrator user)
        {
            //  var l = Securety.hash(user.Password);
            //user.Password = l;

            user.password = BCrypt.Net.BCrypt.HashPassword(user.password);



            //var c = BCrypt.Net.BCrypt.EnhancedHashPassword(user.Password);
            MassageInfo massages = await _data.Add(user);
            if (massages.statuscode == 201)
            {

                return Created("AddAdministrator", massages);

            }
            else
            {
                return BadRequest(new MassageInfo()
                {
                    Massage = "قشل في عملية الاضافة  ",
                    statuscode = 400

                });
            }



        }

    }
}
