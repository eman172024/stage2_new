using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private IWebHostEnvironment iwebHostEnvironment;
        private readonly IMail_Resourcescs _mail;

        public string sub { set; get; }
        public WeatherForecastController(IMailInterface mailcs, IWebHostEnvironment hosting, IMail_Resourcescs mail)
        {
            _mailcs = mailcs;
            iwebHostEnvironment = hosting;
            _mail = mail;

        }


        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IMailInterface _mailcs;
     //   public IHostingEnvironment _environment { get; }



        [HttpPost("addmail")]
        public async Task<IActionResult> addmail([FromBody] Mail mail,[FromForm] List<IFormFile> resourse)
        {

            var c = await _mailcs.Add(mail);
        //   var r= _mailcs.Upload(resourse);

            return Ok(c);
        }

        [HttpPost("Ad")]
        public async Task<IActionResult> Ad([FromBody] MailViewModel mail)
        {

            var c =await _mailcs.addMail(mail);

            RedirectToRoute("Ada");
            return Ok(c);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> get(int id)
        {
            var c =await _mailcs.Get(id);

            if(c!=null)
            return Ok(c);
            return BadRequest(new Result
            {
                message = "لايوجد بريد",
                statusCode = 204
            });
           
        }

    


        [HttpPost("Ada")]
        public async Task<IActionResult> ada(int id,[FromForm] List<IFormFile> resourse)
        {
          
            try
            {
            
                foreach (var file in resourse)
                {
                     sub="";

                    var cc = file.FileName.TakeLast(5);

                    foreach (var item in cc)
                    {
                        sub = sub + item.ToString();

                    }
                  
                    Guid guid = Guid.NewGuid();
                        string x = guid.ToString() + "" + sub;
                 
                    var path = Path.Combine(this.iwebHostEnvironment.WebRootPath, "images",x);

                  //  file.FileName.Replace(file.FileName,x);
                    var stream = new FileStream(path, FileMode.Create);
                                      
                    await file.CopyToAsync(stream);
                 
                }
                return Ok("done");
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost("Adaa")]
        public async Task<IActionResult> Adaa( [FromForm] int id, List<IFormFile> resourse)
        {

            try
            {
             

                foreach (var file in resourse)
                {
                    sub = "";

                    var cc = file.FileName.TakeLast(5);

                    foreach (var item in cc)
                    {
                        sub = sub + item.ToString();

                    }

                    Guid guid = Guid.NewGuid();
                    string x = guid.ToString() + "" + sub;

                    var path = Path.Combine(this.iwebHostEnvironment.WebRootPath, "images", x);

                    //  file.FileName.Replace(file.FileName,x);
                    var stream = new FileStream(path, FileMode.Create);

                    await file.CopyToAsync(stream);
                    Mail_Resourcescs mail = new Mail_Resourcescs();
                    mail.MailID = id;
                    mail.path = x;



                    bool c = await _mail.Add(mail);

                }
                return Ok("done");
            }
            catch
            {
                return BadRequest();
            }
        }




    }
}

