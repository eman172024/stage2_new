using MMSystem.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Services.ReceivedMail
{
     public  interface IReceived
    {
        Task<List<Sended_Maill>> GetRecevidMail(DateTime? myday, int? daycheck, int? mailnum_bool,
            int? mangment, DateTime? d1, DateTime? d2, int? mailnum, string? summary, int? mail_Readed,
            int? mailReaded, int? mailnot_readed, DateTime? Day_sended1, DateTime? Day_sended2, int? 
            Typeof_send , int? mail_type , string? replaytext);

        Task<dynamic> GetMail(DateTime? myday, int? daycheck, int? mailnum_bool,
            int? mangment, DateTime? d1, DateTime? d2, int? mailnum, string? summary, int? mail_Readed,
            int? mailReaded, int? mailnot_readed, DateTime? Day_sended1, DateTime? Day_sended2, int?
            Typeof_send, int? userid, int? mailNumType , int? mail_type , string? replaytext);

        Task<List<ExtarnelinboxViewModel>> GetExtarnelMail(DateTime? myday, int? daycheck, int? mailnum_bool,
            int? mangment, DateTime? d1, DateTime? d2, int? mailnum, string? summary, int? mail_Readed,
            int? mailReaded, int? mailnot_readed, DateTime? Day_sended1, DateTime? Day_sended2, int?
            Typeof_send , int? mail_type , string? replaytext);

        Task<List<ExtarnelinboxViewModel>> GetExtarnelinbox(DateTime? myday, int? daycheck, int? mailnum_bool,
           int? mangment, DateTime? d1, DateTime? d2, int? mailnum, string? summary, int? mail_Readed,
           int? mailReaded, int? mailnot_readed, DateTime? Day_sended1, DateTime? Day_sended2, int?
           Typeof_send , int? mail_type , string? replaytext);

       
        Task<List<ExtarnelinboxViewModel>> GetIncomingExtarnelMail(DateTime? myday, int? daycheck, int? mailnum_bool,
           int? mangment, DateTime? d1, DateTime? d2, int? mailnum, string? summary, int? mail_Readed,
           int? mailReaded, int? mailnot_readed, DateTime? Day_sended1, DateTime? Day_sended2, int?
           Typeof_send, int? mail_type, string? replaytext, int? userid);

        Task<List<ExtarnelinboxViewModel>> GetIncomingExtarnelinbox(DateTime? myday, int? daycheck, int? mailnum_bool,
           int? mangment, DateTime? d1, DateTime? d2, int? mailnum, string? summary, int? mail_Readed,
           int? mailReaded, int? mailnot_readed, DateTime? Day_sended1, DateTime? Day_sended2, int?
           Typeof_send, int? mail_type, string? replaytext, int? userid);

        Task<List<Sended_Maill>> GetIncomingRecevidMail(DateTime? myday, int? daycheck, int? mailnum_bool,
           int? mangment, DateTime? d1, DateTime? d2, int? mailnum, string? summary, int? mail_Readed,
           int? mailReaded, int? mailnot_readed, DateTime? Day_sended1, DateTime? Day_sended2, int?
           Typeof_send, int? mail_type, string? replaytext, int? userid);

        Task<PagenationSendedEmail<Sended_Maill>> Getmail( int depid, int size, int pagenum);

        Task<PagenationSendedEmail<ExtarnelinboxViewModel>> Getextrmail(int depid, int size, int pagenum);

        Task<PagenationSendedEmail<ExtarnelinboxViewModel>> Getinboxmail(int depid, int size, int pagenum);

         Task<PagenationSendedEmail<Sended_Maill>> Getmailincoming( int depid, int size, int pagenum);

        Task<PagenationSendedEmail<ExtarnelinboxViewModel>> Getextrmailincoming(int depid, int size, int pagenum);

        Task<PagenationSendedEmail<ExtarnelinboxViewModel>> Getinboxmailincoming(int depid, int size, int pagenum);

        Task<dynamic> GetDynamic(DateTime? myday, int? daycheck, int? mailnum_bool,
        int? mangment, DateTime? d1, DateTime? d2, int? mailnum, string? summary, int? mail_Readed,
        int? mailReaded, int? mailnot_readed, DateTime? Day_sended1, DateTime? Day_sended2, int?
        Typeof_send, int? userid, int? mailNumType, int? mail_type, string? replaytext);

       // Task<MailState> ChangeMailState(int mailid);
    }
}
