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
            , IExternalMailcs external, IExtrenal_inbox extrenal_Inbox, IMail_Resourcescs resourcescs
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

                        mail.mail.Mail_Number = await GetLastMailNumber(mail.mail.Department_Id, port);


                        Email = await Add(mail.mail);

                        mailViewModel.mail = mail.mail;
                        if (Email)
                        {
                            foreach (var item in mail.actionSenders)
                            {
                                Send_to sender = new Send_to();

                                sender.MailID = mail.mail.MailID;
                                sender.to = item.departmentId;
                                sender.flag = false;
                                sender.type_of_send = item.measureId;
                                bool send = await _sender.Add(sender);
                            }


                            result = true;
                            break;
                        }


                        break;

                    case "صادر خارجي":
                        mail.mail.state = true;
                        mail.mail.Mail_Number = await GetLastMailNumber(mail.mail.Department_Id, port);

                        Email = await Add(mail.mail);
                        if (Email)
                        {

                            if (mail.external_Mail != null)
                            {

                                mail.external_Mail.MailID = mail.mail.MailID;

                                Exmail = await _external.Add(mail.external_Mail);

                                if (Exmail)
                                {
                                    foreach (var item in mail.actionSenders)
                                    {
                                        Send_to sender = new Send_to();

                                        sender.MailID = mail.mail.MailID;
                                        sender.to = item.departmentId;
                                        sender.flag = false;
                                        sender.type_of_send = item.measureId;
                                        bool send = await _sender.Add(sender);
                                    }
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
                        mail.mail.Mail_Number = await GetLastMailNumber(mail.mail.Department_Id, port);

                        Email = await Add(mail.mail);

                        if (Email)
                        {

                            mail.extrenal_Inbox.MailID = mail.mail.MailID;
                            Ex_inboxmail = await _extrenal_Inbox.Add(mail.extrenal_Inbox);

                            if (Ex_inboxmail)
                            {
                                foreach (var item in mail.actionSenders)
                                {
                                    Send_to sender = new Send_to();

                                    sender.MailID = mail.mail.MailID;
                                    sender.to = item.departmentId;
                                    sender.flag = false;
                                    sender.type_of_send = item.measureId;
                                    bool send = await _sender.Add(sender);
                                }
                                result = true;
                                break;

                            }
                            
                                _appContext.Mails.Remove(mail.mail);
                                await _appContext.SaveChangesAsync();
                            
                            



                            break;

                        }
                        break;
                    default: break;




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
                if (mail != null)
                {

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
                Mail mail = await _appContext.Mails.FindAsync(id);
                MailDto dto = _mapper.Map<Mail, MailDto>(mail);
                return dto;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> GetLastMailNumber(int id, string MailType)
        {
            try
            {
                int LastNumber = 0;
                switch (MailType)
                {
                    case "داخلي":
                        Mail mail = await _appContext.Mails.OrderBy(x => x.MailID).Where(x => x.Department_Id == id && x.Mail_Type.Equals("داخلي")).LastOrDefaultAsync();
                        if (mail != null)
                        {
                            LastNumber = mail.Mail_Number + 1;
                            break;
                        }
                        LastNumber += 1;

                        break;
                    case "صادر خارجي":
                        External_Mail external_Mail = await _appContext.External_Mails.OrderBy(x => x.ID).LastOrDefaultAsync();
                        if (external_Mail != null)
                        {
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
                List<Mail> mails = await _appContext.Mails.Where(x => x.state == true).OrderByDescending(x => x.MailID).ToListAsync();

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


            if (_mail != null)
            {
                //   _mail.action = mail.action;
                //  _mail.classification = mail.classification;

                _mail.Date_Of_Mail = mail.Date_Of_Mail;
                _mail.Mail_Summary = mail.Mail_Summary;
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
        public async Task<bool> UpdateMail(MailViewModel mail)
        {
            try
            {
                bool Email, Exmail, Ex_inboxmail, result = false;



                string port = mail.mail.Mail_Type;

                switch (port) {
                    case "داخلي":

                        Email = await Update(mail.mail);
                        if (Email) {

                            if (mail.actionSenders != null){

                                foreach (var item in mail.actionSenders)
                                {
                                    Send_to sender = new Send_to();

                                    sender.MailID = mail.mail.MailID;
                                    sender.to = item.departmentId;
                                    sender.flag = false;
                                    sender.type_of_send = item.measureId;
                                    bool send = await _sender.Add(sender);
                                }

                                result = true;
                                break;

                            }










                            result = true;
                            break;




                        }
                        
                        
                        
                        break;
                    case "صادر خارجي":

                        Email = await Update(mail.mail);
                        if (Email)
                        {

                            Exmail = await _external.Update(mail.external_Mail);
                            if (Exmail) {


                                if (mail.actionSenders !=null) {

                                    foreach (var item in mail.actionSenders)
                                    {
                                        Send_to sender = new Send_to();

                                        sender.MailID = mail.mail.MailID;
                                        sender.to = item.departmentId;
                                        sender.flag = false;
                                        sender.type_of_send = item.measureId;
                                        bool send = await _sender.Add(sender);
                                    }
                                    result = true;
                                    break;


                                }


                                result = true;
                                break;


                            }




                            break;

                        }
                        break;
                    case "وارد خارجي":

                        Email = await Update(mail.mail);
                        if (Email) {

                            mail.extrenal_Inbox.MailID = mail.mail.MailID;
                            Ex_inboxmail = await _extrenal_Inbox.Update(mail.extrenal_Inbox);
                            if (Ex_inboxmail) {

                                if (mail.actionSenders.Count > 0)
                                {

                                    foreach (var item in mail.actionSenders)
                                    {
                                        Send_to sender = new Send_to();

                                        sender.MailID = mail.mail.MailID;
                                        sender.to = item.departmentId;
                                        sender.flag = false;
                                        sender.type_of_send = item.measureId;
                                        bool send = await _sender.Add(sender);
                                    }
                                    result = true;
                                    break;
                                }
                                result = true;
                                break;
                            
                            
                            }
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
                        mail.path = "wwwroot/images/" + x;
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
                List<Mail> mails = await _appContext.Mails.Where(x => x.Department_Id == id && x.state == true && x.Mail_Type == "داخلي").OrderByDescending(x => x.MailID).Skip((page - 1) * PageSize).Take(page).ToListAsync();

                if (mails.Count > 0)
                {
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



        public async Task<bool> UpdateFile(int id, List<IFormFile> listOfPhotes)
        {
            
            var list = await _appContext.Mail_Resourcescs.Where(x => x.MailID == id).ToListAsync();

            var listto = list;
            int index = 0;

            if (list.Count > 0 && listOfPhotes.Count > 0)
            {

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


        public async Task<bool> UpdateFile(Uplode uplode)
        {
            Mail_Resourcescs resourse = new Mail_Resourcescs();
           List<Mail_Resourcescs> res = await _appContext.Mail_Resourcescs.Where(x=>x.MailID==uplode.mail_id).ToListAsync();
            foreach (var item in res)
            {

          
            }


            return true;

              




        }


        public async Task<bool> DeletePhote(int  id)
        {
            try
            {
                Mail_Resourcescs res = await _appContext.Mail_Resourcescs.FirstOrDefaultAsync(x => x.ID == id);

                if (System.IO.File.Exists(res.path))
                {
                    System.IO.File.Delete(res.path);

                     _appContext.Mail_Resourcescs.Remove(res);
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



        public async Task<List<MailDto>> getExternalMail(int id)
        {
            try
            {
                List<Mail> list = await _appContext.Mails.Where(x => x.Department_Id == id && x.Mail_Type.Equals("صادر خارجي")).ToListAsync();


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
                List<Mail> list = await _appContext.Mails.Where(x => x.Department_Id == id && x.Mail_Type.Equals("وارد خارجي")).ToListAsync();


                List<MailDto> listDto = _mapper.Map<List<Mail>, List<MailDto>>(list);
                return listDto;



            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<bool> Uplode(Uplode file)
        {
            try
            {
                foreach (var item in file.list)
                {
                    var index = item.baseAs64.IndexOf(',');
                    var bsee64string = item.baseAs64.Substring(index + 1);
                    index = item.baseAs64.IndexOf(';');
                    var base64signtuer = item.baseAs64.Substring(0, index);
                    index = item.baseAs64.IndexOf('/');
                    var extention = base64signtuer.Substring(index + 1);
                    byte[] bytes = Convert.FromBase64String(bsee64string);
                    Guid guid = Guid.NewGuid();
                    string x = guid.ToString();
                    var path = Path.Combine(this.iwebHostEnvironment.WebRootPath, "images", x+".");


                    await File.WriteAllBytesAsync(path + extention, bytes);
                    Mail_Resourcescs mail = new Mail_Resourcescs();
                    mail.MailID =file.mail_id ;
                    mail.path = path+ extention;
                    mail.order = item.index;
                    bool res = await _resourcescs.Add(mail);




                }

                return true;

            }
            catch (Exception)
            {

                throw;
            }





        }

        public async Task<List<MailDto>> GetSevenMail()
        {
            try
            {
                var list = await _appContext.Mails.Where(x => x.state == true).Take(6).OrderByDescending(x => x.MailID).ToListAsync();

                if (list.Count > 0)
                {

                    List<MailDto> mailDtos = _mapper.Map<List<Mail>, List<MailDto>>(list);

                    return mailDtos;

                }
                return null;



            }
            catch (Exception)
            {

                throw;
            }

        }

        public Task<bool> up(UplodeFile ss)
        {
            throw new NotImplementedException();
        }

        public async Task<MailVM> GetMailById(int id)
        {

            try
            {

                {
                    MailVM mail = new MailVM();


                    MailDto dto = await Get(id);
                    if (dto != null)
                    {


                        mail.mailDto = dto;
                        List<Send_to> sends = await _appContext.Sends.Where(x => x.MailID == mail.mailDto.MailID).ToListAsync();

                        ActionSender sender = new ActionSender();
                        foreach (var item in sends)
                        {
                            Department departments = await _appContext.Departments.FindAsync(item.to);
                            Measures measures = await _appContext.measures.FindAsync(item.type_of_send);

                            mail.actionSenders.Add(new ActionSender()
                            {


                                departmentName = departments.DepartmentName,
                                measureId = item.type_of_send,
                                measureName = measures.MeasuresName,
                                departmentId = departments.Id
                            }




                            );

                            mail.resourcescs = await _resourcescs.GetAll(mail.mailDto.MailID);


                            foreach (var xx in mail.resourcescs)
                            {
                                string x = xx.path;
                                xx.path = await bas(x);

                            }




                        }





                        return mail;


                    }


                    return null;
                }
            }


            catch (Exception)
            {

                throw;


            }


            
       


        }

        public async Task< string> bas(string patj) {


            var attachmentType = System.IO.Path.GetExtension(patj);
            var Type = attachmentType.Substring(1, attachmentType.Length - 1);
            var filePath = System.IO.Path.Combine(patj);
            byte[] fileBytes =await System.IO.File.ReadAllBytesAsync(filePath);
            var ImageBase64 = "data:image/" + Type + ";base64," + Convert.ToBase64String(fileBytes);
            return ImageBase64;

        }

        public async Task<bool> deleteSender(int mail_id,int departmentId)
        {
            try
            {
                Send_to send_ = await _appContext.Sends.FirstOrDefaultAsync(x => x.MailID == mail_id && x.to == departmentId);
                if (send_ != null) {
                    _appContext.Sends.Remove(send_);
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


    }
}




      
  
