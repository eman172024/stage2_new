using Microsoft.AspNetCore.Http;
using MMSystem.Model;
using MMSystem.Model.Dto;
using MMSystem.Model.ViewModel;
using MMSystem.Services.MailServeic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Services.MailServeic
{
    public interface IMailInterface:GenericInterface<Mail,MailDto>
    {


        Task<List<MailDto>> GetSevenMail();

        Task<bool> addMail( MailViewModel mail);
      
        Task<bool> Upload(int id,List<IFormFile> listOfPhotes );
        Task<bool> UpdateFile(int id, List<IFormFile> listOfPhotes);
     Task<int> GetLastMailNumber(int id,string mailType);

      Task<List<MailDto>> getExternalMail(int id);
        Task<List<MailDto>> getExternalInbox(int id);


        Task<Pagenation<MailDto>> PaganationList(int page,int PageSize,int id);


        Task<bool> up(Re ss);
      

    }
}
