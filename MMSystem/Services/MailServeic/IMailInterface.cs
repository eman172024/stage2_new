using Microsoft.AspNetCore.Http;
using MMSystem.Model;
using MMSystem.Model.Dto;
using MMSystem.Model.ViewModel;
using MMSystem.Model.ViewModel.MailVModels;
using MMSystem.Services.MailServeic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Services.MailServeic
{
    public interface IMailInterface:GenericInterface<Mail,MailDto>
    {
        Task<MailDto> Getdto(int id, int type);

        Task<List<VModelForSendAndRecived>> GetSevenMail(int departmentId);

        Task<bool> addMail( MailViewModel mail);

        Task<bool> Delete(int id, int userid,int MailId);

     //   Task<bool> Upload(int id,List<IFormFile> listOfPhotes );
        Task<bool> UpdateFile(int id, List<IFormFile> listOfPhotes);
     Task<int> GetLastMailNumber(int id,int mailType);


        Task<MailVM> GetMailById(int id,int type,int year,int departmentid);
        Task<MailVM> GetMailById(int id, int type);
        Task<ExMail> GetMailById1(int id,int type);
        Task<ExMail> GetMailById1(int id, int type, int year, int departmentid);

        Task<ExInbox> GetMailById2(int id, int type);
        Task<ExInbox> GetMailById2(int id, int type, int year, int departmentid);

        Task<List<MailDto>> getExternalMail(int id);
        Task<List<MailDto>> getExternalInbox(int id);

        Task<dynamic> DynamicGet(int id, int type);
        Task<dynamic> DynamicGet(int id, int type, int year, int departmentId);

        Task<Pagenation<MailDto>> PaganationList(int page,int PageSize,int id);


        Task<bool> Uplode(Uplode ss);
        Task<bool> UpdateMail(MailViewModel mail);
        Task<bool> DeletePhote(int id);
        Task<bool> deleteSender(int mail_id, int departmentId);

        Task<List<MailStatus>> GetMailStatuses();


        Task<DetalisVModel> GetDetalies(int mail_id, int page, int page_size);




    }
}
