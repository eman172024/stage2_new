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

        public async Task<ExMail> Get(int id)
        {
            try
            {
                ExMail ExMail = new ExMail();
                Mail mail = await _appDb.Mails.FindAsync(id);



                if (mail != null)
                {
                    ExMail.mail = _mapper.Map<Mail, MailDto>(mail);


                    External_Mail external = await _appDb.External_Mails.FirstAsync(x=>x.MailID==id);
                    ExMail.External = _mapper.Map<External_Mail, ExternalDto>(external);
                    List<Mail_Resourcescs> resourcescs = await _appDb.Mail_Resourcescs.Where(x => x.MailID == mail.MailID).ToListAsync();
                    ExMail.resourcescsDto = _mapper.Map<List<Mail_Resourcescs>, List<Mail_ResourcescsDto>>(resourcescs);


                    return ExMail;

                }
                return ExMail;

            }
            catch (Exception)
            {

                throw;
            }





        }

        public Task<List<ExMail>> GetAll()
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
