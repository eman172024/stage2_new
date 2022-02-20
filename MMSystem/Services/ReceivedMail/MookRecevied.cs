using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MMSystem.Model;
using MMSystem.Model.Dto;
using MMSystem.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Services.ReceivedMail
{
    public class MookRecevied : IReceived
    {
        private readonly AppDbCon dbcon;
        private readonly IMapper _mapper;
        dynamic d;
        public MookRecevied(AppDbCon _bcon)
        {
            dbcon = _bcon;
        }

        public async Task<PagenationSendedEmail<Sended_Maill>> GetAll(DateTime? myday, int? daycheck, int? mailnum_bool,
           int? mangment, DateTime? d1, DateTime? d2, int? mailnum, string? summary, int? mail_Readed,
           int? mailReaded, int? mailnot_readed, DateTime? Day_sended1, DateTime? Day_sended2, int?
           Typeof_send, int? mail_type, string? replaytext, int? userid, int pagenum, int size, int? Measure_filter,
           int? Department_filter, int? Classfication, int? mail_state, int? genral_incoming_num
            , int? TheSection, bool? Replay_Date)
        {
            try
            {



                DateTime day = DateTime.Now;

                bool dep_filter = false;
                bool clasf_filter = false;
                bool meas_filter = false;
                bool incoing_num_filter = false;
                bool mail_accept = false;
                bool daysended = false;
                bool State_filter = false;
                bool Sectionbool = false;

                // myday = day.Date;

                if (genral_incoming_num == null)
                {
                    incoing_num_filter = true;
                }
                else { incoing_num_filter = false; }




                if(TheSection== null)
                {
                    Sectionbool = true;
                }
                else
                {
                    Sectionbool = false;

                }












                if (mail_state == null)
                {
                    State_filter = true;
                }
                else { State_filter = false; }



                if (Classfication == null)
                {
                    clasf_filter = true;
                }
                else { clasf_filter = false; }


                if (Measure_filter == null)
                {
                    meas_filter = true;
                }
                else { meas_filter = false; }

                if (Department_filter == null)
                {

                    dep_filter = true;

                }
                else { dep_filter = false; }



                if (summary == null)
                { summary = " "; }

                if (mailnum != null)
                {
                    mailnum_bool = 0;
                }
                else
                {
                    mailnum_bool = 1;
                }

                if (myday != null)
                {

                    daycheck = 0;
                }
                else if (myday == null)
                {

                    daycheck = 1;
                }

                if (d1 == null && d2 == null)
                {
                    d1 = day.Date;
                    d2 = day.Date;

                }

                if (mail_Readed == null)
                {
                    mail_accept = true;
                    mailReaded = -1;
                    mailnot_readed = -1;
                }
                else if (mail_Readed == 2)
                {
                    mail_accept = false;
                    mailReaded = 2;
                    mailnot_readed = 5;
                }
                else if (mail_Readed == 1)
                {
                    mail_accept = false;
                    mailnot_readed = 1;
                    mailReaded = 1;
                }

                if (Day_sended1 == null && Day_sended2 == null)
                {
                    daysended = true;
                }
                else
                {
                    daysended = false;
                }


                if (replaytext == null)
                {
                    replaytext = " ";
                }

                //if (mailNumType == 1 && (user_role_num == 10 || user_role_num == 17))
                //{
                //    mail_type = "داخلي";
                //}

                //if (user_role_num == 10)
                //{
                //    mail_type = "خ";
                //}
                ////else if (user_role_num == 17)
                ////{
                ////    mail_type = "داخلي";
                ////}
                //else if (mailNumType == 3 && (user_role_num == 18 || user_role_num == 10))
                //{
                //    mail_type = "وارد خارجي";
                //}
                //else if (mailNumType == 2 && (user_role_num == 19 || user_role_num == 10))
                //{
                //    mail_type = "صادر خارجي";
                //}

                if (replaytext == null)
                {
                    replaytext = " ";
                }
                var m = await dbcon.Departments.FindAsync(mangment);

                PagenationSendedEmail<Sended_Maill> pag = new PagenationSendedEmail<Sended_Maill>();


                var c = await (from mail in dbcon.Mails.Where(x => (x.Department_Id == mangment &&
                                           x.Mail_Summary.Contains(summary) && (x.Date_Of_Mail.Date >= d1 && x.Date_Of_Mail.Date <= d2))
                                           && (mailnum_bool == 1 || x.Mail_Number == mailnum) &&
                                           (x.clasification == Classfication || clasf_filter == true) &&
                                           (x.Genaral_inbox_Number == genral_incoming_num || incoing_num_filter == true) && x.state == true).OrderByDescending(x => x.MailID)

                                   //join Extr in dbcon.Extrenal_Inboxes on mail.MailID equals Extr.MailID
                               join ex in dbcon.Sends.Where(x => (x.flag > 0) &&
                               ((x.flag >= mailReaded && x.flag <= mailnot_readed) || mail_accept == true) &&
                               (x.flag == mail_state || State_filter == true) && (dep_filter == false && x.isMulti == false || dep_filter == false && x.isMulti == true || x.isMulti == true))
                               on mail.MailID equals ex.MailID
                              

                               join dx in dbcon.measures.Where(x => (x.MeasuresId == Measure_filter || meas_filter == true)) on ex.type_of_send equals dx.MeasuresId
                               join n in dbcon.Departments.Where(x => (x.Id == Department_filter || dep_filter == true)) on ex.to equals n.Id
                               join z in dbcon.MailStatuses.Where(x => x.state == true) on ex.flag equals z.flag
                             

                               //  join rep in dbcon.Replies on ex.Id equals rep.ReplyId

                               // join cx in dbcon.Replies.Where(x=> x.ReplyId)
                               select new Sended_Maill()
                               {
                                   mail_id = mail.MailID,
                                   State = z.sent,
                                   type_of_mail = mail.Mail_Type,
                                   Mail_Number = mail.Mail_Number,
                                   date = mail.Date_Of_Mail.ToString("yyyy-MM-dd"),
                                   Masure_type = dx.MeasuresName,
                                   mangment_sender = n.DepartmentName,
                                   mangment_sender_id = mail.Department_Id,
                                   Send_time = ex.Send_time.ToString("yyyy-MM-dd"),
                                   time = ex.Send_time.ToString("HH:mm:ss"),
                                   summary = mail.Mail_Summary,
                                   flag = ex.flag,
                                   Sends_id = ex.Id
                                   


                               }).OrderByDescending(v => v.mail_id).ToListAsync();

                IEnumerable<Sended_Maill> zx;
                if (Replay_Date == true)
                {//d
                    var lx = Replay_Date;


                    zx = (from x in c
                          join vv in dbcon.Replies
                          on x.Sends_id equals vv.send_ToId

                          select new Sended_Maill
                          {

                              mail_id = x.mail_id,
                              State = x.State,
                              type_of_mail = x.type_of_mail,
                              Mail_Number = x.Mail_Number,
                              date = x.date,
                              Masure_type = x.Masure_type,
                              mangment_sender = x.mangment_sender,
                              mangment_sender_id = x.mangment_sender_id,
                              Send_time = x.Send_time,
                              time = x.time,
                              summary = x.summary,
                              flag = x.flag,
                              Sends_id = x.Sends_id
                          }
                              ).ToList();


                }
                else
                {
                    zx = c;
                }










                pag.mail = await (from mail in dbcon.Mails.Where(x => (x.Department_Id == mangment &&
              x.Mail_Summary.Contains(summary) && (x.Date_Of_Mail.Date >= d1 && x.Date_Of_Mail.Date <= d2))
              && (mailnum_bool == 1 || x.Mail_Number == mailnum) && (x.clasification == Classfication || clasf_filter == true)
              && (x.Genaral_inbox_Number == genral_incoming_num || incoing_num_filter == true) && x.state == true).OrderByDescending(x => x.MailID)

                                      //join Extr in dbcon.Extrenal_Inboxes on mail.MailID equals Extr.MailID
                                  join ex in dbcon.Sends.Where(x => (x.flag > 0) &&
                                  ((x.flag >= mailReaded && x.flag <= mailnot_readed) || mail_accept == true) &&
                                  (x.flag == mail_state || State_filter == true) && (dep_filter == false && x.isMulti == false || dep_filter == false && x.isMulti == true || x.isMulti == true))
                                  on mail.MailID equals ex.MailID

                                  

                                  join dx in dbcon.measures.Where(x => (x.MeasuresId == Measure_filter || meas_filter == true)) on ex.type_of_send equals dx.MeasuresId
                                  join n in dbcon.Departments.Where(x => (x.Id == Department_filter || dep_filter == true)) on ex.to equals n.Id
                                  join z in dbcon.MailStatuses.Where(x => x.state == true) on ex.flag equals z.flag


                                  //  join rep in dbcon.Replies on ex.Id equals rep.ReplyId

                                  // join cx in dbcon.Replies.Where(x=> x.ReplyId)
                                  select new Sended_Maill()
                                  {
                                      mail_id = mail.MailID,
                                      State = z.sent,
                                      type_of_mail = mail.Mail_Type,
                                      Mail_Number = mail.Mail_Number,
                                      date = mail.Date_Of_Mail.ToString("yyyy-MM-dd"),
                                      Masure_type = dx.MeasuresName,
                                      mangment_sender = n.DepartmentName,
                                      mangment_sender_id = mail.Department_Id,
                                      Send_time = ex.Send_time.ToString("yyyy-MM-dd"),
                                      time = ex.Send_time.ToString("HH:mm:ss"),
                                      flag = ex.flag,
                                      summary = mail.Mail_Summary,
                                      Sends_id = ex.Id



                                  }).OrderByDescending(v => v.mail_id).Skip((pagenum - 1) * size).Take(size).ToListAsync();
                PagenationSendedEmail<Sended_Maill> pagg = new PagenationSendedEmail<Sended_Maill>();
                if (Replay_Date == true)
                {


                    pagg.mail = (from x in pag.mail
                                 join vv in dbcon.Replies
                                 on x.Sends_id equals vv.send_ToId

                                 select new Sended_Maill
                                 {

                                     mail_id = x.mail_id,
                                     State = x.State,
                                     type_of_mail = x.type_of_mail,
                                     Mail_Number = x.Mail_Number,
                                     date = x.date,
                                     Masure_type = x.Masure_type,
                                     mangment_sender = x.mangment_sender,
                                     mangment_sender_id = x.mangment_sender_id,
                                     Send_time = x.Send_time,
                                     time = x.time,
                                     summary = x.summary,
                                     flag = x.flag,
                                     Sends_id = x.Sends_id
                                 }
                              ).ToList();

                    // z.Count();
                }
                else
                {
                    pagg.mail = pag.mail;
                }
                pagg.Total = zx.Count();
                //pagg.Total = pag.Total;
                return pagg;







            }


            catch (Exception)
            {

                throw;
            }
        }

        public async Task<PagenationSendedEmail<Sended_Maill>> GetAllIncoming(DateTime? myday, int? daycheck,
            int? mailnum_bool, int? mangment, DateTime? d1, DateTime? d2, int? mailnum, string summary, int? mail_Readed,
            int? mailReaded, int? mailnot_readed, DateTime? Day_sended1, DateTime? Day_sended2, int? Typeof_send
            , int? mail_type, string replaytext, int? userid, int pagenum, int size, int? Measure_filter,
            int? Department_filter, int? Classfication, 
            int? mail_state, int? TheSection, int? genral_incoming_num)
        {
            try
            {

                // List<Sended_Maill> repli = new List<Sended_Maill>();

                DateTime day = DateTime.Now;

                bool dep_filter = false;
                bool clasf_filter = false;
                bool meas_filter = false;
                bool mail_accept = false;
                bool daysended = false;
                bool State_filter = false;
                bool Sectionbool = false;
                bool repbool = false;
                bool incoing_num_filter = false;


                // myday = day.Date;





                if (TheSection == null)
                {
                    Sectionbool = true;
                }
                else
                {
                    Sectionbool = false;

                }



                if (genral_incoming_num == null)
                {
                    incoing_num_filter = true;

                }
                else
                {
                    incoing_num_filter = false;
                }



                if (mail_state == null)
                {
                    State_filter = true;
                }
                else { State_filter = false; }


                


                if (TheSection == null)
                {
                    Sectionbool = true;
                }
                else
                {
                    Sectionbool = false;
                }



                if (Classfication == null)
                {
                    clasf_filter = true;
                }
                else { clasf_filter = false; }


                if (Measure_filter == null)
                {
                    meas_filter = true;
                }
                else { meas_filter = false; }

                if (Department_filter == null)
                {

                    dep_filter = true;

                }
                else { dep_filter = false; }



                if (summary == null)
                { summary = " "; }

                if (mailnum != null)
                {
                    mailnum_bool = 0;
                }
                else
                {
                    mailnum_bool = 1;
                }

                if (myday != null)
                {

                    daycheck = 0;
                }
                else if (myday == null)
                {

                    daycheck = 1;
                }

                if (d1 == null && d2 == null)
                {
                    d1 = day.Date;
                    d2 = day.Date;

                }

                if (mail_Readed == null)
                {
                    mail_accept = true;
                    mailReaded = -1;
                    mailnot_readed = -1;
                }
                else if (mail_Readed == 2)
                {
                    mail_accept = false;
                    mailReaded = 2;
                    mailnot_readed = 5;
                }
                else if (mail_Readed == 1)
                {
                    mail_accept = false;
                    mailnot_readed = 1;
                    mailReaded = 1;
                }

                if (Day_sended1 == null && Day_sended2 == null)
                {
                    daysended = true;
                }
                else
                {
                    daysended = false;
                }


                if (replaytext == null)
                {
                    replaytext = " ";
                }

                //if (mailNumType == 1 && (user_role_num == 10 || user_role_num == 17))
                //{
                //    mail_type = "داخلي";
                //}

                //if (user_role_num == 10)
                //{
                //    mail_type = "خ";
                //}
                ////else if (user_role_num == 17)
                ////{
                ////    mail_type = "داخلي";
                ////}
                //else if (mailNumType == 3 && (user_role_num == 18 || user_role_num == 10))
                //{
                //    mail_type = "وارد خارجي";
                //}
                //else if (mailNumType == 2 && (user_role_num == 19 || user_role_num == 10))
                //{
                //    mail_type = "صادر خارجي";
                //}

                if (replaytext == null)
                {
                    replaytext = " ";
                }
                var m = await dbcon.Departments.FindAsync(mangment);

                PagenationSendedEmail<Sended_Maill> pag = new PagenationSendedEmail<Sended_Maill>();


                var c = await (from mail in dbcon.Mails.Where(x => (
                                           x.Mail_Summary.Contains(summary) && (x.Date_Of_Mail.Date >= d1 && x.Date_Of_Mail.Date <= d2))
                                           && (mailnum_bool == 1 || x.Mail_Number == mailnum) &&
                                           (x.clasification == Classfication || clasf_filter == true)
                                           &&(x.Genaral_inbox_Number == genral_incoming_num || incoing_num_filter == true) &&
                                           x.state == true).OrderByDescending(x => x.MailID)

                                   //join Extr in dbcon.Extrenal_Inboxes on mail.MailID equals Extr.MailID
                               join ex in dbcon.Sends.Where(x => (x.flag > 1) && x.to == mangment &&
                               ((x.flag >= mailReaded && x.flag <= mailnot_readed) || mail_accept == true) &&
                               (x.flag == mail_state || State_filter == true) && x.State == true)
                               on mail.MailID equals ex.MailID

                               //join d in dbcon.External_Mails.Where(x => x.Sectionid == TheSection || Sectionbool == true) on mail.MailID equals d.MailID
                               //join b in dbcon.Extrenal_Inboxes.Where(x => x.SectionId == TheSection || Sectionbool == true) on mail.MailID equals b.MailID
                               join dx in dbcon.measures.Where(x => (x.MeasuresId == Measure_filter || meas_filter == true)) on ex.type_of_send equals dx.MeasuresId
                               join n in dbcon.Departments.Where(x => (x.Id == Department_filter || dep_filter == true)) on mail.Department_Id equals n.Id
                               join z in dbcon.MailStatuses.Where(x => x.state == true) on ex.flag equals z.flag
                               // join rep in dbcon.Replies.Where(x=> x.state == true|| repbool == true) on ex.Id equals rep.send_ToId
                               //  join rep in dbcon.Replies on ex.Id equals rep.ReplyId

                               // join cx in dbcon.Replies.Where(x=> x.ReplyId)
                               select new Sended_Maill()
                               {
                                   mail_id = mail.MailID,
                                   State = z.inbox,
                                   type_of_mail = mail.Mail_Type,
                                   Mail_Number = mail.Mail_Number,
                                   date = mail.Date_Of_Mail.ToString("yyyy-MM-dd"),
                                   Masure_type = dx.MeasuresName,
                                   mangment_sender = n.DepartmentName,
                                   mangment_sender_id = mail.Department_Id,
                                   Send_time = ex.Send_time.ToString("yyyy-MM-dd"),
                                   time = ex.Send_time.ToString("HH:mm:ss"),
                                   summary = mail.Mail_Summary,
                                   flag = ex.flag,
                                   Sends_id = ex.Id,
                                   action_require=mail.ActionRequired


                               }).OrderByDescending(v => v.mail_id).ToListAsync();


                ////////////////

                ///////////////


                pag.mail = await (from mail in dbcon.Mails.Where(x => (
                              x.Mail_Summary.Contains(summary) && (x.Date_Of_Mail.Date >= d1 && x.Date_Of_Mail.Date <= d2))
                                           && (mailnum_bool == 1 || x.Mail_Number == mailnum) &&
                                           (x.clasification == Classfication || clasf_filter == true)
                                           && (x.Genaral_inbox_Number == genral_incoming_num || incoing_num_filter == true) &&
                                           x.state == true).OrderByDescending(x => x.MailID)

                                      //join Extr in dbcon.Extrenal_Inboxes on mail.MailID equals Extr.MailID
                                  join ex in dbcon.Sends.Where(x => (x.flag > 1) && x.to == mangment &&
                                  ((x.flag >= mailReaded && x.flag <= mailnot_readed) || mail_accept == true) &&
                                  (x.flag == mail_state || State_filter == true) && x.State == true)
                                  on mail.MailID equals ex.MailID

                                  join dx in dbcon.measures.Where(x => (x.MeasuresId == Measure_filter || meas_filter == true)) on ex.type_of_send equals dx.MeasuresId
                                  join n in dbcon.Departments.Where(x => (x.Id == Department_filter || dep_filter == true)) on mail.Department_Id equals n.Id
                                  join z in dbcon.MailStatuses.Where(x => x.state == true) on ex.flag equals z.flag
                                  //join rep in dbcon.Replies.Where(x => x.state == true || repbool == true) on ex.Id equals rep.send_ToId

                                  //  join rep in dbcon.Replies on ex.Id equals rep.ReplyId

                                  // join cx in dbcon.Replies.Where(x=> x.ReplyId)
                                  select new Sended_Maill()
                                  {
                                      mail_id = mail.MailID,
                                      State = z.inbox,
                                      type_of_mail = mail.Mail_Type,
                                      Mail_Number = mail.Mail_Number,
                                      date = mail.Date_Of_Mail.ToString("yyyy-MM-dd"),
                                      Masure_type = dx.MeasuresName,
                                      mangment_sender = n.DepartmentName,
                                      mangment_sender_id = mail.Department_Id,
                                      Send_time = ex.Send_time.ToString("yyyy-MM-dd"),
                                      time = ex.Send_time.ToString("HH:mm:ss"),
                                      flag = ex.flag,
                                      summary = mail.Mail_Summary,
                                      Sends_id = ex.Id,
                                      action_require = mail.ActionRequired





                                  }).OrderByDescending(v => v.mail_id).Skip((pagenum - 1) * size).Take(size).ToListAsync();
                pag.Total = c.Count;

                return pag;
            }

            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> GetMailState(int mailid)
        {

            var Time_of_read = await dbcon.Sends.OrderBy(x => x.Id).LastOrDefaultAsync(x => x.MailID == mailid);
            var flag = Time_of_read.flag;

            return flag;

        }

        public async Task<dynamic> GetDynamic(DateTime? myday, int? daycheck, int? mailnum_bool,
            int? mangment, DateTime? d1, DateTime? d2, int? mailnum, string summary,
            int? mail_Readed, int? mailReaded, int? mailnot_readed, DateTime? Day_sended1,
            DateTime? Day_sended2, int? Typeof_send, int? userid, int? mailNumType,
            int? mail_type, string? replaytext, int pagenum, int size, int? Measure_filter,
            int? Department_filter, int? Classfication, int? mail_state, int? genral_incoming_num,
            int? TheSection)
        {
            var role_id = await dbcon.userRoles.Where(x => x.UserId == userid).ToListAsync();

            //   var user_role_num = role_id.RoleId;

            switch (mailNumType)
            {

                case 0:
                    if (role_id.Any(x => x.RoleId == 10))
                    {

                        var c0 = await GetAllIncoming(myday, daycheck, mailnum_bool,
            mangment, d1, d2, mailnum, summary, mail_Readed,
            mailReaded, mailnot_readed, Day_sended1, Day_sended2,
           Typeof_send, mail_type, replaytext, userid, pagenum, size, Measure_filter,
           Department_filter, Classfication, mail_state, genral_incoming_num, TheSection);
                        d = c0;
                        break;
                    }
                    else if (role_id.Any(x => x.RoleId == 17))
                    {
                        mail_type = 1;
                        var a = await GetIncomingRecevidMail(myday, daycheck, mailnum_bool,
            mangment, d1, d2, mailnum, summary, mail_Readed,
            mailReaded, mailnot_readed, Day_sended1, Day_sended2,
           Typeof_send, mail_type, replaytext, userid, pagenum, size,
           Measure_filter, Department_filter, mail_state, genral_incoming_num, Classfication);
                        d = a;
                        break;
                    }
                    else if (role_id.Any(x => x.RoleId == 19))
                    {
                        mail_type = 2;

                        var a2 = await GetIncomingExtarnelMail(myday, daycheck, mailnum_bool,
            mangment, d1, d2, mailnum, summary, mail_Readed,
            mailReaded, mailnot_readed, Day_sended1, Day_sended2,
           Typeof_send, mail_type, replaytext, userid, pagenum, size,
           Measure_filter, Department_filter, genral_incoming_num, Classfication, mail_state, TheSection);
                        d = a2;
                        break;
                    }
                    else if (role_id.Any(x => x.RoleId == 18))
                    {

                        mail_type = 3;
                        var a3 = await GetIncomingExtarnelinbox(myday, daycheck, mailnum_bool,
            mangment, d1, d2, mailnum, summary, mail_Readed,
            mailReaded, mailnot_readed, Day_sended1, Day_sended2,
           Typeof_send, mail_type, replaytext, userid, pagenum, size,
           Measure_filter, Department_filter, genral_incoming_num, Classfication, mail_state, TheSection);
                        d = a3;


                        break;
                    }
                    d = null;
                    break;




                case 1:
                    if (role_id.Any(x => x.RoleId == 10 || x.RoleId == 17))
                    {
                        mail_type = 1;
                        var c = await GetIncomingRecevidMail(myday, daycheck, mailnum_bool,
            mangment, d1, d2, mailnum, summary, mail_Readed,
            mailReaded, mailnot_readed, Day_sended1, Day_sended2,
           Typeof_send, mail_type, replaytext, userid, pagenum, size,
           Measure_filter, Department_filter, genral_incoming_num, Classfication, mail_state);
                        d = c;
                        break;
                    }
                    d = null;
                    break;
                case 2:
                    if (role_id.Any(x => x.RoleId == 10 || x.RoleId == 19))
                    {
                        mail_type = 2;

                        var cc = await GetIncomingExtarnelMail(myday, daycheck, mailnum_bool,
            mangment, d1, d2, mailnum, summary, mail_Readed,
            mailReaded, mailnot_readed, Day_sended1, Day_sended2,
           Typeof_send, mail_type, replaytext, userid, pagenum, size,
           Measure_filter, Department_filter, genral_incoming_num, Classfication, mail_state, TheSection);
                        d = cc;
                        break;
                    }
                    d = null;
                    break;

                case 3:
                    if (role_id.Any(x => x.RoleId == 10 || x.RoleId == 18))
                    {
                        mail_type = 3;
                        var ccc = await GetIncomingExtarnelinbox(myday, daycheck, mailnum_bool,
            mangment, d1, d2, mailnum, summary, mail_Readed,
            mailReaded, mailnot_readed, Day_sended1, Day_sended2,
           Typeof_send, mail_type, replaytext, userid, pagenum, size,
           Measure_filter, Department_filter, genral_incoming_num, Classfication, mail_state, TheSection);
                        d = ccc;


                        break;
                    }
                    d = null;
                    break;
                default:
                    break;
            }

            return d;
        }

        public async Task<PagenationSendedEmail<ExtarnelinboxViewModel>> GetExtarnelinbox(DateTime? myday, int? daycheck, int? mailnum_bool,
           int? mangment, DateTime? d1, DateTime? d2, int? mailnum, string? summary, int? mail_Readed,
           int? mailReaded, int? mailnot_readed, DateTime? Day_sended1, DateTime? Day_sended2, int?
           Typeof_send, int? mail_type, string? replaytext, int? userid, int pagenum, int size, int? Measure_filter,
           int? Department_filter, int? Classfication, int? mail_state, int? genral_incoming_num, int? TheSection, bool? Replay_Date)
        {
            try
            {



                DateTime day = DateTime.Now;

                bool dep_filter = false;
                bool clasf_filter = false;
                bool meas_filter = false;
                bool mail_accept = false;
                bool incoing_num_filter = false;
                bool daysended = false;
                bool State_filter = false;
                bool Sectionbool = false;
                // myday = day.Date;



                if (genral_incoming_num == null)
                {
                    incoing_num_filter = true;
                }
                else { incoing_num_filter = false; }



                if (TheSection == null)
                {
                    Sectionbool = true;
                }
                else
                {
                    Sectionbool = false;
                }




                if (mail_state == null)
                {
                    State_filter = true;
                }
                else { State_filter = false; }



                if (Classfication == null)
                {
                    clasf_filter = true;
                }
                else { clasf_filter = false; }


                if (Measure_filter == null)
                {
                    meas_filter = true;
                }
                else { meas_filter = false; }

                if (Department_filter == null)
                {

                    dep_filter = true;

                }
                else { dep_filter = false; }



                if (summary == null)
                { summary = " "; }

                if (mailnum != null)
                {
                    mailnum_bool = 0;
                }
                else
                {
                    mailnum_bool = 1;
                }

                if (myday != null)
                {

                    daycheck = 0;
                }
                else if (myday == null)
                {

                    daycheck = 1;
                }

                if (d1 == null && d2 == null)
                {
                    d1 = day.Date;
                    d2 = day.Date;

                }

                if (mail_Readed == null)
                {
                    mail_accept = true;
                    mailReaded = -1;
                    mailnot_readed = -1;
                }
                else if (mail_Readed == 2)
                {
                    mail_accept = false;
                    mailReaded = 2;
                    mailnot_readed = 5;
                }
                else if (mail_Readed == 1)
                {
                    mail_accept = false;
                    mailnot_readed = 1;
                    mailReaded = 1;
                }

                if (Day_sended1 == null && Day_sended2 == null)
                {
                    daysended = true;
                }
                else
                {
                    daysended = false;
                }


                if (replaytext == null)
                {
                    replaytext = " ";
                }

                //if (mailNumType == 1 && (user_role_num == 10 || user_role_num == 17))
                //{
                //    mail_type = "داخلي";
                //}

                //if (user_role_num == 10)
                //{
                //    mail_type = "خ";
                //}
                ////else if (user_role_num == 17)
                ////{
                ////    mail_type = "داخلي";
                ////}
                //else if (mailNumType == 3 && (user_role_num == 18 || user_role_num == 10))
                //{
                //    mail_type = "وارد خارجي";
                //}
                //else if (mailNumType == 2 && (user_role_num == 19 || user_role_num == 10))
                //{
                //    mail_type = "صادر خارجي";
                //}

                if (replaytext == null)
                {
                    replaytext = " ";
                }
                var m = await dbcon.Departments.FindAsync(mangment);

                PagenationSendedEmail<ExtarnelinboxViewModel> pag = new PagenationSendedEmail<ExtarnelinboxViewModel>();


                var c = await (from mail in dbcon.Mails.Where(x => (x.Department_Id == mangment &&
             x.Mail_Summary.Contains(summary) && (x.Date_Of_Mail.Date >= d1 && x.Date_Of_Mail.Date <= d2))
             && (mailnum_bool == 1 || x.Mail_Number == mailnum) && x.Mail_Type == mail_type &&
             (x.clasification == Classfication || clasf_filter == true)
             && (x.Genaral_inbox_Number == genral_incoming_num || incoing_num_filter == true) && x.state == true).OrderByDescending(x => x.MailID)

                               join ex in dbcon.Sends.Where(x => (x.flag > 0) &&
                               ((x.flag >= mailReaded && x.flag <= mailnot_readed) || mail_accept == true) &&
                               (x.flag == mail_state || State_filter == true) && (dep_filter == false && x.isMulti == false || dep_filter == false && x.isMulti == true || x.isMulti == true))
                               on mail.MailID equals ex.MailID
                               join b in dbcon.Extrenal_Inboxes.Where(x => x.SectionId == TheSection || Sectionbool == true) on mail.MailID equals b.MailID
                               join dx in dbcon.measures.Where(x => (x.MeasuresId == Measure_filter || meas_filter == true)) on ex.type_of_send equals dx.MeasuresId
                               join n in dbcon.Departments.Where(x => (x.Id == Department_filter || dep_filter == true)) on ex.to equals n.Id
                               join z in dbcon.MailStatuses.Where(x => x.state == true) on ex.flag equals z.flag


                               //  join rep in dbcon.Replies on ex.Id equals rep.ReplyId

                               // join cx in dbcon.Replies.Where(x=> x.ReplyId)
                               select new ExtarnelinboxViewModel()
                               {
                                   mail_id = mail.MailID,
                                   State = z.sent,
                                   type_of_mail = mail.Mail_Type,
                                   Mail_Number = mail.Mail_Number,
                                   date = mail.Date_Of_Mail.ToString("yyyy-MM-dd"),
                                   Masure_type = dx.MeasuresName,
                                   mangment_sender = n.DepartmentName,
                                   mangment_sender_id = mail.Department_Id,
                                   Send_time = ex.Send_time.ToString("yyyy-MM-dd"),
                                   time = ex.Send_time.ToString("HH:mm:ss"),
                                   summary = mail.Mail_Summary,
                                   flag = ex.flag,
                                   Sends_id = ex.Id,


                               }).OrderByDescending(v => v.mail_id).ToListAsync();


                IEnumerable<ExtarnelinboxViewModel> zx;
                if (Replay_Date == true)
                {//d
                    var lx = Replay_Date;


                    zx = (from x in c
                          join vv in dbcon.Replies
                          on x.Sends_id equals vv.send_ToId

                          select new ExtarnelinboxViewModel
                          {

                              mail_id = x.mail_id,
                              State = x.State,
                              type_of_mail = x.type_of_mail,
                              Mail_Number = x.Mail_Number,
                              date = x.date,
                              Masure_type = x.Masure_type,
                              mangment_sender = x.mangment_sender,
                              mangment_sender_id = x.mangment_sender_id,
                              Send_time = x.Send_time,
                              time = x.time,
                              summary = x.summary,
                              flag = x.flag,
                              Sends_id = x.Sends_id
                          }
                              ).ToList();


                }
                else
                {
                    zx = c;
                }



                pag.mail = await (from mail in dbcon.Mails.Where(x => (x.Department_Id == mangment &&
              x.Mail_Summary.Contains(summary) && (x.Date_Of_Mail.Date >= d1 && x.Date_Of_Mail.Date <= d2))
              && (mailnum_bool == 1 || x.Mail_Number == mailnum) && x.Mail_Type == mail_type &&
              (x.clasification == Classfication || clasf_filter == true)
              && (x.Genaral_inbox_Number == genral_incoming_num || incoing_num_filter == true) && x.state == true).OrderByDescending(x => x.MailID)

                                  join ex in dbcon.Sends.Where(x => (x.flag > 0) &&
                                  ((x.flag >= mailReaded && x.flag <= mailnot_readed) || mail_accept == true) &&
                                  (x.flag == mail_state || State_filter == true) && (dep_filter == false && x.isMulti == false || dep_filter == false && x.isMulti == true || x.isMulti == true))
                                  on mail.MailID equals ex.MailID
                                  join b in dbcon.Extrenal_Inboxes.Where(x => x.SectionId == TheSection || Sectionbool == true) on mail.MailID equals b.MailID
                                  join dx in dbcon.measures.Where(x => (x.MeasuresId == Measure_filter || meas_filter == true)) on ex.type_of_send equals dx.MeasuresId
                                  join n in dbcon.Departments.Where(x => (x.Id == Department_filter || dep_filter == true)) on ex.to equals n.Id
                                  join z in dbcon.MailStatuses.Where(x => x.state == true) on ex.flag equals z.flag


                                  //  join rep in dbcon.Replies on ex.Id equals rep.ReplyId

                                  // join cx in dbcon.Replies.Where(x=> x.ReplyId)
                                  select new ExtarnelinboxViewModel()
                                  {
                                      mail_id = mail.MailID,
                                      State = z.sent,
                                      type_of_mail = mail.Mail_Type,
                                      Mail_Number = mail.Mail_Number,
                                      date = mail.Date_Of_Mail.ToString("yyyy-MM-dd"),
                                      Masure_type = dx.MeasuresName,
                                      mangment_sender = n.DepartmentName,
                                      mangment_sender_id = mail.Department_Id,
                                      Send_time = ex.Send_time.ToString("yyyy-MM-dd"),
                                      time = ex.Send_time.ToString("HH:mm:ss"),
                                      flag = ex.flag,
                                      summary = mail.Mail_Summary,
                                      Sends_id = ex.Id,




                                  }).OrderByDescending(v => v.mail_id).Skip((pagenum - 1) * size).Take(size).ToListAsync();


                PagenationSendedEmail<ExtarnelinboxViewModel> pagg = new PagenationSendedEmail<ExtarnelinboxViewModel>();
                if (Replay_Date == true)
                {


                    pagg.mail = (from x in pag.mail
                                 join vv in dbcon.Replies
                                 on x.Sends_id equals vv.send_ToId

                                 select new ExtarnelinboxViewModel
                                 {

                                     mail_id = x.mail_id,
                                     State = x.State,
                                     type_of_mail = x.type_of_mail,
                                     Mail_Number = x.Mail_Number,
                                     date = x.date,
                                     Masure_type = x.Masure_type,
                                     mangment_sender = x.mangment_sender,
                                     mangment_sender_id = x.mangment_sender_id,
                                     Send_time = x.Send_time,
                                     time = x.time,
                                     summary = x.summary,
                                     flag = x.flag,
                                     Sends_id = x.Sends_id
                                 }
                              ).ToList();

                    // z.Count();
                }
                else
                {
                    pagg.mail = pag.mail;
                }
                pagg.Total = zx.Count();
                //pagg.Total = pag.Total;
                return pagg;







            }


            catch (Exception)
            {

                throw;
            }

        }

        public async Task<int> GetState(int mail_id)
        {
            try
            {
                var c = await dbcon.Sends.LastOrDefaultAsync(x => x.MailID == mail_id);
                return c.flag;
            }
            catch (Exception)
            {

                throw;
            }


        }

        public async Task<PagenationSendedEmail<ExtarnelinboxViewModel>> GetExtarnelMail(DateTime? myday, int? daycheck, int? mailnum_bool,
           int? mangment, DateTime? d1, DateTime? d2, int? mailnum, string? summary, int? mail_Readed,
           int? mailReaded, int? mailnot_readed, DateTime? Day_sended1, DateTime? Day_sended2, int?
           Typeof_send, int? mail_type, string? replaytext, int? userid, int pagenum, int size, int? Measure_filter,
           int? Department_filter, int? Classfication, int? mail_state, int? genral_incoming_num, int? TheSection, bool? Replay_Date)
        {
            try
            {



                DateTime day = DateTime.Now;

                bool dep_filter = false;
                bool clasf_filter = false;
                bool meas_filter = false;
                bool mail_accept = false;
                bool incoing_num_filter = true;
                bool daysended = false;
                bool State_filter = false;
                bool Sectionbool = false;
                // myday = day.Date;


                if (genral_incoming_num == null)
                {
                    incoing_num_filter = true;

                }
                else
                {
                    incoing_num_filter = false;
                }


                if (TheSection == null)
                {
                    Sectionbool = true;
                }
                else
                {
                    Sectionbool = false;
                }


                if (mail_state == null)
                {
                    State_filter = true;
                }
                else { State_filter = false; }



                if (Classfication == null)
                {
                    clasf_filter = true;
                }
                else { clasf_filter = false; }


                if (Measure_filter == null)
                {
                    meas_filter = true;
                }
                else { meas_filter = false; }

                if (Department_filter == null)
                {

                    dep_filter = true;

                }
                else { dep_filter = false; }



                if (summary == null)
                { summary = " "; }

                if (mailnum != null)
                {
                    mailnum_bool = 0;
                }
                else
                {
                    mailnum_bool = 1;
                }

                if (myday != null)
                {

                    daycheck = 0;
                }
                else if (myday == null)
                {

                    daycheck = 1;
                }

                if (d1 == null && d2 == null)
                {
                    d1 = day.Date;
                    d2 = day.Date;

                }

                if (mail_Readed == null)
                {
                    mail_accept = true;
                    mailReaded = -1;
                    mailnot_readed = -1;
                }
                else if (mail_Readed == 2)
                {
                    mail_accept = false;
                    mailReaded = 2;
                    mailnot_readed = 5;
                }
                else if (mail_Readed == 1)
                {
                    mail_accept = false;
                    mailnot_readed = 1;
                    mailReaded = 1;
                }

                if (Day_sended1 == null && Day_sended2 == null)
                {
                    daysended = true;
                }
                else
                {
                    daysended = false;
                }


                if (replaytext == null)
                {
                    replaytext = " ";
                }

                //if (mailNumType == 1 && (user_role_num == 10 || user_role_num == 17))
                //{
                //    mail_type = "داخلي";
                //}

                //if (user_role_num == 10)
                //{
                //    mail_type = "خ";
                //}
                ////else if (user_role_num == 17)
                ////{
                ////    mail_type = "داخلي";
                ////}
                //else if (mailNumType == 3 && (user_role_num == 18 || user_role_num == 10))
                //{
                //    mail_type = "وارد خارجي";
                //}
                //else if (mailNumType == 2 && (user_role_num == 19 || user_role_num == 10))
                //{
                //    mail_type = "صادر خارجي";
                //}

                if (replaytext == null)
                {
                    replaytext = " ";
                }
                var m = await dbcon.Departments.FindAsync(mangment);

                PagenationSendedEmail<ExtarnelinboxViewModel> pag = new PagenationSendedEmail<ExtarnelinboxViewModel>();


                var c = await (from mail in dbcon.Mails.Where(x => (x.Department_Id == mangment &&
                                           x.Mail_Summary.Contains(summary) && (x.Date_Of_Mail.Date >= d1 && x.Date_Of_Mail.Date <= d2))
                                           && (mailnum_bool == 1 || x.Mail_Number == mailnum) && x.Mail_Type == mail_type &&
                                           (x.clasification == Classfication || clasf_filter == true)
                                           && (x.Genaral_inbox_Number == genral_incoming_num || incoing_num_filter == true) &&
                                           x.state==true).OrderByDescending(x => x.MailID)

                               join Extr in dbcon.External_Mails on mail.MailID equals Extr.MailID
                               join ex in dbcon.Sends.Where(x => (x.flag > 0) &&
                               ((x.flag >= mailReaded && x.flag <= mailnot_readed) || mail_accept == true) &&
                               (x.flag == mail_state || State_filter == true) && (dep_filter == false && x.isMulti == false || dep_filter == false && x.isMulti == true || x.isMulti == true))
                               on mail.MailID equals ex.MailID
                               join d in dbcon.External_Mails.Where(x => x.Sectionid == TheSection || Sectionbool == true) on mail.MailID equals d.MailID
                               join dx in dbcon.measures.Where(x => (x.MeasuresId == Measure_filter || meas_filter == true)) on ex.type_of_send equals dx.MeasuresId
                               join n in dbcon.Departments.Where(x => (x.Id == Department_filter || dep_filter == true)) on ex.to equals n.Id
                               join z in dbcon.MailStatuses.Where(x => x.state == true) on ex.flag equals z.flag


                               //  join rep in dbcon.Replies on ex.Id equals rep.ReplyId

                               // join cx in dbcon.Replies.Where(x=> x.ReplyId)
                               select new ExtarnelinboxViewModel()
                               {
                                   mail_id = mail.MailID,
                                   State = z.sent,
                                   type_of_mail = mail.Mail_Type,
                                   Mail_Number = mail.Mail_Number,
                                   date = mail.Date_Of_Mail.ToString("yyyy-MM-dd"),
                                   Masure_type = dx.MeasuresName,
                                   mangment_sender = n.DepartmentName,
                                   mangment_sender_id = mail.Department_Id,
                                   Send_time = ex.Send_time.ToString("yyyy-MM-dd"),
                                   time = ex.Send_time.ToString("HH:mm:ss"),
                                   summary = mail.Mail_Summary,
                                   flag = ex.flag,
                                   Sends_id = ex.Id,
                                   sectionName = Extr.sectionName


                               }).OrderByDescending(v => v.mail_id).ToListAsync();

                IEnumerable<ExtarnelinboxViewModel> zx;
                if (Replay_Date == true)
                {


                    zx = (from x in c
                          join vv in dbcon.Replies
                          on x.Sends_id equals vv.send_ToId

                          select new ExtarnelinboxViewModel
                          {

                              mail_id = x.mail_id,
                              State = x.State,
                              type_of_mail = x.type_of_mail,
                              Mail_Number = x.Mail_Number,
                              date = x.date,
                              Masure_type = x.Masure_type,
                              mangment_sender = x.mangment_sender,
                              mangment_sender_id = x.mangment_sender_id,
                              Send_time = x.Send_time,
                              time = x.time,
                              summary = x.summary,
                              flag = x.flag,
                              Sends_id = x.Sends_id
                          }
                              ).ToList();


                }
                else
                {
                    zx = c;
                }




                pag.mail = await (from mail in dbcon.Mails.Where(x => (x.Department_Id == mangment &&
              x.Mail_Summary.Contains(summary) && (x.Date_Of_Mail.Date >= d1 && x.Date_Of_Mail.Date <= d2))
              && (mailnum_bool == 1 || x.Mail_Number == mailnum) && x.Mail_Type == mail_type &&
              (x.clasification == Classfication || clasf_filter == true)
               &&  (x.Genaral_inbox_Number == genral_incoming_num || incoing_num_filter == true) && x.state == true).OrderByDescending(x => x.MailID)

                                  join Extr in dbcon.External_Mails on mail.MailID equals Extr.MailID
                                  join ex in dbcon.Sends.Where(x => (x.flag > 0) &&
                                  ((x.flag >= mailReaded && x.flag <= mailnot_readed) || mail_accept == true) &&
                                  (x.flag == mail_state || State_filter == true) && (dep_filter == false && x.isMulti == false || dep_filter == false && x.isMulti == true || x.isMulti == true))
                                  on mail.MailID equals ex.MailID
                                  join d in dbcon.External_Mails.Where(x => x.Sectionid == TheSection || Sectionbool == true) on mail.MailID equals d.MailID
                                  join dx in dbcon.measures.Where(x => (x.MeasuresId == Measure_filter || meas_filter == true)) on ex.type_of_send equals dx.MeasuresId
                                  join n in dbcon.Departments.Where(x => (x.Id == Department_filter || dep_filter == true)) on ex.to equals n.Id
                                  join z in dbcon.MailStatuses.Where(x => x.state == true) on ex.flag equals z.flag


                                  //  join rep in dbcon.Replies on ex.Id equals rep.ReplyId

                                  // join cx in dbcon.Replies.Where(x=> x.ReplyId)
                                  select new ExtarnelinboxViewModel()
                                  {
                                      mail_id = mail.MailID,
                                      State = z.sent,
                                      type_of_mail = mail.Mail_Type,
                                      Mail_Number = mail.Mail_Number,
                                      date = mail.Date_Of_Mail.ToString("yyyy-MM-dd"),
                                      Masure_type = dx.MeasuresName,
                                      mangment_sender = n.DepartmentName,
                                      mangment_sender_id = mail.Department_Id,
                                      Send_time = ex.Send_time.ToString("yyyy-MM-dd"),
                                      time = ex.Send_time.ToString("HH:mm:ss"),
                                      flag = ex.flag,
                                      summary = mail.Mail_Summary,
                                      Sends_id = ex.Id,
                                      sectionName = Extr.sectionName




                                  }).OrderByDescending(v => v.mail_id).Skip((pagenum - 1) * size).Take(size).ToListAsync();


                PagenationSendedEmail<ExtarnelinboxViewModel> pagg = new PagenationSendedEmail<ExtarnelinboxViewModel>();
                if (Replay_Date == true)
                {


                    pagg.mail = (from x in pag.mail
                                 join vv in dbcon.Replies
                                 on x.Sends_id equals vv.send_ToId

                                 select new ExtarnelinboxViewModel
                                 {

                                     mail_id = x.mail_id,
                                     State = x.State,
                                     type_of_mail = x.type_of_mail,
                                     Mail_Number = x.Mail_Number,
                                     date = x.date,
                                     Masure_type = x.Masure_type,
                                     mangment_sender = x.mangment_sender,
                                     mangment_sender_id = x.mangment_sender_id,
                                     Send_time = x.Send_time,
                                     time = x.time,
                                     summary = x.summary,
                                     flag = x.flag,
                                     Sends_id = x.Sends_id
                                 }
                              ).ToList();

                    // z.Count();
                }
                else
                {
                    pagg.mail = pag.mail;
                }
                pagg.Total = zx.Count();
                //pagg.Total = pag.Total;
                return pagg;







            }


            catch (Exception)
            {

                throw;
            }

        }

        public async Task<PagenationSendedEmail<ExtarnelinboxViewModel>> Getextrmail(int depid, int size, int pagenum)
        {
            PagenationSendedEmail<ExtarnelinboxViewModel> pag = new PagenationSendedEmail<ExtarnelinboxViewModel>();

            try
            {
                var m = await dbcon.Departments.FindAsync(depid);




                var c2 = await (from mail in dbcon.Mails.Where(x => x.Department_Id == depid && x.Mail_Type == 2)
                                join y in dbcon.Sends.Where(n => n.flag != 0) on mail.MailID equals y.MailID
                                join Extr in dbcon.External_Mails on mail.MailID equals Extr.MailID
                                join z in dbcon.MailStatuses.Where(x => x.state == true) on y.flag equals z.flag

                                select new ExtarnelinboxViewModel()
                                {
                                    mail_id = mail.MailID,
                                    State = z.sent,
                                    type_of_mail = mail.Mail_Type,
                                    Mail_Number = mail.Mail_Number,
                                    date = mail.Date_Of_Mail.ToString("yyyy-MM-dd"),
                                    //procedure_type = mail.clasification,
                                    mangment_sender = m.DepartmentName,
                                    Send_time = y.Send_time.ToString("yyyy-MM-dd"),
                                    time = y.Send_time.ToString("HH:mm:ss"),
                                    summary = mail.Mail_Summary,
                                    Sends_id = y.Id,
                                    sectionName = Extr.sectionName



                                }).OrderByDescending(v => v.mail_id).ToListAsync();
                pag.Total = c2.Count;
                pag.mail = c2.OrderByDescending(v => v.mail_id).Skip((pagenum - 1) * size).Take(size).ToList();

                return pag;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<PagenationSendedEmail<ExtarnelinboxViewModel>> Getextrmailincoming(int depid, int size, int pagenum)
        {
            PagenationSendedEmail<ExtarnelinboxViewModel> pag = new PagenationSendedEmail<ExtarnelinboxViewModel>();

            try
            {
                var m = await dbcon.Departments.FindAsync(depid);




                var c2 = await (from mail in dbcon.Mails.Where(x => x.Department_Id == depid && x.Mail_Type == 2)
                                join y in dbcon.Sends.Where(n => n.flag != 0) on mail.MailID equals y.MailID
                                join Extr in dbcon.External_Mails on mail.MailID equals Extr.MailID
                                join z in dbcon.MailStatuses.Where(x => x.state == true) on y.flag equals z.flag

                                select new ExtarnelinboxViewModel()
                                {
                                    mail_id = mail.MailID,
                                    State = z.inbox,
                                    type_of_mail = mail.Mail_Type,
                                    Mail_Number = mail.Mail_Number,
                                    date = mail.Date_Of_Mail.ToString("yyyy-MM-dd"),
                                    //procedure_type = mail.clasification,
                                    mangment_sender = m.DepartmentName,
                                    Send_time = y.Send_time.ToString("yyyy-MM-dd"),
                                    time = y.Send_time.ToString("HH:mm:ss"),
                                    summary = mail.Mail_Summary,
                                    Sends_id = y.Id,
                                    sectionName = Extr.sectionName



                                }).OrderByDescending(v => v.mail_id).ToListAsync();
                pag.Total = c2.Count;
                pag.mail = c2.OrderByDescending(v => v.mail_id).Skip((pagenum - 1) * size).Take(size).ToList();

                return pag;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<PagenationSendedEmail<ExtarnelinboxViewModel>> Getinboxmail(int depid, int size, int pagenum)
        {
            PagenationSendedEmail<ExtarnelinboxViewModel> pag = new PagenationSendedEmail<ExtarnelinboxViewModel>();

            try
            {
                var m = await dbcon.Departments.FindAsync(depid);





                var c2 = await (from mail in dbcon.Mails.Where(x => x.Department_Id == depid && x.Mail_Type == 3)
                                join y in dbcon.Sends on mail.MailID equals y.MailID
                                join Extr in dbcon.Extrenal_Inboxes on mail.MailID equals Extr.MailID
                                join z in dbcon.MailStatuses.Where(x => x.state == true) on y.flag equals z.flag

                                select new ExtarnelinboxViewModel()
                                {
                                    mail_id = mail.MailID,
                                    State = z.sent,
                                    type_of_mail = mail.Mail_Type,
                                    Mail_Number = mail.Mail_Number,
                                    date = mail.Date_Of_Mail.ToString("yyyy-MM-dd"),
                                    //procedure_type = mail.clasification,
                                    mangment_sender = m.DepartmentName,
                                    Send_time = y.Send_time.ToString("yyyy-MM-dd"),
                                    time = y.Send_time.ToString("HH:mm:ss"),
                                    summary = mail.Mail_Summary,
                                    Sends_id = y.Id,
                                    sectionName = Extr.section_Name



                                }).OrderByDescending(v => v.mail_id).ToListAsync();
                pag.Total = c2.Count;
                pag.mail = c2.OrderByDescending(v => v.mail_id).Skip((pagenum - 1) * size).Take(size).ToList();

                return pag;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<PagenationSendedEmail<ExtarnelinboxViewModel>> Getinboxmailincoming(int depid, int size, int pagenum)
        {
            PagenationSendedEmail<ExtarnelinboxViewModel> pag = new PagenationSendedEmail<ExtarnelinboxViewModel>();

            try
            {
                var m = await dbcon.Departments.FindAsync(depid);





                var c2 = await (from mail in dbcon.Mails.Where(x => x.Department_Id == depid && x.Mail_Type == 3)
                                join y in dbcon.Sends on mail.MailID equals y.MailID
                                join Extr in dbcon.Extrenal_Inboxes on mail.MailID equals Extr.MailID
                                join z in dbcon.MailStatuses.Where(x => x.state == true) on y.flag equals z.flag

                                select new ExtarnelinboxViewModel()
                                {
                                    mail_id = mail.MailID,
                                    State = z.inbox,
                                    type_of_mail = mail.Mail_Type,
                                    Mail_Number = mail.Mail_Number,
                                    date = mail.Date_Of_Mail.ToString("yyyy-MM-dd"),
                                    //procedure_type = mail.clasification,
                                    mangment_sender = m.DepartmentName,
                                    Send_time = y.Send_time.ToString("yyyy-MM-dd"),
                                    time = y.Send_time.ToString("HH:mm:ss"),
                                    summary = mail.Mail_Summary,
                                    Sends_id = y.Id,
                                    sectionName = Extr.section_Name



                                }).OrderByDescending(v => v.mail_id).ToListAsync();
                pag.Total = c2.Count;
                pag.mail = c2.OrderByDescending(v => v.mail_id).Skip((pagenum - 1) * size).Take(size).ToList();

                return pag;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<PagenationSendedEmail<ExtarnelinboxViewModel>> GetIncomingExtarnelinbox(DateTime? myday, int? daycheck, int? mailnum_bool,
           int? mangment, DateTime? d1, DateTime? d2, int? mailnum, string? summary, int? mail_Readed,
           int? mailReaded, int? mailnot_readed, DateTime? Day_sended1, DateTime? Day_sended2, int?
           Typeof_send, int? mail_type, string? replaytext, int? userid, int pagenum, int size,
           int? Measure_filter, int? Department_filter, int? genral_incoming_num, int? Classfication, int? mail_state, int? TheSection)
        {
            try
            {



                DateTime day = DateTime.Now;

                bool dep_filter = false;
                bool clasf_filter = false;
                bool meas_filter = false;
                bool mail_accept = false;
                bool daysended = false;
                bool State_filter = false;
                bool Sectionbool = false;
                bool incoing_num_filter = false;

                // myday = day.Date;


                if (genral_incoming_num == null)
                {
                    incoing_num_filter = true;

                }
                else
                {
                    incoing_num_filter = false;
                }







                if (mail_state == null)
                {
                    State_filter = true;
                }
                else { State_filter = false; }


                if (TheSection == null)
                {
                    Sectionbool = true;
                }
                else
                {
                    Sectionbool = true;
                }





                if (Classfication == null)
                {
                    clasf_filter = true;
                }
                else { clasf_filter = false; }


                if (Measure_filter == null)
                {
                    meas_filter = true;
                }
                else { meas_filter = false; }

                if (Department_filter == null)
                {

                    dep_filter = true;

                }
                else { dep_filter = false; }



                if (summary == null)
                { summary = " "; }

                if (mailnum != null)
                {
                    mailnum_bool = 0;
                }
                else
                {
                    mailnum_bool = 1;
                }

                if (myday != null)
                {

                    daycheck = 0;
                }
                else if (myday == null)
                {

                    daycheck = 1;
                }

                if (d1 == null && d2 == null)
                {
                    d1 = day.Date;
                    d2 = day.Date;

                }

                if (mail_Readed == null)
                {
                    mail_accept = true;
                    mailReaded = -1;
                    mailnot_readed = -1;
                }
                else if (mail_Readed == 2)
                {
                    mail_accept = false;
                    mailReaded = 2;
                    mailnot_readed = 5;
                }
                else if (mail_Readed == 1)
                {
                    mail_accept = false;
                    mailnot_readed = 1;
                    mailReaded = 1;
                }

                if (Day_sended1 == null && Day_sended2 == null)
                {
                    daysended = true;
                }
                else
                {
                    daysended = false;
                }


                if (replaytext == null)
                {
                    replaytext = " ";
                }

                //if (mailNumType == 1 && (user_role_num == 10 || user_role_num == 17))
                //{
                //    mail_type = "داخلي";
                //}

                //if (user_role_num == 10)
                //{
                //    mail_type = "خ";
                //}
                ////else if (user_role_num == 17)
                ////{
                ////    mail_type = "داخلي";
                ////}
                //else if (mailNumType == 3 && (user_role_num == 18 || user_role_num == 10))
                //{
                //    mail_type = "وارد خارجي";
                //}
                //else if (mailNumType == 2 && (user_role_num == 19 || user_role_num == 10))
                //{
                //    mail_type = "صادر خارجي";
                //}

                if (replaytext == null)
                {
                    replaytext = " ";
                }
                var m = await dbcon.Departments.FindAsync(mangment);

                PagenationSendedEmail<ExtarnelinboxViewModel> pag = new PagenationSendedEmail<ExtarnelinboxViewModel>();


                var c = await (from mail in dbcon.Mails.Where(x => (
                                           x.Mail_Summary.Contains(summary) && (x.Date_Of_Mail.Date >= d1 && x.Date_Of_Mail.Date <= d2))
                                           && (mailnum_bool == 1 || x.Mail_Number == mailnum) && x.Mail_Type == mail_type &&
                                           (x.clasification == Classfication || clasf_filter == true)
                                            
                                            && (x.Genaral_inbox_Number == genral_incoming_num || incoing_num_filter == true) && x.state== true).OrderByDescending(x => x.MailID)

                                   //join Extr in dbcon.Extrenal_Inboxes on mail.MailID equals Extr.MailID
                               join ex in dbcon.Sends.Where(x => (x.flag > 1) && x.to == mangment &&
                               ((x.flag >= mailReaded && x.flag <= mailnot_readed) || mail_accept == true) &&
                               (x.flag == mail_state || State_filter == true) && x.State ==true)
                               on mail.MailID equals ex.MailID
                               join b in dbcon.Extrenal_Inboxes.Where(x => x.SectionId == TheSection || Sectionbool==true) on mail.MailID equals b.MailID
                               join dx in dbcon.measures.Where(x => (x.MeasuresId == Measure_filter || meas_filter == true)) on ex.type_of_send equals dx.MeasuresId
                               join n in dbcon.Departments.Where(x => (x.Id == Department_filter || dep_filter == true)) on mail.Department_Id equals n.Id
                               join z in dbcon.MailStatuses.Where(x => x.state == true) on ex.flag equals z.flag


                               //  join rep in dbcon.Replies on ex.Id equals rep.ReplyId

                               // join cx in dbcon.Replies.Where(x=> x.ReplyId)
                               select new ExtarnelinboxViewModel()
                               {
                                   mail_id = mail.MailID,
                                   State = z.inbox,
                                   type_of_mail = mail.Mail_Type,
                                   Mail_Number = mail.Mail_Number,
                                   date = mail.Date_Of_Mail.ToString("yyyy-MM-dd"),
                                   Masure_type = dx.MeasuresName,
                                   mangment_sender = n.DepartmentName,
                                   mangment_sender_id = mail.Department_Id,
                                   Send_time = ex.Send_time.ToString("yyyy-MM-dd"),
                                   time = ex.Send_time.ToString("HH:mm:ss"),
                                   summary = mail.Mail_Summary,
                                   flag = ex.flag,
                                   Sends_id = ex.Id,
                                   actionrequer=mail.ActionRequired


                               }).OrderByDescending(v => v.mail_id).ToListAsync();
                pag.mail = await (from mail in dbcon.Mails.Where(x => (
              x.Mail_Summary.Contains(summary) && (x.Date_Of_Mail.Date >= d1 && x.Date_Of_Mail.Date <= d2))
              && (mailnum_bool == 1 || x.Mail_Number == mailnum) && x.Mail_Type == mail_type &&
              (x.clasification == Classfication || clasf_filter == true)
               
               &&  (x.Genaral_inbox_Number == genral_incoming_num || incoing_num_filter == true) && x.state == true).OrderByDescending(x => x.MailID)

                                      //join Extr in dbcon.Extrenal_Inboxes on mail.MailID equals Extr.MailID
                                  join ex in dbcon.Sends.Where(x => (x.flag >1) && x.to == mangment &&
                                  ((x.flag >= mailReaded && x.flag <= mailnot_readed) || mail_accept == true) &&
                                  (x.flag == mail_state || State_filter == true) && x.State == true)
                                  on mail.MailID equals ex.MailID
                                  join b in dbcon.Extrenal_Inboxes.Where(x => x.SectionId == TheSection || Sectionbool == true) on mail.MailID equals b.MailID
                                  join dx in dbcon.measures.Where(x => (x.MeasuresId == Measure_filter || meas_filter == true)) on ex.type_of_send equals dx.MeasuresId
                                  join n in dbcon.Departments.Where(x => (x.Id == Department_filter || dep_filter == true)) on mail.Department_Id equals n.Id
                                  join z in dbcon.MailStatuses.Where(x => x.state == true) on ex.flag equals z.flag


                                  //  join rep in dbcon.Replies on ex.Id equals rep.ReplyId

                                  // join cx in dbcon.Replies.Where(x=> x.ReplyId)
                                  select new ExtarnelinboxViewModel()
                                  {
                                      mail_id = mail.MailID,
                                      State = z.inbox,
                                      type_of_mail = mail.Mail_Type,
                                      Mail_Number = mail.Mail_Number,
                                      date = mail.Date_Of_Mail.ToString("yyyy-MM-dd"),
                                      Masure_type = dx.MeasuresName,
                                      mangment_sender = n.DepartmentName,
                                      mangment_sender_id = mail.Department_Id,
                                      Send_time = ex.Send_time.ToString("yyyy-MM-dd"),
                                      time = ex.Send_time.ToString("HH:mm:ss"),
                                      flag = ex.flag,
                                      summary = mail.Mail_Summary,
                                      Sends_id = ex.Id,
                                      actionrequer = mail.ActionRequired




                                  }).OrderByDescending(v => v.mail_id).Skip((pagenum - 1) * size).Take(size).ToListAsync();
                pag.Total = c.Count;

                return pag;



            }


            catch (Exception)
            {

                throw;
            }
        }

        public async Task<PagenationSendedEmail<ExtarnelinboxViewModel>> GetIncomingExtarnelMail(DateTime? myday, int? daycheck, int? mailnum_bool,
           int? mangment, DateTime? d1, DateTime? d2, int? mailnum, string? summary, int? mail_Readed,
           int? mailReaded, int? mailnot_readed, DateTime? Day_sended1, DateTime? Day_sended2, int?
           Typeof_send, int? mail_type, string? replaytext, int? userid, int pagenum, int size,
           int? Measure_filter, int? Department_filter, int? genral_incoming_num, int? Classfication, int? mail_state, int? TheSection)
        {
            try
            {



                DateTime day = DateTime.Now;

                bool dep_filter = false;
                bool clasf_filter = false;
                bool meas_filter = false;
                bool mail_accept = false;
                bool daysended = false;
                bool State_filter = false;
                bool Sectionbool = false;
                bool incoing_num_filter = false;

                // myday = day.Date;




                if (genral_incoming_num == null)
                {

                    incoing_num_filter = true;
                }
                else { incoing_num_filter = false; }



                if (mail_state == null)
                {
                    State_filter = true;
                }
                else { State_filter = false; }


                if (TheSection == null)
                {
                    Sectionbool = true;
                }
                else
                {
                    Sectionbool = false;
                }



                if (Classfication == null)
                {
                    clasf_filter = true;
                }
                else { clasf_filter = false; }


                if (Measure_filter == null)
                {
                    meas_filter = true;
                }
                else { meas_filter = false; }

                if (Department_filter == null)
                {

                    dep_filter = true;

                }
                else { dep_filter = false; }



                if (summary == null)
                { summary = " "; }

                if (mailnum != null)
                {
                    mailnum_bool = 0;
                }
                else
                {
                    mailnum_bool = 1;
                }

                if (myday != null)
                {

                    daycheck = 0;
                }
                else if (myday == null)
                {

                    daycheck = 1;
                }

                if (d1 == null && d2 == null)
                {
                    d1 = day.Date;
                    d2 = day.Date;

                }

                if (mail_Readed == null)
                {
                    mail_accept = true;
                    mailReaded = -1;
                    mailnot_readed = -1;
                }
                else if (mail_Readed == 2)
                {
                    mail_accept = false;
                    mailReaded = 2;
                    mailnot_readed = 5;
                }
                else if (mail_Readed == 1)
                {
                    mail_accept = false;
                    mailnot_readed = 1;
                    mailReaded = 1;
                }

                if (Day_sended1 == null && Day_sended2 == null)
                {
                    daysended = true;
                }
                else
                {
                    daysended = false;
                }


                if (replaytext == null)
                {
                    replaytext = " ";
                }

                //if (mailNumType == 1 && (user_role_num == 10 || user_role_num == 17))
                //{
                //    mail_type = "داخلي";
                //}

                //if (user_role_num == 10)
                //{
                //    mail_type = "خ";
                //}
                ////else if (user_role_num == 17)
                ////{
                ////    mail_type = "داخلي";
                ////}
                //else if (mailNumType == 3 && (user_role_num == 18 || user_role_num == 10))
                //{
                //    mail_type = "وارد خارجي";
                //}
                //else if (mailNumType == 2 && (user_role_num == 19 || user_role_num == 10))
                //{
                //    mail_type = "صادر خارجي";
                //}

                if (replaytext == null)
                {
                    replaytext = " ";
                }
                var m = await dbcon.Departments.FindAsync(mangment);

                PagenationSendedEmail<ExtarnelinboxViewModel> pag = new PagenationSendedEmail<ExtarnelinboxViewModel>();


                var c = await (from mail in dbcon.Mails.Where(x => (
                                           x.Mail_Summary.Contains(summary) && (x.Date_Of_Mail.Date >= d1 && x.Date_Of_Mail.Date <= d2))
                                           && (mailnum_bool == 1 || x.Mail_Number == mailnum) && x.Mail_Type == mail_type &&
                                           (x.clasification == Classfication || clasf_filter == true)
                                          
                                           &&(x.Genaral_inbox_Number == genral_incoming_num || incoing_num_filter == true) && x.state == true).OrderByDescending(x => x.MailID)

                                   //join Extr in dbcon.Extrenal_Inboxes on mail.MailID equals Extr.MailID
                               join ex in dbcon.Sends.Where(x => (x.flag >1) && x.to == mangment &&
                               ((x.flag >= mailReaded && x.flag <= mailnot_readed) || mail_accept == true) &&
                               (x.flag == mail_state || State_filter == true) && x.State==true)
                               on mail.MailID equals ex.MailID
                               join d in dbcon.External_Mails.Where(x => x.Sectionid == TheSection || Sectionbool == true) on mail.MailID equals d.MailID
                               join dx in dbcon.measures.Where(x => (x.MeasuresId == Measure_filter || meas_filter == true)) on ex.type_of_send equals dx.MeasuresId
                               join n in dbcon.Departments.Where(x => (x.Id == Department_filter || dep_filter == true)) on mail.Department_Id equals n.Id
                               join z in dbcon.MailStatuses.Where(x => x.state == true) on ex.flag equals z.flag


                               //  join rep in dbcon.Replies on ex.Id equals rep.ReplyId

                               // join cx in dbcon.Replies.Where(x=> x.ReplyId)
                               select new ExtarnelinboxViewModel()
                               {
                                   mail_id = mail.MailID,
                                   State = z.inbox,
                                   type_of_mail = mail.Mail_Type,
                                   Mail_Number = mail.Mail_Number,
                                   date = mail.Date_Of_Mail.ToString("yyyy-MM-dd"),
                                   Masure_type = dx.MeasuresName,
                                   mangment_sender = n.DepartmentName,
                                   mangment_sender_id = mail.Department_Id,
                                   Send_time = ex.Send_time.ToString("yyyy-MM-dd"),
                                   time = ex.Send_time.ToString("HH:mm:ss"),
                                   summary = mail.Mail_Summary,
                                   flag = ex.flag,
                                   Sends_id = ex.Id,
                                   actionrequer=mail.ActionRequired


                               }).OrderByDescending(v => v.mail_id).ToListAsync();
                pag.mail = await (from mail in dbcon.Mails.Where(x => (
              x.Mail_Summary.Contains(summary) && (x.Date_Of_Mail.Date >= d1 && x.Date_Of_Mail.Date <= d2))
              && (mailnum_bool == 1 || x.Mail_Number == mailnum) && x.Mail_Type == mail_type &&
              (x.clasification == Classfication || clasf_filter == true)
              
              &&(x.Genaral_inbox_Number == genral_incoming_num || incoing_num_filter == true) && x.state == true).OrderByDescending(x => x.MailID)

                                      //join Extr in dbcon.Extrenal_Inboxes on mail.MailID equals Extr.MailID
                                  join ex in dbcon.Sends.Where(x => (x.flag > 1) && x.to == mangment &&
                                  ((x.flag >= mailReaded && x.flag <= mailnot_readed) || mail_accept == true) &&
                                  (x.flag == mail_state || State_filter == true) && x.State == true)
                                  on mail.MailID equals ex.MailID
                                  join d in dbcon.External_Mails.Where(x => x.Sectionid == TheSection || Sectionbool == true) on mail.MailID equals d.MailID
                                  join dx in dbcon.measures.Where(x => (x.MeasuresId == Measure_filter || meas_filter == true)) on ex.type_of_send equals dx.MeasuresId
                                  join n in dbcon.Departments.Where(x => (x.Id == Department_filter || dep_filter == true)) on mail.Department_Id equals n.Id
                                  join z in dbcon.MailStatuses.Where(x => x.state == true) on ex.flag equals z.flag


                                  //  join rep in dbcon.Replies on ex.Id equals rep.ReplyId

                                  // join cx in dbcon.Replies.Where(x=> x.ReplyId)
                                  select new ExtarnelinboxViewModel()
                                  {
                                      mail_id = mail.MailID,
                                      State = z.inbox,
                                      type_of_mail = mail.Mail_Type,
                                      Mail_Number = mail.Mail_Number,
                                      date = mail.Date_Of_Mail.ToString("yyyy-MM-dd"),
                                      Masure_type = dx.MeasuresName,
                                      mangment_sender = n.DepartmentName,
                                      mangment_sender_id = mail.Department_Id,
                                      Send_time = ex.Send_time.ToString("yyyy-MM-dd"),
                                      time = ex.Send_time.ToString("HH:mm:ss"),
                                      flag = ex.flag,
                                      summary = mail.Mail_Summary,
                                      Sends_id = ex.Id,
                                      actionrequer=mail.ActionRequired



                                  }).OrderByDescending(v => v.mail_id).Skip((pagenum - 1) * size).Take(size).ToListAsync();
                pag.Total = c.Count;

                return pag;



            }


            catch (Exception)
            {

                throw;
            }
        }



        public async Task<PagenationSendedEmail<Sended_Maill>> GetIncomingRecevidMail(DateTime? myday, int? daycheck,
            int? mailnum_bool, int? mangment, DateTime? d1, DateTime? d2, int? mailnum, string? summary,
            int? mail_Readed, int? mailReaded, int? mailnot_readed, DateTime? Day_sended1,
            DateTime? Day_sended2, int? Typeof_send, int? mail_type, string? replaytext, int? userid,
            int pagenum, int size, int? Measure_filter, int? Department_filter, int? Classfication
            , int? mail_state , int? genral_incoming_num)
        {
            try
            {



                DateTime day = DateTime.Now;

                bool dep_filter = false;
                bool clasf_filter = false;
                bool meas_filter = false;
                bool mail_accept = false;
                bool daysended = false;
                bool State_filter = false;
                bool incoing_num_filter = false;

                // myday = day.Date;


                if (genral_incoming_num == null)
                {
                    incoing_num_filter = true;

                }
                else
                {
                    incoing_num_filter = false;
                }






                if (mail_state == null)
                {
                    State_filter = true;
                }
                else { State_filter = false; }



                if (Classfication == null)
                {
                    clasf_filter = true;
                }
                else { clasf_filter = false; }


                if (Measure_filter == null)
                {
                    meas_filter = true;
                }
                else { meas_filter = false; }

                if (Department_filter == null)
                {

                    dep_filter = true;

                }
                else { dep_filter = false; }



                if (summary == null)
                { summary = " "; }

                if (mailnum != null)
                {
                    mailnum_bool = 0;
                }
                else
                {
                    mailnum_bool = 1;
                }

                if (myday != null)
                {

                    daycheck = 0;
                }
                else if (myday == null)
                {

                    daycheck = 1;
                }

                if (d1 == null && d2 == null)
                {
                    d1 = day.Date;
                    d2 = day.Date;

                }

                if (mail_Readed == null)
                {
                    mail_accept = true;
                    mailReaded = -1;
                    mailnot_readed = -1;
                }
                else if (mail_Readed == 2)
                {
                    mail_accept = false;
                    mailReaded = 2;
                    mailnot_readed = 5;
                }
                else if (mail_Readed == 1)
                {
                    mail_accept = false;
                    mailnot_readed = 1;
                    mailReaded = 1;
                }

                if (Day_sended1 == null && Day_sended2 == null)
                {
                    daysended = true;
                }
                else
                {
                    daysended = false;
                }


                if (replaytext == null)
                {
                    replaytext = " ";
                }

                //if (mailNumType == 1 && (user_role_num == 10 || user_role_num == 17))
                //{
                //    mail_type = "داخلي";
                //}

                //if (user_role_num == 10)
                //{
                //    mail_type = "خ";
                //}
                ////else if (user_role_num == 17)
                ////{
                ////    mail_type = "داخلي";
                ////}
                //else if (mailNumType == 3 && (user_role_num == 18 || user_role_num == 10))
                //{
                //    mail_type = "وارد خارجي";
                //}
                //else if (mailNumType == 2 && (user_role_num == 19 || user_role_num == 10))
                //{
                //    mail_type = "صادر خارجي";
                //}

                if (replaytext == null)
                {
                    replaytext = " ";
                }
                var m = await dbcon.Departments.FindAsync(mangment);

                PagenationSendedEmail<Sended_Maill> pag = new PagenationSendedEmail<Sended_Maill>();


                var c = await (from mail in dbcon.Mails.Where(x => (
                                           x.Mail_Summary.Contains(summary) && (x.Date_Of_Mail.Date >= d1 && x.Date_Of_Mail.Date <= d2))
                                           && (mailnum_bool == 1 || x.Mail_Number == mailnum) && x.Mail_Type == mail_type &&
                                           (x.clasification == Classfication || clasf_filter == true)

                                            &&(x.Genaral_inbox_Number == genral_incoming_num || incoing_num_filter == true) && x.state== true).OrderByDescending(x => x.MailID)

                                   //join Extr in dbcon.Extrenal_Inboxes on mail.MailID equals Extr.MailID
                               join ex in dbcon.Sends.Where(x => (x.flag > 1) && x.to == mangment &&
                               ((x.flag >= mailReaded && x.flag <= mailnot_readed) || mail_accept == true) &&
                               (x.flag == mail_state || State_filter == true) && x.State == true)
                               on mail.MailID equals ex.MailID

                               join dx in dbcon.measures.Where(x => (x.MeasuresId == Measure_filter || meas_filter == true)) on ex.type_of_send equals dx.MeasuresId
                               join n in dbcon.Departments.Where(x => (x.Id == Department_filter || dep_filter == true)) on mail.Department_Id equals n.Id
                               join z in dbcon.MailStatuses.Where(x => x.state == true) on ex.flag equals z.flag


                               //  join rep in dbcon.Replies on ex.Id equals rep.ReplyId

                               // join cx in dbcon.Replies.Where(x=> x.ReplyId)
                               select new Sended_Maill()
                               {
                                   mail_id = mail.MailID,
                                   State = z.inbox,
                                   type_of_mail = mail.Mail_Type,
                                   Mail_Number = mail.Mail_Number,
                                   date = mail.Date_Of_Mail.ToString("yyyy-MM-dd"),
                                   Masure_type = dx.MeasuresName,
                                   mangment_sender = n.DepartmentName,
                                   mangment_sender_id = mail.Department_Id,
                                   Send_time = ex.Send_time.ToString("yyyy-MM-dd"),
                                   time = ex.Send_time.ToString("HH:mm:ss"),
                                   summary = mail.Mail_Summary,
                                   flag = ex.flag,
                                   Sends_id = ex.Id,
                                   action_require = mail.ActionRequired



                               }).OrderByDescending(v => v.mail_id).ToListAsync();
                pag.mail = await (from mail in dbcon.Mails.Where(x => (
              x.Mail_Summary.Contains(summary) && (x.Date_Of_Mail.Date >= d1 && x.Date_Of_Mail.Date <= d2))
              && (mailnum_bool == 1 || x.Mail_Number == mailnum) && x.Mail_Type == mail_type &&
              (x.clasification == Classfication || clasf_filter == true)

               &&(x.Genaral_inbox_Number == genral_incoming_num || incoing_num_filter == true) && x.state==true).OrderByDescending(x => x.MailID)

                                      //join Extr in dbcon.Extrenal_Inboxes on mail.MailID equals Extr.MailID
                                  join ex in dbcon.Sends.Where(x => (x.flag > 1) && x.to == mangment &&
                                ((x.flag >= mailReaded && x.flag <= mailnot_readed) || mail_accept == true) &&
                                (x.flag == mail_state || State_filter == true) && x.State == true)
                                on mail.MailID equals ex.MailID
                                  join dx in dbcon.measures.Where(x => (x.MeasuresId == Measure_filter || meas_filter == true)) on ex.type_of_send equals dx.MeasuresId
                                  join n in dbcon.Departments.Where(x => (x.Id == Department_filter || dep_filter == true)) on mail.Department_Id equals n.Id
                                  join z in dbcon.MailStatuses.Where(x => x.state == true) on ex.flag equals z.flag


                                  //  join rep in dbcon.Replies on ex.Id equals rep.ReplyId

                                  // join cx in dbcon.Replies.Where(x=> x.ReplyId)
                                  select new Sended_Maill()
                                  {
                                      mail_id = mail.MailID,
                                      State = z.inbox,
                                      type_of_mail = mail.Mail_Type,
                                      Mail_Number = mail.Mail_Number,
                                      date = mail.Date_Of_Mail.ToString("yyyy-MM-dd"),
                                      Masure_type = dx.MeasuresName,
                                      mangment_sender = n.DepartmentName,
                                      mangment_sender_id = mail.Department_Id,
                                      Send_time = ex.Send_time.ToString("yyyy-MM-dd"),
                                      time = ex.Send_time.ToString("HH:mm:ss"),
                                      flag = ex.flag,
                                      summary = mail.Mail_Summary,
                                      Sends_id = ex.Id,
                                      action_require = mail.ActionRequired




                                  }).OrderByDescending(v => v.mail_id).Skip((pagenum - 1) * size).Take(size).ToListAsync();
                pag.Total = c.Count;

                return pag;



            }


            catch (Exception)
            {

                throw;
            }
        }

        public async Task<dynamic> GetMail(DateTime? myday, int? daycheck, int? mailnum_bool,
        int? mangment, DateTime? d1, DateTime? d2, int? mailnum, string? summary, int? mail_Readed,
        int? mailReaded, int? mailnot_readed, DateTime? Day_sended1, DateTime? Day_sended2, int?
        Typeof_send, int? userid, int? mailNumType, int? mail_type, string? replaytext, int pagenum,
        int size, int? Measure_filter, int? Department_filter, int? Classfication,
        int? mail_state, int? genral_incoming_num, int? TheSection, bool? Replay_Date)
        {


            try
            {
                var role_id = await dbcon.userRoles.Where(x => x.UserId == userid).ToListAsync();

                //   var user_role_num = role_id.RoleId;

                switch (mailNumType)
                {

                    case 0:
                        if (role_id.Any(x => x.RoleId == 10))
                        {

                            var c0 = await GetAll(myday, daycheck, mailnum_bool,
                mangment, d1, d2, mailnum, summary, mail_Readed,
                mailReaded, mailnot_readed, Day_sended1, Day_sended2,
               Typeof_send, mail_type, replaytext, userid, pagenum, size, Measure_filter,
               Department_filter, Classfication, mail_state, genral_incoming_num, TheSection,  Replay_Date);
                            d = c0;
                            break;
                        }
                        else if (role_id.Any(x => x.RoleId == 17))
                        {
                            mail_type = 1;
                            var a = await GetSendedMail(myday, daycheck, mailnum_bool,
                mangment, d1, d2, mailnum, summary, mail_Readed,
                mailReaded, mailnot_readed, Day_sended1, Day_sended2,
               Typeof_send, mail_type, replaytext, userid, pagenum, size,
               Measure_filter, Department_filter, Classfication,
               mail_state, genral_incoming_num,  Replay_Date);
                            d = a;
                            break;
                        }
                        else if (role_id.Any(x => x.RoleId == 19))
                        {
                            mail_type = 2;

                            var a2 = await GetExtarnelMail(myday, daycheck, mailnum_bool,
                mangment, d1, d2, mailnum, summary, mail_Readed,
                mailReaded, mailnot_readed, Day_sended1, Day_sended2,
               Typeof_send, mail_type, replaytext, userid, pagenum, size,
               Measure_filter, Department_filter, Classfication,
               mail_state, genral_incoming_num, TheSection,  Replay_Date);
                            d = a2;
                            break;
                        }
                        else if (role_id.Any(x => x.RoleId == 18))
                        {

                            mail_type = 3;
                            var a3 = await GetExtarnelinbox(myday, daycheck, mailnum_bool,
                mangment, d1, d2, mailnum, summary, mail_Readed,
                mailReaded, mailnot_readed, Day_sended1, Day_sended2,
               Typeof_send, mail_type, replaytext, userid, pagenum, size,
               Measure_filter, Department_filter, Classfication, 
               mail_state, genral_incoming_num, TheSection,  Replay_Date);
                            d = a3;


                            break;
                        }
                        d = null;
                        break;




                    case 1:
                        if (role_id.Any(x => x.RoleId == 10 || x.RoleId == 17))
                        {
                            mail_type = 1;
                            var c = await GetSendedMail(myday, daycheck, mailnum_bool,
                mangment, d1, d2, mailnum, summary, mail_Readed,
                mailReaded, mailnot_readed, Day_sended1, Day_sended2,
               Typeof_send, mail_type, replaytext, userid, pagenum, size,
               Measure_filter, Department_filter, Classfication, mail_state, genral_incoming_num,  Replay_Date);
                            d = c;
                            break;
                        }
                        d = null;
                        break;
                    case 2:
                        if (role_id.Any(x => x.RoleId == 10 || x.RoleId == 19))
                        {
                            mail_type = 2;

                            var cc = await GetExtarnelMail(myday, daycheck, mailnum_bool,
                mangment, d1, d2, mailnum, summary, mail_Readed,
                mailReaded, mailnot_readed, Day_sended1, Day_sended2,
               Typeof_send, mail_type, replaytext, userid, pagenum, size,
               Measure_filter, Department_filter, Classfication,
               mail_state, genral_incoming_num, TheSection,  Replay_Date);
                            d = cc;
                            break;
                        }
                        d = null;
                        break;

                    case 3:
                        if (role_id.Any(x => x.RoleId == 10 || x.RoleId == 18))
                        {
                            mail_type = 3;
                            var ccc = await GetExtarnelinbox(myday, daycheck, mailnum_bool,
                mangment, d1, d2, mailnum, summary, mail_Readed,
                mailReaded, mailnot_readed, Day_sended1, Day_sended2,
               Typeof_send, mail_type, replaytext, userid, pagenum, size,
               Measure_filter, Department_filter, Classfication,
               mail_state, genral_incoming_num, TheSection, Replay_Date);
                            d = ccc;


                            break;
                        }
                        d = null;
                        break;
                    default:
                        break;
                }

                return d;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<PagenationSendedEmail<Sended_Maill>> Getmail(int depid, int size, int pagenum)
        {

            PagenationSendedEmail<Sended_Maill> pag = new PagenationSendedEmail<Sended_Maill>();

            try
            {
                var m = await dbcon.Departments.FindAsync(depid);


                //var c = await (from mail in dbcon.Mails.Where(x => x.Department_Id == depid && x.Mail_Type.Equals("داخلي"))
                //               join y in dbcon.Sends.Where(n => n.flag == true) on mail.MailID equals y.MailID
                //               select new Sended_Maill()
                //               {
                //                   mail_id = mail.MailID,
                //                   State = (y.State == true) ? "قرأت" : "لم تقرأ",
                //                   type_of_mail = mail.Mail_Type,
                //                   Mail_Number = mail.Mail_Number,
                //                   date = mail.Date_Of_Mail.ToString("yyyy-MM-dd"),
                //                   procedure_type = mail.clasification,
                //                   mangment_sender = m.DepartmentName,
                //                   Send_time = y.Send_time,
                //                   time = y.Send_time.ToString("HH-mm-ss"),
                //                   summary = mail.Mail_Summary,
                //                   Sends_id = y.Id



                //               }).OrderByDescending(v => v.mail_id).Skip((pagenum - 1) * size).Take(size).ToListAsync();


                var c2 = await (from mail in dbcon.Mails.Where(x => x.Department_Id == depid && x.Mail_Type == 1)
                                join y in dbcon.Sends.Where(n => n.flag != 0) on mail.MailID equals y.MailID
                                join z in dbcon.MailStatuses.Where(x => x.state == true) on y.flag equals z.flag

                                select new Sended_Maill()
                                {
                                    mail_id = mail.MailID,
                                    State = z.sent,
                                    type_of_mail = mail.Mail_Type,
                                    Mail_Number = mail.Mail_Number,
                                    date = mail.Date_Of_Mail.ToString("yyyy-MM-dd"),
                                    //procedure_type = mail.clasification,
                                    mangment_sender = m.DepartmentName,
                                    Send_time = y.Send_time.ToString("yyyy-MM-dd"),
                                    time = y.Send_time.ToString("HH:mm:ss"),
                                    summary = mail.Mail_Summary,
                                    Sends_id = y.Id



                                }).OrderByDescending(v => v.mail_id).ToListAsync();
                pag.Total = c2.Count;
                pag.mail = c2.OrderByDescending(v => v.mail_id).Skip((pagenum - 1) * size).Take(size).ToList();

                return pag;
            }
            catch (Exception)
            {

                throw;
            }


        }

        public async Task<PagenationSendedEmail<Sended_Maill>> Getmailincoming(int depid, int size, int pagenum)
        {
            PagenationSendedEmail<Sended_Maill> pag = new PagenationSendedEmail<Sended_Maill>();

            try
            {
                var m = await dbcon.Departments.FindAsync(depid);


                //var c = await (from mail in dbcon.Mails.Where(x => x.Department_Id == depid && x.Mail_Type.Equals("داخلي"))
                //               join y in dbcon.Sends.Where(n => n.flag == true) on mail.MailID equals y.MailID
                //               select new Sended_Maill()
                //               {
                //                   mail_id = mail.MailID,
                //                   State = (y.State == true) ? "قرأت" : "لم تقرأ",
                //                   type_of_mail = mail.Mail_Type,
                //                   Mail_Number = mail.Mail_Number,
                //                   date = mail.Date_Of_Mail.ToString("yyyy-MM-dd"),
                //                   procedure_type = mail.clasification,
                //                   mangment_sender = m.DepartmentName,
                //                   Send_time = y.Send_time,
                //                   time = y.Send_time.ToString("HH-mm-ss"),
                //                   summary = mail.Mail_Summary,
                //                   Sends_id = y.Id



                //               }).OrderByDescending(v => v.mail_id).Skip((pagenum - 1) * size).Take(size).ToListAsync();


                var c2 = await (from mail in dbcon.Mails.Where(x => x.Department_Id == depid && x.Mail_Type == 1)
                                join y in dbcon.Sends.Where(n => n.flag != 0) on mail.MailID equals y.MailID
                                join z in dbcon.MailStatuses.Where(x => x.state == true) on y.flag equals z.flag

                                select new Sended_Maill()
                                {
                                    mail_id = mail.MailID,
                                    State = z.inbox,
                                    type_of_mail = mail.Mail_Type,
                                    Mail_Number = mail.Mail_Number,
                                    date = mail.Date_Of_Mail.ToString("yyyy-MM-dd"),
                                    //procedure_type = mail.clasification,
                                    mangment_sender = m.DepartmentName,
                                    Send_time = y.Send_time.ToString("yyyy-MM-dd"),
                                    time = y.Send_time.ToString("HH:mm:ss"),
                                    summary = mail.Mail_Summary,
                                    Sends_id = y.Id



                                }).OrderByDescending(v => v.mail_id).ToListAsync();
                pag.Total = c2.Count;
                pag.mail = c2.OrderByDescending(v => v.mail_id).Skip((pagenum - 1) * size).Take(size).ToList();

                return pag;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<PagenationSendedEmail<Sended_Maill>> GetSendedMail(DateTime? myday, int? daycheck, int? mailnum_bool,
           int? mangment, DateTime? d1, DateTime? d2, int? mailnum, string? summary, int? mail_Readed,
           int? mailReaded, int? mailnot_readed, DateTime? Day_sended1, DateTime? Day_sended2, int?
           Typeof_send, int? mail_type, string? replaytext, int? userid, int pagenum, int size, int? Measure_filter,
           int? Department_filter, int? Classfication, int? mail_state, int? genral_incoming_num, bool? Replay_Date)
        {

            try
            {



                DateTime day = DateTime.Now;

                bool dep_filter = false;
                bool clasf_filter = false;
                bool meas_filter = false;
                bool mail_accept = false;
                bool incoing_num_filter = false;
                bool daysended = false;
                bool State_filter = false;
                // myday = day.Date;



                if (genral_incoming_num == null)
                {
                    incoing_num_filter = true;
                }
                else { incoing_num_filter = false; }







                if (mail_state == null)
                {
                    State_filter = true;
                }
                else { State_filter = false; }



                if (Classfication == null)
                {
                    clasf_filter = true;
                }
                else { clasf_filter = false; }


                if (Measure_filter == null)
                {
                    meas_filter = true;
                }
                else { meas_filter = false; }

                if (Department_filter == null)
                {

                    dep_filter = true;

                }
                else { dep_filter = false; }



                if (summary == null)
                { summary = " "; }

                if (mailnum != null)
                {
                    mailnum_bool = 0;
                }
                else
                {
                    mailnum_bool = 1;
                }

                if (myday != null)
                {

                    daycheck = 0;
                }
                else if (myday == null)
                {

                    daycheck = 1;
                }

                if (d1 == null && d2 == null)
                {
                    d1 = day.Date;
                    d2 = day.Date;

                }

                if (mail_Readed == null)
                {
                    mail_accept = true;
                    mailReaded = -1;
                    mailnot_readed = -1;
                }
                else if (mail_Readed == 2)
                {
                    mail_accept = false;
                    mailReaded = 2;
                    mailnot_readed = 5;
                }
                else if (mail_Readed == 1)
                {
                    mail_accept = false;
                    mailnot_readed = 1;
                    mailReaded = 1;
                }

                if (Day_sended1 == null && Day_sended2 == null)
                {
                    daysended = true;
                }
                else
                {
                    daysended = false;
                }


                if (replaytext == null)
                {
                    replaytext = " ";
                }

                //if (mailNumType == 1 && (user_role_num == 10 || user_role_num == 17))
                //{
                //    mail_type = "داخلي";
                //}

                //if (user_role_num == 10)
                //{
                //    mail_type = "خ";
                //}
                ////else if (user_role_num == 17)
                ////{
                ////    mail_type = "داخلي";
                ////}
                //else if (mailNumType == 3 && (user_role_num == 18 || user_role_num == 10))
                //{
                //    mail_type = "وارد خارجي";
                //}
                //else if (mailNumType == 2 && (user_role_num == 19 || user_role_num == 10))
                //{
                //    mail_type = "صادر خارجي";
                //}

                if (replaytext == null)
                {
                    replaytext = " ";
                }
                var m = await dbcon.Departments.FindAsync(mangment);

                PagenationSendedEmail<Sended_Maill> pag = new PagenationSendedEmail<Sended_Maill>();


                var c = await (from mail in dbcon.Mails.Where(x => (x.Department_Id == mangment &&
             x.Mail_Summary.Contains(summary) && (x.Date_Of_Mail.Date >= d1 && x.Date_Of_Mail.Date <= d2))
             && (mailnum_bool == 1 || x.Mail_Number == mailnum) && x.Mail_Type == mail_type &&
             (x.clasification == Classfication || clasf_filter == true)
             && (x.Genaral_inbox_Number == genral_incoming_num || incoing_num_filter == true) && x.state == true).OrderByDescending(x => x.MailID)

                               join ex in dbcon.Sends.Where(x => (x.flag > 0) &&
                               ((x.flag >= mailReaded && x.flag <= mailnot_readed) || mail_accept == true) &&
                               (x.flag == mail_state || State_filter == true) && (dep_filter == false && x.isMulti == false || dep_filter == false && x.isMulti == true || x.isMulti == true))
                               on mail.MailID equals ex.MailID
                               join dx in dbcon.measures.Where(x => (x.MeasuresId == Measure_filter || meas_filter == true)) on ex.type_of_send equals dx.MeasuresId
                               join n in dbcon.Departments.Where(x => (x.Id == Department_filter || dep_filter == true)) on ex.to equals n.Id
                               join z in dbcon.MailStatuses.Where(x => x.state == true) on ex.flag equals z.flag


                               //  join rep in dbcon.Replies on ex.Id equals rep.ReplyId

                               // join cx in dbcon.Replies.Where(x=> x.ReplyId)
                               select new Sended_Maill()
                               {
                                   mail_id = mail.MailID,
                                   State = z.sent,
                                   type_of_mail = mail.Mail_Type,
                                   Mail_Number = mail.Mail_Number,
                                   date = mail.Date_Of_Mail.ToString("yyyy-MM-dd"),
                                   Masure_type = dx.MeasuresName,
                                   mangment_sender = n.DepartmentName,
                                   mangment_sender_id = mail.Department_Id,
                                   Send_time = ex.Send_time.ToString("yyyy-MM-dd"),
                                   time = ex.Send_time.ToString("HH:mm:ss"),
                                   summary = mail.Mail_Summary,
                                   flag = ex.flag,
                                   Sends_id = ex.Id,


                               }).OrderByDescending(v => v.mail_id).ToListAsync();

                IEnumerable<Sended_Maill> zx;
                if (Replay_Date == true)
                {
                   


                    zx = (from x in c
                          join vv in dbcon.Replies
                          on x.Sends_id equals vv.send_ToId

                          select new Sended_Maill
                          {

                              mail_id = x.mail_id,
                              State = x.State,
                              type_of_mail = x.type_of_mail,
                              Mail_Number = x.Mail_Number,
                              date = x.date,
                              Masure_type = x.Masure_type,
                              mangment_sender = x.mangment_sender,
                              mangment_sender_id = x.mangment_sender_id,
                              Send_time = x.Send_time,
                              time = x.time,
                              summary = x.summary,
                              flag = x.flag,
                              Sends_id = x.Sends_id
                          }
                              ).ToList();


                }
                else
                {
                    zx = c;
                }


                pag.mail = await (from mail in dbcon.Mails.Where(x => (x.Department_Id == mangment &&
              x.Mail_Summary.Contains(summary) && (x.Date_Of_Mail.Date >= d1 && x.Date_Of_Mail.Date <= d2))
              && (mailnum_bool == 1 || x.Mail_Number == mailnum) && x.Mail_Type == mail_type &&
              (x.clasification == Classfication || clasf_filter == true)
              && (x.Genaral_inbox_Number == genral_incoming_num || incoing_num_filter == true) && x.state == true).OrderByDescending(x => x.MailID)

                                  join ex in dbcon.Sends.Where(x => (x.flag > 0) &&
                                  ((x.flag >= mailReaded && x.flag <= mailnot_readed) || mail_accept == true) &&
                                  (x.flag == mail_state || State_filter == true) && (dep_filter == false && x.isMulti == false || dep_filter == false && x.isMulti == true || x.isMulti == true))
                                  on mail.MailID equals ex.MailID
                                  join dx in dbcon.measures.Where(x => (x.MeasuresId == Measure_filter || meas_filter == true)) on ex.type_of_send equals dx.MeasuresId
                                  join n in dbcon.Departments.Where(x => (x.Id == Department_filter || dep_filter == true)) on ex.to equals n.Id
                                  join z in dbcon.MailStatuses.Where(x => x.state == true) on ex.flag equals z.flag


                                  //  join rep in dbcon.Replies on ex.Id equals rep.ReplyId

                                  // join cx in dbcon.Replies.Where(x=> x.ReplyId)
                                  select new Sended_Maill()
                                  {
                                      mail_id = mail.MailID,
                                      State = z.sent,
                                      type_of_mail = mail.Mail_Type,
                                      Mail_Number = mail.Mail_Number,
                                      date = mail.Date_Of_Mail.ToString("yyyy-MM-dd"),
                                      Masure_type = dx.MeasuresName,
                                      mangment_sender = n.DepartmentName,
                                      mangment_sender_id = mail.Department_Id,
                                      Send_time = ex.Send_time.ToString("yyyy-MM-dd"),
                                      time = ex.Send_time.ToString("HH:mm:ss"),
                                      flag = ex.flag,
                                      summary = mail.Mail_Summary,
                                      Sends_id = ex.Id,




                                  }).OrderByDescending(v => v.mail_id).Skip((pagenum - 1) * size).Take(size).ToListAsync();


                PagenationSendedEmail<Sended_Maill> pagg = new PagenationSendedEmail<Sended_Maill>();
                if (Replay_Date == true)
                {


                    pagg.mail = (from x in pag.mail
                                 join vv in dbcon.Replies
                                 on x.Sends_id equals vv.send_ToId

                                 select new Sended_Maill
                                 {

                                     mail_id = x.mail_id,
                                     State = x.State,
                                     type_of_mail = x.type_of_mail,
                                     Mail_Number = x.Mail_Number,
                                     date = x.date,
                                     Masure_type = x.Masure_type,
                                     mangment_sender = x.mangment_sender,
                                     mangment_sender_id = x.mangment_sender_id,
                                     Send_time = x.Send_time,
                                     time = x.time,
                                     summary = x.summary,
                                     flag = x.flag,
                                     Sends_id = x.Sends_id
                                 }
                              ).ToList();

                    // z.Count();
                }
                else
                {
                    pagg.mail = pag.mail;
                }
                pagg.Total = zx.Count();
                //pagg.Total = pag.Total;
                return pagg;







            }


            catch (Exception)
            {

                throw;
            }

        }

        //public async Task<int> GetState(int mail_id)
        //{
        //    try
        //    {
        //        var c = await dbcon.Sends.LastOrDefaultAsync(x => x.MailID == mail_id);
        //        return c.flag;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }

        //}

        public async Task<int> GetFlag(int mail_id, int department_Id,int userId)
        {

            try
            {
                var c = await dbcon.Sends.OrderBy(x => x.Id).LastOrDefaultAsync(x => x.MailID == mail_id && department_Id == x.to);
                if (c != null)
                {
                    Historyes historyes = new Historyes();
                    historyes.changes = "تم قراءة البريد";

                    historyes.mailid = c.MailID;
                    historyes.currentUser = userId;
                    historyes.Time = DateTime.Now;
                    historyes.HistortyNameID = 15;
                    await dbcon.History.AddAsync(historyes);

                    
                    c.flag = 3;
                    dbcon.Sends.Update(c);
                    await dbcon.SaveChangesAsync();
                    return c.flag;
                }
                return 0;
            }
            catch (Exception)
            {

                throw;
            }



            //   return c.flag;

        }


        public async Task<List<Extrmal_SectionDto>> getExtrinlSection()

        {
            
            List<Extrmal_SectionDto> dtosection = new List<Extrmal_SectionDto>();

            var c = await (from Sections in dbcon.Extrmal_Sections.Where(x => x.state == true && x.perent!=0).OrderByDescending(x=>x.id)
                                             select new Extrmal_SectionDto
                                             {
                                                Section_Name= Sections.Section_Name,
                                                id= Sections.id,
                                                 perent = Sections.perent,
                                                 state = Sections.state

                                             }).ToListAsync();


            


            return c;
        }



    }
}