using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MMSystem.Model;
using MMSystem.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Services.MailServices
{
    public class MooKExernalnbox : IExtrenal_inbox
    {
        private readonly AppDbCon _dbCon;
        private readonly IMapper _mapper;

        public MooKExernalnbox(AppDbCon dbCon,IMapper mapper)
        {
            _dbCon = dbCon;
            _mapper = mapper;
        }
   

        public async Task<bool> Add(Extrenal_inbox extrenal)
        {
            try
            {
                Result result = new Result();
                Mail mail = await _dbCon.Mails.FindAsync(extrenal.MailID);
                if (mail != null)
                {

                    await _dbCon.Extrenal_Inboxes.AddAsync(extrenal);
                    await _dbCon.SaveChangesAsync();
                 
                    return true;
                }
              
                return false;

            }

            catch (Exception)
            {

                throw;
            }
           
            }
        

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Extrenal_inboxDto> Get(int id)
        {
            try
            {
                var email = await _dbCon.Mails.FindAsync(id);



                if (email != null)
                {

                    Extrenal_inbox external = await _dbCon.Extrenal_Inboxes.FirstOrDefaultAsync(x => x.MailID == id);
                    Extrenal_inboxDto _InboxDto = _mapper.Map<Extrenal_inbox, Extrenal_inboxDto>(external);

                    return _InboxDto;

                }
                return null;

            }
            catch (Exception)
            {

                throw;
            }

          
           
        }

        public async Task<List<Extrenal_inboxDto>> GetAll()
        {
            try
            {
                List<Extrenal_inbox> list = await _dbCon.Extrenal_Inboxes.OrderByDescending(x => x.Id).ToListAsync();
                List<Extrenal_inboxDto> listOfEmail = _mapper.Map<List<Extrenal_inbox>, List<Extrenal_inboxDto>>(list);
                return listOfEmail;
            }
            catch (Exception)
            {

                throw;
            }
     
        }

        public async Task<bool> Update(Extrenal_inbox model)
        {
            Extrenal_inbox _Inbox = await _dbCon.Extrenal_Inboxes.FindAsync(model.Id);

            if (_Inbox != null) {

                await _dbCon.Extrenal_Inboxes.AddAsync(model);
                await _dbCon.SaveChangesAsync();

                return true;
            }
            return false;
        }
    }
}
