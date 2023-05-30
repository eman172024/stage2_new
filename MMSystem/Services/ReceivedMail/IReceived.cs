using MMSystem.Model;
using MMSystem.Model.Dto;
using MMSystem.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Services.ReceivedMail
{
     public  interface IReceived
    {


        Task<dynamic> GetMail(int? mailnum_bool,
        int? mangment, DateTime? d1, DateTime? d2, int? mailnum, string? summary, int? mail_Readed,
        int? mailReaded, int? mailnot_readed, int?
        Typeof_send, int? userid, int? mailNumType, int? mail_type, int pagenum,
        int size, int? Measure_filter, int? Department_filter, int? Classfication,
        int? mail_state, int? genral_incoming_num, int? TheSection, bool? Replay_Date, int? office_type, int? entity_reference_number);



        Task<PagenationSendedEmail<Sended_Maill>> Getmail( int depid, int size, int pagenum);

       

         Task<PagenationSendedEmail<Sended_Maill>> Getmailincoming( int depid, int size, int pagenum);

     

        Task<dynamic> GetDynamic( int? mailnum_bool,
        int? mangment, DateTime? d1, DateTime? d2, int? mailnum, string? summary, int? mail_Readed,
        int? mailReaded, int? mailnot_readed, int?
        Typeof_send, int? userid, int? mailNumType, int? mail_type, int pagenum,
        int size, int? Measure_filter, int? genral_incoming_num, int? Department_filter, int? Classfication, int? mail_state, int? TheSection, int? entity_reference_number);



        Task <PagenationSendedEmail<Sended_Maill>> GetAllIncoming( int? mailnum_bool,
          int? mangment, DateTime? d1, DateTime? d2, int? mailnum, string? summary, int? mail_Readed,
          int? mailReaded, int? mailnot_readed,  int?
          Typeof_send, int? mail_type, int? userid, int? mailNumType, int pagenum, int size,
          int? Measure_filter, int? Department_filter, int? Classfication, int? mail_state,
          int? genral_incoming_num,int? TheSection, int? entity_reference_number);

        Task<PagenationSendedEmail<Sended_Maill>> GetAll( int? mailnum_bool,
          int? mangment, DateTime? d1, DateTime? d2, int? mailnum, string? summary, int? mail_Readed,
          int? mailReaded, int? mailnot_readed, int?Typeof_send, int? mail_type, int? userid, int pagenum,
          int? mailNumType, int size, int? Measure_filter, int? Department_filter, int? Classfication,
          int? mail_state, int? genral_incoming_num, int? TheSection, bool? Replay_Date, int? office_type, int? entity_reference_number);
         Task<int> GetMailState(int mailid);


        Task<List<Extrmal_SectionDto>> getExtrinlSection();
       

        Task<int> GetFlag(int mail_id, int department_Id,int UserId);



        Task<int> print_Attachment(int mail_id, int department_Id, int userId);
        

        }
}
