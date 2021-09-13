using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MMSystem.Model;
using MMSystem.Model.Dto;
using MMSystem.Model.ViewModel;
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
        [HttpPost("Uplode")]
        public async Task<IActionResult> Uplode([FromBody] Uplode file)
        {
            var result = await _Replay.Uplode(file);
            if (result)
                return StatusCode(203, new
                {
                    message = "تمت العملية بنجاح",
                    statusCode = 203,
                   
                });
            return BadRequest(new Result()
            {
                message = "فشلت العملية",
                statusCode = 400
            });
        }
        [HttpGet("GetReplyById/{id}")]
        public async Task<IActionResult> GetRepliesById(int id)
        {
            List<ReplayDto> result = await _Replay.GetAllReplay(id);
            if(result.Count>0)
            return Ok(result);
            return BadRequest(new Result()
            {
                message = "فشلت العملية",
                statusCode = 400
            });
        }




    }
}
