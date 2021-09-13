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
        public async Task<IActionResult> AddMail([FromBody] MailViewModel mail)
        {
            var result = await _Imail.addMail(mail);
            if(result)
            return Created("AddMail",new  {
            message="تمت العملية بنجاح",statusCode=201,
                mailId = mail.mail.MailID
            });
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
            if (result) 
            return Ok( new Result()
            {
                message = "تمت العملية بنجاح",
                statusCode = 200
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

        [HttpPost("Uplode")]
        public async Task<IActionResult> Uplode([FromForm] int id, List<IFormFile> resourse)
        {

            bool state = await _Imail.Upload(id, resourse);
            if (state)
                return Created("Uplode", new Result() { message = "تمت عملية التحميل بنجاح", statusCode = 203 });
            return BadRequest(new Result() { message = "فشلت العملية", statusCode = 404 });


        }

        [HttpPost("UpdateFile")]
        public async Task<IActionResult> UpdateFile([FromForm] int id, List<IFormFile> resourse)
        {

            bool state = await _Imail.UpdateFile(id, resourse);
            if (state)
                return Created("Uplode", new Result() { message = "تمت عملية التعديل بنجاح", statusCode = 203 });
            return BadRequest(new Result() { message = "فشلت العملية", statusCode = 404 });


        }



        [HttpPost("Send")]
        public async Task<IActionResult> Send(int mailid)
        {

            bool state = await _sender.Send(mailid);
            if (state)
                return Created("Send", new Result() { message = "تمت عملية الارسال بنجاح", statusCode = 203 });
            return BadRequest(new Result() { message = "فشلت العملية", statusCode = 404 });


        }

        [HttpGet("GetMail")]
        public async Task<IActionResult> GetMail(DateTime? myday, int? daycheck, int? mailnum_bool, 
            int? mangment, DateTime? d1, DateTime? d2 , int? mailnum ,string? summary , int? mail_Readed,
            bool? mailReaded, bool? mailnot_readed, DateTime? Day_sended1, DateTime? Day_sended2 , int? Typeof_send , int? userid)

        {
            userid = 3;
            string mail_type = " ";
            var role_id = await dbcon.userRoles.FirstOrDefaultAsync(x=> x.UserId== userid);
            int user_role_num = role_id.RoleId;
            
            DateTime day = DateTime.Now;
            bool mail_accept = false;
            bool daysended = false;
            bool sendedType_exsist = false;
           // myday = day.Date;

            if (mangment == null)
            {   mangment = 1; }

            if (summary == null)
            {   summary = " "; }

            if (mailnum != null)
            {
                mailnum_bool = 0;
            }
            else
            {
                mailnum_bool = 1;
            }

            if (myday != null)
            {
               
                daycheck = 0;
            }
            else if (myday == null)
            {
               
                daycheck = 1;
            }

            if (d1 == null && d2 == null)
            { 
                d1 = day.Date;
                d2 = day.Date;

            }

            if(mail_Readed == null)
            {
                mail_accept = true;
                mailReaded = true;
                mailnot_readed = false;
            }else if(mail_Readed == 1)
            {
                mail_accept = false;
                mailReaded = true;
                mailnot_readed = true;
            }else if(mail_Readed ==0)
            {
                mail_accept = false;
                mailnot_readed = false;
                mailReaded = false;
            }

            if(Day_sended1 == null && Day_sended2 == null)
            {
                daysended = true;
            }else
            {
                daysended = false;
            }

            if(Typeof_send ==null)
            {
                sendedType_exsist = true;
            }
            else
            {
                sendedType_exsist = false;
            }

            if(user_role_num == 10 )
            {
                mail_type = "خ";
            }
            else if(user_role_num == 17)
            {
                mail_type = "داخلي";
            }
            else if (user_role_num == 18)
            {
                mail_type = "وارد خارجي";
            }
            else if (user_role_num == 19)
            {
                mail_type = "صادر خارجي";
            }

            var m = await dbcon.Departments.FindAsync(mangment);

            List<Sended_Maill> ma = await (from mail in dbcon.Mails.Where(x => (x.Management_Id == mangment &&
                                           x.Mail_Summary.Contains(summary) && (x.Date_Of_Mail.Date >= d1 && x.Date_Of_Mail.Date <= d2))
                                           &&(mailnum_bool == 1  || x.Mail_Number == mailnum ) &&  x.Mail_Type.Contains(mail_type) ).OrderByDescending(x => x.MailID)

                                           join ex in dbcon.Sends.Where(x => (x.flag == true) && ( daycheck == 1 || x.Send_time.Date == myday) &&
                                           ((x.State == mailnot_readed && x.State == mailReaded) || mail_accept == true ) && 
                                           ((x.Send_time.Date >=Day_sended1 && x.Send_time.Date <=Day_sended2 && x.State == true) || daysended ==true) &&
                                           (x.type_of_send == Typeof_send || sendedType_exsist ==true)   )
                                           on mail.MailID equals ex.MailID
                                          
                                          // join cx in dbcon.Replies.Where(x=> x.ReplyId)
                                           select new Sended_Maill()
                                           {
                                               mail_id=mail.MailID,
                                               State = (ex.State == true) ? "قرأت" : "لم تقرأ",
                                               type_of_mail = mail.Mail_Type,
                                               Mail_Number = mail.Mail_Number,
                                               date = mail.Date_Of_Mail.ToString("yyyy-MM-dd"),
                                               procedure_type = mail.clasification,
                                               mangment_sender = m.DepartmentName,
                                               Send_time = ex.Send_time,
                                               time = ex.Send_time.ToString("HH-mm-ss"),
                                               summary=mail.Mail_Summary,
                                              mail_res=dbcon.Mail_Resourcescs.Where(x=> x.MailID== mail.MailID).ToList()


                                           }).ToListAsync();


            return Ok(ma);

        }










    }
}
