using Microsoft.AspNetCore.Mvc;
using MMSystem.Services.Histor;
using MMSystem.Services.ResendMail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Controllers
{

    [ApiController]
    [Route("api/[controller]")]

    public class ResendController : ControllerBase
    {

        public ResendController(IResendMail resendmail, IHistory hstory)
        {
            _data = resendmail;
            _hstory = hstory;

        }
        private readonly IResendMail _data;

        private readonly IHistory _hstory;



       
    }
}
