using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Services
{
    public class MailResourse
    {

        public int Id { get; set; }

        public List<IFormFile>  listOfPhotes{ get; set; }

    }
}
