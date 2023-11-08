using Microsoft.EntityFrameworkCore;
using MMSystem.Model;
using MMSystem.Model.ViewModel;
using MMSystem.Services.Histor;
using MMSystem.Services.MailServeic;
using MMSystem.Services.ResendMail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Services.ResendMail
{
    public class MockResendMail : IResendMail



    {
        public MockResendMail(AppDbCon data,IMail_Resourcescs resourcescs ,
            ISender sender,IHistory history )
        {
            _data = data;
            _sender = sender;

           // ISectionNote = sectionNot;
           // _history = history;

        }


        private AppDbCon _data { get; }
        private readonly ISender _sender;
        private readonly IHistory _history;




        public async Task<bool> SaveResendMail(ResendViewModel mail)
    {


           
       
            bool result = false;

        try {


                var mail1 = await _data.Mails.FindAsync(mail.Mail_id);


                if (mail1 != null)

                {
                    for (int i = 0; i < mail.actionSenders.Count; i++)
                    {
                        Send_to sender = new Send_to();
                        Section_Notes SNotes = new Section_Notes();

                        if (i == (mail.actionSenders.Count - 1))
                        {
                            sender.isMulti = true;
                        }
                        else
                        {
                            sender.isMulti = false;
                        }
                        sender.MailID = mail1.MailID;
                        sender.to = mail.actionSenders[i].Sendes_to;
                        sender.flag = 1;
                        sender.resendfrom = mail.actionSenders[i].ResendFrom;
                        sender.update_At = DateTime.Now;
                        sender.State = true;
                        bool send = await _sender.Add(sender);
                        await _data.SaveChangesAsync();
                        sender = _data.Sends.OrderBy(x => x.Id).LastOrDefault();

                        int LastID = sender.Id;

                        if (mail.actionSenders[i].Note != "")
                        {
                            SNotes.send_ToId = LastID;
                            SNotes.Note = mail.actionSenders[i].Note;
                            SNotes.State = true;

                         await   _data.section_Notes.AddAsync(SNotes);
                           await _data.SaveChangesAsync();

                        }

                        result = true;
                    }

                    return result;
                }






                return result;

        }
        catch (Exception)
        {

            throw;
        }
    }

        public async Task<bool> deleteSectionsSender(int mail_id, int departmentId, int userid)
        {
            try
            {
                Historyes historyes = new Historyes();

                historyes.currentUser = userid;
                historyes.mailid = mail_id;

                historyes.HistortyNameID = 9;


                Send_to send_ = await _data.Sends.FirstOrDefaultAsync(x => x.MailID == mail_id && x.to == departmentId && x.State == true);

                Section_Notes section_note = await _data.section_Notes.FirstOrDefaultAsync(x => x.send_ToId == send_.Id && x.State == true);

                if (send_ != null)
                {
                    if (send_.flag <= 2)
                    {

                        send_.State = false;

                        section_note.State = false;

                        historyes.changes = $" {departmentId}   تم حدف الادارة رقم";

                        historyes.Time = DateTime.Now;


                        _data.Sends.Update(send_);

                        _data.section_Notes.Update(section_note);

                        _data.History.Add(historyes);

                        await _data.SaveChangesAsync();


                        return true;


                    }
                    else
                    {

                        return false;
                    }


                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<bool> SendResendMail(ResendViewModel mail)
        {

            try
            {
                bool result = false;


                var mail_s = await _data.Mails.FindAsync(mail.Mail_id);
 
                if (mail_s != null)
                {

                    mail_s.resended = true;

                    _data.Mails.Add(mail_s);
                    await _data.SaveChangesAsync();

                    Send_to sender = new Send_to();
                    
                    var sender_resend = await (from x in _data.Sends.Where(x => x.MailID.Equals(mail_s.MailID) && x.State==false)
                                               join y in _data.section_Notes.Where(x => x.State == true) on x.Id equals y.send_ToId
                                               select new Send_to {

                                               }

                                               ).ToListAsync();

                            foreach (var item in sender_resend)
                            {
                                item.State = true;
                      
                               _data.Sends.Add(item);
                               await _data.SaveChangesAsync();
                        
                            }

                    return result;
                }

                return result;

            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
