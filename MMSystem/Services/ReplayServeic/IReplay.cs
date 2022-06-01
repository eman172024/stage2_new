using Microsoft.AspNetCore.Http;
using MMSystem.Model;
using MMSystem.Model.Dto;
using MMSystem.Model.ViewModel;
using MMSystem.Model.ViewModel.MailVModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MMSystem.Services.ReplayServeic
{
    public interface IReplay : GenericInterface<Reply,ReplayDto>
    {

        Task<bool> DeleteNotSendedReply();
        Task<bool> AddReplay(ReplyViewModel model);
        Task<MVM> GetAllReplay(int depid, int mailId);

        Task<bool> Uplode(Uplode file);
        Task<bool> AddResources(Reply_Resources resources);

        Task<List<RViewModel>> GetResourse(int id);

        Task<int> AddReplayWithPhotoFromDeskApp(ReplayPhotoVM replay);
        Task<int> AddReplayWithPhoto(ReplayPhotoVM replay);


    }
}