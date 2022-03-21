using MMSystem.Model.Dto;
using MMSystem.Model.ViewModel.MailVModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Services.MailServeic
{
  public  interface GetMailServices
    {

        Task<MVM> GetMail(int mail_id,int Depa,int tybe);
        Task<string> tobase64(string patj);
        Task<EMVM> GetExternalMail(int mail_id, int Depa, int type);
        Task<MailDto> Getdto(int id, int type);
        Task<EIMVM> GetExternalbox(int mail_id, int Depa, int type);

    
    }
}
