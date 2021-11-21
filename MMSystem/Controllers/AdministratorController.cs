using Microsoft.AspNetCore.Mvc;
using MMSystem.Model;
using MMSystem.Model.Dto;
using MMSystem.Model.ViewModel;
using MMSystem.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MMSystem.Controllers
{

    [ApiController]
    [Route("api/[controller]")]


    public class AdministratorController : ControllerBase
    {


        public AdministratorController(IAdministratorInterface Users)
        {
            _data = Users;

        }
        private readonly IAdministratorInterface _data;


        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<List<Administrator>>> GetAllUsers()
        {
            var users = await _data.GetAll();
            if (users != null)
            {
                return Ok(users);
            }
            else
            {
                return NotFound();

            }
        }


        [HttpGet]
        [Route("GetPageintoin")]
        public async Task<ActionResult<PageintoinAdmin>> GetAllAdministrator(int page, int pageSize)
        {
            var users = await _data.GetAdministrator(page, pageSize);
            if (users != null)
            {
                return Ok(users);
            }
            else
            {
                return NotFound();

            }
        }

        [HttpGet]
        [Route("Get/{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _data.Get(id);


            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return NotFound(new Result() {  message= "المستخدم غير موجود", statusCode= 404});

            }
        }
        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> UpdateAdministrator([FromBody] UserAddORUpdate id)
        {
            bool results = await _data.Update(id);
            if (results)
                return Ok(new Result() { message = "تمت عملية التحديث ", statusCode = 200 });
            return StatusCode(304, new Result() { message = "لم تتم عملية التحديث ", statusCode = 304 });
        }

        [HttpPut]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteAdministrator(int id)
        {
            bool results = await _data.Delete(id);
            if (results)
                return Accepted(new Result() { message = "تم إيقاف المستخدم", statusCode = 202 });

            return NotFound(new Result() { message = "هذا المستخدم غير موجود", statusCode = 404 });

        }



        [HttpPost]
        [Route("Add")]

        public async Task<IActionResult> AddAdministrator([FromBody] UserAddORUpdate user)
        {
        
            user.Administrator.password = BCrypt.Net.BCrypt.HashPassword(user.Administrator.password);

             bool results = await _data.Add(user);

              if (results)
            
                return Created("AddAdministrator", new Result() { message="تمت عملية الاضافة بنجاح", statusCode = 201 });

            
                 return BadRequest(new Result() { message = "قشل في عملية الاضافة  ", statusCode = 400 }); 

        }


        [HttpGet]
        [Route("GetByDepartmentId")]
        public async Task<ActionResult<List<Administrator>>> GetByDepartmentId(int department)
        {
            var users = await _data.SearchByDepartmentId(department);
            if (users != null)
            {
                return Ok(users);
            }
            else
            {
                return NotFound(new Result() { message = "لايوجد مستخدم في هذه الإدارة  ", statusCode = 400 });

            }
        }

        [HttpGet]
        [Route("GetByUserName")]
        public async Task<IActionResult> GetByUserName(string username)
        {
            var users = await _data.SearchByName(username);
            if (users != null)
            {
                return Ok(users);
            }
            else
            {
                return NotFound(new Result() { message = "لايوجد مستخدم بهذا الاسم", statusCode = 400 });

            }
        }

    }
}
