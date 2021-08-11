﻿using AutoMapper;
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

namespace MMSystem.Services.MailServeic
{
    public class MookMail : IMailInterface

    {
        private readonly AppDbCon _appContext;

        public string sub { get; set; }

        private IWebHostEnvironment iwebHostEnvironment;

        public IExternalMailcs _external { get; }


        private readonly IMapper _mapper;


        private readonly IExtrenal_inbox _extrenal_Inbox;
        private IMail_Resourcescs _resourcescs;
        private readonly ISender _sender;

        public MookMail(AppDbCon appContext, IWebHostEnvironment environment, IMapper mapper
            ,IExternalMailcs external, IExtrenal_inbox extrenal_Inbox, IMail_Resourcescs resourcescs
            , ISender sender
            )
        {
            _appContext = appContext;
            iwebHostEnvironment = environment;
           _external = external;
            _mapper = mapper;
            _extrenal_Inbox = extrenal_Inbox;
            _resourcescs = resourcescs;
            _sender = sender;
        }



        public async Task<bool> Add(Mail mail)
        {
         
            if (mail != null)
            {
            mail.Date_Of_Mail = DateTime.Now;
              
                await _appContext.Mails.AddAsync(mail);

                await _appContext.SaveChangesAsync();



                return true;

            }
            
            return false;
        }

