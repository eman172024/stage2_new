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
            External_Mail mail =await _appDb.External_Mails.FindAsync(id);

            if (mail!=null) {

                ExternalDto dto = _mapper.Map<External_Mail, ExternalDto>(mail);


                return dto;
            }

            return null;
        }

        public async Task<List<ExternalDto>> GetAll()
        {
            try
            {
                List<External_Mail> mails = await _appDb.External_Mails.OrderByDescending(x => x.ID).ToListAsync();

                List<ExternalDto> externals = _mapper.Map<List<External_Mail>, List<ExternalDto>>(mails);

                return externals;

            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public async Task<bool> Update(External_Mail model)
        {
            Result result = new Result();

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
