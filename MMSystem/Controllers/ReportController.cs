using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MMSystem.Services;
using MMSystem.Services.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        
        public ReportsController(IRportInterface reportinterface)
        {
            _data = reportinterface;         
        }

       private IRportInterface _data { get; }

        [HttpGet]
        [Route("GetAllSystemCount")]
        public async Task<IActionResult> GetAllSystemCount()
        {
            var roles = await _data.GetAllSystemCount();
            if (roles != null)
            {
                return Ok(roles);
            }
            else
            {
                return NotFound(new Result() { message = "التقارير غير موجودة", statusCode = 404 });
            }
        }


        [HttpGet]
        [Route("GetAllUserCount")]
        public async Task<IActionResult> GetAllUserCount(int departmentid, DateTime fromdate, DateTime  todate, int ? MailType , string SendedOrRecieved)
        {
            var roles = await _data.GetAllUserCount(departmentid, fromdate, todate,  MailType, SendedOrRecieved);
            if (roles != null)
            {
                return Ok(roles);
            }
            else
            {
                return NotFound(new Result() { message = "التقارير غير موجودة", statusCode = 404 });

            }
        }

        [HttpGet]
        [Route("GetAllDepartmentReports")]
        public async Task<IActionResult> GetAllDepartmentReports(DateTime fromdate, DateTime todate, int ? MailType, string SendedOrRecieved)
        {
            var role = await _data.GetAllDepartmentReports( fromdate,todate, MailType , SendedOrRecieved);

            if (role != null)
            {
                return Ok(role);
            }
            else
            {
                return NotFound(new Result() { message = "التقارير غير موجودة", statusCode = 404 });
            }
        }

        [HttpGet]
        [Route("GetAllUserMassageReport")]
        public async Task<IActionResult> GetAllUserMassageReport(int userid, DateTime fromdate, DateTime todate, int ? MailType, string SendedOrRecieved)
        {
            var role = await _data.GetAllUserMassageReport(userid, fromdate, todate, MailType, SendedOrRecieved);

            if (role != null)
            {
                return Ok(role);
            }
            else
            {
                return NotFound(new Result() { message = "التقارير غير موجودة", statusCode = 404 });
            }
        }

        [HttpGet]
        [Route("GetMySectionReport")]
        public async Task<IActionResult> GetMySectionReport(int departmentid, DateTime fromdate, DateTime todate, int? MailType, string SendedOrRecieved)
        {
            var roles = await _data.GetMySectionReport(departmentid, fromdate, todate, MailType, SendedOrRecieved);
            if (roles != null)
            {
                return Ok(roles);
            }
            else
            {
                return NotFound(new Result() { message = "التقارير غير موجودة", statusCode = 404 });

            }
        }

        [HttpGet]
        [Route("GetReportDepartment")]

        
        public async Task<IActionResult> GetDepartment(int departmenti_d, DateTime? from, DateTime? to, int? Department_filter, int? mailnum, int? mailnum_bool, string? summary, int? mail_Readed,
            int? mailReaded, int? mailnot_readed, int? mail_type, int? Measure_filter, int? Classfication
                   //    , int? mail_state, int? genral_incoming_num)
                   , int? mail_state, int? genral_incoming_num,int? thesection, int? entity_reference_number, bool? Replay_Date)
        {

            try
            {
                var c = await _data.ReportForDep( departmenti_d,  from,  to,  Department_filter,  mailnum,  mailnum_bool,  summary, mail_Readed,
            mailReaded,  mailnot_readed,  mail_type,  Measure_filter,  Classfication
 , mail_state,  genral_incoming_num, thesection, entity_reference_number, Replay_Date);
                if (c.Count() > 0)
                {



                    return Ok(c);
                }
                else
                {
                    return NotFound(new Result() { message = "التقارير غير موجودة", statusCode = 404 });

                }
            }
            catch (Exception ex)
            {
                return BadRequest(new Result() { message =  ex.Message, statusCode = 404 });

            }

        }
        [HttpGet]
        [Route("Get_main_statistics_Report")]
        public async Task<IActionResult> Get_main_statistics_Report(DateTime from, DateTime to)
        {
            var role = await _data.Get_main_statistics_Report(from, to);

            if (role != null)
            {
                return Ok(role);
            }
            else
            {
                return NotFound(new Result() { message = "التقارير غير موجودة", statusCode = 404 });
            }
        }

        [HttpGet]
        [Route("Get_Detailes_statistics_Report")]
        public async Task<IActionResult> Get_Detailes_statistics_Report(DateTime from, DateTime to)
        {
            var role = await _data.Get_Detailes_statistics_Report(from, to);

            if (role != null)
            {
                return Ok(role);
            }
            else
            {
                return NotFound(new Result() { message = "التقارير غير موجودة", statusCode = 404 });
            }
        }
    }
}
