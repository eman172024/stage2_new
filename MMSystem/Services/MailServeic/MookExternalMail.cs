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
    public class MookExternalMail : IExternalMailcs
    {
        private readonly AppDbCon _appDb;
        private readonly IMapper _mapper;

        public MookExternalMail(AppDbCon appDb,IMapper mapper)
        {
            _appDb = appDb;
            _mapper = mapper;
        }
        public async Task<bool> Add(External_Mail exMail)
        {
            Result result = new Result();
            try
            {
                Mail mail = await _appDb.Mails.FindAsync(exMail.MailID);
                
                if (mail != null)
                {
                 exMail.MailID = mail.MailID;
                    await _appDb.External_Mails.AddAsync(exMail);

                    await _appDb.SaveChangesAsync();
                  
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

        public async Task<ExternalDto> Get(int id)
        {
            try
            {
            
                Mail mail = await _appDb.Mails.FindAsync(id);



                if (mail != null)
                {
                    External_Mail external = _appDb.External_Mails.FirstOrDefault(x=>x.MailID==id);

                    ExternalDto dto = _mapper.Map<External_Mail, ExternalDto>(external);

                    return dto;

                }
                return null;

            }
            catch (Exception)
            {

                throw;
            }





        }

        public Task<List<ExternalDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Update(External_Mail model)
        {
           

            try
            {
                External_Mail mail = await _appDb.External_Mails.FirstOrDefaultAsync(x=>x.MailID==model.MailID);

                if (mail != null)

                {
                    mail.Sectionid = model.Sectionid;
                    mail.action = model.action;
                    mail.action_required_by_the_entity = model.action_required_by_the_entity;



                    _appDb.External_Mails.Update(mail);
                    await _appDb.SaveChangesAsync();
                 
                    return true;
                }
            
                return false;
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        //تعديل بريد الصادر الخارجي
        public async Task<bool> Update(Mail mail1, External_Mail mail, int userid)
        {
            try
            {
                Mail _mail = await _appDb.Mails.FindAsync(mail1.MailID);
                List<HVModel> hVModels = new List<HVModel>();
                ClasificationSubject clasificationSubjects = await _appDb.clasifications.FindAsync(_mail.clasification);
                ClasificationSubject clasificationSubjects2 = await _appDb.clasifications.FindAsync(mail1.clasification);



                if (_mail != null)
                {

                    hVModels.Add(new HVModel { name = "تاريخ الايميل", newvalue = mail1.Date_Of_Mail, oldvalue = _mail.Date_Of_Mail });
                    hVModels.Add(new HVModel { name = "ملخص الموضوع", newvalue = mail1.Mail_Summary, oldvalue = _mail.Mail_Summary });
                    hVModels.Add(new HVModel { name = "حالة الايميل", newvalue = mail1.state, oldvalue = _mail.state });
                    hVModels.Add(new HVModel { name = "رقم المستخدم", newvalue = mail1.userId, oldvalue = _mail.userId });
                    hVModels.Add(new HVModel { name = "السنة", newvalue = mail1.Genaral_inbox_year, oldvalue = _mail.Genaral_inbox_year });
                    hVModels.Add(new HVModel { name = "رقم الوارد العام", newvalue = mail1.Genaral_inbox_Number, oldvalue = _mail.Genaral_inbox_Number });
                    hVModels.Add(new HVModel { name = "تاريخ الايميل", newvalue = mail1.Date_Of_Mail, oldvalue = _mail.Date_Of_Mail });
                    hVModels.Add(new HVModel { name = "التصنيف ", newvalue = mail1.clasification, oldvalue = _mail.clasification });
                    hVModels.Add(new HVModel { name = "الاجراء المطلوب", newvalue = mail1.ActionRequired, oldvalue = _mail.ActionRequired });


                    Historyes histor = new Historyes();

                    
                    histor.mailid = mail.MailID;
                    histor.HistortyNameID = 2;
                    histor.currentUser = userid;
                    histor.Time = DateTime.Now;
                    histor.changes = Histoteyvm.getValue(hVModels);
                    _mail.Date_Of_Mail = mail1.Date_Of_Mail;
                    _mail.Mail_Summary = mail1.Mail_Summary + " ";
                    _mail.state = mail1.state;
                    _mail.userId = mail1.userId;
                    _mail.Genaral_inbox_year = mail1.Genaral_inbox_year;
                    _mail.Genaral_inbox_Number = mail1.Genaral_inbox_Number;
                    _mail.Date_Of_Mail = mail1.Date_Of_Mail;

                    _mail.clasification = mail1.clasification;
                    _mail.ActionRequired = mail1.ActionRequired;
                    _mail.old_mail_number = mail1.old_mail_number;
                    _mail.office_type = mail1.office_type;



                    _appDb.Mails.Update(_mail);
                    await _appDb.SaveChangesAsync();
                  


               //     return true;


                    External_Mail ex = await _appDb.External_Mails.FirstOrDefaultAsync(x => x.MailID == mail1.MailID);

                    if (ex != null)

                    {

                        hVModels.Add(new HVModel { name = "الجهة الخارجية", newvalue = mail.Sectionid, oldvalue = ex.Sectionid });
                        hVModels.Add(new HVModel { name = "الاجراء ", newvalue = mail.action, oldvalue = ex.action });
                        hVModels.Add(new HVModel { name = "الاجراء المطلوب من ", newvalue = mail.action_required_by_the_entity, oldvalue = ex.action_required_by_the_entity });
                     //   hVModels.Add(new HVModel { name = "القطاع", newvalue = mail.SectorId, oldvalue = ex.SectorId });
                     //   hVModels.Add(new HVModel { name = "الجهة", newvalue = mail.SectorType, oldvalue = ex.SectorType });




                        string note = Histoteyvm.getValue(hVModels);

                        if (!String.IsNullOrWhiteSpace(note)) {

                            histor.changes = note;
                            histor.mailid = ex.MailID;
                            histor.Time = DateTime.Now;
                            histor.currentUser = userid;
                            _appDb.History.Add(histor);
                            await _appDb.SaveChangesAsync();
                        }
                      
                   //     ex.Sectionid = mail.Sectionid;
                       //ex.SectorType = mail.SectorType;
                    //    ex.SectorId = mail.SectorId;
                        ex.action = mail.action;
                        ex.action_required_by_the_entity = mail.action_required_by_the_entity;



                        _appDb.External_Mails.Update(ex);
                      //  _appDb.History.Add(histor);
                        await _appDb.SaveChangesAsync();

                        return true;
                    }


                 //   return false;

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
