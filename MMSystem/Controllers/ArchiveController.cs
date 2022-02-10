using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MMSystem.Model.ViewModel.ArchivesReport;
using MMSystem.Model.ViewModel.ArchiveVM;
using MMSystem.Services.Archives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArchiveController : ControllerBase
    {
        private readonly IArchives _archives;

        public ArchiveController(IArchives archives)
        {
            _archives = archives;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(int page, int pageSize, int? mail_number, DateTime? date_time_of_day, DateTime? date_time_from, int? department_id, int? side_id, string? mail_summary, int? get_all ,int? MailType, int? Perent)
        {
            

            ArchiveVModelWithPag mail = await _archives.GetAll( page,  pageSize,   mail_number,   date_time_of_day,   date_time_from,   department_id,   side_id,   mail_summary,   get_all, MailType, Perent);
            if (mail != null)
                return Ok(mail);

            return NotFound(new
            {
                message = "لايوجد بريد ",
                statusCode = 404
            });
           
          
            }




        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateArchiveViewModel model)
        {
            bool result = await _archives.UpdateExternal(model);
            if (result)
                return StatusCode(203, new
                {
                    mes = "تمت عملية التعديل بنجاح"
                    ,
                    Stut = 203
                });


            return BadRequest(new
            {
                message = "فشلت العملية ",
                statusCode = 400
            });
        }

        [HttpPut("Updates")]
        public async Task<IActionResult> Updates([FromBody] UpdateArchiveViewModel model)
        {
            bool result = await _archives.UpdateExternals(model);
            if (result)
                return StatusCode(203, new
                {
                    mes = "تمت عملية التعديل بنجاح"
                    ,
                    Stut = 203
                });


            return BadRequest(new
            {
                message = "فشلت العملية ",
                statusCode = 400
            });
        }
    }
}
