using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Services.MailServices
{
    public class Resourse
    {
        public int Id { get; set; }
        public List<IFormFile> files { get; set; }
    }
}
