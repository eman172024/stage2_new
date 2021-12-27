using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MMSystem.Model;
using MMSystem.Model.Dto;
using MMSystem.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Services.MailServeic
{
    public class MookSender : ISender
    {
        private readonly AppDbCon _data;
        private readonly IMapper _mapper;

        public MookSender(AppDbCon data, IMapper mapper)
        {
            _data = data;
            _mapper = mapper;
        }
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

        public async Task<bool> IsRead(int id)
        {

            try
            {
                Send_to send_ = await _data.Sends.FirstOrDefaultAsync(x => x.MailID == id);
                if (send_ != null)
                {
                    send_.flag = 1;
                    send_.time_of_read = DateTime.Now;

                    _data.Sends.Update(send_);
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

        public async Task<bool> Send(int mailId)
        {
            try
            {
                Mail mail = await _data.Mails.FindAsync(mailId);

                if (mail != null) {
                    
                    mail.is_send = true;
                    _data.Mails.Update(mail);
                    await _data.SaveChangesAsync();

                    List<Send_to> send_ = await _data.Sends.Where(x => x.MailID == mailId).ToListAsync();
                    if (send_.Count > 0)
                    {
                        foreach (var item in send_)
                        {
                            item.flag = 2;
                            item.Send_time = DateTime.Now;

                            _data.Sends.Update(item);
                            await _data.SaveChangesAsync();
                        }



                       
                    }
                    return true;
                }


                return false;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<bool> Update(Send_to send_)
        {
            try
            {
                Send_to send_To = await _data.Sends.FirstOrDefaultAsync(x => x.MailID == send_.MailID && x.to == send_.to && x.type_of_send == send_.type_of_send);

                if (send_To!=null) { 
                
                }
               
            }
            catch (Exception)
            {

                throw;
            }


            return true;

        }

        public async Task<bool> UpdateSenderList(UpdateVM update)
        {

            Mail mail = await _data.Mails.FindAsync(update.mail_id);



            if (mail != null) {
                for (int i = 0; i < update.actionSenders.Count; i++)
                {
                    Send_to sender = new Send_to();

                    
                    sender.MailID = mail.MailID;
                    sender.to = update.actionSenders[i].departmentId;
                    sender.flag = 2;
                    sender.type_of_send = update.actionSenders[i].measureId;
                    bool send = await Add(sender);
                }
                return true;

            }
            return false;

        }
    }
}