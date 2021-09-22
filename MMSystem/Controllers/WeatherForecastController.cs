using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MMSystem.Model;
using MMSystem.Model.ViewModel;
using MMSystem.Services;
using MMSystem.Services.MailServeic;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using System.Net.NetworkInformation;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MMSystem.Controllers
{
    [ApiController]

    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly AppDbCon appDb;
        private readonly GetMailServices _getMailServices;

        public string sub { set; get; }
        public WeatherForecastController(AppDbCon appDb, GetMailServices getMailServices)
        {
            this.appDb = appDb;
            _getMailServices = getMailServices;
        }

        [HttpGet("GetAllDepartments")]
        public async Task<IActionResult> GetAllDepartments()
        {

            var c = await appDb.Departments.ToListAsync();
            return Ok(c);



        }


        [HttpGet("GetMailInfo")]
        public async Task<IActionResult> GetMailInfo(int mail_id, int Department_Id, int type)
        {

            var c = await _getMailServices.GetMail(mail_id, Department_Id, type);
            return Ok(c);

        }




        [HttpGet("GetSectors/{type}")]
        public async Task<IActionResult> GetSectors(int type)
        {
            var c = await appDb.Extrmal_Sections.Where(x => x.type == type&&x.perent== 0).ToListAsync();
            if(c.Count>0)
            return Ok(c);
            return NotFound("لايوجد بيانات");
        }

     

        [HttpGet("GetSides/{id}")]
        public async Task<IActionResult> GetSides(int id)
        {
            var c = await appDb.Extrmal_Sections.Where(x => x.perent == id).ToListAsync();

            if (c.Count > 0)
                return Ok(c);
            return NotFound("لايوجد بيانات");
        }

    }
}

