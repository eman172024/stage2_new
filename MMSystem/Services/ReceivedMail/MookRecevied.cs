﻿using Microsoft.EntityFrameworkCore;
using MMSystem.Model;
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
        dynamic d;
        public MookRecevied(AppDbCon _bcon )
        {
            dbcon = _bcon;    
        }

        public async Task<PagenationSendedEmail<Sended_Maill>> GetAll(DateTime? myday, int? daycheck, int? mailnum_bool, 
            int? mangment, DateTime? d1, DateTime? d2, int? mailnum, string summary, int? mail_Readed, int? mailReaded,
            int? mailnot_readed, DateTime? Day_sended1, DateTime? Day_sended2, int? Typeof_send, int? mail_type,
            string replaytext, int? userid , int pagenum, int size)
        {
            try
            {


                DateTime day = DateTime.Now;
                bool mail_accept = false;
                bool daysended = false;
                bool sendedType_exsist = false;
                // myday = day.Date;

                if (mangment == null)
                { mangment = 1; }

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

                if (Typeof_send == null)
                {
                    sendedType_exsist = true;
                }
                else
                {
                    sendedType_exsist = false;
                }

                //if (user_role_num == 10)
                //{
                //    mail_type = "خ";
                //}
                //else if (user_role_num == 17)
                //{
                //    mail_type = "داخلي";
                //}
                //else if (user_role_num == 18)
                //{
                //    mail_type = "وارد خارجي";
                //}
                //else if (user_role_num == 19)
                //{
                //    mail_type = "صادر خارجي";
                //}
                //if (replaytext == null)
                //{
                //    replaytext = " ";
                //}

                var m = await dbcon.Departments.FindAsync(mangment);


                PagenationSendedEmail<Sended_Maill> pag = new PagenationSendedEmail<Sended_Maill>();


                var c = await(from mail in dbcon.Mails.Where(x => (x.Department_Id == mangment &&
                                              x.Mail_Summary.Contains(summary) && (x.Date_Of_Mail.Date >= d1 && x.Date_Of_Mail.Date <= d2))
                                              && (mailnum_bool == 1 || x.Mail_Number == mailnum)).OrderByDescending(x => x.MailID)

                                              join ex in dbcon.Sends.Where(x => (x.flag != 0) && (daycheck == 1 || x.Send_time.Date == myday) &&
                                              ((x.flag >= mailReaded && x.flag <= mailnot_readed) || mail_accept == true) &&
                                                    ((x.Send_time.Date >= Day_sended1 && x.Send_time.Date <= Day_sended2 && x.flag == 5) || daysended == true) &&
                                         (x.type_of_send == Typeof_send || sendedType_exsist == true))
                                         on mail.MailID equals ex.MailID


                                              //  join rep in dbcon.Replies on ex.Id equals rep.ReplyId
                                              // join cx in dbcon.Replies.Where(x=> x.ReplyId)
                                              select new Sended_Maill()
                                              {
                                                  mail_id = mail.MailID,
                                                  State = (ex.flag >= 2) ? "قرأت" : "لم تقرأ",
                                                  type_of_mail = mail.Mail_Type,
                                                  Mail_Number = mail.Mail_Number,
                                                  date = mail.Date_Of_Mail.ToString("yyyy-MM-dd"),
                                                  //procedure_type = mail.clasification,
                                                  mangment_sender = m.DepartmentName,
                                                  Send_time = ex.Send_time.ToString("yyyy-MM-dd"),
                                                  time = ex.Send_time.ToString("HH-mm-ss"),
                                                  summary = mail.Mail_Summary,
                                                  Sends_id = ex.Id



                                              }).OrderByDescending(v => v.mail_id).ToListAsync();


                pag.mail = await (from mail in dbcon.Mails.Where(x => (x.Department_Id == mangment &&
                                               x.Mail_Summary.Contains(summary) && (x.Date_Of_Mail.Date >= d1 && x.Date_Of_Mail.Date <= d2))
                                               && (mailnum_bool == 1 || x.Mail_Number == mailnum)).OrderByDescending(x => x.MailID)

                               join ex in dbcon.Sends.Where(x => (x.flag != 0) && (daycheck == 1 || x.Send_time.Date == myday) &&
                               ((x.flag >= mailReaded && x.flag <= mailnot_readed) || mail_accept == true) &&
                                ((x.Send_time.Date >= Day_sended1 && x.Send_time.Date <= Day_sended2 && x.flag == 5) || daysended == true) &&
                          (x.type_of_send == Typeof_send || sendedType_exsist == true))
                          on mail.MailID equals ex.MailID


                               //  join rep in dbcon.Replies on ex.Id equals rep.ReplyId
                               // join cx in dbcon.Replies.Where(x=> x.ReplyId)
                               select new Sended_Maill()
                               {
                                   mail_id = mail.MailID,
                                   State = (ex.flag >= 2) ? "قرأت" : "لم تقرأ",
                                   type_of_mail = mail.Mail_Type,
                                   Mail_Number = mail.Mail_Number,
                                   date = mail.Date_Of_Mail.ToString("yyyy-MM-dd"),
                                   //procedure_type = mail.clasification,
                                   mangment_sender = m.DepartmentName,
                                   Send_time = ex.Send_time.ToString("yyyy-MM-dd"),
                                   time = ex.Send_time.ToString("HH-mm-ss"),
                                   summary = mail.Mail_Summary,
                                   Sends_id = ex.Id



                               }).OrderByDescending(v => v.mail_id).Skip((pagenum - 1) * size).Take(size).ToListAsync();
                pag.Total = c.Count;

                return pag;
            }


            catch (Exception)
            {

                throw;
            }
        }

        public async Task<PagenationSendedEmail<Sended_Maill>> GetAllIncoming(DateTime? myday, int? daycheck, 
            int? mailnum_bool, int? mangment, DateTime? d1, DateTime? d2, int? mailnum, string summary, int? mail_Readed,
            int? mailReaded, int? mailnot_readed, DateTime? Day_sended1, DateTime? Day_sended2, int? Typeof_send
            , int? mail_type, string replaytext, int? userid , int pagenum,int size)
        {
            try
            {



                DateTime day = DateTime.Now;
                bool mail_accept = false;
                bool daysended = false;
                bool sendedType_exsist = false;
                // myday = day.Date;


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

                if (Typeof_send == null)
                {
                    sendedType_exsist = true;
                }
                else
                {
                    sendedType_exsist = false;
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


                   var c  = await(from mail in dbcon.Mails.Where(x => (
                                              x.Mail_Summary.Contains(summary) && (x.Date_Of_Mail.Date >= d1 && x.Date_Of_Mail.Date <= d2))
                                              && (mailnum_bool == 1 || x.Mail_Number == mailnum)).OrderByDescending(x => x.MailID)

                                                            //join Extr in dbcon.Extrenal_Inboxes on mail.MailID equals Extr.MailID
                                                            join ex in dbcon.Sends.Where(x => (x.flag != 0) && x.to == mangment && (daycheck == 1 || x.Send_time.Date == myday) &&
                                                            ((x.flag >= mailReaded && x.flag <= mailnot_readed) || mail_accept == true) &&
                                                   ((x.Send_time.Date >= Day_sended1 && x.Send_time.Date <= Day_sended2 && x.flag == 5) || daysended == true) &&
                                                            (x.type_of_send == Typeof_send || sendedType_exsist == true))
                                                            on mail.MailID equals ex.MailID
                                                             join dx in dbcon.measures on ex.type_of_send equals dx.MeasuresId
                                                            
                                                            
                                                          //  join rep in dbcon.Replies on ex.Id equals rep.ReplyId

                                                            // join cx in dbcon.Replies.Where(x=> x.ReplyId)
                                                            select new Sended_Maill()
                                                            {
                                                                mail_id = mail.MailID,
                                                                State = (ex.flag >= 2) ? "قرأت" : "لم تقرأ",
                                                                type_of_mail = mail.Mail_Type,
                                                                Mail_Number = mail.Mail_Number,
                                                                date = mail.Date_Of_Mail.ToString("yyyy-MM-dd"),
                                                                Masure_type=dx.MeasuresName,                                                                mangment_sender = m.DepartmentName,
                                                                Send_time = ex.Send_time.ToString("yyyy-MM-dd"),
                                                                time = ex.Send_time.ToString("HH-mm-ss"),
                                                                summary = mail.Mail_Summary,
                                                                //sectionName = Extr.section_Name,
                                                                Sends_id = ex.Id



                                                            }).OrderByDescending(v => v.mail_id).ToListAsync();
                pag.mail  = await (from mail in dbcon.Mails.Where(x => (
                                            x.Mail_Summary.Contains(summary) && (x.Date_Of_Mail.Date >= d1 && x.Date_Of_Mail.Date <= d2))
                                            && (mailnum_bool == 1 || x.Mail_Number == mailnum)).OrderByDescending(x => x.MailID)

                                   //join Extr in dbcon.Extrenal_Inboxes on mail.MailID equals Extr.MailID
                               join ex in dbcon.Sends.Where(x => (x.flag != 0) && x.to == mangment && (daycheck == 1 || x.Send_time.Date == myday) &&
                               ((x.flag >= mailReaded && x.flag <= mailnot_readed) || mail_accept == true) &&
                      ((x.Send_time.Date >= Day_sended1 && x.Send_time.Date <= Day_sended2 && x.flag == 5) || daysended == true) &&
                               (x.type_of_send == Typeof_send || sendedType_exsist == true))
                               on mail.MailID equals ex.MailID
                                   join dx in dbcon.measures on ex.type_of_send equals dx.MeasuresId

                                   //  join rep in dbcon.Replies on ex.Id equals rep.ReplyId

                                   // join cx in dbcon.Replies.Where(x=> x.ReplyId)
                                   select new Sended_Maill()
                               {
                                   mail_id = mail.MailID,
                                   State = (ex.flag >= 2) ? "قرأت" : "لم تقرأ",
                                   type_of_mail = mail.Mail_Type,
                                   Mail_Number = mail.Mail_Number,
                                   date = mail.Date_Of_Mail.ToString("yyyy-MM-dd"),
                                   Masure_type= dx.MeasuresName,
                                   mangment_sender = m.DepartmentName,
                                   Send_time = ex.Send_time.ToString("yyyy-MM-dd"),
                                   time = ex.Send_time.ToString("HH-mm-ss"),
                                   summary = mail.Mail_Summary,
                                   Sends_id = ex.Id



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

            var Time_of_read = await dbcon.Sends.OrderBy(x=> x.Id).LastOrDefaultAsync(x => x.MailID == mailid);
            var flag = Time_of_read.flag;

            return flag;

        }

        public async  Task<dynamic> GetDynamic(DateTime? myday, int? daycheck, int? mailnum_bool, 
            int? mangment, DateTime? d1, DateTime? d2, int? mailnum, string summary, 
            int? mail_Readed, int? mailReaded, int? mailnot_readed, DateTime? Day_sended1,
            
            DateTime? Day_sended2, int? Typeof_send, int? userid, int? mailNumType, 
            int? mail_type, string? replaytext, int pagenum, int size)
        {
            var role_id = await dbcon.userRoles.Where(x => x.UserId == userid).ToListAsync();

         //   var user_role_num = role_id.RoleId;

            switch (mailNumType)
            {

                case 0:
                    if (role_id.Any(x => x.RoleId == 10 ))
                    {
                      
                        var c0 = await GetAllIncoming(myday, daycheck, mailnum_bool,
            mangment, d1, d2, mailnum, summary, mail_Readed,
            mailReaded, mailnot_readed, Day_sended1, Day_sended2,
           Typeof_send, mail_type, replaytext, userid, pagenum, size);
                        d = c0;
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
           Typeof_send, mail_type, replaytext, userid,  pagenum,  size);
                        d = c;
                        break;
                    }
                    d = null;
                    break;
                case 2:
                    if (role_id.Any(x => x.RoleId == 10 || x.RoleId == 19))
                    {
                        mail_type =2;

                        var cc = await GetIncomingExtarnelMail(myday, daycheck, mailnum_bool,
            mangment, d1, d2, mailnum, summary, mail_Readed,
            mailReaded, mailnot_readed, Day_sended1, Day_sended2,
           Typeof_send, mail_type, replaytext, userid, pagenum,size);
                        d = cc;
                        break;
                    }
                    d = null;
                    break;

                case 3 :
                    if (role_id.Any(x => x.RoleId == 10 || x.RoleId == 18))
                    {
                        mail_type = 3;
                        var ccc = await GetIncomingExtarnelinbox(myday, daycheck, mailnum_bool,
            mangment, d1, d2, mailnum, summary, mail_Readed,
            mailReaded, mailnot_readed, Day_sended1, Day_sended2,
           Typeof_send, mail_type, replaytext, userid , pagenum,size);
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

        public async Task<PagenationSendedEmail<ExtarnelinboxViewModel>> GetExtarnelinbox(DateTime? myday, int? daycheck,
            int? mailnum_bool, int? mangment, DateTime? d1, DateTime? d2, int? mailnum, string summary, 
            int? mail_Readed, int? mailReaded, int? mailnot_readed, DateTime? Day_sended1, DateTime? Day_sended2,
            int? Typeof_send , int? mail_type ,string? replaytext, int pagenum, int size)
        {
            try
            {
              
               

                DateTime day = DateTime.Now;
                bool mail_accept = false;
                bool daysended = false;
                bool sendedType_exsist = false;
                // myday = day.Date;


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

                if (Typeof_send == null)
                {
                    sendedType_exsist = true;
                }
                else
                {
                    sendedType_exsist = false;
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

                if(replaytext == null)
                {
                    replaytext = " ";
                }
                var m = await dbcon.Departments.FindAsync(mangment);



                PagenationSendedEmail<ExtarnelinboxViewModel> pag = new PagenationSendedEmail<ExtarnelinboxViewModel>();

               var c = await (from mail in dbcon.Mails.Where(x => (x.Department_Id == mangment &&
                                               x.Mail_Summary.Contains(summary) && (x.Date_Of_Mail.Date >= d1 && x.Date_Of_Mail.Date <= d2))
                                               && (mailnum_bool == 1 || x.Mail_Number == mailnum) && x.Mail_Type == mail_type).OrderByDescending(x => x.MailID)

                              join Extr in dbcon.Extrenal_Inboxes on mail.MailID equals Extr.MailID
                              join ex in dbcon.Sends.Where(x => (x.flag != 0) && (daycheck == 1 || x.Send_time.Date == myday) &&
                              ((x.flag >= mailReaded && x.flag <= mailnot_readed) || mail_accept == true) &&
                                   ((x.Send_time.Date >= Day_sended1 && x.Send_time.Date <= Day_sended2 && x.flag == 5) || daysended == true) &&
                              (x.type_of_send == Typeof_send || sendedType_exsist == true))
                              on mail.MailID equals ex.MailID
                              //  join rep in dbcon.Replies on ex.Id equals rep.ReplyId


                              // join cx in dbcon.Replies.Where(x=> x.ReplyId)
                              select new ExtarnelinboxViewModel()
                              {
                                  mail_id = mail.MailID,
                                  State = (ex.flag >= 2) ? "قرأت" : "لم تقرأ",
                                  type_of_mail = mail.Mail_Type,
                                  Mail_Number = mail.Mail_Number,
                                  date = mail.Date_Of_Mail.ToString("yyyy-MM-dd"),
                                  //procedure_type = mail.clasification,
                                  mangment_sender = m.DepartmentName,
                                  Send_time = ex.Send_time.ToString("yyyy-MM-dd"),
                                  time = ex.Send_time.ToString("HH-mm-ss"),
                                  summary = mail.Mail_Summary,
                                  sectionName = Extr.section_Name,
                                  Sends_id = ex.Id



                              }).OrderByDescending(v => v.mail_id).ToListAsync();


                pag.mail   = await (from mail in dbcon.Mails.Where(x => (x.Department_Id == mangment &&
                                               x.Mail_Summary.Contains(summary) && (x.Date_Of_Mail.Date >= d1 && x.Date_Of_Mail.Date <= d2))
                                               && (mailnum_bool == 1 || x.Mail_Number == mailnum) && x.Mail_Type == mail_type).OrderByDescending(x => x.MailID)

                                    join Extr in dbcon.Extrenal_Inboxes on mail.MailID equals Extr.MailID
                                    join ex in dbcon.Sends.Where(x => (x.flag != 0) && (daycheck == 1 || x.Send_time.Date == myday) &&
                                    ((x.flag >= mailReaded && x.flag <= mailnot_readed) || mail_accept == true) &&
                                         ((x.Send_time.Date >= Day_sended1 && x.Send_time.Date <= Day_sended2 && x.flag == 5) || daysended == true) &&
                                    (x.type_of_send == Typeof_send || sendedType_exsist == true))
                                    on mail.MailID equals ex.MailID
                                    //  join rep in dbcon.Replies on ex.Id equals rep.ReplyId


                                    // join cx in dbcon.Replies.Where(x=> x.ReplyId)
                                    select new ExtarnelinboxViewModel()
                                    {
                                        mail_id = mail.MailID,
                                        State = (ex.flag >= 2) ? "قرأت" : "لم تقرأ",
                                        type_of_mail = mail.Mail_Type,
                                        Mail_Number = mail.Mail_Number,
                                        date = mail.Date_Of_Mail.ToString("yyyy-MM-dd"),
                                       // procedure_type = mail.clasification,
                                        mangment_sender = m.DepartmentName,
                                        Send_time = ex.Send_time.ToString("yyyy-MM-dd"),
                                        time = ex.Send_time.ToString("HH-mm-ss"),
                                        summary = mail.Mail_Summary,
                                        sectionName = Extr.section_Name,
                                        Sends_id = ex.Id



                                    }).OrderByDescending(v => v.mail_id).Skip((pagenum - 1) * size).Take(size).ToListAsync();

                pag.Total = c.Count;

                return pag;
                }
            
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<PagenationSendedEmail<ExtarnelinboxViewModel>> GetExtarnelMail(DateTime? myday, int? daycheck, int? mailnum_bool,
            int? mangment, DateTime? d1, DateTime? d2, int? mailnum, string? summary, int? mail_Readed,
            int? mailReaded, int? mailnot_readed, DateTime? Day_sended1, DateTime? Day_sended2, int?
            Typeof_send, int? mail_type , string? replaytext, int pagenum, int size)
        {
            try
            {
               

                DateTime day = DateTime.Now;
                bool mail_accept = false;
                bool daysended = false;
                bool sendedType_exsist = false;
                // myday = day.Date;

                

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

                if (Typeof_send == null)
                {
                    sendedType_exsist = true;
                }
                else
                {
                    sendedType_exsist = false;
                }

                //if(mailNumType == 1 && (user_role_num ==  10 || user_role_num  == 17) )
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
                //else if (mailNumType == 2 && (user_role_num == 19 || user_role_num== 10))
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
                                               && (mailnum_bool == 1 || x.Mail_Number == mailnum) && x.Mail_Type == mail_type).OrderByDescending(x => x.MailID)

                                               join Extr in dbcon.External_Mails on mail.MailID equals Extr.MailID
                                               join ex in dbcon.Sends.Where(x => (x.flag !=0) && (daycheck == 1 || x.Send_time.Date == myday) &&
                                               ((x.flag >= mailReaded && x.flag <=  mailnot_readed) || mail_accept == true) &&
                                                    ((x.Send_time.Date >= Day_sended1 && x.Send_time.Date <= Day_sended2 && x.flag == 5) || daysended == true) &&
                                               (x.type_of_send == Typeof_send || sendedType_exsist == true))
                                               on mail.MailID equals ex.MailID
                                                       //  join rep in dbcon.Replies on ex.Id equals rep.ReplyId


                                                         // join cx in dbcon.Replies.Where(x=> x.ReplyId)
                                                         select new ExtarnelinboxViewModel()
                                               {
                                                   mail_id = mail.MailID,
                                                   State = (ex.flag >= 2) ? "قرأت" : "لم تقرأ",
                                                   type_of_mail = mail.Mail_Type,
                                                   Mail_Number = mail.Mail_Number,
                                                   date = mail.Date_Of_Mail.ToString("yyyy-MM-dd"),
                                                   //procedure_type = mail.clasification,
                                                   mangment_sender = m.DepartmentName,
                                                   Send_time = ex.Send_time.ToString("yyyy-MM-dd"),
                                                   time = ex.Send_time.ToString("HH-mm-ss"),
                                                   summary = mail.Mail_Summary,
                                                   sectionName= Extr.sectionName,
                                                   Sends_id = ex.Id



                                               }).OrderByDescending(v => v.mail_id).ToListAsync();

                pag.mail = await (from mail in dbcon.Mails.Where(x => (x.Department_Id == mangment &&
                                               x.Mail_Summary.Contains(summary) && (x.Date_Of_Mail.Date >= d1 && x.Date_Of_Mail.Date <= d2))
                                               && (mailnum_bool == 1 || x.Mail_Number == mailnum) && x.Mail_Type == mail_type).OrderByDescending(x => x.MailID)

                                  join Extr in dbcon.External_Mails on mail.MailID equals Extr.MailID
                                  join ex in dbcon.Sends.Where(x => (x.flag != 0) && (daycheck == 1 || x.Send_time.Date == myday) &&
                                  ((x.flag >= mailReaded && x.flag <= mailnot_readed) || mail_accept == true) &&
                                       ((x.Send_time.Date >= Day_sended1 && x.Send_time.Date <= Day_sended2 && x.flag == 5) || daysended == true) &&
                                  (x.type_of_send == Typeof_send || sendedType_exsist == true))
                                  on mail.MailID equals ex.MailID
                                  //  join rep in dbcon.Replies on ex.Id equals rep.ReplyId


                                  // join cx in dbcon.Replies.Where(x=> x.ReplyId)
                                  select new ExtarnelinboxViewModel()
                                  {
                                      mail_id = mail.MailID,
                                      State = (ex.flag >= 2) ? "قرأت" : "لم تقرأ",
                                      type_of_mail = mail.Mail_Type,
                                      Mail_Number = mail.Mail_Number,
                                      date = mail.Date_Of_Mail.ToString("yyyy-MM-dd"),
                                     // procedure_type = mail.clasification,
                                      mangment_sender = m.DepartmentName,
                                      Send_time = ex.Send_time.ToString("yyyy-MM-dd"),
                                      time = ex.Send_time.ToString("HH-mm-ss"),
                                      summary = mail.Mail_Summary,
                                      sectionName = Extr.sectionName,
                                      Sends_id = ex.Id



                                  }).OrderByDescending(v => v.mail_id).Skip((pagenum - 1) * size).Take(size).ToListAsync();

                pag.Total = c.Count;

                return pag;
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




                var c2 = await(from mail in dbcon.Mails.Where(x => x.Department_Id == depid && x.Mail_Type== 2)
                               join y in dbcon.Sends.Where(n => n.flag !=0) on mail.MailID equals y.MailID
                               join Extr in dbcon.External_Mails on mail.MailID equals Extr.MailID

                               select new ExtarnelinboxViewModel()
                               {
                                   mail_id = mail.MailID,
                                   State = (y.flag >=2) ? "قرأت" : "لم تقرأ",
                                   type_of_mail = mail.Mail_Type,
                                   Mail_Number = mail.Mail_Number,
                                   date = mail.Date_Of_Mail.ToString("yyyy-MM-dd"),
                                   //procedure_type = mail.clasification,
                                   mangment_sender = m.DepartmentName,
                                   Send_time = y.Send_time.ToString("yyyy-MM-dd"),
                                   time = y.Send_time.ToString("HH-mm-ss"),
                                   summary = mail.Mail_Summary,
                                   Sends_id = y.Id,
                                   sectionName=Extr.sectionName



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




                var c2 = await(from mail in dbcon.Mails.Where(x => x.Department_Id == depid && x.Mail_Type == 2)
                               join y in dbcon.Sends.Where(n => n.flag != 0) on mail.MailID equals y.MailID
                               join Extr in dbcon.External_Mails on mail.MailID equals Extr.MailID

                               select new ExtarnelinboxViewModel()
                               {
                                   mail_id = mail.MailID,
                                   State = (y.flag >= 2) ? "قرأت" : "لم تقرأ",
                                   type_of_mail = mail.Mail_Type,
                                   Mail_Number = mail.Mail_Number,
                                   date = mail.Date_Of_Mail.ToString("yyyy-MM-dd"),
                                   //procedure_type = mail.clasification,
                                   mangment_sender = m.DepartmentName,
                                   Send_time = y.Send_time.ToString("yyyy-MM-dd"),
                                   time = y.Send_time.ToString("HH-mm-ss"),
                                   summary = mail.Mail_Summary,
                                   Sends_id = y.Id,
                                   sectionName=Extr.sectionName



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


               


                var c2 = await(from mail in dbcon.Mails.Where(x => x.Department_Id == depid && x.Mail_Type == 3)
                               join y in dbcon.Sends on mail.MailID equals y.MailID
                               join Extr in dbcon.Extrenal_Inboxes on mail.MailID equals Extr.MailID

                               select new ExtarnelinboxViewModel()
                               {
                                   mail_id = mail.MailID,
                                   State = (y.flag >= 2) ? "قرأت" : "لم تقرأ",
                                   type_of_mail = mail.Mail_Type,
                                   Mail_Number = mail.Mail_Number,
                                   date = mail.Date_Of_Mail.ToString("yyyy-MM-dd"),
                                   //procedure_type = mail.clasification,
                                   mangment_sender = m.DepartmentName,
                                   Send_time = y.Send_time.ToString("yyyy-MM-dd"),
                                   time = y.Send_time.ToString("HH-mm-ss"),
                                   summary = mail.Mail_Summary,
                                   Sends_id = y.Id,
                                   sectionName=Extr.section_Name



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

                                select new ExtarnelinboxViewModel()
                                {
                                    mail_id = mail.MailID,
                                    State = (y.flag >= 2) ? "قرأت" : "لم تقرأ",
                                    type_of_mail = mail.Mail_Type,
                                    Mail_Number = mail.Mail_Number,
                                    date = mail.Date_Of_Mail.ToString("yyyy-MM-dd"),
                                    //procedure_type = mail.clasification,
                                    mangment_sender = m.DepartmentName,
                                    Send_time = y.Send_time.ToString("yyyy-MM-dd"),
                                    time = y.Send_time.ToString("HH-mm-ss"),
                                    summary = mail.Mail_Summary,
                                    Sends_id = y.Id,
                                    sectionName=Extr.section_Name



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
           Typeof_send, int? mail_type, string? replaytext, int? userid ,int pagenum,int size)
        {
            try
            {


                DateTime day = DateTime.Now;
                bool mail_accept = false;
                bool daysended = false;
                bool sendedType_exsist = false;
                // myday = day.Date;

               

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

                if (Typeof_send == null)
                {
                    sendedType_exsist = true;
                }
                else
                {
                    sendedType_exsist = false;
                }

                //if (user_role_num == 10)
                //{
                //    mail_type = "خ";
                //}
                //else if (user_role_num == 17)
                //{
                //    mail_type = "داخلي";
                //}
                //else if (user_role_num == 18)
                //{
                //    mail_type = "وارد خارجي";
                //}
                //else if (user_role_num == 19)
                //{
                //    mail_type = "صادر خارجي";
                //}
                //if (replaytext == null)
                //{
                //    replaytext = " ";
                //}
             

                var m = await dbcon.Departments.FindAsync(mangment);


                PagenationSendedEmail<ExtarnelinboxViewModel> pag = new PagenationSendedEmail<ExtarnelinboxViewModel>();

               var c = await (from mail in dbcon.Mails.Where(x => (
                                               x.Mail_Summary.Contains(summary) && (x.Date_Of_Mail.Date >= d1 && x.Date_Of_Mail.Date <= d2))
                                               && (mailnum_bool == 1 || x.Mail_Number == mailnum) && x.Mail_Type==mail_type).OrderByDescending(x => x.MailID)

                                                         join Extr in dbcon.Extrenal_Inboxes on mail.MailID equals Extr.MailID

                                                         join ex in dbcon.Sends.Where(x => (x.flag != 0) && x.to == mangment && (daycheck == 1 || x.Send_time.Date == myday) &&
                                               ((x.flag >= mailReaded && x.flag <=  mailnot_readed) || mail_accept == true) &&
                                               ((x.Send_time.Date >= Day_sended1 && x.Send_time.Date <= Day_sended2 && x.flag == 5) || daysended == true) &&
                                               (x.type_of_send == Typeof_send || sendedType_exsist == true))
                                               on mail.MailID equals ex.MailID
                              join dx in dbcon.measures on ex.type_of_send equals dx.MeasuresId

                              // join rep in dbcon.Replies on ex.Id equals rep.ReplyId
                              // join cx in dbcon.Replies.Where(x=> x.ReplyId)
                              select new ExtarnelinboxViewModel()
                                                         {
                                                             mail_id = mail.MailID,
                                                             State = (ex.flag >= 2) ? "قرأت" : "لم تقرأ",
                                                             type_of_mail = mail.Mail_Type,
                                                             Mail_Number = mail.Mail_Number,
                                                             date = mail.Date_Of_Mail.ToString("yyyy-MM-dd"),
                                                             Masure_type=dx.MeasuresName,
                                                             mangment_sender = m.DepartmentName,
                                                             Send_time = ex.Send_time.ToString("yyyy-MM-dd"),
                                                             time = ex.Send_time.ToString("HH-mm-ss"),
                                                             summary = mail.Mail_Summary,
                                                             Sends_id = ex.Id,
                                                           //  sectionName=Extr.section_Name



                                                         }).OrderByDescending(v => v.mail_id).ToListAsync();

                pag.mail = await (from mail in dbcon.Mails.Where(x => (
                                             x.Mail_Summary.Contains(summary) && (x.Date_Of_Mail.Date >= d1 && x.Date_Of_Mail.Date <= d2))
                                             && (mailnum_bool == 1 || x.Mail_Number == mailnum) && x.Mail_Type == mail_type).OrderByDescending(x => x.MailID)

                               join Extr in dbcon.Extrenal_Inboxes on mail.MailID equals Extr.MailID

                               join ex in dbcon.Sends.Where(x => (x.flag != 0) && x.to == mangment && (daycheck == 1 || x.Send_time.Date == myday) &&
                     ((x.flag >= mailReaded && x.flag <= mailnot_readed) || mail_accept == true) &&
                     ((x.Send_time.Date >= Day_sended1 && x.Send_time.Date <= Day_sended2 && x.flag == 5) || daysended == true) &&
                     (x.type_of_send == Typeof_send || sendedType_exsist == true))
                     on mail.MailID equals ex.MailID
                                  join dx in dbcon.measures on ex.type_of_send equals dx.MeasuresId

                                  // join rep in dbcon.Replies on ex.Id equals rep.ReplyId
                                  // join cx in dbcon.Replies.Where(x=> x.ReplyId)
                                  select new ExtarnelinboxViewModel()
                               {
                                   mail_id = mail.MailID,
                                   State = (ex.flag >= 2) ? "قرأت" : "لم تقرأ",
                                   type_of_mail = mail.Mail_Type,
                                   Mail_Number = mail.Mail_Number,
                                   date = mail.Date_Of_Mail.ToString("yyyy-MM-dd"),
                                   Masure_type=dx.MeasuresName,
                                   mangment_sender = m.DepartmentName,
                                   Send_time = ex.Send_time.ToString("yyyy-MM-dd"),
                                   time = ex.Send_time.ToString("HH-mm-ss"),
                                   summary = mail.Mail_Summary,
                                   Sends_id = ex.Id,
                                  // sectionName = Extr.section_Name



                               }).OrderByDescending(v => v.mail_id).Skip((pagenum - 1) * size).Take(size).ToListAsync();
                pag.Total = c.Count;

                return pag;
            }
            
            catch (Exception)
            {

                throw;
            }
        }

        public async Task <PagenationSendedEmail<ExtarnelinboxViewModel>> GetIncomingExtarnelMail(DateTime? myday, int? daycheck, int? mailnum_bool,
           int? mangment, DateTime? d1, DateTime? d2, int? mailnum, string? summary, int? mail_Readed,
           int? mailReaded, int? mailnot_readed, DateTime? Day_sended1, DateTime? Day_sended2, int?
           Typeof_send, int? mail_type, string? replaytext, int? userid ,int pagenum ,int size)
        {
            try
            {


                DateTime day = DateTime.Now;
                bool mail_accept = false;
                bool daysended = false;
                bool sendedType_exsist = false;
                // myday = day.Date;

               

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

                if (Typeof_send == null)
                {
                    sendedType_exsist = true;
                }
                else
                {
                    sendedType_exsist = false;
                }

                //if (user_role_num == 10)
                //{
                //    mail_type = "خ";
                //}
                //else if (user_role_num == 17)
                //{
                //    mail_type = "داخلي";
                //}
                //else if (user_role_num == 18)
                //{
                //    mail_type = "وارد خارجي";
                //}
                //else if (user_role_num == 19)
                //{
                //    mail_type = "صادر خارجي";
                //}
                //if (replaytext == null)
                //{
                //    replaytext = " ";
                //}
               

                var m = await dbcon.Departments.FindAsync(mangment);


                PagenationSendedEmail<ExtarnelinboxViewModel> pag = new PagenationSendedEmail<ExtarnelinboxViewModel>();

                


               var c = await (from mail in dbcon.Mails.Where(x => (
                                               x.Mail_Summary.Contains(summary) && (x.Date_Of_Mail.Date >= d1 && x.Date_Of_Mail.Date <= d2))
                                               && (mailnum_bool == 1 || x.Mail_Number == mailnum) && x.Mail_Type == mail_type).OrderByDescending(x => x.MailID)

                                                         join Extr in dbcon.External_Mails on mail.MailID equals Extr.MailID

                                                         join ex in dbcon.Sends.Where(x => (x.flag !=0) && x.to == mangment && (daycheck == 1 || x.Send_time.Date == myday) &&
                                               ((x.flag >= mailReaded && x.flag <=  mailnot_readed) || mail_accept == true) &&
                                               ((x.Send_time.Date >= Day_sended1 && x.Send_time.Date <= Day_sended2 && x.flag == 5) || daysended == true) &&
                                               (x.type_of_send == Typeof_send || sendedType_exsist == true))
                                               on mail.MailID equals ex.MailID
                              join dx in dbcon.measures on ex.type_of_send equals dx.MeasuresId

                              // join rep in dbcon.Replies on ex.Id equals rep.ReplyId
                              // join cx in dbcon.Replies.Where(x=> x.ReplyId)
                              select new ExtarnelinboxViewModel()
                                               {
                                                   mail_id = mail.MailID,
                                                   State = (ex.flag >= 2) ? "قرأت" : "لم تقرأ",
                                                   type_of_mail = mail.Mail_Type,
                                                   Mail_Number = mail.Mail_Number,
                                                   date = mail.Date_Of_Mail.ToString("yyyy-MM-dd"),
                                                   Masure_type=dx.MeasuresName,
                                                   mangment_sender = m.DepartmentName,
                                                   Send_time = ex.Send_time.ToString("yyyy-MM-dd"),
                                                   time = ex.Send_time.ToString("HH-mm-ss"),
                                                   summary = mail.Mail_Summary,
                                                   Sends_id = ex.Id,
                                                  // sectionName=Extr.sectionName



                                               }).OrderByDescending(v => v.mail_id).ToListAsync();

               pag.mail = await (from mail in dbcon.Mails.Where(x => (
                                              x.Mail_Summary.Contains(summary) && (x.Date_Of_Mail.Date >= d1 && x.Date_Of_Mail.Date <= d2))
                                              && (mailnum_bool == 1 || x.Mail_Number == mailnum) && x.Mail_Type == mail_type).OrderByDescending(x => x.MailID)

                               join Extr in dbcon.External_Mails on mail.MailID equals Extr.MailID

                               join ex in dbcon.Sends.Where(x => (x.flag != 0) && x.to == mangment && (daycheck == 1 || x.Send_time.Date == myday) &&
                     ((x.flag >= mailReaded && x.flag <= mailnot_readed) || mail_accept == true) &&
                     ((x.Send_time.Date >= Day_sended1 && x.Send_time.Date <= Day_sended2 && x.flag == 5) || daysended == true) &&
                     (x.type_of_send == Typeof_send || sendedType_exsist == true))
                     on mail.MailID equals ex.MailID
                                 join dx in dbcon.measures on ex.type_of_send equals dx.MeasuresId

                                 // join rep in dbcon.Replies on ex.Id equals rep.ReplyId
                                 // join cx in dbcon.Replies.Where(x=> x.ReplyId)
                                 select new ExtarnelinboxViewModel()
                               {
                                   mail_id = mail.MailID,
                                   State = (ex.flag >= 2) ? "قرأت" : "لم تقرأ",
                                   type_of_mail = mail.Mail_Type,
                                   Mail_Number = mail.Mail_Number,
                                   date = mail.Date_Of_Mail.ToString("yyyy-MM-dd"),
                                   Masure_type=dx.MeasuresName,
                                   mangment_sender = m.DepartmentName,
                                   Send_time = ex.Send_time.ToString("yyyy-MM-dd"),
                                   time = ex.Send_time.ToString("HH-mm-ss"),
                                   summary = mail.Mail_Summary,
                                   Sends_id = ex.Id,
                                 //  sectionName = Extr.sectionName



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
            int? mailnum_bool, int? mangment, DateTime? d1, DateTime? d2, int? mailnum, string ? summary, 
            int? mail_Readed, int? mailReaded, int? mailnot_readed, DateTime? Day_sended1,
            DateTime? Day_sended2, int? Typeof_send, int? mail_type, string? replaytext , int? userid , int pagenum, int size)
        {
            try
            {


                DateTime day = DateTime.Now;
                bool mail_accept = false;
                bool daysended = false;
                bool sendedType_exsist = false;
                // myday = day.Date;

                

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

                if (Typeof_send == null)
                {
                    sendedType_exsist = true;
                }
                else
                {
                    sendedType_exsist = false;
                }

                //if (user_role_num == 10)
                //{
                //    mail_type = "خ";
                //}
                //else if (user_role_num == 17)
                //{
                //    mail_type = "داخلي";
                //}
                //else if (user_role_num == 18)
                //{
                //    mail_type = "وارد خارجي";
                //}
                //else if (user_role_num == 19)
                //{
                //    mail_type = "صادر خارجي";
                //}
                //if (replaytext == null)
                //{
                //    replaytext = " ";
                //}

                PagenationSendedEmail<Sended_Maill> pag = new PagenationSendedEmail<Sended_Maill>();

                var m = await dbcon.Departments.FindAsync(mangment);

               

                

                var c = await(from mail in dbcon.Mails.Where(x => (
                                              x.Mail_Summary.Contains(summary) && (x.Date_Of_Mail.Date >= d1 && x.Date_Of_Mail.Date <= d2))
                                              && (mailnum_bool == 1 || x.Mail_Number == mailnum) && x.Mail_Type == mail_type).OrderByDescending(x => x.MailID)

                                              join ex in dbcon.Sends.Where(x => (x.flag != 0) && x.to == mangment && (daycheck == 1 || x.Send_time.Date == myday) &&
                                              ((x.flag >= mailReaded && x.flag <=  mailnot_readed) || mail_accept == true) &&
                                              ((x.Send_time.Date >= Day_sended1 && x.Send_time.Date <= Day_sended2 && x.flag == 5) || daysended == true) &&
                                              (x.type_of_send == Typeof_send || sendedType_exsist == true))
                                              on mail.MailID equals ex.MailID
                                              join dx in dbcon.measures on ex.type_of_send equals dx.MeasuresId

                                             // join rep in dbcon.Replies on ex.Id equals rep.ReplyId
                                              // join cx in dbcon.Replies.Where(x=> x.ReplyId)
                                              select new Sended_Maill()
                                              {
                                                  mail_id = mail.MailID,
                                                  State = (ex.flag >= 2) ? "قرأت" : "لم تقرأ",
                                                  type_of_mail = mail.Mail_Type,
                                                  Mail_Number = mail.Mail_Number,
                                                  date = mail.Date_Of_Mail.ToString("yyyy-MM-dd"),
                                                  Masure_type=dx.MeasuresName,
                                                  mangment_sender = m.DepartmentName,
                                                  Send_time = ex.Send_time.ToString("yyyy-MM-dd"),
                                                  time = ex.Send_time.ToString("HH-mm-ss"),
                                                  summary = mail.Mail_Summary,
                                                  Sends_id = ex.Id



                                              }).OrderByDescending(v => v.mail_id).ToListAsync();

               pag.mail = await (from mail in dbcon.Mails.Where(x => (
                                            x.Mail_Summary.Contains(summary) && (x.Date_Of_Mail.Date >= d1 && x.Date_Of_Mail.Date <= d2))
                                            && (mailnum_bool == 1 || x.Mail_Number == mailnum) && x.Mail_Type == mail_type).OrderByDescending(x => x.MailID)

                               join ex in dbcon.Sends.Where(x => (x.flag != 0) && x.to == mangment && (daycheck == 1 || x.Send_time.Date == myday) &&
                               ((x.flag >= mailReaded && x.flag <= mailnot_readed) || mail_accept == true) &&
                               ((x.Send_time.Date >= Day_sended1 && x.Send_time.Date <= Day_sended2 && x.flag == 5) || daysended == true) &&
                               (x.type_of_send == Typeof_send || sendedType_exsist == true))
                               on mail.MailID equals ex.MailID
                               join dx in dbcon.measures on ex.type_of_send equals dx.MeasuresId

                                 // join rep in dbcon.Replies on ex.Id equals rep.ReplyId
                                 // join cx in dbcon.Replies.Where(x=> x.ReplyId)
                                 select new Sended_Maill()
                               {
                                   mail_id = mail.MailID,
                                   State = (ex.flag >= 2) ? "قرأت" : "لم تقرأ",
                                   type_of_mail = mail.Mail_Type,
                                   Mail_Number = mail.Mail_Number,
                                   date = mail.Date_Of_Mail.ToString("yyyy-MM-dd"),
                                   Masure_type=dx.MeasuresName,
                                   mangment_sender = m.DepartmentName,
                                   Send_time = ex.Send_time.ToString("yyyy-MM-dd"),
                                   time = ex.Send_time.ToString("HH-mm-ss"),
                                   summary = mail.Mail_Summary,
                                   Sends_id = ex.Id



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
            Typeof_send, int? userid, int? mailNumType , int? mail_type , string? replaytext ,int pagenum,int size)
        {


            try
            {
                var role_id = await dbcon.userRoles.Where(x => x.UserId == userid).ToListAsync();


                switch (mailNumType)
                {
                    case 0:
                        if (role_id.Any(x => x.RoleId == 10 ))
                        {
                            var internel = await GetAll( myday,  daycheck,  mailnum_bool,
          mangment,  d1,  d2, mailnum,  summary,  mail_Readed,
          mailReaded,  mailnot_readed,  Day_sended1,  Day_sended2, 
         Typeof_send,  mail_type,  replaytext,  userid, pagenum,size);
                            d = internel;
                        }
                        break;


                    case 1: if(role_id.Any(x => x.RoleId == 10 || x.RoleId == 17))
                        {
                            mail_type = 1;
                            var internel = await GetSendedMail(myday, daycheck, mailnum_bool,
              mangment, d1, d2, mailnum, summary, mail_Readed,
              mailReaded, mailnot_readed, Day_sended1, Day_sended2,
             Typeof_send , mail_type , replaytext,  pagenum,  size);
                            d = internel;
                        }

                        break;

                    case 2: if(role_id.Any(x => x.RoleId == 10 || x.RoleId == 19))
                        {
                            mail_type = 2;
                            var extr = await GetExtarnelMail(myday, daycheck, mailnum_bool,
                mangment, d1, d2, mailnum, summary, mail_Readed,
                mailReaded, mailnot_readed, Day_sended1, Day_sended2,
               Typeof_send , mail_type , replaytext, pagenum,size);
                            d = extr;
                        }

                      
                        break;

                    case 3:
                        if (role_id.Any(x => x.RoleId == 10 || x.RoleId == 18))
                        {
                            mail_type = 3;
                            var extrinbox = await GetExtarnelinbox(myday, daycheck, mailnum_bool,
                                            mangment, d1, d2, mailnum, summary, mail_Readed,
                                            mailReaded, mailnot_readed, Day_sended1, Day_sended2,
                                           Typeof_send, mail_type , replaytext,pagenum,size);
                            d = extrinbox;
                        }
                        break;
                    default:break;
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


                var c2 = await (from mail in dbcon.Mails.Where(x => x.Department_Id == depid && x.Mail_Type==1)
                               join y in dbcon.Sends.Where(n => n.flag !=0) on mail.MailID equals y.MailID
                               select new Sended_Maill()
                               {
                                   mail_id = mail.MailID,
                                   State = (y.flag >= 2) ? "قرأت" : "لم تقرأ",
                                   type_of_mail = mail.Mail_Type,
                                   Mail_Number = mail.Mail_Number,
                                   date = mail.Date_Of_Mail.ToString("yyyy-MM-dd"),
                                   //procedure_type = mail.clasification,
                                   mangment_sender = m.DepartmentName,
                                   Send_time = y.Send_time.ToString("yyyy-MM-dd"),
                                   time = y.Send_time.ToString("HH-mm-ss"),
                                   summary = mail.Mail_Summary,
                                   Sends_id = y.Id



                               }).OrderByDescending(v => v.mail_id).ToListAsync();
                pag.Total = c2.Count;
                pag.mail =  c2.OrderByDescending(v => v.mail_id).Skip((pagenum - 1) * size).Take(size).ToList();
                
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


                var c2 = await(from mail in dbcon.Mails.Where(x => x.Department_Id == depid && x.Mail_Type == 1)
                               join y in dbcon.Sends.Where(n => n.flag != 0) on mail.MailID equals y.MailID
                               select new Sended_Maill()
                               {
                                   mail_id = mail.MailID,
                                   State = (y.flag >= 2) ? "قرأت" : "لم تقرأ",
                                   type_of_mail = mail.Mail_Type,
                                   Mail_Number = mail.Mail_Number,
                                   date = mail.Date_Of_Mail.ToString("yyyy-MM-dd"),
                                   //procedure_type = mail.clasification,
                                   mangment_sender = m.DepartmentName,
                                   Send_time = y.Send_time.ToString("yyyy-MM-dd"),
                                   time = y.Send_time.ToString("HH-mm-ss"),
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

        public async Task <PagenationSendedEmail <Sended_Maill>> GetSendedMail(DateTime? myday, int? daycheck, int? mailnum_bool, int? mangment,
            DateTime? d1, DateTime? d2, int? mailnum, string summary,
            int? mail_Readed, int? mailReaded, int? mailnot_readed,
            DateTime? Day_sended1, DateTime? Day_sended2, int? Typeof_send , int? mail_type ,
            string? replaytext, int pagenum, int size)
        {

            try
            {
               

                DateTime day = DateTime.Now;
                bool mail_accept = false;
                bool daysended = false;
                bool sendedType_exsist = false;
                // myday = day.Date;

              if(mangment == null)
                { mangment = 1; }

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

                if (Typeof_send == null)
                {
                    sendedType_exsist = true;
                }
                else
                {
                    sendedType_exsist = false;
                }

                //if (user_role_num == 10)
                //{
                //    mail_type = "خ";
                //}
                //else if (user_role_num == 17)
                //{
                //    mail_type = "داخلي";
                //}
                //else if (user_role_num == 18)
                //{
                //    mail_type = "وارد خارجي";
                //}
                //else if (user_role_num == 19)
                //{
                //    mail_type = "صادر خارجي";
                //}
                //if (replaytext == null)
                //{
                //    replaytext = " ";
                //}

                var m = await dbcon.Departments.FindAsync(mangment);



                PagenationSendedEmail<Sended_Maill> pag = new PagenationSendedEmail<Sended_Maill>();

                    var c = await (from mail in dbcon.Mails.Where(x => (x.Department_Id == mangment &&
                                                   x.Mail_Summary.Contains(summary) && (x.Date_Of_Mail.Date >= d1 && x.Date_Of_Mail.Date <= d2))
                                                   && (mailnum_bool == 1 || x.Mail_Number == mailnum) && x.Mail_Type == mail_type).OrderByDescending(x => x.MailID)

                                                   join ex in dbcon.Sends.Where(x => (x.flag !=0) && (daycheck == 1 || x.Send_time.Date == myday) &&
                                                   ((x.flag >= mailReaded && x.flag <= mailnot_readed) || mail_accept == true) &&
                                                    ((x.Send_time.Date >= Day_sended1 && x.Send_time.Date <= Day_sended2 && x.flag == 5) || daysended == true) &&
                                              (x.type_of_send == Typeof_send || sendedType_exsist == true))
                                              on mail.MailID equals ex.MailID
                                                  

                                                 //  join rep in dbcon.Replies on ex.Id equals rep.ReplyId
                                                   // join cx in dbcon.Replies.Where(x=> x.ReplyId)
                                                   select new Sended_Maill()
                                                   {
                                                       mail_id = mail.MailID,
                                                       State = (ex.flag >= 2) ? "قرأت" : "لم تقرأ",
                                                       type_of_mail = mail.Mail_Type,
                                                       Mail_Number = mail.Mail_Number,
                                                       date = mail.Date_Of_Mail.ToString("yyyy-MM-dd"),
                                                      // procedure_type = mail.clasification,
                                                       mangment_sender = m.DepartmentName,
                                                       Send_time = ex.Send_time.ToString("yyyy-MM-dd"),
                                                       time = ex.Send_time.ToString("HH-mm-ss"),
                                                       summary = mail.Mail_Summary,
                                                       Sends_id = ex.Id



                                                   }).OrderByDescending(v => v.mail_id).ToListAsync();



                pag.mail = await (from mail in dbcon.Mails.Where(x => (x.Department_Id == mangment &&
                                               x.Mail_Summary.Contains(summary) && (x.Date_Of_Mail.Date >= d1 && x.Date_Of_Mail.Date <= d2))
                                               && (mailnum_bool == 1 || x.Mail_Number == mailnum) && x.Mail_Type == mail_type).OrderByDescending(x => x.MailID)

                               join ex in dbcon.Sends.Where(x => (x.flag != 0) && (daycheck == 1 || x.Send_time.Date == myday) &&
                               ((x.flag >= mailReaded && x.flag <= mailnot_readed) || mail_accept == true) &&
                                ((x.Send_time.Date >= Day_sended1 && x.Send_time.Date <= Day_sended2 && x.flag == 5) || daysended == true) &&
                          (x.type_of_send == Typeof_send || sendedType_exsist == true))
                          on mail.MailID equals ex.MailID


                               //  join rep in dbcon.Replies on ex.Id equals rep.ReplyId
                               // join cx in dbcon.Replies.Where(x=> x.ReplyId)
                               select new Sended_Maill()
                               {
                                   mail_id = mail.MailID,
                                   State = (ex.flag >= 2) ? "قرأت" : "لم تقرأ",
                                   type_of_mail = mail.Mail_Type,
                                   Mail_Number = mail.Mail_Number,
                                   date = mail.Date_Of_Mail.ToString("yyyy-MM-dd"),
                                  // procedure_type = mail.clasification,
                                   mangment_sender = m.DepartmentName,
                                   Send_time = ex.Send_time.ToString("yyyy-MM-dd"),
                                   time = ex.Send_time.ToString("HH-mm-ss"),
                                   summary = mail.Mail_Summary,
                                   Sends_id = ex.Id



                               }).OrderByDescending(v => v.mail_id).Skip((pagenum - 1) * size).Take(size).ToListAsync();


                pag.Total = c.Count;

                return pag;
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

        public async Task<int> GetFlag(int mail_id, int department_Id)
        {


            var c = await dbcon.Sends.LastOrDefaultAsync(x => x.MailID == mail_id&&department_Id==x.to);
            if (c != null) {
                c.flag = 2;
                dbcon.Sends.Update(c);
                await dbcon.SaveChangesAsync();
                return c.flag;
            }
            return 0;


            return c.flag;

        }
    }
}