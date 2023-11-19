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
        Task<bool> SendResendMail(int mail_id,int user_id , int department_id);
        Task<bool> deleteSectionsSender(int sends_to_id, int section_note_id, int userid);

        Task<bool> Add(Send_to t);
        Task<bool> SaveResendMail(ResendViewModel t, int userid);
        Task<bool> UpdateResendMail(ResendViewModel t, int userid);

    }
}
