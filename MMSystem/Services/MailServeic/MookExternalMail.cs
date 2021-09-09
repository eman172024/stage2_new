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
    public class MookExternalMail : IExternalMailcs
    {
        private readonly AppDbCon _appDb;
        private readonly IMapper _mapper;

        public MookExternalMail(AppDbCon appDb,IMapper mapper)
        {
            _appDb = appDb;
            _mapper = mapper;
        }
        public async Task<bool> Add(External_Mail exMail)
        {
            Result result = new Result();
            try
            {
                Mail mail = await _appDb.Mails.FindAsync(exMail.MailID);
                
                if (mail != null)
                {
                 exMail.MailID = mail.MailID;
                    await _appDb.External_Mails.AddAsync(exMail);

                    await _appDb.SaveChangesAsync();
                  
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

        public async Task<ExternalDto> Get(int id)
        {
            try
            {
            
                Mail mail = await _appDb.Mails.FindAsync(id);



                if (mail != null)
                {
                    External_Mail external = _appDb.External_Mails.FirstOrDefault(x=>x.MailID==id);

                    ExternalDto dto = _mapper.Map<External_Mail, ExternalDto>(external);

                    return dto;

                }
                return null;

            }
            catch (Exception)
            {

                throw;
            }





        }

        public Task<List<ExternalDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Update(External_Mail model)
        {
           

            try
            {
                External_Mail mail = await _appDb.External_Mails.FindAsync(model.ID);

                if (mail != null)

                {
                    mail.Sectionid = model.Sectionid;
                    mail.sectionName = model.sectionName;
                    mail.action = model.action;
                    mail.action_required_by_the_entity = model.action_required_by_the_entity;



                    _appDb.External_Mails.Update(mail);
                    await _appDb.SaveChangesAsync();
                 
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
