using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MMSystem.Model;
using MMSystem.Model.Dto;
using MMSystem.Model.ViewModel;
using MMSystem.Model.ViewModel.MailVModels;
using MMSystem.Services.Histor;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Services.MailServeic
{
    public class MookMail : IMailInterface

    {
        dynamic c;
        dynamic serch;
         
       

        private readonly AppDbCon _appContext;

        public string sub { get; set; }

        private IWebHostEnvironment iwebHostEnvironment;

        private IExternalMailcs _external;


        private readonly IMapper _mapper;


        private readonly IExtrenal_inbox _extrenal_Inbox;
        private IMail_Resourcescs _resourcescs;
        private readonly ISender _sender;
        private readonly IHistory _history;

        public MookMail(AppDbCon appContext, IWebHostEnvironment environment, IMapper mapper
            , IExternalMailcs external, IExtrenal_inbox extrenal_Inbox, IMail_Resourcescs resourcescs
            , ISender sender,
            IHistory history
            )
        {
            _appContext = appContext;
            iwebHostEnvironment = environment;
            _external = external;
            _mapper = mapper;
            _extrenal_Inbox = extrenal_Inbox;
            _resourcescs = resourcescs;
            _sender = sender;
            _history = history;
        }



        public async Task<bool> Add(Mail mail)
        {

            if (mail != null)
            {
              
                mail.Mail_Summary = mail.Mail_Summary + " ";
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
                int port = mail.mail.Mail_Type;

                switch (port)
                {
                    case 1:
                        mail.mail.state = true;

                        mail.mail.Mail_Number = await GetLastMailNumber(mail.mail.Department_Id, port);


                        Email = await Add(mail.mail);

                        mailViewModel.mail = mail.mail;
                        if (Email)
                        {
                            //for (var item in mail.actionSenders)
                            //{
                            //    Send_to sender = new Send_to();
                            Historyes histor = new Historyes();
                          
                            histor.currentUser = mail.mail.userId;
                            histor.mailid = mail.mail.MailID;
                            histor.Time = DateTime.Now;
                            histor.HistortyNameID = 1;
                                
                            bool res = await _history.Add(histor);

                            //    sender.MailID = mail.mail.MailID;
                            //    sender.to = item.departmentId;
                            //    sender.flag = 1;
                            //    sender.type_of_send = item.measureId;
                            //    bool send = await _sender.Add(sender);
                            //}

                            for (int i = 0; i < mail.actionSenders.Count; i++)
                            {
                                Send_to sender = new Send_to();


                                if (i == (mail.actionSenders.Count - 1))
                                {
                                    sender.isMulti = true;
                                }
                                else
                                {
                                    sender.isMulti = false;
                                }
                                sender.MailID = mail.mail.MailID;
                                sender.to = mail.actionSenders[i].departmentId;
                                sender.flag = 1;
                                sender.State = true;
                                sender.type_of_send = mail.actionSenders[i].measureId;
                                bool send = await _sender.Add(sender);
                            }
                            result = true;
                            break;
                        }


                        break;

                    case 2:
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
                                    //foreach (var item in mail.actionSenders)
                                    //{
                                    //    Send_to sender = new Send_to();

                                    //    sender.MailID = mail.mail.MailID;
                                    //    sender.to = item.departmentId;
                                    //    sender.flag = 1;
                                    //    sender.type_of_send = item.measureId;
                                    //    bool send = await _sender.Add(sender);
                                    //}
                                    Historyes histor = new Historyes();

                                    histor.currentUser = mail.mail.userId;
                                    histor.mailid = mail.mail.MailID;
                                    histor.Time = DateTime.Now;
                                    histor.HistortyNameID = 1;
                                    bool res = await _history.Add(histor);

                                    for (int i = 0; i < mail.actionSenders.Count; i++)
                                    {
                                        Send_to sender = new Send_to();


                                        if (i == (mail.actionSenders.Count - 1))
                                        {
                                            sender.isMulti = true;
                                        }
                                        else
                                        {
                                            sender.isMulti = false;
                                        }
                                        sender.MailID = mail.mail.MailID;
                                        sender.to = mail.actionSenders[i].departmentId;
                                        sender.flag = 1;
                                        sender.State = true;

                                        sender.type_of_send = mail.actionSenders[i].measureId;
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


                    case 3:
                        mail.mail.state = true;
                        mail.mail.Mail_Number = await GetLastMailNumber(mail.mail.Department_Id, port);

                        Email = await Add(mail.mail);

                        if (Email)
                        {

                            mail.extrenal_Inbox.MailID = mail.mail.MailID;
                            Ex_inboxmail = await _extrenal_Inbox.Add(mail.extrenal_Inbox);

                            if (Ex_inboxmail)
                            {


                                Historyes histor = new Historyes();

                                histor.currentUser = mail.mail.userId;
                                histor.mailid = mail.mail.MailID;
                                histor.Time = DateTime.Now;
                                histor.HistortyNameID = 1;
                                bool res = await _history.Add(histor);
                                //foreach (var item in mail.actionSenders)
                                //{
                                //    Send_to sender = new Send_to();

                                //    sender.MailID = mail.mail.MailID;
                                //    sender.to = item.departmentId;
                                //    sender.flag = 1;
                                //    sender.type_of_send = item.measureId;
                                //    bool send = await _sender.Add(sender);
                                //}

                                for (int i = 0; i < mail.actionSenders.Count; i++)
                                {
                                    Send_to sender = new Send_to();


                                    if (i == (mail.actionSenders.Count - 1))
                                    {
                                        sender.isMulti = true;
                                    }
                                    else
                                    {
                                        sender.isMulti = false;
                                    }
                                    sender.MailID = mail.mail.MailID;
                                    sender.to = mail.actionSenders[i].departmentId;
                                    sender.flag = 1;
                                    sender.State = true;

                                    sender.type_of_send = mail.actionSenders[i].measureId;
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

        public async Task<bool> Delete(int id, int userid, int mailId)
        {
            try
            {
              

                    Mail mail = await _appContext.Mails.Where(x => x.Department_Id == id && x.MailID == mailId).FirstOrDefaultAsync();
                    if (mail != null)
                    {
                    Historyes historyes = new Historyes();
                    historyes.currentUser = userid;
                    historyes.mailid = mailId;
                    historyes.HistortyNameID = 3;
                    historyes.Time = DateTime.Now;
                    historyes.changes = $"{mailId}   تم حدف البريد رقم ";


                        mail.state = false;
                        _appContext.Mails.Update(mail);
                    await _appContext.History.AddAsync(historyes);


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

        public async Task<bool> Delete(int id)
        {
            try
            {




                Mail mail = await _appContext.Mails.FindAsync(id);
                if (mail != null)
                {

                    mail.state = false;
                    _appContext.Mails.Update(mail);
                    Historyes histor = new Historyes();
                    histor.currentUser = mail.userId;
                    histor.mailid = id;
                    histor.Time = DateTime.Now;
                    histor.HistortyNameID = 4;
                    histor.Time = DateTime.Now;
                    bool res = await _history.Add(histor);



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
                MailDto dto1 = new MailDto();




                Mail mail2 = await _appContext.Mails.FirstOrDefaultAsync(x => x.MailID == id && x.Mail_Type == 2);
                dto1 = _mapper.Map<Mail, MailDto>(mail2);
                return dto1;

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
                        Mail mail = await _appContext.Mails.FirstOrDefaultAsync(x => x.MailID == id && x.Mail_Type == 1 && x.state == true);
                        dto1 = _mapper.Map<Mail, MailDto>(mail);

                        break;
                    case 2:
                        Mail mail1 = await _appContext.Mails.FirstOrDefaultAsync(x => x.MailID == id && x.Mail_Type == 2 && x.state == true);
                        dto1 = _mapper.Map<Mail, MailDto>(mail1);

                        break;
                    case 3:
                        Mail mail2 = await _appContext.Mails.FirstOrDefaultAsync(x => x.MailID == id && x.Mail_Type == 3 && x.state == true);
                        dto1 = _mapper.Map<Mail, MailDto>(mail2);
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


        public async Task<MailDto> Getdto(int id, int type, int date, int departmentId)
        {
            try
            {
                MailDto dto1 = new MailDto();

                switch (type)
                {

                    case 1:
                        Mail mail = await _appContext.Mails.FirstOrDefaultAsync(x => x.Mail_Number == id && x.Mail_Type == 1 && x.Date_Of_Mail.Year == date && x.Department_Id == departmentId && x.state == true);
                        dto1 = _mapper.Map<Mail, MailDto>(mail);

                        break;
                    case 2:
                        Mail mail1 = await _appContext.Mails.FirstOrDefaultAsync(x => x.Mail_Number == id && x.Mail_Type == 2 && x.Date_Of_Mail.Year == date && x.Department_Id == departmentId && x.state == true);

                        dto1 = _mapper.Map<Mail, MailDto>(mail1);

                        break;
                    case 3:
                        Mail mail2 = await _appContext.Mails.FirstOrDefaultAsync(x => x.Mail_Number == id && x.Mail_Type == 3 && x.Date_Of_Mail.Year == date && x.Department_Id == departmentId && x.state == true);
                        dto1 = _mapper.Map<Mail, MailDto>(mail2);
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


        public async Task<int> GetLastMailNumber(int id, int MailType)
        {
            try
            {
                int year = DateTime.Now.Year;
                int LastNumber = 0;
                switch (MailType)
                {
                    case 1:
                        Mail mail = await _appContext.Mails.OrderBy(x => x.MailID).Where(x => x.Department_Id == id && x.Mail_Type == 1 && x.Date_Of_Mail.Year == year).LastOrDefaultAsync();
                        if (mail != null)
                        {
                            LastNumber = mail.Mail_Number + 1;
                            break;
                        }
                        LastNumber += 1;

                        break;
                    case 2:
                        External_Mail external_Mail = await _appContext.External_Mails.OrderBy(x => x.ID).LastOrDefaultAsync();
                        if (external_Mail != null)
                        {
                            LastNumber = external_Mail.ID + 1;
                            break;

                        }
                        LastNumber = LastNumber + 1;
                        break;
                    case 3:

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
                List<Mail> mails = await _appContext.Mails.Where(x => x.state == true).
                    OrderByDescending(x => x.MailID).ToListAsync();

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
            List<HVModel> hVModels = new List<HVModel>();


            if (_mail != null)
            {

                Historyes histor = new Historyes();

                histor.currentUser = mail.userId;
                histor.mailid = mail.MailID;
                histor.HistortyNameID = 2;
                histor.changes = _mail.Mail_Summary + " " + _mail.Genaral_inbox_Number.ToString() 
                     + " " +mail.Date_Of_Mail.ToString()+" "+ _mail.Genaral_inbox_year.ToString()
                     
                     +" " +mail.Genaral_inbox_Number.ToString();
              
                //old.Add("ملخص الموضوع", _mail.Mail_Summary);

                //old.Add("تاريخ البريد", _mail.Date_Of_Mail);

                //old.Add("رقم الوارد العام", _mail.Genaral_inbox_Number);
                //old.Add("الاجراء المصلوب", _mail.ActionRequired);


                //newvalue.Add("الموضوع", mail.Mail_Summary);

                //newvalue.Add("البريد", mail.Date_Of_Mail);

                //newvalue.Add("رقم الوارد العام", mail.Genaral_inbox_Number);
                //newvalue.Add("الاجراء المصلوب", mail.ActionRequired);

                //    string results= Histoteyvm.getValue(old,newvalue); 

                _mail.Date_Of_Mail = mail.Date_Of_Mail;
                _mail.Mail_Summary = mail.Mail_Summary + " ";
                _mail.state = mail.state;
                _mail.userId = mail.userId;
                _mail.Genaral_inbox_year = mail.Genaral_inbox_year;
                _mail.Genaral_inbox_Number = mail.Genaral_inbox_Number;
                _mail.Date_Of_Mail = mail.Date_Of_Mail;

                _mail.clasification = mail.clasification;
                _mail.ActionRequired = mail.ActionRequired;


                string fff = Histoteyvm.getValue(hVModels);


                _appContext.Mails.Update(_mail);
                await _appContext.SaveChangesAsync();
                histor.changes = mail.Mail_Summary + " " + mail.Genaral_inbox_Number.ToString()
                    + " " + mail.Date_Of_Mail.ToString() + " " + mail.Genaral_inbox_year.ToString()

                    + " " + mail.Genaral_inbox_Number.ToString();

                
                histor.Time = DateTime.Now;



                return true;

            }

            return false;


        }
        public async Task<bool> UpdateMail(MailViewModel mail)
        {
            try
            {
                bool Email, Exmail, Ex_inboxmail, result = false;
                int flag = 0;

                string numOfSend = "";


                int port = mail.mail.Mail_Type;

                switch (port)
                {
                    case 1:

                        Email = await Update(mail.userId,mail.mail);
                        if (Email)
                
                        
                        {
                            var obj = await _appContext.Sends.FirstOrDefaultAsync(x=>x.MailID==mail.mail.MailID);
                            if (obj.flag > 1)
                            {
                                flag = 2;
                            }
                            else {
                                flag = 1;
                            
                            }


                            if (mail.newactionSenders.Count > 0)
                            {
                                for (int i = 0; i < mail.newactionSenders.Count; i++)
                                {
                                    Send_to sender = new Send_to();

                                   

                                    sender.MailID = mail.mail.MailID;
                                    sender.to = mail.newactionSenders[i].departmentId;
                                    numOfSend = numOfSend + " " + sender.to.ToString();

                                    sender.flag = flag;
                                    sender.State = true;
                                    sender.type_of_send = mail.newactionSenders[i].measureId;
                                    bool send = await _sender.Add(sender);
                                }
                                Historyes histor = new Historyes();
                                histor.currentUser = mail.userId;

                                histor.mailid = mail.mail.MailID;
                                histor.HistortyNameID = 8;
                                histor.changes = $"تمت اضافة ادارة جديدة { numOfSend}";
                                histor.Time = DateTime.Now;

                                await _appContext.History.AddAsync(histor);

                                await _appContext.SaveChangesAsync();

                            }
                            else { }
                          
                           




                            result = true;
                            break;




                        }


                        result = true;


                        break;
                    case 2:
                        //delete to test
                        //Email = await Update(mail.userId,mail.mail);
                        //if (Email)
                        //{

                        //    var obj = await _appContext.Sends.FirstOrDefaultAsync(x => x.MailID == mail.mail.MailID);
                        //    if (obj.flag > 1)
                        //    {
                        //        flag = 2;
                        //    }
                        //    else
                        //    {
                        //        flag = 1;

                        //    }
                        //    mail.external_Mail.MailID = mail.mail.MailID;

                        //    Exmail = await _external.Update(mail.userId,mail.external_Mail);
                        //    if (Exmail)
                        //    {
                        //        if (mail.newactionSenders.Count > 0)
                        //        {
                        //            for (int i = 0; i < mail.newactionSenders.Count; i++)
                        //            {
                        //                Send_to sender = new Send_to();

                        //                sender.State = true;

                        //                sender.MailID = mail.mail.MailID;
                        //                sender.to = mail.newactionSenders[i].departmentId;
                        //                sender.flag = flag;
                        //                sender.type_of_send = mail.newactionSenders[i].measureId;
                        //                bool send = await _sender.Add(sender);
                        //            }
                        //            result = true;
                        //            break;

                        //        }
                        //        else { }

                        //        result = true;
                        //        break;


                        //    }




                        //    break;

                        //}


                        // delete to test


                        //start new 

                        bool isUpdate = await _external.Update(mail.mail,mail.external_Mail,mail.userId);

                        if (isUpdate)
                        {
                            if (mail.newactionSenders.Count > 0)
                            {
                                for (int i = 0; i < mail.newactionSenders.Count; i++)
                                {
                                    Send_to sender = new Send_to();

                                    
                                    sender.State = true;

                                    sender.MailID = mail.mail.MailID;
                                    sender.to = mail.newactionSenders[i].departmentId;
                                    numOfSend = numOfSend + " " + sender.to.ToString();
                                    sender.flag = flag;
                                    sender.type_of_send = mail.newactionSenders[i].measureId;
                                    bool send = await _sender.Add(sender);
                                }


                                Historyes histor = new Historyes();
                                histor.currentUser = mail.userId;

                                histor.mailid = mail.mail.MailID;
                                histor.HistortyNameID = 8;
                                histor.changes = $"تمت اضافة ادارة جديدة { numOfSend}";
                                histor.Time = DateTime.Now;

                                await _appContext.History.AddAsync(histor);

                                await _appContext.SaveChangesAsync();

                                result = true;
                                break;

                            }
                            else { }

                            result = true;
                            break;


                        }



                            break;

                        //ende start
                    case 3:

                        //old function

                        //Email = await Update(mail.mail);
                        //if (Email)
                        //{
                        //    var obj = await _appContext.Sends.FirstOrDefaultAsync(x => x.MailID == mail.mail.MailID);
                        //    if (obj.flag > 1)
                        //    {
                        //        flag = 2;
                        //    }
                        //    else
                        //    {
                        //        flag = 1;

                        //    }
                        //    mail.extrenal_Inbox.MailID = mail.mail.MailID;
                        //    Ex_inboxmail = await _extrenal_Inbox.Update(mail.extrenal_Inbox);
                        //    if (Ex_inboxmail)
                        //    {

                        //        if (mail.newactionSenders.Count > 0)
                        //        {
                        //            for (int i = 0; i < mail.newactionSenders.Count; i++)
                        //            {
                        //                Send_to sender = new Send_to();

                        //                sender.State = true;

                        //                sender.MailID = mail.mail.MailID;
                        //                sender.to = mail.newactionSenders[i].departmentId;
                        //                sender.flag = 2;
                        //                sender.type_of_send = mail.newactionSenders[i].measureId;
                        //                bool send = await _sender.Add(sender);
                        //            }


                        //        }
                        //        else { }

                        //        result = true;
                        //        break;
                        //    }


                        //}

                        //result = false;

                        //old function



                        //new function


                        Ex_inboxmail = await _extrenal_Inbox.Update(mail.mail, mail.extrenal_Inbox, mail.userId);
                        if (Ex_inboxmail)
                        {

                            if (mail.newactionSenders.Count > 0)
                            {
                                for (int i = 0; i < mail.newactionSenders.Count; i++)
                                {
                                    Send_to sender = new Send_to();

                                    sender.State = true;


                                    sender.to = mail.newactionSenders[i].departmentId;



                                    sender.MailID = mail.mail.MailID;
                                    sender.to = mail.newactionSenders[i].departmentId;
                                    sender.flag = 2;
                                    sender.type_of_send = mail.newactionSenders[i].measureId;
                                    bool send = await _sender.Add(sender);
                                }


                                Historyes histor = new Historyes();
                                histor.currentUser = mail.userId;

                                histor.mailid = mail.mail.MailID;
                                histor.HistortyNameID = 8;
                                histor.changes = $"تمت اضافة ادارة جديدة { numOfSend}";
                                histor.Time = DateTime.Now;

                                await _appContext.History.AddAsync(histor);

                                await _appContext.SaveChangesAsync();


                            }
                            else { }


                            result = true;
                                  break;

                        }

                        result = false;
                        break;


                        //new function





                    default:
                        break;



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
                List<Mail> mails = await _appContext.Mails.Where(x => x.Department_Id == id && x.state == true && x.Mail_Type == 1).OrderByDescending(x => x.MailID).Skip((page - 1) * PageSize).Take(page).ToListAsync();

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
            List<Mail_Resourcescs> res = await _appContext.Mail_Resourcescs.Where(x => x.MailID == uplode.mail_id).ToListAsync();
            foreach (var item in res)
            {


            }


            return true;






        }


        public async Task<bool> DeletePhote(int id,int userId)
        {
            try
            {
                Mail_Resourcescs res = await _appContext.Mail_Resourcescs.FirstOrDefaultAsync(x => x.ID == id);

                if (System.IO.File.Exists(res.path))
                {
                   // System.IO.File.Delete(res.path);


                    res.State = false;
                    _appContext.Mail_Resourcescs.Update(res);
                    await _appContext.SaveChangesAsync();

                    Historyes histor = new Historyes();
                    histor.currentUser = userId;
                    histor.mailid = res.MailID;
                    histor.Time = DateTime.Now;
                    histor.HistortyNameID = 5;
                    histor.changes = res.path;
                    bool resw = await _history.Add(histor);


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
                List<Mail> list = await _appContext.Mails.Where(x => x.Department_Id == id && x.Mail_Type == 2).ToListAsync();


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
                List<Mail> list = await _appContext.Mails.Where(x => x.Department_Id == id && x.Mail_Type == 3).ToListAsync();


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
                bool result = false;


                string year = DateTime.Now.Year.ToString();
                string Month = DateTime.Now.Month.ToString();
                string day = DateTime.Now.Day.ToString();

                string name = "Mail_photos";




                string x1 = Path.Combine(this.iwebHostEnvironment.WebRootPath, name).ToLower();

                string y = Path.Combine(x1, year);
                string z = Path.Combine(y, Month);
                string last = Path.Combine(z, day);

                if (!Directory.Exists(x1))
                {
                    Directory.CreateDirectory(x1);
                }

                if (!Directory.Exists(y))
                {
                    Directory.CreateDirectory(y);

                }

                if (!Directory.Exists(z))
                    Directory.CreateDirectory(z);


                if (!Directory.Exists(last))
                    Directory.CreateDirectory(last);

                else { }


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
                    var path = Path.Combine(last + "/"+x + ".");
                   

                    await File.WriteAllBytesAsync(path + extention, bytes);
                    Mail_Resourcescs mail = new Mail_Resourcescs();
                    mail.MailID = file.mail_id;
                    mail.path = path + extention;
                    mail.order = item.index;
                    Historyes histor = new Historyes();
                    histor.currentUser = file.userId;
                    histor.mailid = file.mail_id;
                    histor.HistortyNameID = 4;
                 
                    bool res = await _resourcescs.Add(mail);
                    if (res)
                 
                    
                    {

                       await _appContext.History.AddAsync(histor);

                        await _appContext.SaveChangesAsync();
                        result = true;
                    }
                    else
                    {
                        File.Delete(mail.path);

                    }

                }

                return result;

            }
            catch (Exception)
            {

                throw;
            }



        }

        public async Task<List<VModelForSendAndRecived>> GetSevenMail(int departmentId)
        {
            try
            {
                List<VModelForSendAndRecived> list = new List<VModelForSendAndRecived>() { };


                List<VModelForSendAndRecived> sendedmail = await (from mail in _appContext.Mails.Where(x => x.Department_Id == departmentId)
                                                                  join send in _appContext.Sends.Where(x => x.isMulti == true && x.flag >= 1)
                                                                  on mail.MailID equals send.MailID
                                                                  join measures in _appContext.measures on send.type_of_send equals measures.MeasuresId
                                                                  join Departments in _appContext.Departments on send.to equals Departments.Id
                                                                  join mailStatuses in _appContext.MailStatuses.Where(x => x.state == true) on send.flag equals mailStatuses.flag

                                                                  select new VModelForSendAndRecived()
                                                                  {
                                                                      mail_id = mail.MailID,
                                                                      State = mailStatuses.sent,
                                                                      type_of_mail = mail.Mail_Type,
                                                                      Mail_Number = mail.Mail_Number,
                                                                      date = mail.Date_Of_Mail.ToString("yyyy-MM-dd"),
                                                                      Masure_type = measures.MeasuresName,
                                                                      mangment_sender = Departments.DepartmentName,
                                                                      mangment_sender_id = mail.Department_Id,
                                                                      Send_time = send.Send_time.ToString("yyyy-MM-dd"),
                                                                      time = send.Send_time.ToString("HH:mm:ss"),
                                                                      summary = mail.Mail_Summary,
                                                                      flag = send.flag,
                                                                      inbox_send = true,
                                                                      DateTocompare = mail.Date_Of_Mail,

                                                                      Sends_id = send.Id



                                                                  }).OrderByDescending(v => v.mail_id).Take(5).ToListAsync();
                list.AddRange(sendedmail);



                List<VModelForSendAndRecived> recivedMail = await (from mail in _appContext.Mails
                                                                   join send in _appContext.Sends.Where(x => x.to == departmentId && x.flag >= 1)
                                                                   on mail.MailID equals send.MailID
                                                                   join measures in _appContext.measures on send.type_of_send equals measures.MeasuresId
                                                                   join Departments in _appContext.Departments on mail.Department_Id equals Departments.Id
                                                                   join mailStatuses in _appContext.MailStatuses.Where(x => x.state == true) on send.flag equals mailStatuses.flag

                                                                   select new VModelForSendAndRecived()
                                                                   {
                                                                       mail_id = mail.MailID,
                                                                       State = mailStatuses.sent,
                                                                       type_of_mail = mail.Mail_Type,
                                                                       Mail_Number = mail.Mail_Number,
                                                                       date = mail.Date_Of_Mail.ToString("yyyy-MM-dd"),
                                                                       Masure_type = measures.MeasuresName,
                                                                       mangment_sender = Departments.DepartmentName,
                                                                       mangment_sender_id = mail.Department_Id,
                                                                       Send_time = send.Send_time.ToString("yyyy-MM-dd"),
                                                                       time = send.Send_time.ToString("HH:mm:ss"),
                                                                       summary = mail.Mail_Summary,
                                                                       flag = send.flag,
                                                                       inbox_send = false,
                                                                       DateTocompare = mail.Date_Of_Mail,
                                                                       Sends_id = send.Id



                                                                   }).OrderByDescending(v => v.mail_id).Take(7).ToListAsync();
                list.AddRange(recivedMail);

                var list1 = list.OrderByDescending(x => x.DateTocompare).Take(5).ToList();















                return list1;

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

        public async Task<dynamic> DynamicGet(int id, int type)
        {

            try
            {

                switch (type)
                {
                    case 1:
                        MailVM mail = await GetMailById(id, type);
                        if (mail != null)

                        {
                            mail.departments = await _appContext.Departments.ToListAsync();
                            foreach (var item in mail.actionSenders)
                            {
                                mail.departments.RemoveAll(x => x.Id == item.departmentId);
                            }


                            c = mail;

                        }
                       

                        break;


                    case 2:

                        ExMail ddc = await GetMailById1(id, type);
                        if (ddc != null)
                        {
                            ddc.departments = await _appContext.Departments.ToListAsync();
                            foreach (var item in ddc.actionSenders)
                            {
                                ddc.departments.RemoveAll(x => x.Id == item.departmentId);
                            }


                            c = ddc;

                        }
                           
                        break;

                    case 3:

                        ExInbox ccc = await GetMailById2(id, type);
                        if (ccc != null)
                        {
                            ccc.departments = await _appContext.Departments.ToListAsync();
                            foreach (var item in ccc.actionSenders)
                            {
                                ccc.departments.RemoveAll(x => x.Id == item.departmentId);
                            }


                            c = ccc;
                        }
                        break;
                    default: break;
                }
                return c;


            }
            catch (Exception)
            {

                throw;
            }

        }


        public async Task<dynamic> DynamicGet(int id, int type, int year, int departmentId)
        {
            try
            {
                MailDto mail = await Getdto(id, type, year, departmentId);


                switch (type)
                {

                    case 1:
                        MailVM mailn = await GetMailById(id, type, year, departmentId);
                        if (mail != null)
                            serch = mailn;
                        break;
                    case 2:


                        var ddc = await GetMailById1(id, type, year, departmentId);
                        if (ddc != null)

                            serch = ddc;
                        break;
                    case 3:

                        var ddd = GetMailById2(id, type, year, departmentId);
                        if (ddd != null)
                            serch = ddd;

                        break;
                    default: break;


                }


                return serch;

            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<MailVM> GetMailById(int id, int type)
        {

            try
            {
                MailVM mail = new MailVM();
                ExMail ex = new ExMail();
                ExInbox inbox = new ExInbox();


                MailDto dto = await Getdto(id, type);
                if (dto != null)
                {

                    mail.mail = dto;
                    List<Send_to> sends = await _appContext.Sends.Where(x => x.MailID == mail.mail.MailID&&x.State==true).ToListAsync();

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
                            departmentId = departments.Id,
                            send_ToId = item.Id,
                            flag=item.flag
                        }

                        );
                    }
                    mail.resourcescs = await _resourcescs.GetAll(mail.mail.MailID);


                    foreach (var xx in mail.resourcescs)
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




                    return mail;
                }
                return null;
            }


            catch (Exception)
            {

                throw;


            }


        }

        public async Task<MailVM> GetMailById(int id, int type, int date, int departmentid)
        {

            try
            {
                MailVM mail = new MailVM();
                ExMail ex = new ExMail();
                ExInbox inbox = new ExInbox();


                MailDto dto = await Getdto(id, type, date, departmentid);
                if (dto != null)
                {

                    mail.mail = dto;
                    List<Send_to> sends = await _appContext.Sends.Where(x => x.MailID == mail.mail.MailID).ToListAsync();

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
                            departmentId = departments.Id,
                            send_ToId = item.Id,
                            flag = item.flag

                        }

                        );
                    }
                    mail.resourcescs = await _resourcescs.GetAll(mail.mail.MailID);


                    foreach (var xx in mail.resourcescs)
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




                    return mail;
                }
                return null;
            }


            catch (Exception)
            {

                throw;


            }


        }



        public async Task<ExMail> GetMailById1(int id, int type)
        {

            try
            {


                MailVM mail = new MailVM();
                ExMail ex = new ExMail();


                MailDto dto = await Getdto(id, type);
                if (dto != null)
                {

                    ex.mail = dto;
                    ex.External = await _external.Get(dto.MailID);

                    if (ex.External == null)
                    {

                        return null;
                    }
                    else
                    {

                        var side = await _appContext.Extrmal_Sections.FindAsync(ex.External.Sectionid);

                        ex.side.Add(side);

                        var sector = await _appContext.Extrmal_Sections.FirstOrDefaultAsync(x => x.perent == 0 && x.type == side.type);
                        ex.sector.Add(sector);






                        List<Send_to> sends = await _appContext.Sends.Where(x => x.MailID == id&&x.State==true).ToListAsync();


                        foreach (var item in sends)
                        {
                            Department departments = await _appContext.Departments.FindAsync(item.to);
                            Measures measures = await _appContext.measures.FindAsync(item.type_of_send);

                            ex.actionSenders.Add(new ActionSender()
                            {

                                departmentName = departments.DepartmentName,
                                measureId = item.type_of_send,
                                measureName = measures.MeasuresName,
                                departmentId = departments.Id,
                                send_ToId = item.Id,
                                flag = item.flag

                            }

                            );
                        }
                        ex.resourcescs = await _resourcescs.GetAll(id);


                        foreach (var xx in ex.resourcescs)
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


                        return ex;

                    }

                }
                return null;
            }


            catch (Exception)
            {

                throw;


            }
        }


        public async Task<ExMail> GetMailById1(int id, int type, int year, int departmentID)
        {

            try
            {


                MailVM mail = new MailVM();
                ExMail ex = new ExMail();


                MailDto dto = await Getdto(id, type, year, departmentID);
                if (dto != null)
                {

                    ex.mail = dto;
                    ex.External = await _external.Get(dto.MailID);

                    if (ex.External == null)
                    {

                        return null;
                    }
                    else
                    {

                        var side = await _appContext.Extrmal_Sections.FindAsync(ex.External.Sectionid);

                        ex.side.Add(side);

                        var sector = await _appContext.Extrmal_Sections.FirstOrDefaultAsync(x => x.perent == 0 && x.type == side.type);
                        ex.sector.Add(sector);






                        List<Send_to> sends = await _appContext.Sends.Where(x => x.MailID == ex.mail.MailID).ToListAsync();


                        foreach (var item in sends)
                        {
                            Department departments = await _appContext.Departments.FindAsync(item.to);
                            Measures measures = await _appContext.measures.FindAsync(item.type_of_send);

                            ex.actionSenders.Add(new ActionSender()
                            {

                                departmentName = departments.DepartmentName,
                                measureId = item.type_of_send,
                                measureName = measures.MeasuresName,
                                departmentId = departments.Id,
                                send_ToId = item.Id,
                                flag = item.flag

                            }

                            );
                        }
                        ex.resourcescs = await _resourcescs.GetAll(id);


                        foreach (var xx in ex.resourcescs)
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


                        return ex;

                    }

                }
                return null;
            }


            catch (Exception)
            {

                throw;


            }
        }

        public async Task<ExInbox> GetMailById2(int id, int type)
        {

            try
            {


                MailVM mail = new MailVM();
                ExInbox ex = new ExInbox();

                MailDto dto = await Getdto(id, type);
                if (dto != null)
                {

                    ex.mail = dto;

                    ex.external = await _extrenal_Inbox.Get(id);
                    var side = await _appContext.Extrmal_Sections.FindAsync(ex.external.SectionId);

                    ex.side.Add(side);

                    var sector = await _appContext.Extrmal_Sections.FirstOrDefaultAsync(x => x.perent == 0 && x.type == side.type);
                    ex.sector.Add(sector);


                    List<Send_to> sends = await _appContext.Sends.Where(x => x.MailID == id&&x.State==true).ToListAsync();


                    foreach (var item in sends)
                    {
                        Department departments = await _appContext.Departments.FindAsync(item.to);
                        Measures measures = await _appContext.measures.FindAsync(item.type_of_send);

                        ex.actionSenders.Add(new ActionSender()
                        {

                            departmentName = departments.DepartmentName,
                            measureId = item.type_of_send,
                            measureName = measures.MeasuresName,
                            departmentId = departments.Id,
                            send_ToId = item.Id,
                            flag = item.flag

                        }

                        );
                    }
                    ex.resourcescs = await _resourcescs.GetAll(id);


                    foreach (var xx in ex.resourcescs)
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


                    return ex;
                }
                return null;
            }


            catch (Exception)
            {

                throw;


            }
        }

        public async Task<ExInbox> GetMailById2(int id, int type, int year, int department)
        {

            try
            {


                MailVM mail = new MailVM();
                ExInbox ex = new ExInbox();

                MailDto dto = await Getdto(id, type, year, department);
                if (dto != null)
                {

                    ex.mail = dto;

                    ex.external = await _extrenal_Inbox.Get(dto.MailID);
                    var side = await _appContext.Extrmal_Sections.FindAsync(ex.external.SectionId);

                    ex.side.Add(side);

                    var sector = await _appContext.Extrmal_Sections.FirstOrDefaultAsync(x => x.perent == 0 && x.type == side.type);
                    ex.sector.Add(sector);


                    List<Send_to> sends = await _appContext.Sends.Where(x => x.MailID == dto.MailID).ToListAsync();


                    foreach (var item in sends)
                    {
                        Department departments = await _appContext.Departments.FindAsync(item.to);
                        Measures measures = await _appContext.measures.FindAsync(item.type_of_send);

                        ex.actionSenders.Add(new ActionSender()
                        {

                            departmentName = departments.DepartmentName,
                            measureId = item.type_of_send,
                            measureName = measures.MeasuresName,
                            departmentId = departments.Id,
                            send_ToId = item.Id,
                                                        flag=item.flag

                        }

                        );
                    }
                    ex.resourcescs = await _resourcescs.GetAll(id);


                    foreach (var xx in ex.resourcescs)
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


                    return ex;
                }
                return null;
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

        public async Task<bool> deleteSender(int mail_id, int departmentId,int userid)
        {
            try
            {
                Historyes historyes = new Historyes();

                historyes.currentUser = userid;
                historyes.mailid = mail_id;

                historyes.HistortyNameID = 9;

            
                Send_to send_ = await _appContext.Sends.FirstOrDefaultAsync(x => x.MailID == mail_id && x.to == departmentId);
                if (send_ != null)
                {
                    if (send_.flag <= 2)
                    {

                        send_.State = false;

                        historyes.changes = $" {departmentId}   تم حدف الادارة رقم";
                        historyes.Time = DateTime.Now;
                        await _appContext.SaveChangesAsync();

                        _appContext.Sends.Update(send_);

                        _appContext.History.Add(historyes);

                        await _appContext.SaveChangesAsync();
                        return true;


                    }
                    else {

                        return false;
                    }
                    
                   
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<List<MailStatus>> GetMailStatuses()
        {
            try
            {
                List<MailStatus> list = await _appContext.MailStatuses.ToListAsync();



                return list;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<SendsDetalies>> GetDetalies(int mail_id)
        {
            try
            {

           
                      
           
                string date;
                var c = await (from mail in _appContext.Mails.Where(x => x.MailID == mail_id && x.state == true)
                               join send in _appContext.Sends.Where(x=>x.State==true) on mail.MailID equals send.MailID
                               join department in _appContext.Departments on send.to equals department.Id
                               join measures in _appContext.measures on send.type_of_send equals measures.MeasuresId
                               join mailState in _appContext.MailStatuses on send.flag equals mailState.flag

                               


                               select new SendsDetalies()
                               {
                                   Department_id = send.to,
                                   Department_name = department.DepartmentName,
                                   flag = mailState.flag,
                                   MesureName = measures.MeasuresName,
                                   State = mailState.sent,
                                   send_ToId=send.Id,
                                   
                                  date = (send.Send_time.ToString().StartsWith("0001")) ? "لم يتم الارسال" : send.Send_time.ToString("yyyy-MM-dd"),
                                date_read =(send.time_of_read.ToString().StartsWith("0001"))?"لم يتم الرد" : send.time_of_read.ToString("yyyy-MM-dd")

                               }).ToListAsync();
              


               




                return c;

            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<dynamic> search(int id, int type, int year, int departmentId)
        {
            try
            {
                MailDto dto = new MailDto();
                switch (type)
                {
                    case 1:
                        MailVM mail = new MailVM();
                        dto = await Getdto(id, type, year, departmentId);

                        if (dto != null) {

                            mail.mail = dto;
                            List<Send_to> sends = await _appContext.Sends.Where(x => x.MailID == mail.mail.MailID&&x.State==true).ToListAsync();

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
                                    departmentId = departments.Id,
                                    send_ToId = item.Id
                                }

                                );
                            }
                            mail.resourcescs = await _resourcescs.GetAll(mail.mail.MailID);


                            foreach (var xx in mail.resourcescs)
                            {
                                string x = xx.path;

                                if (File.Exists(xx.path))
                                {
                                    xx.path = await tobase64(x);

                                }
                                else {

                                  
                                }
                                

                            }


                            serch = mail;

                            break;


                        }
                        serch = null;

                        break;
                    case 2:
                        dto = await Getdto(id, type, year, departmentId);
                        ExMail ex = new ExMail();
                        if (dto != null) {
                            ex.mail = dto;
                            ex.External = await _external.Get(dto.MailID);

                            var side = await _appContext.Extrmal_Sections.FindAsync(ex.External.Sectionid);

                            ex.side.Add(side);

                            var sector = await _appContext.Extrmal_Sections.FirstOrDefaultAsync(x => x.perent == 0 && x.type == side.type);
                            ex.sector.Add(sector);






                            List<Send_to> sends = await _appContext.Sends.Where(x => x.MailID == ex.mail.MailID&&x.State==true).ToListAsync();


                            foreach (var item in sends)
                            {
                                Department departments = await _appContext.Departments.FindAsync(item.to);
                                Measures measures = await _appContext.measures.FindAsync(item.type_of_send);

                                ex.actionSenders.Add(new ActionSender()
                                {

                                    departmentName = departments.DepartmentName,
                                    measureId = item.type_of_send,
                                    measureName = measures.MeasuresName,
                                    departmentId = departments.Id,
                                    send_ToId = item.Id
                                }

                                );
                            }
                            ex.resourcescs = await _resourcescs.GetAll(dto.MailID);


                            foreach (var xx in ex.resourcescs)
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


                            serch= ex;
                            break;

                        }


                        serch = null;

                        break;
                    case 3:
                        dto = await Getdto(id, type, year, departmentId);

                        if (dto != null) {
                            ExInbox ex1 = new ExInbox();

                            ex1.mail = dto;

                            ex1.external = await _extrenal_Inbox.Get(dto.MailID);
                            var side = await _appContext.Extrmal_Sections.FindAsync(ex1.external.SectionId);

                            ex1.side.Add(side);

                            var sector = await _appContext.Extrmal_Sections.FirstOrDefaultAsync(x => x.perent == 0 && x.type == side.type);
                            ex1.sector.Add(sector);


                            List<Send_to> sends = await _appContext.Sends.Where(x => x.MailID == dto.MailID && x.State == true).ToListAsync();


                            foreach (var item in sends)
                            {
                                Department departments = await _appContext.Departments.FindAsync(item.to);
                                Measures measures = await _appContext.measures.FindAsync(item.type_of_send);

                                ex1.actionSenders.Add(new ActionSender()
                                {

                                    departmentName = departments.DepartmentName,
                                    measureId = item.type_of_send,
                                    measureName = measures.MeasuresName,
                                    departmentId = departments.Id,
                                    send_ToId = item.Id
                                }

                                );
                            }
                            ex1.resourcescs = await _resourcescs.GetAll(dto.MailID);


                            foreach (var xx in ex1.resourcescs)
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


                            serch = ex1;
                            break;

                        }
                        serch = null;
                        break;

                    default:
                        break;
                       
                      
                }
                return serch;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<MailStateViewModel>> GetAllState(int number)
        {
            try
            {
                List<MailStateViewModel> list = new List<MailStateViewModel>();
                switch (number)
                {
                    case 1:
                        list = await (from mailstate in _appContext.MailStatuses
                                select new MailStateViewModel()
                                {flag=mailstate.flag,
                                statename=mailstate.sent
                                }).ToListAsync();


                        break;
                    case 2:

                        list = await (from mailstate in _appContext.MailStatuses.Where(x=>x.flag>1)
                                      select new MailStateViewModel()
                                      {
                                          flag = mailstate.flag,
                                          statename = mailstate.inbox
                                      }).ToListAsync();


                        break;
                    default:
                        break;
                }
                return list;
            }
            catch (Exception)
            {

                throw;
            }
        }



        public async Task<bool> Update(int userid,Mail mail) {
            try
            {
                Mail _mail = await _appContext.Mails.FindAsync(mail.MailID);

                ClasificationSubject clasificationSubjects = await _appContext.clasifications.FindAsync(_mail.clasification);
                ClasificationSubject clasificationSubjects2 = await _appContext.clasifications.FindAsync(mail.clasification);

                List<HVModel> hVModels = new List<HVModel>();


                if (_mail != null)
                {

                    hVModels.Add(new HVModel { name = "تاريخ الايميل", newvalue = mail.Date_Of_Mail, oldvalue = _mail.Date_Of_Mail });
                    hVModels.Add(new HVModel { name = "ملخص الموضوع", newvalue = mail.Mail_Summary, oldvalue = _mail.Mail_Summary });
                    hVModels.Add(new HVModel { name = "حالة الايميل", newvalue = mail.state, oldvalue = _mail.state });
                    hVModels.Add(new HVModel { name = "رقم المستخدم", newvalue = mail.userId, oldvalue = _mail.userId });
                    hVModels.Add(new HVModel { name = "السنة", newvalue = mail.Genaral_inbox_year, oldvalue = _mail.Genaral_inbox_year });
                    hVModels.Add(new HVModel { name = "رقم الوارد العام", newvalue = mail.Genaral_inbox_Number, oldvalue = _mail.Genaral_inbox_Number });
                    hVModels.Add(new HVModel { name = "تاريخ الايميل", newvalue = mail.Date_Of_Mail, oldvalue = _mail.Date_Of_Mail });
                    hVModels.Add(new HVModel { name = "التصنيف ", newvalue = clasificationSubjects2.Name, oldvalue = clasificationSubjects.Name });
                    hVModels.Add(new HVModel { name = "الاجراء المطلوب", newvalue = mail.ActionRequired, oldvalue = _mail.ActionRequired });







                    Historyes histor = new Historyes();

                    histor.mailid = mail.MailID;
                    histor.HistortyNameID = 2;


                    _mail.Date_Of_Mail = mail.Date_Of_Mail;
                    _mail.Mail_Summary = mail.Mail_Summary + " ";
                    _mail.state = mail.state;
                    _mail.userId = mail.userId;
                    _mail.Genaral_inbox_year = mail.Genaral_inbox_year;
                    _mail.Genaral_inbox_Number = mail.Genaral_inbox_Number;
                    _mail.Date_Of_Mail = mail.Date_Of_Mail;

                    _mail.clasification = mail.clasification;
                    _mail.ActionRequired = mail.ActionRequired;


                    string chamges = Histoteyvm.getValue(hVModels);


                    _appContext.Mails.Update(_mail);
                    await _appContext.SaveChangesAsync();
                    histor.changes = chamges;
                    histor.currentUser = userid;

                    histor.Time = DateTime.Now;
                    _appContext.History.Add(histor);
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


        public async Task<List<ReportViewModelForMail>> getreprts(DateTime first,DateTime last,int dep) {


            List<ReportViewModelForMail> list = await(from mail in _appContext.Mails.Where(x=>x.Date_Of_Mail>=first


                                                      &&x.Date_Of_Mail<=last&&
                                                     x .Department_Id == dep && x.state == true


                                                      )

                                                      join send in _appContext.Sends on mail.MailID equals send.MailID
                                                      select new ReportViewModelForMail
                                                      { flag = _appContext.MailStatuses.FirstOrDefault(w => w.flag == send.flag).sent,
                                                          hours = mail.Date_Of_Mail.ToString("HH:mm:ss"),
                                                          Send_time = mail.Date_Of_Mail.ToString("yyyy-MM-dd"),
                                                          Mail_Number=mail.Mail_Number,
                                                          Mail_Summary=mail.Mail_Summary,
                                                          sent_to= _appContext.Departments.FirstOrDefault(w => w.Id == send.to).DepartmentName,
                                                          mail_type =(mail.Mail_Type==1)?"داخلي": (mail.Mail_Type == 2) ?"صادر خارجي":"وارد خارجي"


                                                      }


                                                       ).ToListAsync();

            return list;
        
        
        } 
    }
}






