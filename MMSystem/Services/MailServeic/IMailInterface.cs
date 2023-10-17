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


        Task<bool> addMail( MailViewModel mail);

        Task<bool> Delete(int id, int userid,int MailId);

      
        Task<int> GetLastMailNumber(int id,int mailType);


        Task<MailVM> GetMailById(int id, int type,int page);
        Task<ExMail> GetMailById1(int id, int type,int page);

        Task<ExInbox> GetMailById2(int id, int type, int page);


        Task<dynamic> DynamicGet(int id, int type, int page);


        Task<bool> Uplode(Uplode ss);
        Task<bool> UpdateMail(MailViewModel mail);
        Task<bool> DeletePhote(int id,int userId);
        Task<bool> deleteSender(int mail_id, int departmentId,int userid);

        Task<List<MailStatus>> GetMailStatuses();


        Task<List<SendsDetalies>> GetDetalies(int mail_id);
        Task<dynamic> search(int id, int type, int year, int departmentId);

        Task<List<MailStateViewModel>> GetAllState(int number);

        Task<bool> Update(int userid, Mail mail);
        Task<bool> is_exisite_genaral_inbox_number(int Genaral_inbox_Number);
        Task<bool> conclusion(int MailID, string conclusion);


        Task<bool> delete_sector(int id);


        Task<List<REsViewModel>> Reppor();


        Task<List<ReportViewModelData>> ReportViewModelData();

    }
}
