using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MMSystem.Model;
using MMSystem.Model.Dto;
using MMSystem.Services;
using MMSystem.Services.MailServeic;
using MMSystem.Services.ReceivedMail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExternalMailsController : ControllerBase
   
    {
        private readonly IExternalMailcs _external;
        private readonly IReceived _re;

        public ExternalMailsController(IExternalMailcs external , IReceived re)
        {
            _external = external;
            _re = re;
        }

        [HttpGet("GetMailById/{id}")]
        public async Task<IActionResult> GetMailById(int id)
        {
            var mail = await _external.Get(id);
            if (mail != null)
                return Ok(mail);


            return NotFound(new Result
            {
                message = "لايوجد بريد ",
                statusCode = 404
            });
        }


        [HttpGet("GetMail")]
        public async Task<IActionResult> GetMail(
            int? mailnum_bool, int? mangment, DateTime? date_from, DateTime? date_to, int? mailnum, string? summary,
            int? mail_Readed, int? mailReaded, int? mailnot_readed, int? Typeof_send, int? mail_type, int? userid, int mailNumType, int page_num,
            int page_size, int? Measure_filter, int? Department_filter, 
            int? Classfication, int? mail_state, int? genral_incoming_num, int? TheSection, bool? Replay_Date, int? office_type, int? entity_reference_number)

        {
            
            dynamic c =await _re.GetMail( mailnum_bool,
             mangment, date_from, date_to, mailnum, summary,
            mail_Readed, mailReaded, mailnot_readed, Typeof_send, userid, mailNumType,
             mail_type, page_num, page_size,
             Measure_filter, Department_filter, Classfication, mail_state,
             genral_incoming_num,  TheSection,  Replay_Date, office_type, entity_reference_number);

            if (c != null)
                return Ok(c);
            return Unauthorized("غير مسموح لك بدخول  ");
        }
        dynamic p;
        [HttpGet("pag")]
        public async Task<IActionResult> pag(int depid, int size, int pagenum , int type)

        {


            try
            {
                var c = await _re.Getmail(depid, size, pagenum);
                p = c;
                return Ok(p);
            }
            catch (Exception)
            {
                
                throw;
            }
        
                   

              

           
        }

        [HttpGet("GetIncomingMail")]
        public async Task<IActionResult> GetIncomingMail(
            int? mailnum_bool, int? mangment, DateTime? date_from, DateTime? date_to, int? mailnum, string? summary,
            int? mail_Readed, int? mailReaded, int? mailnot_readed,  int? Typeof_send, int? mail_type, int? userid,int mailNumType, int page_num,
            int page_size, int? Measure_filter, int? Department_filter, int? Classfication,
            int? mail_state, int? TheSection, int? genral_incoming_num ,int? entity_reference_number
)

        {

            var c = await _re.GetDynamic( mailnum_bool,
             mangment, date_from, date_to, mailnum, summary,
            mail_Readed,  mailReaded,  mailnot_readed, Typeof_send,  userid,  mailNumType,
             mail_type, page_num, page_size,
             Measure_filter,  Department_filter,  Classfication,
             mail_state, TheSection, genral_incoming_num, entity_reference_number);
            if(c!=null)
            return Ok(c);
            return Unauthorized("غير مسموح لك بدخول  ");
        }

        [HttpGet("GetMailState/{mailid}")]
        public async Task<IActionResult> GetMailState(int mailid)

        {

            var c = await _re.GetMailState(mailid);
            if (c != 0)
                return Ok(new {
                flag=c
                });
            return NotFound();
        }

        [HttpPut("read_it_mail")]
        public async Task<IActionResult> read_it_mail(int mail_id,int  department_Id,int userId)

        {

            var c = await _re.GetFlag(mail_id, department_Id, userId);
            if (c >0)
                return Ok(
                
                     c  
                );
            return BadRequest("فشلت العملية");
        }


        [HttpGet("Get_Extirnl_Sections")]
        public async Task<List<Extrmal_SectionDto>> Get_Extirnl_Sections()

        {

            var Sections = await _re.getExtrinlSection();

            
               return Sections;
           

          
        }

        [HttpPut("print_Attachment")]
        public async Task<IActionResult> print_Attachment(int mail_id, int department_Id, int userId)

        {

            var c = await _re.print_Attachment(mail_id, department_Id, userId);
            if (c > 0)
                return Accepted("print_Attachment", new { 
                message="j",
                StatusCode=203
                
                }

                     
                );
            return BadRequest("فشلت العملية");
        }


    }


}
