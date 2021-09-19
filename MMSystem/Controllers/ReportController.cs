﻿using AutoMapper;
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
        public async Task<IActionResult> GetAllUserCount(int departmentid, DateTime? fromdate, DateTime ? todate, int ? MailType , string SendedOrRecieved)
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
        public async Task<IActionResult> GetAllDepartmentReports(DateTime? fromdate, DateTime? todate, int ? MailType, string SendedOrRecieved)
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
        public async Task<IActionResult> GetAllUserMassageReport(int userid, DateTime? fromdate, DateTime? todate, int ? MailType, string SendedOrRecieved)
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
        public async Task<IActionResult> GetMySectionReport(int departmentid, DateTime? fromdate, DateTime? todate, int? MailType, string SendedOrRecieved)
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
    }
}
