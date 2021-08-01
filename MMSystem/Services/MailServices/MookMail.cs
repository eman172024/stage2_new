using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MMSystem.Model;
using MMSystem.Model.Dto;
using MMSystem.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Services.MailServices
{
    public class MookMail : IMailInterface

    {
        private readonly AppDbCon _appContext;

        public string sub { get; set; }

        private IWebHostEnvironment iwebHostEnvironment;

        public IExternalMailcs _external { get; }

        private readonly IMapper _mapper;
        private readonly IExtrenal_inbox _extrenal_Inbox;

        public MookMail(AppDbCon appContext, IWebHostEnvironment environment, IMapper mapper
            ,IExternalMailcs external, IExtrenal_inbox extrenal_Inbox)
        {
            _appContext = appContext;
            iwebHostEnvironment = environment;
           _external = external;
            _mapper = mapper;
            _extrenal_Inbox = extrenal_Inbox;
        }



        public async Task<bool> Add(Mail mail)
        {
            Result result = new Result();
            if (mail != null)
            {
            mail.Date_Of_Mail = DateTime.Now;
               mail.currentYear = DateTime.Now.Year;
                await _appContext.Mails.AddAsync(mail);

                await _appContext.SaveChangesAsync();



                return true;

            }
            
            return false;
        }

        public async Task<MailViewModel> addMail(MailViewModel mail)
        {


            MailViewModel mailViewModel = mail;

            try
            {
                string port = mail.mail.Mail_Type;

                switch (port)
                {
                    case "داخلي":
                       var  m =await Add(mail.mail);
                        mailViewModel.mail = mail.mail;



                        break;

                    case "صادر خارجي":
                        var s = await Add(mail.mail);
                        mailViewModel.mail = mail.mail;
                        mailViewModel.external_Mail.MailID = mailViewModel.mail.MailID;
                        
                        
                        bool s1 = await _external. Add(mail.external_Mail);
                        mailViewModel.external_Mail = mail.external_Mail;
                        break;




                    case "وارد خارجي":
                        var s11 = await Add(mail.mail);
                        mailViewModel.mail = mail.mail;
                        mailViewModel.extrenal_Inbox.MailID = mailViewModel.mail.MailID;

                        var s12 = await _extrenal_Inbox.Add(mail.extrenal_Inbox);
                        mailViewModel.extrenal_Inbox = mail.extrenal_Inbox;

                        break;
              
                       


                }
             return mailViewModel;

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

        public async Task<MailDto> Get(int id)
        {
            try
            {
                Mail mail =await  _appContext.Mails.FindAsync(id);
                MailDto dto = _mapper.Map<Mail, MailDto>(mail);
                return dto;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<MailDto>> GetAll()
        {
            try
            {
                List<Mail> mails = await _appContext.Mails.OrderByDescending(x => x.MailID).ToListAsync();

                List<MailDto> l = _mapper.Map<List<Mail>, List<MailDto>>(mails);

                return l;
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public async Task<bool> Update(Mail mail)
        {
            Mail _mail = await _appContext.Mails.FindAsync(mail.MailID);


            if (_mail != null) {

              _appContext.Mails.Update(mail);
                await _appContext.SaveChangesAsync();
               
                

                return true;

            }
           
            return false;


        }


      
        public async Task<bool> Upload(List<IFormFile> listOfPhotes)
        {
            try
            {
               

                foreach (var file in listOfPhotes)
                  
                {
                    if (file.Length > 0)
                    {
                        sub = "";

                        var cc = file.FileName.TakeLast(5);

                        foreach (var item in cc)
                        {
                            sub = sub + item.ToString();

                        }

                        Guid guid = Guid.NewGuid();
                        string x = guid.ToString() + "" + sub;

                        var path = Path.Combine(this.iwebHostEnvironment.WebRootPath, "images", x);

                      
                        var stream = new FileStream(path, FileMode.Create);

                        await file.CopyToAsync(stream);


                    }


                }
                return true;
            }
            catch (Exception)
            {
                throw;

            }
        }

        public async Task<List<MailDto>> GetInternalMail(int id)
        {
            try
            {
                var mails = await _appContext.Mails.Where(x => x.Management_Id == id).OrderByDescending(x => x.MailID).ToListAsync();

                List<MailDto> listOfMail = _mapper.Map<List<Mail>, List<MailDto>>(mails);

                return listOfMail;

            }
            catch (Exception)
            {

                throw;
            }
        
        }




        //public async Task<string> Upload(List<IFormFile> resourse)
        //{

        //  Mail_Resourcescs mail_Resourcescs = new Mail_Resourcescs();



        //    try
        //    {
        //        foreach (var item in resourse)
        //        {
        //            if (!Directory.Exists(_environment.WebRootPath + "\\uploads\\"))
        //            {
        //                Directory.CreateDirectory(_environment.WebRootPath + "\\uploads\\");
        //            }
        //            using (FileStream filestream = System.IO.File.Create(_environment.WebRootPath + "\\uploads\\" + item.FileName))
        //            {
        //                string guid = Guid.NewGuid().ToString(); 
        //                item.CopyTo(filestream);


        //                var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\uploads\", guid);

        //                mail_Resourcescs.path = guid;
        //                mail_Resourcescs.MailID = 1;
        //                await _appContext.Mail_Resourcescs.AddAsync(mail_Resourcescs);

        //                await _appContext.SaveChangesAsync();


        //            }

        //        }

        //        return "done";
        //    }
        //    catch (Exception ex) {

        //        return "error";
        //    }

        //    } } }
    }
}