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
        Task<bool> DeleteReply(int ReplayId,int UserId);
        Task<bool> DeleteNotSendedReply(ReplayPhotoVM replayPhotoVM);
        Task<bool> AddReplay(ReplyViewModel model);
        Task<MVM> GetAllReplay(int depid, int mailId);
        Task<bool> Uplode(Uplode file);
        Task<bool> AddResources(Reply_Resources resources);
        Task<List<RViewModel>> GetResourse(int id);
        Task<int> AddReplayWithPhotoFromDeskApp(ReplayPhotoVM replay);
        // Task<int> AddReplayWithPhoto(ReplayPhotoVM replay);
        Task<Replayid> AddReplayWithPhoto(ReplayPhotoVM replay);
        Task<Page_Reply_Resources> GetResources_ById(int id, int page_number);

        //*****28/2/2023
        Task<bool> update_replay(ReplayPhotoVM replay);
        //**end 28/2/2023


    }
}