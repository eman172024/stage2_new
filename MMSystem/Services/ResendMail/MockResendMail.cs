﻿using Microsoft.EntityFrameworkCore;
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



        public async Task<bool> SaveResendMail(ResendViewModel mail, int userid)
    {


           
       
            bool result = false;

        try {


                var mail1 = await _data.Mails.FindAsync(mail.Mail_id);
                Send_to main_mail;

                if (mail1 != null)

                {
                    for (int i = 0; i < mail.actionSenders.Count; i++)
                    {
                        Send_to sender = new Send_to();
                        Section_Notes SNotes = new Section_Notes();
                         main_mail = _data.Sends.Where(x => x.MailID == mail.Mail_id && x.to == mail.actionSenders[i].ResendFrom).FirstOrDefault();
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
                        sender.type_of_send = main_mail.type_of_send;
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

                            Historyes histor = new Historyes();
                            histor.currentUser = userid;
                            histor.mailid = mail1.MailID;
                            histor.HistortyNameID = 26;
                            histor.Time = DateTime.Now;
                            bool res = await _history.Add(histor);
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



        public async Task<bool> UpdateResendMail(ResendViewModel mail,int userid)
        {
            bool result = false;
            bool sendsState =false;
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
                        List<Send_to> sends_state;
                        // virable sends empty when action sender get one more when its add 
                        sends = _data.Sends.Where(x => x.MailID == mail.Mail_id && x.resendfrom == mail.actionSenders[i].ResendFrom && mail.actionSenders[i].Sendes_to==x.to).ToList();
                        sends_state  = _data.Sends.Where(x => x.MailID == mail.Mail_id && x.resendfrom == mail.actionSenders[i].ResendFrom ).ToList();
                        if(sends_state.Count != 0)
                        {
                            for (int t = 0; t < sends_state.Count; t++)
                            {
                                if (sends_state[t].State == true)
                                {
                                    sendsState = true;
                                }
                            }
                        }
                       



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

                                        Historyes histor = new Historyes();
                                        histor.currentUser = userid;
                                        histor.mailid = mail1.MailID;
                                        histor.HistortyNameID = 26;
                                        histor.Time = DateTime.Now;
                                        bool res = await _history.Add(histor);
                                    }
                                }
                                else if (mail.actionSenders[i].Sendes_to == sends[j].to && mail.actionSenders[i].ResendFrom == sends[j].resendfrom && mail.Mail_id == sends[j].MailID)
                                {
                                    sends[j].MailID = mail1.MailID;
                                    sends[j].to = mail.actionSenders[i].Sendes_to;
                                    sends[j].flag = 1;
                                    sends[j].resendfrom = mail.actionSenders[i].ResendFrom;
                                    sends[j].update_At = DateTime.Now;
                                    sends[j].State = sendsState;
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

                                            Historyes histor = new Historyes();
                                            histor.currentUser = userid;
                                            histor.mailid = mail1.MailID;
                                            histor.HistortyNameID = 27;
                                            histor.Time = DateTime.Now;
                                            bool res = await _history.Add(histor);
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



        public async Task<bool> SendResendMail(int Mail_id,int user_id, int departmen_id)
        {
            try
            {                
                var mail_s = await _data.Mails.FindAsync(Mail_id);
 
                if (mail_s != null)
                {

                    //     Send_to sender = new Send_to();
                    var change_resended = await  _data.Sends.FirstOrDefaultAsync(x => x.MailID.Equals(mail_s.MailID) && x.to == 17&& x.State==true);

                        change_resended.resended = true;

                        _data.Sends.Update(change_resended);
                   
                         await _data.SaveChangesAsync();


                    var sender_resend = await (from x in _data.Sends.Where(x => x.MailID.Equals(mail_s.MailID) && x.resendfrom ==17 && x.State==false)
                                               join y in _data.section_Notes.Where(x => x.State == true) on x.Id equals y.send_ToId
                                               select new Send_to {
                                                   MailID =x.MailID ,
                                                    
                                               }

                                               ).ToListAsync();

                            foreach (var item in sender_resend)
                            {
                                item.State = true;
                      
                               _data.Sends.Update(item);
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
