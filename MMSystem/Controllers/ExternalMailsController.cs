using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> GetMail(DateTime? myday, int? daycheck, int? mailnum_bool,
            int? mangment, DateTime? d1, DateTime? d2, int? mailnum, string? summary, int? mail_Readed,
            int? mailReaded, int? mailnot_readed, DateTime? Day_sended1, DateTime? Day_sended2,
            int? Typeof_send, int? userid, int? mailNumType , int? mail_type, string? replaytext, int pagenum, int size)

        {

            dynamic c =await _re.GetMail(myday, daycheck, mailnum_bool,
                mangment, d1, d2, mailnum, summary, mail_Readed,
                mailReaded, mailnot_readed, Day_sended1, Day_sended2,
               Typeof_send, userid, mailNumType , mail_type , replaytext, pagenum,size);

            return Ok(c);
        }
        dynamic p;
        [HttpGet("pag")]
        public async Task<IActionResult> pag(int depid, int size, int pagenum , int type)

        {
            switch (type)
            {

                case 1: var c = await _re.Getmail(depid, size, pagenum);
                    p = c;
                    break;

                         case 2:
                    var c1 = await _re.Getextrmail(depid, size, pagenum);
                    p = c1;
                    break;

                case 3:
                    var c2 = await _re.Getinboxmail(depid, size, pagenum);
                    p = c2;
                    break;

                default:
                    p = null;
                    break;
            }


            return Ok(p);
        }

        [HttpGet("GetIncomingMail")]
        public async Task<IActionResult> GetIncomingMail(DateTime? myday, int? daycheck,
            int? mailnum_bool, int? mangment, DateTime? date_from, DateTime? date_to, int? mailnum, string? summary,
            int? mail_Readed, int? mailReaded, int? mailnot_readed, DateTime? Day_sended1,
            DateTime? Day_sended2, int? Typeof_send, int? mail_type, string? replaytext, int? userid,int mailNumType, int page_num,
            int page_size, int? Measure_filter, int? Department_filter, int? Classfication, int? mail_state)

        {

            var c = await _re.GetDynamic( myday, daycheck, mailnum_bool,
             mangment, date_from, date_to, mailnum, summary,
            mail_Readed,  mailReaded,  mailnot_readed,  Day_sended1,
             Day_sended2,Typeof_send,  userid,  mailNumType,
             mail_type, replaytext, page_num, page_size,
             Measure_filter,  Department_filter,  Classfication, mail_state);
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
        public async Task<IActionResult> read_it_mail(int mail_id,int  department_Id)

        {

            var c = await _re.GetFlag(mail_id, department_Id);
            if (c >0)
                return Ok(new
                {
                    flag = c,
                    State="قرأت"
                });
            return BadRequest("فشلت العملية");
        }





    }


}
