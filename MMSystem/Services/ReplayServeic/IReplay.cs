using Microsoft.AspNetCore.Http;
using MMSystem.Model;
using MMSystem.Model.Dto;
using MMSystem.Model.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MMSystem.Services.ReplayServeic
{
    public interface IReplay : GenericInterface<Reply,ReplayDto>
    {
     
        Task<bool> AddReplay(ReplyViewModel model);
        Task<List<ReplayDto>> GetAllReplay(int id);

        Task<bool> Uplode(Uplode file);
        Task<bool> AddResources(Reply_Resources resources);

        Task<bool> Upload(int id, List<IFormFile> listOfPhotes);


    }
}