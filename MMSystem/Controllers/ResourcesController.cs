using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MMSystem.Model.Dto;
using MMSystem.Model.ViewModel;
using MMSystem.Services.MailServeic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourcesController : ControllerBase
    {
        private readonly IMail_Resourcescs _resourcescs;

        public ResourcesController(IMail_Resourcescs Resourcescs)
        {
            _resourcescs = Resourcescs;
        }


        [HttpGet("GetMailResources")]
        public async Task<IActionResult> GetMailResources(int mail_id, int userId)
        {

           List< Mail_ResourcescsDto >list = await _resourcescs.GetAllRes(mail_id,userId);
                if(list.Count>0)
            return Ok(list);
            return NotFound("لايوجد صور ");
        }

        // GetResourse

        [HttpGet("GetMailReplyResources")]
        public async Task<IActionResult> GetMailReplyResources(int id)
        {

            List<Mail_ResourcescsDto> list = await _resourcescs.GetAllRes(id);
            if (list.Count > 0)
                return Ok(list);
            return NotFound("لايوجد صور ");
        }
        
            [HttpDelete("DeletePhoto")]
        public async Task<IActionResult> DeletePhoto(int id)
        {

         bool resulte = await _resourcescs.Delete(id);
            if (resulte)
                return Ok("تمت عملية الحدف بنجاح");
            return NotFound("فشلت العملية ");
        }
        [HttpGet("GetAllRes")]
        public async Task<IActionResult> GetAll(int id)
        {

            List<Mail_ResourcescsDto> resulte = await _resourcescs.GetAll(id);
            if (resulte.Count>0)
                return Ok(resulte);
            return NotFound("  لايوجد صور");
        }

        [HttpPost("print")]
        public async Task<IActionResult> print(int mail_id, int userId,int type)
        {


            bool result = await _resourcescs.print(mail_id, userId, type);

            if(result)
                return Ok();
            return BadRequest();

        }

        //api/Resources/GetAllDoc
        [HttpGet("GetAllDoc")]
        public async Task<IActionResult> GetAllDoc(int mail_id, int page_number)
        {

            try
            {
                var result = await _resourcescs.GetAllResswithPage(mail_id, page_number);

                if (result.total > 0)
                    return Ok(result);
                else
                {

                    return NotFound("لايوجد صور");

                }

            }
            catch (Exception ex)
            {

            return    BadRequest(new { massege=ex.Message,StatusCode=400});            }
          


        }
        [HttpDelete("delete_all_image")]
        public async Task<IActionResult> delete_all_image(int id,int userId)
        {

            var resulte = await _resourcescs.delete_all_image(id, userId);
            
                return Ok(resulte);
        }



        [HttpPut("update_mail_Resources_order")]
        public async Task<IActionResult> update_mail_Resources(List<ResViewModel> list)
        {


            if (list.Count != 0) {

                var isudate = await _resourcescs.order_images(list);
                if (isudate)
                    return Ok(new { message = "تمت العملية بنجاح" });
                return NotFound("لايوجد صور ");

            }

            return NotFound("لايوجد صور ");

        }


        [HttpGet("Get_Mail_Resourcescs_orders")]
        public async Task<IActionResult> Get_Mail_Resourcescs_orders(int mail_id)
        {

            try
            {
                var result = await _resourcescs.Get_Mail_Resourcescs_orders(mail_id);

                if (result.Count > 0)
                    return Ok(result);
                else
                {

                    return NotFound("لايوجد صور");

                }

            }
            catch (Exception ex)
            {

                return BadRequest(new { massege = ex.Message, StatusCode = 400 });
            }



        }

        [HttpGet("GetSingleImage")]
        public async Task<IActionResult> GetSingleImage(int id)
        {

            try
            {
                var result = await _resourcescs.GetSingleImage(id);

                if (result.total > 0)
                    return Ok(result);
                else
                {

                    return NotFound("لايوجد صور");

                }

            }
            catch (Exception ex)
            {

                return BadRequest(new { massege = ex.Message, StatusCode = 400 });
            }



        }
    }
}
