using MMSystem.Model;
using MMSystem.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Services.MailServeic
{
  public interface IMail_Resourcescs:GenericInterface<Mail_Resourcescs, Mail_ResourcescsDto>
    {

        Task<List<Mail_ResourcescsDto>> GetAll(int id);

        Task<List<Mail_ResourcescsDto>> GetAll(int id,int userID);

        Task<string> tobase64(string patj);

        Task<List<Mail_ResourcescsDto>> GetAllRes(int id, int userId);
        Task<List<Mail_ResourcescsDto>> GetAllRes(int id);

        Task<bool> print(int mailid, int userId, int type);
    }
}
