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
        private readonly GenericInterface<Measures, Measures> _generic;

        public ServiceController(GenericInterface<Measures, Measures> generic)
        {
            _generic = generic;
        }
        // GET: api/<ServiceController>
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            List<Measures> list = await _generic.GetAll();
            return Ok(list);
        }

        // GET api/<ServiceController>/5
        [HttpGet("Get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Measures measures = await _generic.Get(id);
            if (measures != null) {

                return Ok(measures);
            }
            return NotFound(new Result() { message = "الاجراء غير موجود", statusCode = 404 });

        }

        // POST api/<ServiceController>
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] Measures measures)
        {
            bool result = await _generic.Add(measures);

            if (result) {

                return Created("Add",new Result() { message="تمت العملية بنجاح", statusCode=201});
            }
            return BadRequest(new Result() { message="فشلت العملية",statusCode=404});
        }

        // PUT api/<ServiceController>/5
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] Measures measures)
        {
            bool result = await _generic.Update(measures);
            if (result)
                return Ok(new Result() { message = "تمت عملية التحديث ", statusCode = 200 });
            return StatusCode(304, new Result() { message = "لم تتم عملية التحديث ", statusCode = 304 });



        }

        // DELETE api/<ServiceController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult>  Delete(int id)
        {
            bool result = await _generic.Delete(id);
            if (result)
                return Ok(new Result() { message = "تمت عملية الحدف ", statusCode = 200 });
            return StatusCode(304, new Result() { message = "فشلت العملية ", statusCode = 304 });


        }
    }
}
