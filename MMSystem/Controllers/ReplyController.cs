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

        private readonly IReplay _Replay;

        [HttpPost("AddReply")]
        public async Task<IActionResult> AddReply([FromBody] ReplyViewModel mail)
        {
            var result = await _Replay.AddReplay(mail);
            if (result)
                return Created("AddMail", new
                {
                    message = "تمت العملية بنجاح",
                    statusCode = 201,
                    ReplyId = mail.reply.ReplyId
                });
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
        [HttpGet("GetReplyById")]
        public async Task<IActionResult> GetReplyById(int department_id, int mail_id)
        {
            var result = await _Replay.GetAllReplay(department_id, mail_id);

            return Ok(result);
            //return BadRequest(new Result()
            //{
            //    message = "فشلت العملية",
            //    statusCode = 400
            //});
        }
        [HttpGet("GetReplyWithRessourses/{id}")]
        public async Task<IActionResult> GetReplyWithRessourses(int id)
        {
            var result = await _Replay.GetResourse(id);
            if (result.Count > 0)
                return Ok(result);
            return BadRequest(new Result()
            {
                message = "فشلت العملية",
                statusCode = 400
            });
        }
        [HttpPut("DeleteReply")]
        public async Task<IActionResult> DeleteReply(int id,int UserId)
        {
            var result = await _Replay.DeleteReply(id,UserId);
           
            if (result) {                        
                

                return Ok(result);
            }
            return BadRequest(new Result()
            {
                message = "فشلت العملية",
                statusCode = 400
            });
        }


        //**************28/3/2023
        [HttpPost("update_replay")]
        public async Task<IActionResult> update_replay([FromBody] ReplayPhotoVM mail)
        {
            var result = await _Replay.update_replay(mail);
            if (result)
            {


                return Ok(result);
            }
            return BadRequest(new Result()
            {
                message = "فشلت العملية",
                statusCode = 400
            });

        }

        //**********end 28/3/2023

        [HttpPost("AddReplyWithPhoto")]
        public async Task<IActionResult> AddReplyWithPhoto([FromBody] ReplayPhotoVM mail)
        {
            var result = await _Replay.AddReplayWithPhoto(mail);
            string massege;
           // switch (result) {
             switch (result.result1) { 
                case 1:
                    massege = "تمت الاضافة بنجاح";
                    break;
                case 2:

                    massege = "تمت اضافة رد من غير مرفق";
                    break;
                case 3:
                 massege = "فشلت العملية";
                    break;
               
                default:
                    massege = "حدث خطأ ";

                    break;
            };

          
            //1/3/2023 return Ok(massege);
            return Ok(result);

        }
        [HttpPost("DeleteNotSendedReply")]
        public async Task<IActionResult> DeleteNotSendedReply(ReplayPhotoVM replayPhotoVM)
        {
            var result = await _Replay.DeleteNotSendedReply(replayPhotoVM);           
            if (result)
            return Ok(result); 
            return BadRequest(new Result()
            {
                message = "فشلت العملية",
                statusCode = 404
            });

        }
        [HttpPost("AddReplayWithPhotoFromDeskApp")]
        public async Task<IActionResult> AddReplayWithPhotoFromDeskApp([FromBody] ReplayPhotoVM mail)
        {
            var result = await _Replay.AddReplayWithPhotoFromDeskApp(mail);
            string massege;
            switch (result)
            {
                case 1:
                    massege = "تمت الاضافة بنجاح";
                    break;
                case 2:

                    massege = "تمت اضافة رد من غير مرفق";
                    break;
                case 3:
                    massege = "فشلت العملية";
                    break;

                default:
                    massege = "حدث خطأ ";

                    break;
            };

            return Ok(massege);

        }

        //GetResources_ById

        [HttpGet("GetResources_ById")]
        public async Task<IActionResult> GetResources_ById(int id, int page_number)
        {
            var result = await _Replay.GetResources_ById(id, page_number);
            if (result.total>0)
                return Ok(result);
            return NotFound(new 
            {
                message = "لايوجد مرفقات ",
                statusCode = 404
            });

        }
    }
}
