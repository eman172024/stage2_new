using Microsoft.AspNetCore.Mvc;
using MMSystem.Model;
using MMSystem.Model.Dto;
using MMSystem.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MMSystem.Controllers
{

    [ApiController]
    [Route("[controller]")]

    public class AdministratorController : ControllerBase
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
                return Ok(users);
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
                return Ok(users);
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
                return Ok(user);
            }
            else
            {
                return NotFound();

            }
        }
        [HttpPut]
        [Route("UpdateAdministrator")]
        public async Task<IActionResult> UpdateAdministrator([FromBody] Administrator id)
        {
           bool results = await _data.Update(id);
            if (results)
                return Ok(new Result() {  message = "تمت عملية التحديث ",statusCode=200  });
                return StatusCode(304,new Result() {  message = "لم تتم عملية التحديث " ,statusCode=304});
        }

        [HttpPut]
        [Route("DeleteAdministrator/{id}")]
        public async Task<IActionResult> DeleteAdministrator(int id)
        {
          bool results = await _data.Delete(id);
            if (results)
                return Accepted(new Result() { message= "تمت عملية الحذف",statusCode = 202 });
            
                return NotFound(new Result() {message ="هذا المستخدم غير موجود", statusCode = 404 });
            
        }


        [HttpGet]
        [Route("LoginAdministrator")]
        public async Task<IActionResult> LoginAdministrator([FromBody] Login user)
        {
            
            AdministratorDto find = await _data.login(user);

            if (find != null)
            
                return Ok(find);
         
                return NotFound(new Result() {  message = "رقم المستخدم او كلمة المرور غير صحيحة",statusCode=404 });
            
        }

        [HttpPost]
        [Route("AddAdministrator")]

        public async Task<IActionResult> AddAdministrator([FromBody] Administrator user)
        {
        
            user.password = BCrypt.Net.BCrypt.HashPassword(user.password);

             bool results = await _data.Add(user);
            if (results)
            
                return Created("AddAdministrator", new Result() { message="تمت عملية الاضافة بنجاح", statusCode = 201 });

            
                 return BadRequest(new Result() { message = "قشل في عملية الاضافة  ", statusCode = 400 }); 



        }

    }
}
