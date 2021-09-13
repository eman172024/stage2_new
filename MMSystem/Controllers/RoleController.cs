using Microsoft.AspNetCore.Mvc;
using MMSystem.Model;
using MMSystem.Model.Dto;
using MMSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class RoleController : ControllerBase
    {
  
        public RoleController(GenericInterface<Role,RoleDto> Roles)
        {
            _data = Roles;

        }
        private readonly GenericInterface<Role,RoleDto> _data;



        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAllRoles()
        {
            var roles = await _data.GetAll();
            if (roles != null)
            {
                return Ok(roles);
            }
            else
            {
                return NotFound(new Result() { message = "لا يوجد صلاحيات مخزنة مسبقاً", statusCode = 404 });

            }
        }


        [HttpGet]
        [Route("Get/{id}")]
        public async Task<IActionResult> GetRole(int id)
        {
            var role = await _data.Get(id);

            if (role != null)
            {
                return Ok(role);
            }
            else
            {
                return NotFound(new Result() { message = "الصلاحية غير موجودة", statusCode = 404 });
            }
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> UpdateRole([FromBody] Role id)
        {
            bool results = await _data.Update(id);
            if (results)

            return Ok(new Result() { message = "تمت عملية التحديث ", statusCode = 200 });

            return StatusCode(304, new Result() { message = "لم تتم عملية التحديث ", statusCode = 304 });
        }

        [HttpPut]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            bool results = await _data.Delete(id);

            if (results)
     
            return Accepted(new Result() { message = "تمت عملية الحذف", statusCode = 202 });

            return NotFound(new Result() { message = "هذه الصلاحية غير موجود", statusCode = 404 });

        }



        [HttpPost]
        [Route("Add")]

        public async Task<IActionResult> AddRole([FromBody] Role role)
        {

            bool results = await _data.Add(role);

            if (results)

                return Created("AddRole", new Result() { message = "تمت عملية الاضافة بنجاح", statusCode = 201 });


            return BadRequest(new Result()  { message = "قشل في عملية الاضافة  ", statusCode = 400 });

        }
    }
}
