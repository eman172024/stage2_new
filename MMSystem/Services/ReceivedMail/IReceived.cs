using MMSystem.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Services.ReceivedMail
{
     public  interface IReceived
    {
        Task<PagenationSendedEmail<Sended_Maill>> GetSendedMail(DateTime? myday, int? daycheck, int? mailnum_bool,
            int? mangment, DateTime? d1, DateTime? d2, int? mailnum, string? summary, int? mail_Readed,
            int? mailReaded, int? mailnot_readed, DateTime? Day_sended1, DateTime? Day_sended2, int? 
            Typeof_send , int? mail_type , string? replaytext, int pagenum, int size);

        Task<dynamic> GetMail(DateTime? myday, int? daycheck, int? mailnum_bool,
            int? mangment, DateTime? d1, DateTime? d2, int? mailnum, string? summary, int? mail_Readed,
            int? mailReaded, int? mailnot_readed, DateTime? Day_sended1, DateTime? Day_sended2, int?
            Typeof_send, int? userid, int? mailNumType , int? mail_type , string? replaytext,  int pagenum, int size);

        Task<PagenationSendedEmail<ExtarnelinboxViewModel>> GetExtarnelMail(DateTime? myday, int? daycheck, int? mailnum_bool,
            int? mangment, DateTime? d1, DateTime? d2, int? mailnum, string? summary, int? mail_Readed,
            int? mailReaded, int? mailnot_readed, DateTime? Day_sended1, DateTime? Day_sended2, int?
            Typeof_send , int? mail_type , string? replaytext, int pagenum, int size);

        Task<PagenationSendedEmail<ExtarnelinboxViewModel>> GetExtarnelinbox(DateTime? myday, int? daycheck, int? mailnum_bool,
           int? mangment, DateTime? d1, DateTime? d2, int? mailnum, string? summary, int? mail_Readed,
           int? mailReaded, int? mailnot_readed, DateTime? Day_sended1, DateTime? Day_sended2, int?
           Typeof_send , int? mail_type , string? replaytext, int pagenum, int size);

       
        Task <PagenationSendedEmail<ExtarnelinboxViewModel>> GetIncomingExtarnelMail(DateTime? myday, int? daycheck, int? mailnum_bool,
           int? mangment, DateTime? d1, DateTime? d2, int? mailnum, string? summary, int? mail_Readed,
           int? mailReaded, int? mailnot_readed, DateTime? Day_sended1, DateTime? Day_sended2, int?
           Typeof_send, int? mail_type, string? replaytext, int? userid , int pagenum,int size);

        Task <PagenationSendedEmail<ExtarnelinboxViewModel>> GetIncomingExtarnelinbox(DateTime? myday, int? daycheck, int? mailnum_bool,
           int? mangment, DateTime? d1, DateTime? d2, int? mailnum, string? summary, int? mail_Readed,
           int? mailReaded, int? mailnot_readed, DateTime? Day_sended1, DateTime? Day_sended2, int?
           Typeof_send, int? mail_type, string? replaytext, int? userid ,int pagenum, int size);

        Task<PagenationSendedEmail<Sended_Maill>> GetIncomingRecevidMail(DateTime? myday, int? daycheck, int? mailnum_bool,
           int? mangment, DateTime? d1, DateTime? d2, int? mailnum, string? summary, int? mail_Readed,
           int? mailReaded, int? mailnot_readed, DateTime? Day_sended1, DateTime? Day_sended2, int?
           Typeof_send, int? mail_type, string? replaytext, int? userid  , int pagenum, int size);

        Task<PagenationSendedEmail<Sended_Maill>> Getmail( int depid, int size, int pagenum);

        Task<PagenationSendedEmail<ExtarnelinboxViewModel>> Getextrmail(int depid, int size, int pagenum);

        Task<PagenationSendedEmail<ExtarnelinboxViewModel>> Getinboxmail(int depid, int size, int pagenum);

         Task<PagenationSendedEmail<Sended_Maill>> Getmailincoming( int depid, int size, int pagenum);

        Task<PagenationSendedEmail<ExtarnelinboxViewModel>> Getextrmailincoming(int depid, int size, int pagenum);

        Task<PagenationSendedEmail<ExtarnelinboxViewModel>> Getinboxmailincoming(int depid, int size, int pagenum);

        Task<dynamic> GetDynamic(DateTime? myday, int? daycheck, int? mailnum_bool,
        int? mangment, DateTime? d1, DateTime? d2, int? mailnum, string? summary, int? mail_Readed,
        int? mailReaded, int? mailnot_readed, DateTime? Day_sended1, DateTime? Day_sended2, int?
        Typeof_send, int? userid, int? mailNumType, int? mail_type, string? replaytext, int pagenum, int size);



        Task <PagenationSendedEmail<Sended_Maill>> GetAllIncoming(DateTime? myday, int? daycheck, int? mailnum_bool,
          int? mangment, DateTime? d1, DateTime? d2, int? mailnum, string? summary, int? mail_Readed,
          int? mailReaded, int? mailnot_readed, DateTime? Day_sended1, DateTime? Day_sended2, int?
          Typeof_send, int? mail_type, string? replaytext, int? userid, int pagenum, int size);

        Task<PagenationSendedEmail<Sended_Maill>> GetAll(DateTime? myday, int? daycheck, int? mailnum_bool,
         int? mangment, DateTime? d1, DateTime? d2, int? mailnum, string? summary, int? mail_Readed,
         int? mailReaded, int? mailnot_readed, DateTime? Day_sended1, DateTime? Day_sended2, int?
         Typeof_send, int? mail_type, string? replaytext, int? userid ,int pagenum, int size);
         Task<int> GetMailState(int mailid);

        Task<int> GetFlag(int mail_id, int department_Id);
    }
}
