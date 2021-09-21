using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MMSystem.Model;
using MMSystem.Model.Dto;
using MMSystem.Model.ViewModel.MailVModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Services.MailServeic
{
    public class MookGetMail : GetMailServices
    {
        private readonly AppDbCon _dbCon;
        private readonly IMapper _mapper;

        public MookGetMail(AppDbCon dbCon, IMapper mapper)
        {
            _dbCon = dbCon;
           _mapper = mapper;
        }

        public async Task<MVM> GetMail(int mail_id,int  department_Id)
        {
            try
            {

                MVM model = new MVM();
                Mail mail = await _dbCon.Mails.FindAsync(mail_id);
                model.mail = _mapper.Map<Mail, MailDto>(mail);
                 List<Mail_Resourcescs> mail_Resourcescs = await _dbCon.Mail_Resourcescs.Where(x => x.MailID == mail_id).ToListAsync();
                Send_to c =  await _dbCon.Sends.Where(x => x.to == department_Id && x.MailID == mail_id).FirstOrDefaultAsync();
                model.mail_Resourcescs = _mapper.Map<List<Mail_Resourcescs>,List<Mail_ResourcescsDto>>(mail_Resourcescs);
              model.list = await (from x in _dbCon.Replies.Where(x => x.ReplyId == c.Id)
                               join y in _dbCon.Reply_Resources on x.ReplyId equals y.ReplyId
                               select new RViewModel { 
                               reply=_mapper.Map<Reply,ReplayDto>(x),
                               Resources=_mapper.Map<List<Reply_Resources>,List<Reply_ResourcesDto>>(  _dbCon.Reply_Resources.Where(x=>x.ReplyId==x.ID).ToList())
                               }).ToListAsync();

                foreach (var xx in model.mail_Resourcescs)
                {
                    string x = xx.path;
                    xx.path = await tobase64(x);

                }

                foreach (var item in model.list)
                {
                    foreach (var item2 in item.Resources)
                    {
                        string x1 =item2.path;
                        item2.path = await tobase64(x1);
                    }
                }
            

                return model;


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
    }
}
