using Microsoft.AspNetCore.Http;
using MMSystem.Model;
using MMSystem.Model.Dto;
using MMSystem.Model.ViewModel;
using MMSystem.Services.MailServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Services
{
    public interface IMailInterface:GenericInterface<Mail,MailDto>
    {


        Task<MailViewModel> addMail( MailViewModel mail);
      
        Task<bool> Upload(List<IFormFile> listOfPhotes );

        Task<List<MailDto>> GetInternalMail(int id);

    }
}
