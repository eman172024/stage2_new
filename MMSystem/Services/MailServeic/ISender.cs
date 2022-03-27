using MMSystem.Model;
using MMSystem.Model.Dto;
using MMSystem.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Services.MailServeic
{
    public interface ISender
    {

        Task<bool> Add(Send_to t);
        Task<bool> Send(int mailId,int userId);
   
        Task<bool> UpdateSenderList(UpdateVM update);



    }
}
