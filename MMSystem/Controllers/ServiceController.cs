using Microsoft.AspNetCore.Mvc;
using MMSystem.Model;
using MMSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MMSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly GenericInterface<Measures, Measures> _measures;
        private readonly GenericInterface<ClasificationSubject, ClasificationSubject> _ClasificationSubject;

        public ServiceController(GenericInterface<Measures, Measures> measures,
            GenericInterface<ClasificationSubject, ClasificationSubject> clasificationSubject)
        {
            _measures = measures;
            _ClasificationSubject = clasificationSubject;
        }
        // GET: api/<ServiceController>
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            List<Measures> list = await _measures.GetAll();
            return Ok(list);
        }
        [HttpGet("GetAllClassFication")]
        public async Task<IActionResult> GetAllClassFication()
        {
            List<ClasificationSubject> list = await _ClasificationSubject.GetAll();
            return Ok(list);
        }


        // GET api/<ServiceController>/5
        [HttpGet("Get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Measures measures = await _measures.Get(id);
            if (measures != null) {

                return Ok(measures);
            }
            return NotFound(new Result() { message = "الاجراء غير موجود", statusCode = 404 });

        }
        [HttpGet("GetClassfication/{id}")]
        public async Task<IActionResult> GetClassfication(int id)
        {
            ClasificationSubject model = await _ClasificationSubject.Get(id);
            if (model != null)
            {

                return Ok(model);
            }
            return NotFound(new Result() { message = "التصنيف غير موجود", statusCode = 404 });

        }

        // POST api/<ServiceController>
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] Measures measures)
        {
            bool result = await _measures.Add(measures);

            if (result) {

                return Created("Add", new Result() { message = "تمت العملية بنجاح", statusCode = 201 });
            }
            return BadRequest(new Result() { message = "فشلت العملية", statusCode = 404 });
        }
        [HttpPost("AddClassfication")]
        public async Task<IActionResult> AddClassfication ([FromBody] ClasificationSubject model)
        {
            bool result = await _ClasificationSubject.Add(model);

            if (result)
            {

                return Created("Add", new Result() { message = "تمت العملية بنجاح", statusCode = 201 });
            }
            return BadRequest(new Result() { message = "فشلت العملية", statusCode = 404 });
        }

        // PUT api/<ServiceController>/5
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] Measures measures)
        {
            bool result = await _measures.Update(measures);
            if (result)
                return Ok(new Result() { message = "تمت عملية التحديث ", statusCode = 200 });
            return StatusCode(304, new Result() { message = "لم تتم عملية التحديث ", statusCode = 304 });



        }
        [HttpPut("UpdateClassfication")]
        public async Task<IActionResult> UpdateClassfication([FromBody] ClasificationSubject model)
        {
            bool result = await _ClasificationSubject.Update(model);
            if (result)
                return Ok(new Result() { message = "تمت عملية التحديث ", statusCode = 200 });
            return StatusCode(304, new Result() { message = "لم تتم عملية التحديث ", statusCode = 304 });



        }

        // DELETE api/<ServiceController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult>  Delete(int id)
        {
            bool result = await _measures.Delete(id);
            if (result)
                return Ok(new Result() { message = "تمت عملية الحدف ", statusCode = 200 });
            return StatusCode(304, new Result() { message = "فشلت العملية ", statusCode = 304 });


        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClassfication(int id)
        {
            bool result = await _ClasificationSubject.Delete(id);
            if (result)
                return Ok(new Result() { message = "تمت عملية الحدف ", statusCode = 200 });
            return StatusCode(304, new Result() { message = "فشلت العملية ", statusCode = 304 });


        }
    }
}
