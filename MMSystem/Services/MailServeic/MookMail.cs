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
        dynamic c;

        private readonly AppDbCon _appContext;

        public string sub { get; set; }

        private IWebHostEnvironment iwebHostEnvironment;

        private IExternalMailcs _external;


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
                                else {
                                    sender.isMulti = false;
                                }
                                sender.MailID = mail.mail.MailID;
                                sender.to = mail.actionSenders[i].departmentId;
                                sender.flag = 1;
                                sender.type_of_send = mail.actionSenders[i].measureId;
                                bool send = await _sender.Add(sender);
                            }
                            result = true;
                            break;
                        }


                        break;

                    case  2:
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

                                    
                            for (int i = 0; i < mail.actionSenders.Count; i++)
                            {
                                Send_to sender = new Send_to();


                                if (i == (mail.actionSenders.Count - 1))
                                {
                                    sender.isMulti = true;
                                }
                                else {
                                    sender.isMulti = false;
                                }
                                sender.MailID = mail.mail.MailID;
                                sender.to = mail.actionSenders[i].departmentId;
                                sender.flag = 1;
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


                    case  3:
                        mail.mail.state = true;
                        mail.mail.Mail_Number = await GetLastMailNumber(mail.mail.Department_Id, port);

                        Email = await Add(mail.mail);

                        if (Email)
                        {

                            mail.extrenal_Inbox.MailID = mail.mail.MailID;
                            Ex_inboxmail = await _extrenal_Inbox.Add(mail.extrenal_Inbox);

                            if (Ex_inboxmail)
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
                        Mail mail = await _appContext.Mails.FirstOrDefaultAsync(x => x.MailID == id && x.Mail_Type == 1);
                        dto1 = _mapper.Map<Mail, MailDto>(mail);

                        break;
                    case 2:
                        Mail mail1 = await _appContext.Mails.FirstOrDefaultAsync(x => x.MailID == id && x.Mail_Type ==  2);
                        dto1 = _mapper.Map<Mail, MailDto>(mail1);

                        break;
                    case 3:
                        Mail mail2 = await _appContext.Mails.FirstOrDefaultAsync(x => x.MailID == id && x.Mail_Type == 3);
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
                int LastNumber = 0;
                switch (MailType)
                {
                    case 1:
                        Mail mail = await _appContext.Mails.OrderBy(x => x.MailID).Where(x => x.Department_Id == id && x.Mail_Type==1).LastOrDefaultAsync();
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
                _mail.Mail_Summary = mail.Mail_Summary+" ";
                _mail.state = mail.state;
                _mail.userId = mail.userId;
                _mail.Genaral_inbox_year = mail.Genaral_inbox_year;
                _mail.Genaral_inbox_Number = mail.Genaral_inbox_Number;
                _mail.Date_Of_Mail = mail.Date_Of_Mail;
             
                _mail.clasification = mail.clasification;
                _mail.ActionRequired = mail.ActionRequired;


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



                int port = mail.mail.Mail_Type;

                switch (port)
                {
                    case 1:

                        Email = await Update(mail.mail);
                        if (Email)
                        {

                            //var list = await _appContext.Sends.Where(x => x.MailID == mail.mail.MailID).ToListAsync();

                            //if (list.Count > 0)
                            //{

                            //    _appContext.Sends.RemoveRange(list);
                            //    await _appContext.SaveChangesAsync();

                            //}
                            //else { }



                            //if (mail.actionSenders != null){

                            //    foreach (var item in mail.actionSenders)
                            //    {
                            //        Send_to sender = new Send_to();

                            //        sender.MailID = mail.mail.MailID;
                            //        sender.to = item.departmentId;
                            //        sender.flag = 1;
                            //        sender.type_of_send = item.measureId;
                            //        bool send = await _sender.Add(sender);
                            //    }

                            //    result = true;
                            //    break;

                            //}


                            result = true;
                            break;




                        }



                        break;
                    case 2:

                        Email = await Update(mail.mail);
                        if (Email)
                        {

                            Exmail = await _external.Update(mail.external_Mail);
                            if (Exmail)
                            {


                                //var list = await _appContext.Sends.Where(x => x.MailID == mail.mail.MailID).ToListAsync();

                                //if (list.Count > 0)
                                //{

                                //    _appContext.Sends.RemoveRange(list);
                                //    await _appContext.SaveChangesAsync();

                                //}


                                //if (mail.actionSenders !=null) {

                                //    foreach (var item in mail.actionSenders)
                                //    {
                                //        Send_to sender = new Send_to();

                                //        sender.MailID = mail.mail.MailID;
                                //        sender.to = item.departmentId;
                                //        sender.flag = 1;
                                //        sender.type_of_send = item.measureId;
                                //        bool send = await _sender.Add(sender);
                                //    }
                                //    result = true;
                                //   break;


                                //  }


                                result = true;
                                break;


                            }




                            break;

                        }
                        break;
                    case 3:

                        Email = await Update(mail.mail);
                        if (Email)
                        {

                            mail.extrenal_Inbox.MailID = mail.mail.MailID;
                            Ex_inboxmail = await _extrenal_Inbox.Update(mail.extrenal_Inbox);
                            if (Ex_inboxmail)
                            {


                                //    var list = await _appContext.Sends.Where(x => x.MailID == mail.mail.MailID).ToListAsync();

                                //    if (list.Count > 0)
                                //    {

                                //        _appContext.Sends.RemoveRange(list);
                                //        await _appContext.SaveChangesAsync();

                                //    }
                                //    else { }



                                //    if (mail.actionSenders.Count > 0)
                                //    {

                                //        foreach (var item in mail.actionSenders)
                                //        {
                                //            Send_to sender = new Send_to();

                                //            sender.MailID = mail.mail.MailID;
                                //            sender.to = item.departmentId;
                                //            sender.flag = 1;
                                //            sender.type_of_send = item.measureId;
                                //            bool send = await _sender.Add(sender);
                                //        }
                                //        result = true;
                                //        break;
                                //    }
                                //    result = true;
                                //    break;


                                //}
                                //break;
                                result = true;
                            }
                            result = false;
                           
                        }
                        break;
                       
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
                List<Mail> list = await _appContext.Mails.Where(x => x.Department_Id == id && x.Mail_Type==2).ToListAsync();


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
                List<Mail> list = await _appContext.Mails.Where(x => x.Department_Id == id && x.Mail_Type==3).ToListAsync();


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
                    var path = Path.Combine(this.iwebHostEnvironment.WebRootPath, "images", x + ".");


                    await File.WriteAllBytesAsync(path + extention, bytes);
                    Mail_Resourcescs mail = new Mail_Resourcescs();
                    mail.MailID = file.mail_id;
                    mail.path = path + extention;
                    mail.order = item.index;
                    bool res = await _resourcescs.Add(mail);
                    if (res)
                    {
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

        public async Task<List<VModelForSendAndRecived>> GetSevenMail(int  departmentId)
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
                                           date =mail.Date_Of_Mail.ToString("yyyy-MM-dd"),
                                           Masure_type = measures.MeasuresName,
                                           mangment_sender = Departments.DepartmentName,
                                           mangment_sender_id = mail.Department_Id,
                                           Send_time = send.Send_time.ToString("yyyy-MM-dd"),
                                           time = send.Send_time.ToString("HH:mm:ss"),
                                           summary = mail.Mail_Summary,
                                           flag = send.flag,
                                           inbox_send=true,DateTocompare=mail.Date_Of_Mail,

                                           Sends_id=send.Id
                                          


                                       }).OrderByDescending(v => v.mail_id).Take(5).ToListAsync();
                        list.AddRange( sendedmail);

            

                        List<VModelForSendAndRecived> recivedMail = await (from mail in _appContext.Mails
                                       join send in _appContext.Sends.Where(x=>x.to==departmentId&& x.flag >= 1)
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
                                           inbox_send=false,
                                           DateTocompare=mail.Date_Of_Mail,
                                           Sends_id = send.Id



                                       }).OrderByDescending(v => v.mail_id).Take(7).ToListAsync();
                list.AddRange(recivedMail);

              var list1=  list.OrderByDescending(x => x.DateTocompare).Take(5).ToList();















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

        public async Task<dynamic> DynamicGet(int id,int type) {

            try
            {
              
                switch (type)
                {
                    case 1:
                        MailVM mail = await GetMailById(id, type);
                        if (mail != null)
                            c = mail;
                        break;


                    case 2:

                        var ddc = await GetMailById1(id, type);
                        if (ddc != null)

                            c = ddc;
                        break;

                    case 3:

                        var ccc = await GetMailById2(id, type);
                        if (ccc != null)
                            c = ccc;
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





        public async Task<MailVM> GetMailById(int id,int type)
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
                            departmentId = departments.Id
                        }

                        );
                    }
                    mail.resourcescs = await _resourcescs.GetAll(mail.mail.MailID);


                    foreach (var xx in mail.resourcescs)
                    {
                        string x = xx.path;
                        xx.path = await tobase64(x);

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

        public async Task<ExMail> GetMailById1(int id,int type)
        {

            try
            {


                MailVM mail = new MailVM();
                ExMail ex = new ExMail();
           

                MailDto dto = await Getdto(id,type);
                if (dto != null)
                {
                    
                    ex.mail = dto;
                    ex.External = await _external.Get(dto.MailID);

                    if (ex.External == null)
                    {

                        return null;
                    }
                    else {

                        var side = await _appContext.Extrmal_Sections.FindAsync(ex.External.Sectionid);

                        ex.side.Add(side);

                        var sector = await _appContext.Extrmal_Sections.FirstOrDefaultAsync(x => x.perent == 0 && x.type == side.type);
                        ex.sector.Add(sector);


                



                        List<Send_to> sends = await _appContext.Sends.Where(x => x.MailID == id).ToListAsync();


                        foreach (var item in sends)
                        {
                            Department departments = await _appContext.Departments.FindAsync(item.to);
                            Measures measures = await _appContext.measures.FindAsync(item.type_of_send);

                            ex.actionSenders.Add(new ActionSender()
                            {

                                departmentName = departments.DepartmentName,
                                measureId = item.type_of_send,
                                measureName = measures.MeasuresName,
                                departmentId = departments.Id
                            }

                            );
                        }
                        ex.resourcescs = await _resourcescs.GetAll(id);


                        foreach (var xx in ex.resourcescs)
                        {
                            string x = xx.path;
                            xx.path = await tobase64(x);

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

        public async Task<ExInbox> GetMailById2(int id,int type)
        {

            try
            {


                MailVM mail = new MailVM();
                ExInbox ex = new ExInbox();

                    MailDto dto = await Getdto(id,type);
                if (dto != null)
                {

                    ex.mail = dto;

                    ex.external = await _extrenal_Inbox.Get(id);
                    var side = await _appContext.Extrmal_Sections.FindAsync(ex.external.SectionId);

                    ex.side.Add(side);

                    var sector = await _appContext.Extrmal_Sections.FirstOrDefaultAsync(x => x.perent == 0 && x.type == side.type);
                    ex.sector.Add(sector);


                    List<Send_to> sends = await _appContext.Sends.Where(x => x.MailID == id).ToListAsync();


                    foreach (var item in sends)
                    {
                        Department departments = await _appContext.Departments.FindAsync(item.to);
                        Measures measures = await _appContext.measures.FindAsync(item.type_of_send);

                        ex.actionSenders.Add(new ActionSender()
                        {

                            departmentName = departments.DepartmentName,
                            measureId = item.type_of_send,
                            measureName = measures.MeasuresName,
                            departmentId = departments.Id
                        }

                        );
                    }
                    ex.resourcescs = await _resourcescs.GetAll(id);


                    foreach (var xx in ex.resourcescs)
                    {
                        string x = xx.path;
                        xx.path = await tobase64(x);

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



        public async Task< string> tobase64(string patj) {

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
    }
}




      
  
