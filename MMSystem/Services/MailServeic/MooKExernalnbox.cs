using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MMSystem.Model;
using MMSystem.Model.Dto;
using MMSystem.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Services.MailServeic
{
    public class MooKExernalnbox : IExtrenal_inbox
    {
        private readonly AppDbCon _dbCon;
        private readonly IMapper _mapper;

        public string to;
        public string to2;

        public MooKExernalnbox(AppDbCon dbCon,IMapper mapper)
        {
            _dbCon = dbCon;
            _mapper = mapper;
        }
   

        public async Task<bool> Add(Extrenal_inbox extrenal)
        {
            try
            {
          
                Mail mail = await _dbCon.Mails.FindAsync(extrenal.MailID);
                if (mail != null)
                {

                    await _dbCon.Extrenal_Inboxes.AddAsync(extrenal);
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

        public async Task<Extrenal_inboxDto> Get(int id)
        {
            try
            {
            
                Mail mail = await _dbCon.Mails.FindAsync(id);



                if (mail != null)
                {
                    
                    
                    var c= _mapper.Map<Mail, MailDto>(mail);

                   
                    Extrenal_inbox external = await _dbCon.Extrenal_Inboxes.FirstOrDefaultAsync(x => x.MailID == id);
                  Extrenal_inboxDto dto = _mapper.Map<Extrenal_inbox, Extrenal_inboxDto>(external);
                  

                    return dto;

                }
                return null;

            }
            catch (Exception)
            {

                throw;
            }

          
           
        }

        public async Task<List<Extrenal_inboxDto>> GetAll()
        {
            try
            {
                List<Extrenal_inbox> list = await _dbCon.Extrenal_Inboxes.OrderByDescending(x => x.Id).ToListAsync();
                List<Extrenal_inboxDto> listOfEmail = _mapper.Map<List<Extrenal_inbox>, List<Extrenal_inboxDto>>(list);
                return null;
            }
            catch (Exception)
            {

                throw;
            }
     
        }

        public async Task<bool> Update(Extrenal_inbox model)
        {
            Extrenal_inbox _Inbox = await _dbCon.Extrenal_Inboxes.FirstOrDefaultAsync(x=>x.MailID==model.MailID);

            if (_Inbox != null) {
                _Inbox.action = model.action;
                _Inbox.entity_reference_number = model.entity_reference_number;
              //  _Inbox.SectionId = model.SectionId;
                _Inbox.section_Name = model.section_Name;
                _Inbox.procedure_type = model.procedure_type;
                _Inbox.to = model.to;
                _Inbox.type = model.type;
                _Inbox.Send_time = model.Send_time;
                _Inbox.office_type = model.office_type;

                 _dbCon.Extrenal_Inboxes.Update(_Inbox);
                await _dbCon.SaveChangesAsync();

                return true;
            }
            return false;
        }

        public async Task<bool> Update(Mail mail, Extrenal_inbox ex, int userid)
        {


            try
            {
             
                Mail _mail = await _dbCon.Mails.FindAsync(mail.MailID);
                List<HVModel> hVModels = new List<HVModel>();
                ClasificationSubject clasificationSubjects = await _dbCon.clasifications.FindAsync(_mail.clasification);
                ClasificationSubject clasificationSubjects2 = await _dbCon.clasifications.FindAsync(mail.clasification);

                if (_mail != null)
                {

                    hVModels.Add(new HVModel { name = "تاريخ الايميل", newvalue = mail.Date_Of_Mail, oldvalue = _mail.Date_Of_Mail });
                    hVModels.Add(new HVModel { name = "ملخص الموضوع", newvalue = mail.Mail_Summary, oldvalue = _mail.Mail_Summary });
                    hVModels.Add(new HVModel { name = "حالة الايميل", newvalue = mail.state, oldvalue = _mail.state });
                    hVModels.Add(new HVModel { name = "رقم المستخدم", newvalue = mail.userId, oldvalue = _mail.userId });
                    hVModels.Add(new HVModel { name = "السنة", newvalue = mail.Genaral_inbox_year, oldvalue = _mail.Genaral_inbox_year });
                    hVModels.Add(new HVModel { name = "رقم الوارد العام", newvalue = mail.Genaral_inbox_Number, oldvalue = _mail.Genaral_inbox_Number });
                    hVModels.Add(new HVModel { name = "تاريخ الايميل", newvalue = mail.Date_Of_Mail, oldvalue = _mail.Date_Of_Mail });
                    hVModels.Add(new HVModel { name = "التصنيف ", newvalue = mail.clasification, oldvalue = _mail.clasification });
                    hVModels.Add(new HVModel { name = "الاجراء المطلوب", newvalue = mail.ActionRequired, oldvalue = _mail.ActionRequired });


                    Historyes histor = new Historyes();

                    histor.mailid = mail.MailID;
                    histor.HistortyNameID = 2;

                    histor.currentUser = userid;

                    histor.Time = DateTime.Now;
                    _mail.Date_Of_Mail = mail.Date_Of_Mail;
                    _mail.Mail_Summary = mail.Mail_Summary + " ";
                    _mail.state = mail.state;
                    _mail.userId = mail.userId;
                    _mail.Genaral_inbox_year = mail.Genaral_inbox_year;
                    _mail.Genaral_inbox_Number = mail.Genaral_inbox_Number;
                    _mail.Date_Of_Mail = mail.Date_Of_Mail;

                    _mail.clasification = mail.clasification;
                    _mail.ActionRequired = mail.ActionRequired;
                    _mail.old_mail_number = mail.old_mail_number;
                    _mail.office_type = mail.office_type;


                    _dbCon.Mails.Update(_mail);
                  
                    await _dbCon.SaveChangesAsync();




                    Extrenal_inbox _Inbox = await _dbCon.Extrenal_Inboxes.FirstOrDefaultAsync(x => x.MailID == mail.MailID);

                    if (_Inbox != null)
                    {
                       

                        switch (_Inbox.to) {
                            case 1:to = "رئيس الهيئة";
                                break;
                            case 2:
                                to = "وكيل الهيئة";
                                break;

                            case 3:
                                to = "مدير إدارة أو مكتب";
                                break;

                        }
                        switch (ex.to)
                        {
                            case 1:
                                to2 = "رئيس الهيئة";
                                break;
                            case 2:
                                to2 = "وكيل الهيئة";
                                break;

                            case 3:
                                to2 = "مدير إدارة أو مكتب";
                                break;

                        }


                        hVModels.Add(new HVModel { name = "الاجراء ", newvalue = ex.action, oldvalue = _Inbox.action });
                        hVModels.Add(new HVModel { name = "رقم اشاري الجهة", newvalue = ex.entity_reference_number, oldvalue = _Inbox.entity_reference_number });
                  //      hVModels.Add(new HVModel { name = "رقم القسم", newvalue = ex.SectionId, oldvalue = _Inbox.SectionId });
                     //   hVModels.Add(new HVModel { name = "اسم القسم", newvalue = ex.section_Name, oldvalue = _Inbox.section_Name });
                        hVModels.Add(new HVModel { name = "الاجراء المطلوب", newvalue = ex.procedure_type, oldvalue = _Inbox.procedure_type });
                        hVModels.Add(new HVModel { name = " وارد الي", newvalue = to2.ToString(), oldvalue = to.ToString() });
                        hVModels.Add(new HVModel { name = "نوع الاجراء", newvalue = ex.type, oldvalue = _Inbox.type });
                        hVModels.Add(new HVModel { name = "تاريخ رسالة الجهة", newvalue = ex.Send_time, oldvalue = _Inbox.Send_time });


                        _Inbox.action = ex.action;
                        _Inbox.entity_reference_number = ex.entity_reference_number;
                        _Inbox.section_Name = ex.section_Name;
                        _Inbox.procedure_type = ex.procedure_type;
                        _Inbox.to = ex.to;
                        _Inbox.type = ex.type;
                        _Inbox.Send_time = ex.Send_time;
                        _Inbox.office_type = ex.office_type;

                        _dbCon.Extrenal_Inboxes.Update(_Inbox);

                        string chamges = Histoteyvm.getValue(hVModels);
                        if (!String.IsNullOrWhiteSpace(chamges))
                        {
                            histor.currentUser = userid;

                            histor.Time = DateTime.Now;
                            histor.changes = chamges;
                            histor.currentUser = userid;
                            histor.mailid = _Inbox.MailID;
                            histor.Time = DateTime.Now;
                            _dbCon.History.Add(histor);
                            await _dbCon.SaveChangesAsync();


                        }


                        else { }


                       

                        return true;
                    }
                    return false;
                }

                return true;
            }

            catch (Exception)
            {

                throw;
            }
        }
    }
}
