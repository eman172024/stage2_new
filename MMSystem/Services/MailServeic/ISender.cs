using MMSystem.Model;
using MMSystem.Model.Dto;
using MMSystem.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Services.MailServeic
{
    public interface ISender:GenericInterface<Send_to, SenderDto>
    {

        Task<List<Re>> GetMySenderMail(int id);

    }
}
