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


        public async Task<PagenationSendedEmail<Sended_Maill>> GetAll(int? mailnum_bool,
            int? mangment, DateTime? d1, DateTime? d2, int? mailnum, string? summary, int? mail_Readed,
            int? mailReaded, int? mailnot_readed, int? Typeof_send, int? mail_type, int? userid, int pagenum,
            int? mailNumType, int size, int? Measure_filter, int? Department_filter, int? Classfication, int? mail_state,
            int? genral_incoming_num, int? TheSection, bool? Replay_Date, int? office_type)
        {
            try
            {


                bool dep_filter = false;
                bool clasf_filter = false;
                bool meas_filter = false;
                bool incoing_num_filter = false;
                bool mail_accept = false;
                bool State_filter = false;
                bool mangmentrole = false;
                bool rep_all = false;
                bool officetype = true;
                int tomang;
                bool allmailtype = false;
                bool sectionstate = false;

                if ((mangment == 21 || mangment == 22) && office_type != null)
                {
                    officetype = false;
                }
                else { officetype = true; }

                if (genral_incoming_num != null && mangment == 21)
                {
                    mangmentrole = true;
                }
                else
                {
                    mangmentrole = false;
                }



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
                    tomang = 1;

                }
                else
                {
                    dep_filter = false;
                    tomang = 0;
                }


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


                if (Replay_Date == null || Replay_Date == false)
                {
                    rep_all = true;

                }
                else
                {
                    rep_all = false;

                }

                if (mailNumType == 0)
                {
                    allmailtype = true;
                }
                else
                {
                    allmailtype = false;
                }
                if (mailNumType == 1)
                { TheSection = null; }

                if (TheSection == null)
                {
                    sectionstate = true;
                }
                else
                {
                    sectionstate = false;
                }

                var m = await dbcon.Departments.FindAsync(mangment);

                PagenationSendedEmail<Sended_Maill> pag = new PagenationSendedEmail<Sended_Maill>();


                //chang where to firs or defult and remove order by 
                var c1 = await (from mail in dbcon.Mails.Where(x=>x.Department_Id == mangment && x.state==true)

                                join send in dbcon.Sends
                                on mail.MailID equals send.MailID
                                   into fullmail
                                from b1 in fullmail.DefaultIfEmpty()

                                join exmail in dbcon.External_Mails on mail.MailID equals exmail.MailID
                                  into exmailin
                                from ex in exmailin.DefaultIfEmpty()

                                join exInmail in dbcon.Extrenal_Inboxes on mail.MailID equals exInmail.MailID
                                 into exInmailin
                                from exin in exInmailin.DefaultIfEmpty()

                                join replay in dbcon.Replies on b1.Id equals replay.send_ToId
                                into re
                                from rep in re.DefaultIfEmpty()

                                select new Sended_Maill()
                                {
                                   
                                    replay_State = rep == null ? false : rep.state,
                                    replay_isSend = rep == null ? false : rep.IsSend,
                                    replay_To = rep == null ? 0 : rep.To,
                                    external_sectionid = ex == null ? 0 : ex.Sectionid,
                                    externalInbox_sectionid = exin == null ? 0 : exin.SectionId,
                                    typeofsend = b1 == null ? 1 : b1.type_of_send,
                                    mail_id = mail.MailID,
                                    sends_state = b1 == null ? true : b1.State,
                                    type_of_mail = mail.Mail_Type,
                                    Mail_Number = mail.Mail_Number,
                                    date = mail.insert_at.Date,
                                    date2 = mail.Date_Of_Mail.Date,
                                    mangment_sender_id = mail.Department_Id,
                                    Send_time = b1.Send_time.ToString("yyyy-MM-dd"),
                                    time = b1.Send_time.ToString("HH:mm:ss"),
                                    summary = mail.Mail_Summary,
                                    flag = b1 == null ? 1 : b1.flag,
                                    Sends_id = b1 == null ? 0 : b1.Id,
                                    is_multi = b1 == null ? true : b1.isMulti,
                                    mail_state = mail.state,
                                    clasfiction = mail.clasification,
                                    genralinboxnumber = mail.Genaral_inbox_Number,
                                    tomangment = b1 == null ? tomang : b1.to


                                }).OrderByDescending(v => v.date2).Distinct().ToListAsync();



                var c = (from mail in c1.Where(x => ((mangmentrole == true || (mangmentrole == false && x.mangment_sender_id == mangment)) &&
                                            x.summary.Contains(summary)) &&
                                  (x.date.Date >= d1 && x.date.Date <= d2) && ((x.type_of_mail == mailNumType) || allmailtype == true)
                                            && (mailnum_bool == 1 || x.Mail_Number == mailnum) &&
                                            (x.clasfiction == Classfication || clasf_filter == true) &&
                                            (x.genralinboxnumber == genral_incoming_num || incoing_num_filter == true) && x.mail_state == true &&

                                         (x.flag > 0) &&
                                        ((x.flag >= mailReaded && x.flag <= mailnot_readed) || mail_accept == true) &&
                                        (x.flag == mail_state || State_filter == true) && x.sends_state == true
                                           && ((Replay_Date == true && x.replay_State == true && x.replay_isSend == true && x.replay_To == mangment) || rep_all == true))



                         join z in dbcon.MailStatuses.Where(x => x.state == true || ((Replay_Date == true))) on mail.flag equals z.flag

                         join dx in dbcon.measures.Where(x => (x.MeasuresId == Measure_filter || meas_filter == true)) on mail.typeofsend equals dx.MeasuresId

                         join n in dbcon.Departments.Where(x => (x.Id == Department_filter || dep_filter == true) && x.state == true) on mail.tomangment equals n.Id

                         join ex_dep in dbcon.external_Departments.Where(x => (x.state == true && x.side_number == TheSection) || sectionstate == true) on mail.mail_id equals ex_dep.Mail_id


                         select new Sended_Maill()
                         {
                            
                             replay_State = mail == null ? false : mail.replay_State,
                             replay_isSend = mail == null ? false : mail.replay_isSend,
                             replay_To = mail == null ? 0 : mail.replay_To,
                             external_sectionid = mail == null ? 0 : mail.external_sectionid,
                             externalInbox_sectionid = mail == null ? 0 : mail.externalInbox_sectionid,
                             measure_id = dx == null ? 1 : dx.MeasuresId,
                             typeofsend = mail.typeofsend,
                             sends_state = mail == null ? true : mail.sends_state,
                             mail_id = mail.mail_id,
                             State = mail.State,
                             type_of_mail = mail.type_of_mail,
                             Mail_Number = mail.Mail_Number,
                             date = mail.date.Date,
                             date2 = mail.date2.Date,
                             Masure_type = dx == null ? " " : dx.MeasuresName,
                             mangment_sender = n == null ? "" : n.DepartmentName,
                             mangment_sender_id = mail.mangment_sender_id,
                             Send_time = mail.Send_time,
                             time = mail.Send_time,
                             summary = mail.summary,
                             flag = mail == null ? 0 : mail.flag,
                             Sends_id = mail == null ? 0 : mail.Sends_id,
                             is_multi = mail == null ? true : mail.is_multi,
                             mail_state = mail.mail_state,
                             clasfiction = mail.clasfiction,
                             genralinboxnumber = mail.genralinboxnumber,
                             tomangment = mail == null ? tomang : mail.tomangment


                         }).OrderByDescending(v => v.date2).ToList();

                List<Sended_Maill> dd = new List<Sended_Maill>();
                foreach (var item in c)
                {

                    if (!dd.Exists(x => x.mail_id == item.mail_id))
                    {

                        dd.Add(item);
                    }
                }

                c = dd;


                pag.mail = c.OrderByDescending(v => v.date2).Skip((pagenum - 1) * size).Take(size).ToList();

            

                pag.Total = c.Count();

                return pag;

            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<PagenationSendedEmail<Sended_Maill>> GetAllIncoming(
           int? mailnum_bool, int? mangment, DateTime? d1, DateTime? d2, int? mailnum, string summary, int? mail_Readed,
           int? mailReaded, int? mailnot_readed, int? Typeof_send
           , int? mail_type, int? userid, int? mailNumType, int pagenum, int size, int? Measure_filter,
           int? Department_filter, int? Classfication,
           int? mail_state, int? TheSection, int? genral_incoming_num)
        {
            try
            {



                bool dep_filter = false;
                bool clasf_filter = false;
                bool meas_filter = false;
                bool mail_accept = false;
                bool State_filter = false;
                bool incoing_num_filter = false;
                bool mangmentrole = false;
                bool allmailtype = true;

                if (genral_incoming_num != null && mangment == 21)
                {
                    mangmentrole = true;
                }
                else
                {
                    mangmentrole = false;
                }

                if (mailNumType == 0)
                {
                    allmailtype = true;
                }
                else
                {
                    allmailtype = false;
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

                var m = await dbcon.Departments.FindAsync(mangment);

                PagenationSendedEmail<Sended_Maill> pag = new PagenationSendedEmail<Sended_Maill>();

                var c = await (from mail in dbcon.Mails.Where(x => (
                                          x.Mail_Summary.Contains(summary)) && ((x.Mail_Type == mailNumType) || allmailtype == true)
                                          && (mailnum_bool == 1 || x.Mail_Number == mailnum) &&
                                          (x.clasification == Classfication || clasf_filter == true)
                                          && (x.Genaral_inbox_Number == genral_incoming_num || incoing_num_filter == true) &&
                                          x.state == true).OrderByDescending(x => x.MailID)

                               join ex in dbcon.Sends.Where(x => (x.flag > 1) && (mangmentrole == true || (mangmentrole == false && x.to == mangment)) &&
                               (x.Send_time.Date >= d1 && x.Send_time.Date <= d2) &&
                               ((x.flag >= mailReaded && x.flag <= mailnot_readed) || mail_accept == true) &&
                               (x.flag == mail_state || State_filter == true) && x.State == true)
                               on mail.MailID equals ex.MailID

                               join dx in dbcon.measures.Where(x => (x.MeasuresId == Measure_filter || meas_filter == true)) on ex.type_of_send equals dx.MeasuresId
                               join n in dbcon.Departments.Where(x => (x.Id == Department_filter || dep_filter == true)) on mail.Department_Id equals n.Id
                               join z in dbcon.MailStatuses.Where(x => x.state == true) on ex.flag equals z.flag

                               select new Sended_Maill()
                               {
                                   mail_id = mail.MailID,
                                   State = z.inbox,
                                   type_of_mail = mail.Mail_Type,
                                   Mail_Number = mail.Mail_Number,
                                   date = mail.Date_Of_Mail.Date,
                                   date2 = ex.Send_time.Date,
                                   Masure_type = dx.MeasuresName,
                                   mangment_sender = n.DepartmentName,
                                   mangment_sender_id = mail.Department_Id,
                                   Send_time = ex.Send_time.ToString("yyyy-MM-dd"),
                                   time = ex.Send_time.ToString("HH:mm:ss"),
                                   summary = mail.Mail_Summary,
                                   flag = ex.flag,
                                   Sends_id = ex.Id,
                                   action_require = mail.ActionRequired


                               }).OrderByDescending(v => v.date2).ToListAsync();
                

             pag.mail =  c.OrderByDescending(v => v.date2).Skip((pagenum - 1) * size).Take(size).ToList();
               


                pag.Total = c.Count();

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



        public async Task<dynamic> GetDynamic( int? mailnum_bool,
            int? mangment, DateTime? d1, DateTime? d2, int? mailnum, string summary,
            int? mail_Readed, int? mailReaded, int? mailnot_readed, int? Typeof_send, int? userid, int? mailNumType,
            int? mail_type, int pagenum, int size, int? Measure_filter,
            int? Department_filter, int? Classfication, int? mail_state, int? genral_incoming_num,
            int? TheSection)
        {
            var role_id = await dbcon.userRoles.Where(x => x.UserId == userid).ToListAsync();

            //   var user_role_num = role_id.RoleId;
            try
            {

                var c0 = await GetAllIncoming(mailnum_bool,
            mangment, d1, d2, mailnum, summary, mail_Readed,
            mailReaded, mailnot_readed,
           Typeof_send, mail_type, userid, mailNumType, pagenum, size, Measure_filter,
           Department_filter, Classfication, mail_state, genral_incoming_num, TheSection);
                return c0;

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



     

        public async Task<dynamic> GetMail( int? mailnum_bool,
        int? mangment, DateTime? d1, DateTime? d2, int? mailnum, string? summary, int? mail_Readed,
        int? mailReaded, int? mailnot_readed, int?
        Typeof_send, int? userid, int? mailNumType, int? mail_type, int pagenum,
        int size, int? Measure_filter, int? Department_filter, int? Classfication,
        int? mail_state, int? genral_incoming_num, int? TheSection, bool? Replay_Date, int? office_type)
        {


            try
            {

                var c0 = await GetAll(mailnum_bool,
             mangment, d1, d2, mailnum, summary,
            mail_Readed, mailReaded, mailnot_readed, Typeof_send, mail_type, userid, pagenum,
             mailNumType, size, Measure_filter, Department_filter, Classfication, mail_state,
             genral_incoming_num, TheSection, Replay_Date, office_type
             );
                return c0;

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


                var c2 = await (from mail in dbcon.Mails.Where(x => x.Department_Id == depid && x.Mail_Type == 1)
                                join y in dbcon.Sends.Where(n => n.flag != 0) on mail.MailID equals y.MailID
                                join z in dbcon.MailStatuses.Where(x => x.state == true) on y.flag equals z.flag

                                join vv in dbcon.Sends.Where(x => x.State == true)
                                on mail.MailID equals vv.MailID

                                join rep in dbcon.Replies.Distinct().Where(rep => rep.state == true).Distinct()
                                on vv.Id equals rep.send_ToId

                                select new Sended_Maill()
                                {
                                    mail_id = mail.MailID,
                                    State = z.sent,
                                    type_of_mail = mail.Mail_Type,
                                    Mail_Number = mail.Mail_Number,
                                    date = mail.Date_Of_Mail.Date,
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
              


                var c2 = await (from mail in dbcon.Mails.Where(x => x.Department_Id == depid && x.Mail_Type == 1)
                                join y in dbcon.Sends.Where(n => n.flag != 0) on mail.MailID equals y.MailID
                                join z in dbcon.MailStatuses.Where(x => x.state == true) on y.flag equals z.flag

                                select new Sended_Maill()
                                {
                                    mail_id = mail.MailID,
                                    State = z.inbox,
                                    type_of_mail = mail.Mail_Type,
                                    Mail_Number = mail.Mail_Number,
                                    date = mail.Date_Of_Mail.Date,
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


        }

        public async Task<int> print_Attachment(int mail_id, int department_Id, int userId)
        {

            try
            {
                var c = await dbcon.Sends.OrderBy(x => x.Id).LastOrDefaultAsync(x => x.MailID == mail_id && department_Id == x.to);
                if (c != null)
                {
                    Historyes historyes = new Historyes();
                    historyes.changes = "طباعة مستندات الرد";

                    historyes.mailid = c.MailID;
                    historyes.currentUser = userId;
                    historyes.Time = DateTime.Now;
                    historyes.HistortyNameID = 21;
                    await dbcon.History.AddAsync(historyes);


                    c.flag = 6;
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