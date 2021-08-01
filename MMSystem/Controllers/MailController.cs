using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using MMSystem.Model;
using MMSystem.Model.Dto;
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
    public class MailController : ControllerBase
    {
        private readonly IMailInterface _Imail;
        private IWebHostEnvironment iwebHostEnvironment;
        public string sub { set; get; }
        public MailController(IMailInterface Imail, IWebHostEnvironment hosting)
        {
            _Imail = Imail;
            iwebHostEnvironment = hosting;

        }


        // GET: api/<MailController>
        [HttpGet("GetAllMail")]
        public async Task<IActionResult> GetAllMail()
        {

            List<MailDto> mails =await _Imail.GetAll();
            return Ok(mails);
        }

        // GET api/<MailController>/5
        [HttpGet("GetMailById{id}")]
        public async Task<IActionResult> GetMailById(int id)
        {
            MailDto mail = await _Imail.Get(id);
            if (mail != null) 
                return Ok(mail);


         return NotFound(  new Result { message="لايوجد بريد ",
         statusCode=404});
        }

        // POST api/<MailController>
        [HttpPost("AddMail")]
        public async Task<IActionResult> AddMail([FromBody] Mail mail)
        {
            var result = await _Imail.Add(mail);
            if(result)
            return Created("AddMail",new Result() {
            message="تمت العملية بنجاح",statusCode=201});
            return BadRequest(new Result()
            {
                message = "فشلت العملية",
                statusCode = 400
            });
        }

        // PUT api/<MailController>/5
        [HttpPut("UpdateMail")]
        public async Task<IActionResult> UpdateMail([FromBody] Mail mail)
        {
           bool result = await _Imail.Update(mail);
            if (result) ;
            return  StatusCode(204, new Result()
            {
                message = "تمت العملية بنجاح",
                statusCode = 204
            });
            return BadRequest(new Result()
            {
                message = "فشلت العملية",
                statusCode = 400
            });
        }

        // DELETE api/<MailController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
