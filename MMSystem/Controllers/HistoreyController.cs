using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MMSystem.Model;
using MMSystem.Services.Histor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoreyController : ControllerBase
    {

        private readonly IHistory _History;

        public HistoreyController(IHistory history)
        {
           
            _History = history;
        }

        [HttpGet]
        [Route("GetAll")]
        public async  Task<IActionResult> GetAll()
        {
            var Histor   =await _History.GetAll();

            if (Histor!=null)
            
                return Ok(Histor);
               
            return BadRequest();
          
        }


    }
}
