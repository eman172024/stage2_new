using MMSystem.Model;
using MMSystem.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Services.ResendMail
{
    public interface  IResendMail
    {
        Task<bool> SendResendMail(ResendViewModel mail);
        Task<bool> deleteSectionsSender(int mail_id, int departmentId, int userid);


        Task<bool> SaveResendMail(ResendViewModel t);

    }
}
