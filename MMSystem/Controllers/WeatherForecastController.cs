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
      public  dynamic obj;

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
          

            switch (type)
            {
                case 1:
                    var mail = await _getMailServices.GetMail(mail_id, Department_Id, type);
                    obj = mail;
                    break;
                case 2:
                    var External = await _getMailServices.GetExternalMail(mail_id, Department_Id,type);
                    obj = External;
                    break;
                case 3:
                    var ExternalInbox = await _getMailServices.GetExternalbox(mail_id, Department_Id, type);
                    obj = ExternalInbox;
                    break;
                default:
                    break;
            }

          
            return Ok(obj);

        }




        [HttpGet("GetSectors/{type}")]
        public async Task<IActionResult> GetSectors(int type)
        {

            List<Extrmal_Section> c = new List<Extrmal_Section>();
            switch (type)
            {
                case 0:
                  c = await appDb.Extrmal_Sections.Where(x=> x.perent == 0&&x.state==true).ToListAsync();

                    break;

                default:
                    c = await appDb.Extrmal_Sections.Where(x => x.type == type && x.perent == 0 && x.state == true).ToListAsync();

                    break;
            }

           
            if(c.Count>0)
            return Ok(c);
            return NotFound("لايوجد بيانات");
        }

     

        [HttpGet("GetSides/{id}")]
        public async Task<IActionResult> GetSides(int id)
        {
            List<Extrmal_Section> laist = new List<Extrmal_Section>();
            switch (id)
               
            {
                case 0:

                    laist = await appDb.Extrmal_Sections.Where(x => x.perent !=0).ToListAsync();
                    break;
                default:
                    laist = await appDb.Extrmal_Sections.Where(x => x.perent == id).ToListAsync();
                    break;
            }
            

            if (laist.Count > 0)
                return Ok(laist);
            return NotFound("لايوجد بيانات");
        }

    }
}

