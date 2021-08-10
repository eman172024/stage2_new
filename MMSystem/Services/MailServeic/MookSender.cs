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

        public MookSender(AppDbCon data,IMapper mapper)
        {
            _data = data;
            _mapper = mapper;
        }
        public async Task<bool> Add(Send_to t)
        {
            try
            {
                t.flag = true;
                t.State = false;
                t.Send_time = DateTime.Now;
                await _data.Sends.AddAsync(t);
                await _data.SaveChangesAsync();
                return true;

            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                Send_to send_ = await _data.Sends.FindAsync(id);
                if (send_ != null)
                {
                    send_.State = false;

                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
         
        }

        public async Task<SenderDto> Get(int id)
        {
            try
            {
                Send_to send_ = await _data.Sends.FindAsync(id);

                if (send_.State)

                {
                    send_.State = true;
                    send_.time_of_read = DateTime.Now;
                    _data.Sends.Update(send_);
                    await _data.SaveChangesAsync();

                    SenderDto dto = _mapper.Map<Send_to, SenderDto>(send_);


                    return dto;
                
                }
                SenderDto dtosender = _mapper.Map<Send_to, SenderDto>(send_);
                return dtosender;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<SenderDto>> GetAll()
        {

            try
            {

            }
            catch (Exception)
            {

                throw;
            }
            return null;
        }

        public async Task<List<Re>> GetMySenderMail(int id)
        {
            try
            {
                List<Re> list = await (from o in _data.Mails   from s in _data.Sends where s.MailID == s.MailID && o.Management_Id==id select new Re { MailID = o.MailID, Mail_Summary = o.Mail_Summary,to=s.to}).ToListAsync();

                
                return list;

            }
            catch (Exception)
            {

                throw;
            }
        
        }

        public async Task<bool> Update(Send_to model)
        {
            try
            {
                Send_to send_ =await _data.Sends.FindAsync(model.Id);

                if (send_ != null) {

                     _data.Sends.Update(model);
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
    }
}
