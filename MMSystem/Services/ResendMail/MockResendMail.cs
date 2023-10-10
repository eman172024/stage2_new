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
            ISender sender,IHistory history /*ISectionNote sectionNote*/)
        {
            _data = data;
            _sender = sender;
           // _history = history;
           //_sectionNote = sectionNote;

        }


        private AppDbCon _data { get; }
        private readonly ISender _sender;
        private readonly IHistory _history;
        //private readonly ISectionNote _sectionNote;



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
                            //bool note=await _sectionNote.AddNotes(SNotes);
                            //await _data.SaveChangesAsync();
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

     
    }
}
