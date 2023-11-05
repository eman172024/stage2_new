﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MMSystem.Model;
using MMSystem.Model.Dto;
using MMSystem.Model.ViewModel;
using MMSystem.Model.ViewModel.MailVModels;
using MMSystem.Services;
using MMSystem.Services.Histor;
using MMSystem.Services.MailServeic;
using MMSystem.Services.ResendMail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMSystem.Controllers
{

    [ApiController]
    [Route("api/[controller]")]

    public class ResendController : ControllerBase
    {
        private readonly IResendMail _data;
        private readonly IHistory _hstory;

        public ResendController(IResendMail resendmail, IHistory hstory)
        {
            _data = resendmail;
            _hstory = hstory;

        }


        [HttpPost("ResendMail")]
        public async Task<IActionResult> Resendmail([FromBody] ResendViewModel mail)
        {
            var result = await _data.SaveResendMail(mail);
            if (result)
                return Created("ResendMail", new
                {
                    message = "تمت العملية بنجاح",
                    statusCode = 201,
                    mailId = mail.Mail_id,
  
                });
            return BadRequest(new Result()
            {
                message = "فشلت العملية",
                statusCode = 400
            });
        }



    }
}
