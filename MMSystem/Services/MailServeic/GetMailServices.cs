using MMSystem.Model.ViewModel.MailVModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Services.MailServeic
{
  public  interface GetMailServices
    {

        Task<MVM> GetMail(int mail_id,int Depa);
        Task<string> tobase64(string patj);

    }
}
