using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MMSystem.Services;
using MMSystem.Services.MailServeic;
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

        public ExternalMailsController(IExternalMailcs external)
        {
            _external = external;
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

    }
}
