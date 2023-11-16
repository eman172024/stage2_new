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
            _history = history;

        }


        private readonly AppDbCon _data;
        private readonly ISender _sender;
        private readonly IHistory _history;



        public async Task<bool> Add(Send_to t)
        {
            try
            {


                await _data.Sends.AddAsync(t);
                await _data.SaveChangesAsync();
                return true;


            }
            catch (Exception)
            {
                throw;
            }

        }
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
                        sender.State = false;
                        bool send = await Add(sender);
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



        public async Task<bool> UpdateResendMail(ResendViewModel mail)
        {
            bool result = false;
            int j;
            Section_Notes SNotes = new Section_Notes();
            int LastID;
            try
            {
                var mail1 = await _data.Mails.FindAsync(mail.Mail_id);


                if (mail1 != null)

                {
                    for (int i = 0; i < mail.actionSenders.Count; i++)
                    {
                        Send_to sender = new Send_to(); 
                        List<Section_Notes> SNote;
                        List<Send_to> sends;
                        // virable sends empty when action sender get one more when its add 
                        sends = _data.Sends.Where(x => x.MailID == mail.Mail_id && x.resendfrom == mail.actionSenders[i].ResendFrom && mail.actionSenders[i].Sendes_to==x.to).ToList();

                       
                       
                       
                        if (sends != null)
                        {
                            if (i == (mail.actionSenders.Count - 1))
                            {
                                sender.isMulti = true;
                            }
                            else
                            {
                                sender.isMulti = false;
                            }

                            if (sends.Count() == 0)
                               {  j = -1; }else { j = 0; }

                                for ( j=j ; j < sends.Count; j++)
                            {
                             

                                if (sends.Count==0)
                                {
                                    sender.MailID = mail1.MailID;
                                    sender.to = mail.actionSenders[i].Sendes_to;
                                    sender.flag = 1;
                                    sender.resendfrom = mail.actionSenders[i].ResendFrom;
                                    sender.update_At = DateTime.Now;
                                    sender.State = false;
                                    bool send= await Add(sender);
                                    await _data.SaveChangesAsync();

                                    sender = _data.Sends.OrderBy(x => x.Id).LastOrDefault();

                                    LastID = sender.Id;
                                    result = true;
                                   
                                    if (mail.actionSenders[i].Note != "")
                                    {
                                        SNotes.send_ToId = LastID;
                                        SNotes.Note = mail.actionSenders[i].Note;
                                        SNotes.State = true;

                                        await _data.section_Notes.AddAsync(SNotes);
                                        await _data.SaveChangesAsync();
                                        result = true;

                                    }
                                }
                                else if (mail.actionSenders[i].Sendes_to == sends[j].to && mail.actionSenders[i].ResendFrom == sends[j].resendfrom && mail.Mail_id == sends[j].MailID)
                                {
                                    sends[j].MailID = mail1.MailID;
                                    sends[j].to = mail.actionSenders[i].Sendes_to;
                                    sends[j].flag = 1;
                                    sends[j].resendfrom = mail.actionSenders[i].ResendFrom;
                                    sends[j].update_At = DateTime.Now;
                                    sends[j].State = false;
                                     _data.Sends.Update(sends[j]);
                                    await _data.SaveChangesAsync();
                                    sender = _data.Sends.OrderBy(x => x.Id).LastOrDefault();

                                    LastID = sender.Id;
                                    if (j != -1) {
                                    SNote = _data.section_Notes.Where(x => x.send_ToId == sends[j].Id).ToList();
                                    if (mail.actionSenders[i].Note != "" )
                                    {
                                      //SNote[j].send_ToId = sends[j].Id;
                                        SNote[j].Note = mail.actionSenders[i].Note;
                                        SNote[j].State = true;

                                         _data.section_Notes.Update(SNote[j]);
                                        await _data.SaveChangesAsync();
                                        result = true;

                                    }
                                    }
                                }

                            }


                        }

                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return result;

        }


        public async Task<bool> deleteSectionsSender(int sends_to_id, int section_note_id, int userid)
        {
            try
            {



                Send_to send_ = await _data.Sends.FindAsync(sends_to_id);

                if (send_!=null) { 
                send_.State = false;
                
                _data.Sends.Update(send_);
                await _data.SaveChangesAsync();

               
                Section_Notes section_note = await _data.section_Notes.FindAsync(section_note_id);
                  
                     section_note.State = false;
                    _data.section_Notes.Update(section_note);
                    await _data.SaveChangesAsync();


                
                Historyes historyes = new Historyes();

                historyes.currentUser = userid;
                historyes.mailid = send_.MailID;

                historyes.HistortyNameID = 9;

                historyes.changes = $" {send_.to}   تم حدف الادارة رقم";

                        historyes.Time = DateTime.Now;

                        _data.History.Add(historyes);

                        await _data.SaveChangesAsync();


                        return true;
                }
                return false;

            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<bool> SendResendMail(int Mail_id,int user_id, int department_id)
        {
            try
            {                
                var mail_s = await _data.Mails.FindAsync(Mail_id);
 
                if (mail_s != null)
                {

                    //     Send_to sender = new Send_to();
                    var change_resended = await  _data.Sends.FirstOrDefaultAsync(x => x.MailID.Equals(Mail_id) && x.to == department_id&& x.State==true);

                        change_resended.resended = true;

                        _data.Sends.Update(change_resended);
                   
                         await _data.SaveChangesAsync();


                   List<Send_to> sender_resend = await (from x in _data.Sends.Where(x => x.MailID == Mail_id && x.resendfrom == department_id && x.State==false)
                                               join yj in _data.section_Notes.Where(x => x.State == true) on x.Id equals yj.send_ToId
                                               select new Send_to {
                                                  Id = x.Id,
                                                 
                                                    
                                               }

                                               ).ToListAsync();

                            foreach (var item in sender_resend)
                            {
                              var section_sended = await _data.Sends.FirstOrDefaultAsync(x => x.Id.Equals(item.Id));

                               section_sended.State = true;
                      
                               _data.Sends.Update(section_sended);
                               await _data.SaveChangesAsync();
                           }
                            

                    Historyes histor = new Historyes();
                    histor.currentUser = user_id;
                    histor.mailid = Mail_id;
                    histor.HistortyNameID = 28;
                    histor.Time = DateTime.Now;
                    bool res = await _history.Add(histor);
                    
                    return true;
                }

                   return false;

            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
