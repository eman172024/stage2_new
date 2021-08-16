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
                t.flag = false;
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

        public async Task<bool> IsRead(int id)
        {

            try
            {
                Send_to send_ = await _data.Sends.FirstOrDefaultAsync(x => x.MailID == id);
                if (send_ != null)
                {
                    send_.State = true;
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

        public async Task<bool> Send(int id)
        {
            try
            {
                Send_to send_ = await _data.Sends.FirstOrDefaultAsync(x=>x.MailID==id);
                if (send_ != null)
                {
                    send_.flag = true;
                    send_.Send_time = DateTime.Now;

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

       

    

      

       
    }
}
