using MMSystem.Model;
using MMSystem.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Services.MailServices
{
    public class MooKMail_Resourcescs : IMail_Resourcescs
    {
        private readonly AppDbCon _dbCon;

        public MooKMail_Resourcescs(AppDbCon dbCon)
        {
            _dbCon = dbCon;
        }
        public async Task<bool> Add(Mail_Resourcescs t)
        {
            try
            {
                Mail mail =await _dbCon.Mails.FindAsync(t.MailID);

                if (mail != null) {


                    await _dbCon.Mail_Resourcescs.AddAsync(t);
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

        public Task<MailDto> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<MailDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Mail_Resourcescs model)
        {
            throw new NotImplementedException();
        }
    }
}
