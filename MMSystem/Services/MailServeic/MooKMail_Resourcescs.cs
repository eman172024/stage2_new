using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MMSystem.Model;
using MMSystem.Model.Dto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Services.MailServeic
{
    public class MooKMail_Resourcescs : IMail_Resourcescs
    {
        private readonly AppDbCon _dbCon;
        private readonly IMapper _mapper;

        public MooKMail_Resourcescs(AppDbCon dbCon,IMapper mapper)
        {
            _dbCon = dbCon;
            _mapper = mapper;
        }
        public async Task<bool> Add(Mail_Resourcescs t)
        {
            try
            {
                Mail mail =await _dbCon.Mails.FindAsync(t.MailID);

                if (mail != null) {

                    t.State = true;
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

        public async Task<bool> Delete(int id)
        {
            try
            {

                Mail_Resourcescs mailResourse = await _dbCon.Mail_Resourcescs.FindAsync(id);
                if (mailResourse != null)
                {
                    mailResourse.State = false;
                    _dbCon.Mail_Resourcescs.Update(mailResourse);
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

        public async Task<Mail_ResourcescsDto> Get(int id)
        {
            Mail_Resourcescs mail = await _dbCon.Mail_Resourcescs.FindAsync(id);
            if (mail != null) {
                Mail_ResourcescsDto resourse = _mapper.Map<Mail_Resourcescs, Mail_ResourcescsDto>(mail);

                return resourse;


            }
            return null;
        }

        public Task<List<Mail_ResourcescsDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Mail_ResourcescsDto>> GetAll(int id)
        {
            try
            {
                List<Mail_Resourcescs> _Resourcescs = await _dbCon.Mail_Resourcescs.Where(x => x.MailID == id && x.State == true).ToListAsync();
                List<Mail_ResourcescsDto> mail_ResourcescsDtos = _mapper.Map<List<Mail_Resourcescs>, List<Mail_ResourcescsDto>>(_Resourcescs);



                foreach (var xx in mail_ResourcescsDtos)
                {
                    string x = xx.path;

                    if (File.Exists(xx.path))
                    {
                        xx.path = await tobase64(x);

                    }
                    else
                    {






                    }

                }
                return mail_ResourcescsDtos;

            }
            catch (Exception)
            {

                throw;
            }
          
        }

        public async Task<bool> Update(Mail_Resourcescs mail_Resourcescs)
        {
            try
            {
                Mail_Resourcescs resourcescs = await _dbCon.Mail_Resourcescs.FindAsync(mail_Resourcescs.ID);
                if (mail_Resourcescs != null) {

                    _dbCon.Mail_Resourcescs.Update(mail_Resourcescs);
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
        public async Task<string> tobase64(string patj)
        {

            try
            {
                var attachmentType = System.IO.Path.GetExtension(patj);
                var Type = attachmentType.Substring(1, attachmentType.Length - 1);
                var filePath = System.IO.Path.Combine(patj);
                byte[] fileBytes = await System.IO.File.ReadAllBytesAsync(filePath);
                var ImageBase64 = "data:image/" + Type + ";base64," + Convert.ToBase64String(fileBytes);
                return ImageBase64;
            }
            catch (Exception)
            {

                throw;
            }


        }

        public async Task<List<Mail_ResourcescsDto>> GetAllRes(int id)
        {
            try
            {
                var list = await GetAll(id);

               foreach (var xx in list)
               {
                string x = xx.path;
               xx.path = await tobase64(x);
}


                return list;

            }
            catch (Exception)
            {

                throw;
            }
           
        }
    }
}
