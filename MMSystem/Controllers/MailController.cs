using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MMSystem.Model;
using MMSystem.Model.Dto;
using MMSystem.Model.ViewModel;
using MMSystem.Services;
using MMSystem.Services.MailServeic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MMSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly IMailInterface _Imail;
        private readonly AppDbCon dbcon;

        //   private IWebHostEnvironment iwebHostEnvironment;

        private readonly ISender _sender;

     
        public MailController(IMailInterface Imail,AppDbCon dbcon,
            ISender sender)
        {
            _Imail = Imail;
            this.dbcon = dbcon;
            _sender = sender;

        }


        // GET: api/<MailController>
        [HttpGet("GetAllMail")]
        public async Task<IActionResult> GetAllMail()
        {

            List<MailDto> mails =await _Imail.GetAll();
            return Ok(mails);
        }
        dynamic c;

        // GET api/<MailController>/5
        [HttpGet("GetMailById")]
        public async Task<IActionResult> GetMailById(int id,int type)
        {
            //switch (type) 
            //{
            //    case "1":
            //        MailVM mail = await _Imail.GetMailById(id,type);
            //        if (mail != null)
            //            c = mail;
            //        break;


            //    case "2":

            //        var ddc = await _Imail.GetMailById1(id,type);
            //        if (ddc != null)

            //            c = ddc;
            //        break;

            //    case"3":

            //        var ccc = await _Imail.GetMailById2(id,type);
            //        if (ccc != null)
            //            c = ccc;
            //        break;
            //    default:break;
            //}
            var c = await _Imail.DynamicGet(id,type);
            if(c!=null)
            return Ok(c);
            return NotFound("لايوجد بريد ");
        }

        // POST api/<MailController>
        [HttpPost("AddMail")]
        public async Task<IActionResult> AddMail([FromBody] MailViewModel mail)
        {
            var result = await _Imail.addMail(mail);
            if(result)
            return Created("AddMail",new  {
            message="تمت العملية بنجاح",statusCode=201,
                mailId = mail.mail.MailID,
                Department_Id=mail.mail.Department_Id,
                mail_year=mail.mail.Date_Of_Mail.Year

            });
            return BadRequest(new Result()
            {
                message = "فشلت العملية",
                statusCode = 400
            });
        }




      


        // DELETE api/<MailController>/5
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            bool state = await _Imail.Delete(id);
            if (state)
                return StatusCode(203, new Result() { message = "تمت عملية الحذف بنجاح", statusCode = 203 });
            return BadRequest(new Result() { message = "غشلت العملية", statusCode = 404 });




        }
        
        //[HttpPost("Uplode")]
        //public async Task<IActionResult> Uplode([FromForm] int id, List<IFormFile> resourse)
        //{

        //    bool state = await _Imail.Upload(id, resourse);
        //    if (state)
        //        return Created("Uplode", new Result() { message = "تمت عملية التحميل بنجاح", statusCode = 203 });
        //    return BadRequest(new Result() { message = "فشلت العملية", statusCode = 404 });


        //}

        [HttpGet("GetLastMails")]
        public async Task<IActionResult> GetLastMails()
        {

            List<MailDto> list = await _Imail.GetSevenMail();
           // if (list.Count>0)
                return Ok(list);
            //return BadRequest(new Result() { message = "فشلت العملية", statusCode = 404 });


        }

        [HttpDelete("DeleteMangament")]
        public async Task<IActionResult> DeleteMangament(int mail_id, int departmentId )
        {
            bool result = await _Imail.deleteSender(mail_id,departmentId);
            if (result)
                return StatusCode(203, new Result() { message = "تمت عملية الحذف بنجاح", statusCode = 203 });
            return BadRequest(new Result() { message = "غشلت العملية", statusCode = 404 });

        }

        [HttpPut("UpdateMail")]
        public async Task<IActionResult> UpdateMail(MailViewModel mail)
        {
            bool result = await _Imail.UpdateMail(mail);
            if (result)
                return StatusCode(203, new Result() { message = "تمت عملية التعديل بنجاح", statusCode = 203 });
            return BadRequest(new Result() { message = "غشلت العملية", statusCode = 404 });

        }


        //[HttpPost("UpdateFile")]
        //public async Task<IActionResult> UpdateFile([FromForm] int id, List<IFormFile> resourse)
        //{

        //    bool state = await _Imail.UpdateFile(id, resourse);
        //    if (state)
        //        return Created("Uplode", new Result() { message = "تمت عملية التعديل بنجاح", statusCode = 203 });
        //    return BadRequest(new Result() { message = "فشلت العملية", statusCode = 404 });


        //}



        [HttpPut("Send")]
        public async Task<IActionResult> Send(int mailid)
        {

            bool state = await _sender.Send(mailid);
            if (state)
                return Created("Send", new Result() { message = "تمت عملية الارسال بنجاح", statusCode = 203 });
            return BadRequest(new Result() { message = "فشلت العملية", statusCode = 404 });


        }
        [HttpPost("Uplode")]
        public async Task<IActionResult> Uplode(Uplode file)
        {

       




            if (ModelState.IsValid)
            {
                bool state = await _Imail.Uplode(file);
                if (state)
                    return Created("Uplode", new Result() { message = "تمت عملية التحميل بنجاح", statusCode = 203 });
                return BadRequest(new Result() { message = "فشلت العملية", statusCode = 404 });

            }

            return BadRequest(new Result() { message = "فشلت العملية", statusCode = 404 });


        }
      
           [HttpDelete("DeleteDocument/{id}")]
        public async Task<IActionResult> DeletePhote(int id)
        {

         
           
                bool state = await _Imail.DeletePhote(id);
                if (state)
                    return Ok( new Result() { message = "تمت عملية الحذف", statusCode = 203 });
                return NotFound(new Result() { message = "لايوجد صور", statusCode = 404 });

         
        }

















    }
}
