using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MMSystem.Model.Dto;
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
        public async Task<IActionResult> GetMailResources(int id)
        {

           List< Mail_ResourcescsDto >list = await _resourcescs.GetAllRes(id);
                if(list.Count>0)
            return Ok(list);
            return NotFound("لايوجد صور ");
        }


    }
}
