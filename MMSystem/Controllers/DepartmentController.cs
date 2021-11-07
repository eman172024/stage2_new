using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MMSystem.Model;
using MMSystem.Model.Dto;
using MMSystem.Services;
using MMSystem.Services.Depart;

namespace MMSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {

        public DepartmentController(Idepartment data, IMapper mm)
        {
            _data = data;
            _mm = mm;

        }
       

        private readonly Idepartment _data;
        private readonly IMapper _mm;

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<List<Department>>> GetAlldep()
        {
            var dep1 = await _data.GetAll();

            if (dep1 != null)
            {
                return Ok(dep1);
            }
            else
            {
                return NotFound();

            }
        }

        [HttpGet]
        [Route("Getsub")]

        public async Task<IActionResult> Gettsub(int par)
        {
            var ss = await _data.getsub(par);

            if (ss.Count() != 0)
            {
                return Ok(ss);
            }
            else
            {
                return NotFound(new Result() { message = "الادارة  غير موجود", statusCode = 404 });
                //   return null;

            }
        }

        //
        [HttpPost]
        [Route("Add")]

        public async Task<IActionResult> Adddepartment([FromBody] Department dep)
        {



            bool results = await _data.Add(dep);
            if (results)
            {
                //var test=     _mm.Map<DepartmentDto>(dep);
                //     return CreatedAtRoute("", new { id = test.Id },test);
                return Created("Adddepartment", new Result() { message = "تمت عملية الاضافة بنجاح", statusCode = 201 });
            }
            else

                return BadRequest(new Result() { message = "قشل في عملية الاضافة  ", statusCode = 400 });



        }
        //

        [HttpPost]
        [Route("Addsub")]

        public async Task<IActionResult> Addsub(int par, [FromBody] Department dep)
        {



            bool results = await _data.addsub(par, dep);
            if (results)
            {
                //var test=     _mm.Map<DepartmentDto>(dep);
                //     return CreatedAtRoute("", new { id = test.Id },test);
                return Created("Adddepartment", new Result() { message = "تمت عملية الاضافة بنجاح", statusCode = 201 });
            }
            else

                return BadRequest(new Result() { message = "قشل في عملية الاضافة  ", statusCode = 400 });



        }


        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Updatedepartment([FromBody] Department depid)


        {
            bool results = await _data.Update(depid);
            if (results)
                return Ok(new Result() { message = "تمت عملية التحديث ", statusCode = 200 });
            return StatusCode(304, new Result() { message = "لم تتم عملية التحديث ", statusCode = 304 });
        }

        [HttpPut]
        // [Route("Delete/{id}")]
        [Route("Delete")]
        public async Task<IActionResult> Deletedepartment(int id)
        {
            bool results = await _data.Delete(id);
            if (results)
                return Accepted(new Result() { message = "تمت عملية الحذف", statusCode = 202 });

            return NotFound(new Result() { message = "هذه الادارة غير موجود", statusCode = 404 });

        }

        [HttpGet]
        // [Route("Delete/{id}")]
        [Route("Show_all_departments_except_the_current_one")]
        public async Task<IActionResult> GetDepartmentWithOutYours(int department_id)
        {
            List<DepartmentDto> departments = await _data.GetDepartment(department_id);

            if (departments.Count > 0) 

                return Ok(departments);
            return NotFound("لايوجد اقسام");
           
        }

    }
}
