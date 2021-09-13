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
            
                Mail mail = await _dbCon.Mails.FindAsync(id);



                if (mail != null)
                {
                    
                    
                    var c= _mapper.Map<Mail, MailDto>(mail);

                   
                    Extrenal_inbox external = await _dbCon.Extrenal_Inboxes.FirstAsync(x => x.MailID == id);
                  Extrenal_inboxDto dto = _mapper.Map<Extrenal_inbox, Extrenal_inboxDto>(external);
                  

                    return dto;

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
                return null;
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
                _Inbox.action = model.action;
                _Inbox.entity_reference_number = model.entity_reference_number;
                _Inbox.SectionId = model.SectionId;
                _Inbox.section_Name = model.section_Name;
                _Inbox.procedure_type = model.procedure_type;
                _Inbox.to = model.to;
                _Inbox.type = model.type;
                _Inbox.Send_time = model.Send_time;

                 _dbCon.Extrenal_Inboxes.Update(_Inbox);
                await _dbCon.SaveChangesAsync();

                return true;
            }
            return false;
        }
    }
}
