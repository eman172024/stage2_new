using MMSystem.Model;
using MMSystem.Model.Dto;
using MMSystem.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Services.MailServeic
{
  public interface IMail_Resourcescs:GenericInterface<Mail_Resourcescs, Mail_ResourcescsDto>
    {

        Task<List<Mail_ResourcescsDto>> GetAll(int id);

     

        Task<string> tobase64(string patj);

        Task<List<Mail_ResourcescsDto>> GetAllRes(int id, int userId);
        Task<List<Mail_ResourcescsDto>> GetAllRes(int id);

        Task<bool> print(int mailid, int userId, int type);
        
        Task<RessPage> GetAllResss(int id, int pageNumber);
        Task<RessObj> GetAllResswithPage(int id, int pageNumber);

        Task<dynamic> delete_all_image(int id,int userid);

        Task<bool> order_images(List<ResViewModel> list);

        Task<RessObj> GetSingleImage(int id);

        Task<List<ResViewModel>> Get_Mail_Resourcescs_orders(int id);
    }
}
