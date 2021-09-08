﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MMSystem.Model;
using MMSystem.Services;
using MMSystem.Services.ReplayServeic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReplyController : ControllerBase
    {
        public ReplyController(IReplay replay)
        {
            _Replay = replay;
        }

        private readonly IReplay _Replay ;

        [HttpPost("AddReply")]
        public async Task<IActionResult> AddReply([FromBody] Reply  mail)
        {
            var result = await _Replay.Add(mail);
            if (result)
                return Created("AddMail", new
                {
                    message = "تمت العملية بنجاح",
                    statusCode = 201,
                    ReplyId = mail.ReplyId
                }) ;
            return BadRequest(new Result()
            {
                message = "فشلت العملية",
                statusCode = 400
            });
        }
      




    }
}