using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MMSystem.Model;
using MMSystem.Model.Dto;
using MMSystem.Model.ViewModel.MailVModels;
using System;
using System.Collections.Generic;
using System.IO;
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

        public async Task<EMVM> GetExternalMail(int mail_id, int Depa,int type)
        {
            try
            {

                EMVM model = new EMVM();
                //   Mail mail = await _dbCon.Mails.FindAsync(mail_id);
                model.mail =await Getdto(mail_id, type);
                External_Mail external_Mail = await _dbCon.External_Mails.OrderBy(x => x.ID).FirstOrDefaultAsync(x => x.MailID == mail_id);
                model.side= await _dbCon.Extrmal_Sections.FindAsync(external_Mail.Sectionid);
                model.Sector = await _dbCon.Extrmal_Sections.FirstOrDefaultAsync(x => x.id == model.side.perent);
              
                model.External = _mapper.Map<External_Mail, ExternalDto>(external_Mail);
                List<Mail_Resourcescs> mail_Resourcescs = await _dbCon.Mail_Resourcescs.Where(x => x.MailID == mail_id).ToListAsync();
                Send_to c = await _dbCon.Sends.Where(x => x.to == Depa && x.MailID == mail_id).FirstOrDefaultAsync();


               

                    model.external_sectoin = await _dbCon.external_Departments.Where(x => x.Mail_id == model.mail.MailID && x.state == true).Select(z => new Ex_Departments
                    {

                        side_name = _dbCon.Extrmal_Sections.FirstOrDefault(v => v.id == z.side_number).Section_Name,
                        side_number = z.side_number,
                        id = z.id,
                        Mail_id = z.Mail_id,
                        sector_name = _dbCon.Extrmal_Sections.FirstOrDefault(v => v.id == z.sector_number).Section_Name,
                        sector_number = z.sector_number
                        ,
                        mail_forwarding=z.mail_forwarding

                    })
                            .ToListAsync();



                model.mail_Resourcescs = _mapper.Map<List<Mail_Resourcescs>, List<Mail_ResourcescsDto>>(mail_Resourcescs);
                model.list = await(from x in _dbCon.Replies.Where(x => x.send_ToId == c.Id&&x.state.Equals(true)&&x.IsSend.Equals(true))
                                  
                                   select new RViewModel
                                   {
                                       reply = _mapper.Map<Reply, ReplayDto>(x),
                                       Resources = x._Resources.Where(a => a.State == true && x.ReplyId == x.ReplyId).Any()
                                   }).ToListAsync();

                //foreach (var xx in model.mail_Resourcescs)
                //{
                //    string x = xx.path;
                //    xx.path = await tobase64(x);

                //}

                //foreach (var item in model.list)
                //{
                //    foreach (var item2 in item.Resources)
                //    {
                //        string x1 = item2.path;
                //        item2.path = await tobase64(x1);
                //    }
                //}


                return model;


            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<MVM> GetMail(int mail_id,int  department_Id,int tybe)
        {
            try
            {

                MVM model = new MVM();

                model.mail = await Getdto(mail_id, tybe);
                 List<Mail_Resourcescs> mail_Resourcescs = await _dbCon.Mail_Resourcescs.Where(x => x.MailID == mail_id&&x.State==true).ToListAsync();
                Send_to c =  await _dbCon.Sends.Where(x => x.to == department_Id && x.MailID == mail_id&&x.State==true).FirstOrDefaultAsync();
                model.mail_Resourcescs = _mapper.Map<List<Mail_Resourcescs>,List<Mail_ResourcescsDto>>(mail_Resourcescs);
              model.list = await (from x in _dbCon.Replies.Where(x => x.send_ToId == c.Id&&x.state.Equals(true)&&x.IsSend.Equals(true))
                      //       join y in _dbCon.Reply_Resources on x.ReplyId equals y.ReplyId
                               select new RViewModel { 
                               reply=_mapper.Map<Reply,ReplayDto>(x),
                                   Resources = x._Resources.Where(a => a.State == true && x.ReplyId == x.ReplyId).Any()
                               }).ToListAsync();

                //foreach (var xx in model.mail_Resourcescs)
                //{
                //    string x = xx.path;
                //    if (File.Exists(x))
                //    {
                //        xx.path = await tobase64(x);

                //    }

                //}

                //foreach (var item in model.list)
                //{
                //    foreach (var item2 in item.Resources)
                //    {
                //        string x = item2.path;
                //        if (File.Exists(x))
                //        {
                //            item2.path = await tobase64(x);

                //        }

                //    }
                //}
            

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

        public async Task<MailDto> Getdto(int id, int type)
        {
            try
            {
                MailDto dto1 = new MailDto();

                switch (type)
                {

                    case 1:
                        Mail mail = await _dbCon.Mails.FirstOrDefaultAsync(x => x.MailID == id && x.Mail_Type == 1);
                        dto1 = _mapper.Map<Mail, MailDto>(mail);
                        var dd=await  _dbCon.clasifications.OrderBy(x=>x.Id).FirstOrDefaultAsync(x=>x.Id==int .Parse(dto1.clasification));
                        dto1.classification_name = dd.Name;
                        

                        break;
                    case 2:
                        Mail mail1 = await _dbCon.Mails.FirstOrDefaultAsync(x => x.MailID == id && x.Mail_Type == 2);
                        dto1 = _mapper.Map<Mail, MailDto>(mail1);
                        var clasification =await _dbCon.clasifications.OrderBy(x=>x.Id).FirstOrDefaultAsync(x => x.Id == int.Parse(dto1.clasification));
                        dto1.classification_name = clasification.Name;

                        break;
                    case 3:
                        Mail mail2 = await _dbCon.Mails.FirstOrDefaultAsync(x => x.MailID == id && x.Mail_Type == 3);
                        dto1 = _mapper.Map<Mail, MailDto>(mail2);
                        var clasificationx =await _dbCon.clasifications.OrderBy(x=>x.Id).FirstOrDefaultAsync(x => x.Id == int.Parse(dto1.clasification));
                        dto1.classification_name = clasificationx.Name;

                        break;
                    default: break;

                }


                return dto1;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<EIMVM> GetExternalbox(int mail_id, int Depa, int type)
        {
            try
            {

                EIMVM model = new EIMVM();
                bool dep = false;
                if (Depa == 21) {

                    dep = true;
                }
                //   Mail mail = await _dbCon.Mails.FindAsync(mail_id);
                model.mail = await Getdto(mail_id, type);
                Extrenal_inbox external_Mail = await _dbCon.Extrenal_Inboxes.OrderBy(x => x.Id).FirstOrDefaultAsync(x => x.MailID == mail_id);
              //  model.side = await _dbCon.Extrmal_Sections.FindAsync(external_Mail.SectionId);
               // model.Sector = await _dbCon.Extrmal_Sections.FirstOrDefaultAsync(x => x.id == model.side.perent);



                model.external_sectoin = await _dbCon.external_Departments.Where(x => x.Mail_id == model.mail.MailID && x.state == true).Select(z => new Ex_Departments
                {

                    side_name = _dbCon.Extrmal_Sections.FirstOrDefault(v => v.id == z.side_number).Section_Name,
                    side_number = z.side_number,
                    id = z.id,
                    Mail_id = z.Mail_id,
                    sector_name = _dbCon.Extrmal_Sections.FirstOrDefault(v => v.id == z.sector_number).Section_Name,
                    sector_number = z.sector_number,
                    mail_forwarding=z.mail_forwarding
                   

                })
                        .ToListAsync();

                model.Inbox = _mapper.Map<Extrenal_inbox, Extrenal_inboxDto>(external_Mail);
                List<Mail_Resourcescs> mail_Resourcescs = await _dbCon.Mail_Resourcescs.Where(x => x.MailID == mail_id&&x.State==true).ToListAsync();
               // Send_to c = await _dbCon.Sends.Where(x =>  x.MailID == mail_id&&(dep == true||dep== false&&x.to == Depa )).FirstOrDefaultAsync();
               // Send_to c = await _dbCon.Sends.Where(x => x.MailID == mail_id && ((dep == true || dep == false) && x.to == Depa)).FirstOrDefaultAsync();
                Send_to c = await _dbCon.Sends.Where(x => x.MailID == mail_id && x.State==true && ((dep == true || dep == false) && x.to == Depa)).FirstOrDefaultAsync();


                model.mail_Resourcescs = _mapper.Map<List<Mail_Resourcescs>, List<Mail_ResourcescsDto>>(mail_Resourcescs);
                model.list = await(from x in _dbCon.Replies.Where(x => x.send_ToId == c.Id&&x.state.Equals(true)&&x.IsSend.Equals(true))
                                 //  join y in _dbCon.Reply_Resources.Where(x=>x.ReplyId==x.ID)
                                   select new RViewModel
                                   {
                                       reply = _mapper.Map<Reply, ReplayDto>(x),
                                       Resources = x._Resources.Where(a => a.State == true && x.ReplyId == x.ReplyId).Any()
                                   }).ToListAsync();

                //foreach (var xx in model.mail_Resourcescs)
                //{
                //    string x = xx.path;
                //    if (File.Exists(x))
                //    {
                //        xx.path = await tobase64(x);

                //    }

                //}

                //foreach (var item in model.list)
                //{
                //    foreach (var item2 in item.Resources)
                //    {
                //        string x1 = item2.path;
                //        if (File.Exists(x1))
                //        {
                //            item2.path = await tobase64(x1);

                //        }


                //    }
                //}


                return model;


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

       
    }
}
