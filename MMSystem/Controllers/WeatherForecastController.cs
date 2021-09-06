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

        public string sub { set; get; }
        public WeatherForecastController(AppDbCon appDb)
        {
            this.appDb = appDb;
        }

        [HttpGet("GetAllDepartments")]
        public async Task<IActionResult> GetAllDepartments()
        {

            var c = await appDb.Departments.ToListAsync();
            return Ok(c);



        }
        [HttpGet("Get/{id}")]
        public async Task<IActionResult> Get(int id)
        {

            var c = await appDb.Extrmal_Sections.Where(x => x.perent  >0&&x.type==id).ToListAsync();
            return Ok(c);


            //return spcefic value 
        }
        [HttpGet("GetAll/{id}")]
        public async Task<IActionResult> GetAll(int id)
        {

            var c = await appDb.Extrmal_Sections.Where(x=>x.perent==id).ToListAsync();
            return Ok(c);



        }


        [HttpGet("GetParent")]
        public async Task<IActionResult> GetParent(int id,int parent)
        {

            var c = await appDb.Extrmal_Sections.Where(x => x.type == id&&x.perent== parent).ToListAsync();
            return Ok(c);



        }

    }
}

