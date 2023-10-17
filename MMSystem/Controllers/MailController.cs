using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MMSystem.Model;
using MMSystem.Model.Dto;
using MMSystem.Model.ViewModel;
using MMSystem.Model.ViewModel.MailVModels;
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
        public async Task<IActionResult> GetMailById(int id,int type,int page_number)
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
            var c = await _Imail.DynamicGet(id,type, page_number);
            if(c!=null)
            return Ok(c);
            return NotFound("لايوجد بريد ");
        }


        [HttpGet("search")]
        public async Task<IActionResult> search(int id, int type,int year,int department_Id)
        {
        
            var c = await _Imail.search(id, type,year,department_Id);
            if (c != null)
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
                Mail_Number = mail.mail.Mail_Number,
                Department_Id =mail.mail.Department_Id,
                mail_year=mail.mail.Date_Of_Mail.Year

            });
            return BadRequest(new Result()
            {
                message = "فشلت العملية",
                statusCode = 400
            });
        }




      


        // DELETE api/<MailController>/5
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int department_id,int userId,int mail_id)
        {

            bool state = await _Imail.Delete(department_id,userId,mail_id);
            if (state)
                return StatusCode(203, new Result() { message = "تمت عملية الحذف بنجاح", statusCode = 203 });
            return BadRequest(new Result() { message = "غشلت العملية", statusCode = 404 });




        }
        
      

     

        [HttpDelete("DeleteMangament")]
        public async Task<IActionResult> DeleteMangament(int mail_id, int departmentId,int userId)
        {
            bool result = await _Imail.deleteSender(mail_id,departmentId, userId);
            if (result)
                return StatusCode(203, new Result() { message = "تمت عملية الحذف بنجاح", statusCode = 203 });
            return BadRequest(new Result() { message = "لايمكنك حذف الادارة ", statusCode = 404 });

        }

        [HttpPut("UpdateMail")]
        public async Task<IActionResult> UpdateMail(MailViewModel mail)
        {
            bool result = await _Imail.UpdateMail(mail);
            if (result)
                return StatusCode(203, new Result() { message = "تمت عملية التعديل بنجاح", statusCode = 203 });
            return BadRequest(new Result() { message = "غشلت العملية", statusCode = 404 });

        }


   


        [HttpPut("Send")]
        public async Task<IActionResult> Send(int mailid, int userId)
        {

            bool state = await _sender.Send(mailid, userId);
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
      
           [HttpDelete("DeleteDocument")]
        public async Task<IActionResult> DeletePhote(int id, int userId)
        {

         
           
                bool state = await _Imail.DeletePhote(id,userId);
                if (state)
                    return Ok( new Result() { message = "تمت عملية الحذف", statusCode = 203 });
                return NotFound(new Result() { message = "لا يمكن حذف الصور ", statusCode = 404 });

         
        }


        [HttpGet("GetAllMailState")]
        public async Task<IActionResult> GetAllMailState()
        {



          List<MailStatus> list = await _Imail.GetMailStatuses();
            if (list.Count>0)
                return Ok(list);
            return NotFound(new Result() { message = "لايوجد حالات", statusCode = 404 });


        }


        [HttpGet("GetMailStatuses")]
        public async Task<IActionResult> GetMailStatuses(int mail_id)
        {



            List<MailStatus> list = await _Imail.GetMailStatuses();
            if (list.Count > 0)
                return Ok(list);
            return NotFound(new Result() { message = "لايوجد حالات", statusCode = 404 });


        }






        [HttpGet("GetDetalies")]
        public async Task<IActionResult> GetDetalies(int mail_id,int page,int page_size)
        {
            
            var c = await _Imail.GetDetalies(mail_id);
            if (c.Count>0)
                return Ok(c);
            return NotFound("لايوجد بريد ");
        }




        [HttpPut("update_send")]
        public async Task<IActionResult> update_send(UpdateVM mailid)
        {

            bool state = await _sender.UpdateSenderList(mailid);
            if (state)
                return StatusCode(203, new Result() { message = "تمت عملية التعديل بنجاح", statusCode = 203 });
            return BadRequest(new Result() { message = "فشلت العملية", statusCode = 404 });


        }
        //test

        [HttpPut("Delete_Mail")]
        public async Task<IActionResult> Delete_Mail(int departmentId,int userid, int mail_id)
        {

            bool state = await _Imail.Delete(departmentId,userid,mail_id);
            if (state)
                return StatusCode(203, new Result() { message = "تمت عملية التعديل بنجاح", statusCode = 203 });
            return BadRequest(new Result() { message = "فشلت العملية", statusCode = 404 });


        }


        [HttpGet("GetAllMailStateWithId")]
        public async Task<IActionResult> GetAllMailStateWithId(int flag)
        {

            List<MailStateViewModel> list = await _Imail.GetAllState(flag);
            if (list.Count>0)
                return Ok(list);
            return BadRequest(new Result() { message = "لايوجد حالات للبريد", statusCode = 404 });


        }
        [HttpGet("is_exisite_genaral_inbox_number")]
        public async Task<IActionResult> is_exisite_genaral_inbox_number(int Genaral_inbox_Number_id)
        {
            try
            {
                bool is_not_existe = await _Imail.is_exisite_genaral_inbox_number(Genaral_inbox_Number_id);

                if (is_not_existe)

                    return Ok(new { is_not_existe = is_not_existe, statusCode = 200 });
                return NotFound(new { is_not_existe = is_not_existe, statusCode = 404 });

            }
            catch (Exception ex)
            {

                return BadRequest(new Result() { message = "حدث خطأ", statusCode = 400 });
            }


        }

        [HttpPut("conclusion")]
        public async Task<IActionResult> conclusion(int MailID,string conclusion)
        {
            try
            {
                bool is_existe = await _Imail.conclusion(MailID,conclusion);

                if (is_existe)

                    return Created("conclusion", new
                    {
                        message = "تمت العملية بنجاح",
                        statusCode = 201,

                    });
                return BadRequest(new Result()
                {
                    message = "فشلت العملية",
                    statusCode = 400
                });

            }
            catch (Exception ex)
            {

                return BadRequest(new Result() { message = "حدث خطأ", statusCode = 400 });
            }


        }


        [HttpDelete("delete_sector")]
        public async Task<IActionResult> delete_sector(int id, int userId)
        {
            try
            {
                bool is_existe = await _Imail.delete_sector(id);

                if (is_existe)

                    return Created("conclusion", new
                    {
                        message = "تمت العملية بنجاح",
                        statusCode = 201,

                    });
                return BadRequest(new Result()
                {
                    message = "فشلت العملية",
                    statusCode = 400
                });

            }
            catch (Exception ex)
            {

                return BadRequest(new Result() { message = "حدث خطأ", statusCode = 400 });
            }


        }



        [HttpGet("ReportAllMail")]
        public async Task<IActionResult> ReportAllMail()
        {
            try
            {
                var list = await _Imail.Reppor();

                if (list.Count > 0)

                    return Ok(list);
                return BadRequest(new Result()
                {
                    message = "فشلت العملية",
                    statusCode = 400
                });

            }
            catch (Exception ex)
            {

                return BadRequest(new Result() { message = "حدث خطأ", statusCode = 400 });
            }


        }



        [HttpGet("Report")]
        public async Task<IActionResult> Report()
        {
            try
            {
                var list = await _Imail.ReportViewModelData();

                if (list.Count > 0)

                    return Ok(list);
                return BadRequest(new Result()
                {
                    message = "فشلت العملية",
                    statusCode = 400
                });

            }
            catch (Exception ex)
            {

                return BadRequest(new Result() { message = "حدث خطأ", statusCode = 400 });
            }


        }
    }
}
