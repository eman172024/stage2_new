using MMSystem.Model;
using MMSystem.Model.Dto;
using MMSystem.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Services.MailServeic
{
   public interface IExtrenal_inbox:GenericInterface<Extrenal_inbox, Extrenal_inboxDto>
    {

        Task<bool> Update(Mail mail, Extrenal_inbox ex, int userid);

    }
}