        public async Task<bool> addMail(MailViewModel mail)
        {


            MailViewModel mailViewModel = mail;

            try
            {
                bool Email;
                bool Exmail;
                bool Ex_inboxmail;
                bool result = false;
                string port = mail.mail.Mail_Type;

                switch (port)
                {
                    case "داخلي":
                        mail.mail.state = true;

                        mail.mail.Mail_Number =await GetLastMailNumber(mail.mail.Management_Id,port);
              

                        Email = await Add(mail.mail);
                   
                        mailViewModel.mail = mail.mail;
                        if (Email)
                        {
                            Send_to sender = new Send_to();
                            sender.MailID = mail.mail.MailID;
                            sender.to = mail.section;
                        bool send = await _sender.Add(sender);
                            result = true;
                            break;
                        }


                        break;

                    case "صادر خارجي":
                        mail.mail.state = true;
                        mail.mail.Mail_Number = await GetLastMailNumber(mail.mail.Management_Id,port);

                        Email = await Add(mail.mail);
                        if (Email)
                        {

                            if (mail.external_Mail != null) {

                                mail.external_Mail.MailID = mail.mail.MailID;

                                Exmail = await _external.Add(mail.external_Mail);

                                if (Exmail)
                                {
                                    Send_to sender = new Send_to();
                                    sender.MailID = mail.mail.MailID;
                                    sender.to = mail.section;
                                    bool send = await _sender.Add(sender);
                                    result = true;
                                    break;
                                }

                                _appContext.Mails.Remove(mail.mail);
                                await _appContext.SaveChangesAsync();

                            }
                           




                        }
                        break;


                    case "وارد خارجي":
                        mail.mail.state = true;
                        mail.mail.Mail_Number = await GetLastMailNumber(mail.mail.Management_Id,port);

                        Email = await Add(mail.mail);

                        if (Email)
                        {

                            mail.extrenal_Inbox.MailID = mail.mail.MailID;
                            Ex_inboxmail = await _extrenal_Inbox.Add(mail.extrenal_Inbox);

                            if (Ex_inboxmail)
                            {
                                result = true;
                                Send_to sender = new Send_to();
                                sender.MailID = mail.mail.MailID;
                                sender.to = mail.section;
                                bool send = await _sender.Add(sender);
                                break;

                            }
                            _appContext.Mails.Remove(mail.mail);
                            await _appContext.SaveChangesAsync();



                            break;

                        }
                        break;
                    default:break;




                }
                return result;

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
                Mail mail = await _appContext.Mails.FindAsync(id);
                if (mail != null) {

                    mail.state = false;
                    _appContext.Mails.Update(mail);
                    await _appContext.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
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

        public async Task<int> GetLastMailNumber(int id,string MailType)
        {
            try
            {
                int LastNumber=0;
                switch (MailType)
                {
                    case "داخلي":
                        Mail mail = await _appContext.Mails.OrderBy(x => x.MailID).Where(x => x.Management_Id == id&&x.Mail_Type.Equals("داخلي")).LastOrDefaultAsync();
                        if (mail != null) {
                            LastNumber = mail.Mail_Number + 1;
                            break;
                        }
                        LastNumber += 1;
                   
                   break;
                    case "صادر خارجي":
                        External_Mail external_Mail = await _appContext.External_Mails.OrderBy(x => x.ID).LastOrDefaultAsync();
                        if (external_Mail != null) {
                            LastNumber = external_Mail.ID + 1;
                            break;

                        }
                        LastNumber = LastNumber + 1;
                        break;
                    case "وارد خارجي":

                        Extrenal_inbox _Inbox = await _appContext.Extrenal_Inboxes.OrderBy(x => x.Id).LastOrDefaultAsync();
                         if (_Inbox != null)
                        {
                            LastNumber = _Inbox.Id + 1;
                            break;

                        }
                        LastNumber = LastNumber + 1;

                        break;
                    default:
                        break;
                }



                return LastNumber;
              

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
                List<Mail> mails = await _appContext.Mails.Where(x=>x.state==true).OrderByDescending(x => x.MailID).ToListAsync();

                List<MailDto> listdto = _mapper.Map<List<Mail>, List<MailDto>>(mails);

                return listdto;
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
              _mail.Action_Required = mail.Action_Required;
          _mail.classification = mail.classification;
              _mail.currentYear = mail.currentYear;
           _mail.Date_Of_Mail = mail.Date_Of_Mail;
              _mail.Mail_Summary = mail.Mail_Summary;
                _mail.currentYear = mail.currentYear;
                _mail.state = mail.state;
                _mail.userId = mail.userId;
                _mail.Genaral_inbox_year = mail.Genaral_inbox_year;
                _mail.Genaral_inbox_Number = mail.Genaral_inbox_Number;
                _mail.Date_Of_Mail = mail.Date_Of_Mail;
                _mail.Mail_Number = mail.Mail_Number;

              _appContext.Mails.Update(_mail);
                await _appContext.SaveChangesAsync();
               
                

                return true;

            }
           
            return false;


        }


      
        public async Task<bool> Upload(int id, List<IFormFile> listOfPhotes)
        {
            try
            {
                if (listOfPhotes.Count > 0)
                {
                    foreach (var file in listOfPhotes)
                    {
                        sub = "";

                        IEnumerable<char> takeFiveChar = file.FileName.TakeLast(5);

                        foreach (var item in takeFiveChar)
                        {
                            sub = sub + item.ToString();

                        }

                        Guid guid = Guid.NewGuid();
                        string x = guid.ToString() + "" + sub;

                        var path = Path.Combine(this.iwebHostEnvironment.WebRootPath, "images", x);

                        //  file.FileName.Replace(file.FileName,x);
                        var stream = new FileStream(path, FileMode.Create);

                        await file.CopyToAsync(stream);
                        Mail_Resourcescs mail = new Mail_Resourcescs();
                        mail.MailID = id;
                        mail.path = "wwwroot/images/"+x;
                        bool res = await _resourcescs.Add(mail);



                    }
                    return true;

                }
                return false;
                
            }
            catch
            {
                throw;
            }


        }


   


        public async Task<Pagenation<MailDto>> PaganationList(int page, int PageSize, int id)
        {
            try
            {
                Pagenation<MailDto> pagenation = new Pagenation<MailDto>();
                List<Mail> mails = await _appContext.Mails.Where(x => x.Management_Id == id && x.state==true && x.Mail_Type == "داخلي").OrderByDescending(x => x.MailID).Skip((page - 1) * PageSize).Take(page).ToListAsync();

                if (mails.Count > 0) {
                    pagenation.Count = mails.Count();
                    pagenation.list = _mapper.Map<List<Mail>, List<MailDto>>(mails);

                    return pagenation;
                }
               
                return null;
            }
            catch (Exception)
            {

                throw;
            }
          

        }

        public async Task<List<Re>> Sendermail(int id)
        {
            try
            {
                var lis = await (from mail in _appContext.Mails.Where(x => x.Management_Id == id)
                                 join sender in _appContext.Sends on mail.MailID equals sender.MailID
                                 select new Re { MailID = mail.MailID, Mail_Summary = mail.Mail_Summary, to = sender.to }).ToListAsync();
                return lis;

            }
            catch (Exception)
            {

                throw;
            }

         
        }

        public async Task<bool> UpdateFile(int id, List<IFormFile> listOfPhotes)
        {
           
            var list = await _appContext.Mail_Resourcescs.Where(x => x.MailID == id).ToListAsync();

            var listto = list;
            int index = 0;

            if (list.Count > 0 &&listOfPhotes.Count>0) {

                //for delete photo
                foreach (var item in list)
                {
                    if (System.IO.File.Exists(item.path))
                        System.IO.File.Delete(item.path);
                }
                foreach (var file in listOfPhotes)
                {
                    sub = "";

               IEnumerable<char> takeFiveChar = file.FileName.TakeLast(5);

                    foreach (var item in takeFiveChar)
                    {
                        sub = sub + item.ToString();

                    }

                    Guid guid = Guid.NewGuid();
                    var xx = guid.ToString() + "" + sub;

                    var path = Path.Combine(this.iwebHostEnvironment.WebRootPath, "images", xx);

                    //  file.FileName.Replace(file.FileName,x);
                    var stream = new FileStream(path, FileMode.Create);

                    await file.CopyToAsync(stream);
                    Mail_Resourcescs mail = listto.ElementAt(index);
                  
                    mail.path = "wwwroot/images/" + xx;
                    bool res = await _resourcescs.Update(mail);
                    index += 1;

                  

                }
                return true;

            }
            return false;

              


                }

        public async Task<List<Re>> ResevidMail(int id)
        {
            try
            {
                var lis = await(from mail in _appContext.Mails
                                join sender in _appContext.Sends.Where(x=>x.to==id) on mail.MailID equals sender.MailID 
                                select new Re { MailID = mail.MailID, Mail_Summary = mail.Mail_Summary, to = sender.to }).ToListAsync();
                return lis;

            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<List<MailDto>> getExternalMail(int id)
        {
            try
            {
                List<Mail> list = await _appContext.Mails.Where(x => x.Management_Id == id&&x.Mail_Type.Equals("صادر خارجي")).ToListAsync();


                List<MailDto> listDto = _mapper.Map<List<Mail>, List<MailDto>>(list);
                return listDto;



            }
            catch (Exception)
            {

                throw;
            }
           

        }

        public async Task<List<MailDto>> getExternalInbox(int id)
        {
            try
            {
                List<Mail> list = await _appContext.Mails.Where(x => x.Management_Id == id && x.Mail_Type.Equals("وارد خارجي")).ToListAsync();


                List<MailDto> listDto = _mapper.Map<List<Mail>, List<MailDto>>(list);
                return listDto;



            }
            catch (Exception)
            {

                throw;
            }

        }

        //public async Task<ExternalViewModel> getExternalMail(int id)
        //{
        //    try
        //    {
        //        ExternalViewModel model = new ExternalViewModel();
        //    model.list = await (from mail in _appContext.Mails.Where(x=>x.Management_Id==id&&x.Mail_Type== "صادر خارجي")
        //                                join ex in _appContext.External_Mails on mail.MailID equals ex.MailID
        //                        join re in _appContext.Mail_Resourcescs on mail.MailID equals re.MailID

        //                        select new ExMail
        //                                {
        //                                    mail = new MailDto
        //                                    {
        //                                        Action_Required = mail.Action_Required,
        //                                        MailID = mail.MailID,
        //                                        currentYear = mail.currentYear,
        //                                        classification = mail.classification,
        //                                        Date_Of_Mail = mail.Date_Of_Mail,
        //                                        Genaral_inbox_Number = mail.Genaral_inbox_Number,
        //                                        Genaral_inbox_year = mail.Genaral_inbox_year,
        //                                        Mail_Summary = mail.Mail_Summary,
        //                                        Mail_Type = mail.Mail_Type,
        //                                        Management_Id = mail.Management_Id,
        //                                        Mail_Number = mail.Mail_Number,
        //                                        userId = mail.userId

        //                                    },
        //                                    External = new ExternalDto() {
        //                                   ID=ex.ID,
        //                                   action_Requierd=ex.action_Requierd,
        //                                   MailID=ex.MailID,
        //                                   Sectionid=ex.Sectionid,
        //                                   sectionName=ex.sectionName

        //                                        },
        //                                    resourcescsDto=new List<Mail_Resourcescs>{
        //                                        new Mail_Resourcescs(){ 
        //                                         ID=re.ID,
        //                                        path=re.path}


        //                                    }


        //                        }).ToListAsync();
        //        ExternalViewModel model2 = new ExternalViewModel();
        //        foreach (var item in model.list)

        //        {
        //            model2.list.Add(new ExMail
        //            {
        //                mail = item.mail,
        //                External = item.External,
        //                resourcescsDto= await _appContext.Mail_Resourcescs.Where(x=>x.MailID==item.mail.MailID).ToListAsync()
        //            }); 



        //        }
        //        model.count = model.list.Count;
        //        model2.count = model.count;








        //        return model;

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }

        //}


    }

        }




      
  