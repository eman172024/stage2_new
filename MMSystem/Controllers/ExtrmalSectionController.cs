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

namespace MMSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExtrmalSectionController : ControllerBase
    {
        public ExtrmalSectionController(Generic2<Extrmal_Section, Extrmal_SectionDto> data, IMapper mm)
        {
            _data = data;
            _mm = mm;

        }
      
        private readonly Generic2<Extrmal_Section, Extrmal_SectionDto> _data;
        private readonly IMapper _mm;
      
        
        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<List<Extrmal_Section>>> GetAlldep()
        {
            var extr1 = await _data.GetAll();

            if (extr1 != null)
            {
                return Ok(extr1);
            }
            else
            {
                return NotFound();

            }
        }
        [HttpGet]
        [Route("GetSide")]
        public async Task<ActionResult<List<Extrmal_Section>>> Get( int id)
        {
            var extr1 = await _data.Get(id);

            if (extr1 != null)
            {
                return Ok(extr1);
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
                return NotFound(new Result() { message = "القطاع  غير موجود", statusCode = 404 });
                //   return null;

            }
        }



        [HttpPost]
        [Route("Add")]

        public async Task<IActionResult> Add( [FromBody] Extrmal_Section ext)

        {
            try
            {
                bool results = await _data.add( ext);
                if (results)
                {
                    //var test=     _mm.Map<DepartmentDto>(dep);
                    //     return CreatedAtRoute("", new { id = test.Id },test);
                    return Created("Add", new Result() { message = "تمت عملية الاضافة بنجاح", statusCode = 201 });
                }
                else

                    return BadRequest(new Result() { message = "قشل في عملية الاضافة  ", statusCode = 400 });



            }

            catch (Exception ex)
            {

                return BadRequest(new  { message = "قشل في عملية الاضافة  ", statusCode = 400 , ma=ex.Message});
            }

        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Updateextr([FromBody] Extrmal_Section extr1)


        {
            try
            {
                bool results = await _data.Update(extr1);
                if (results)
                    return Ok(new Result() { message = "تمت عملية التحديث ", statusCode = 200 });
                return StatusCode(304, new Result() { message = "لم تتم عملية التحديث ", statusCode = 304 });
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = "قشل في عملية التعديل  ", statusCode = 400, ma = ex.Message });
            }

        }

        [HttpPut]
        // [Route("Delete/{id}")]
        [Route("Delete")]
        public async Task<IActionResult> Deleteextr( int id)
        {
            bool results = await _data.Delete(id);
            if (results)
                return Accepted(new Result() { message = "تمت عملية التعديل", statusCode = 202 });

            return NotFound(new Result() { message = "هذا القطاع غير موجود", statusCode = 404 });

        }
    }
}

