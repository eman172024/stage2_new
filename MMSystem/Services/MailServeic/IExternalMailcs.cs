using MMSystem.Model;
using MMSystem.Model.Dto;
using MMSystem.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Services.MailServeic
{
   public interface IExternalMailcs:GenericInterface<External_Mail, ExternalDto>
    {

        //تعديل بريد الصادر الخارجي
    
        Task<bool> Update(Mail mail1, External_Mail mail,int userid);
    }
}
