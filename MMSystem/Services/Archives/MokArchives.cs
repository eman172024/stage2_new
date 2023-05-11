using Microsoft.EntityFrameworkCore;
using MMSystem.Model;
using MMSystem.Model.Dto;
using MMSystem.Model.ViewModel.ArchivesReport;
using MMSystem.Model.ViewModel.ArchiveVM;
using MMSystem.Services.Histor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Services.Archives
{

    public class MokArchives : IArchives
    {
        private readonly AppDbCon _db;

        public IHistory _history;

        public MokArchives(AppDbCon db, IHistory history)
        {
            _db = db;
            _history = history;
        }

        public async Task<ArchiveVModelWithPag> GetAll(int page, int pageSize, int? mail_number, DateTime? date_time_of_day,
            DateTime? date_time_from, int? department_id, int? side_id, string? mail_summary,int?get_all, int? MailType ,int? Perent)
        {
            bool mail_numbers = false;
            bool Summ = false;
            bool date = true;
            bool perent = false;
          
            bool sides_id = false;
            bool mail_type = false;
            bool departments_id = false;
            if (side_id == null|| side_id == 0)
            {
                sides_id = true;
            }
            if (department_id == null)
            {
                departments_id = true;
            }
            if (MailType==null)
            {
                mail_type = true;
            }
            if (get_all!=1)
            {
                if (date_time_of_day == null)
                {
                    date_time_of_day = DateTime.Parse(DateTime.Now.ToShortDateString());

                }

                if (date_time_from == null)
                {
                    date_time_from =DateTime.Parse( DateTime.Now.ToShortDateString());
                   
                }

                if (date_time_from != date_time_of_day)
                {
                 
                    date = false;
                }
            }
            
            if (mail_number==null)
            {
                mail_numbers = true;
            }

            if (mail_summary == null) {

                mail_summary = " ";
                Summ = true;

            }
            if (Perent==null|| Perent==0)
            {
                perent = true;
            }
             
            try
            {
                ArchiveVModelWithPag model = new ArchiveVModelWithPag();

                var listc = await (from x in _db.Mails.
                                 Where(a => a.Mail_Type == 2 //t
                                 && (a.Mail_Number == mail_number || mail_numbers == true) //t/t
                                 && ((a.Date_Of_Mail>= date_time_of_day && a.Date_Of_Mail <= date_time_from) /*|| (date == true)*/)//t
                                
                                 && (a.Department_Id == department_id || departments_id == true)//t
                                 && (a.Mail_Summary.Contains(mail_summary) || (Summ == true))
                                 )
                                  
                                   join m in _db.Sends.Where(x =>x.to==19 && x.State == true&&x.flag>1) on x.MailID equals m.MailID
                                 

                                   join de in _db.Departments on x.Department_Id equals de.Id

                                   join y in _db.External_Mails
                                                  on m.MailID equals y.MailID
                                   //&& (c.perent == Perent || perent == true) || (c.state == true)
                                   
                               //************eman 
                                   join ex_dep in _db.external_Departments
                                   .Where(e=>e.state==true) 
                                   on x.MailID equals ex_dep.Mail_id

                                  // join w in _db.Extrmal_Sections.Where(c => c.state == true
                                   join w in _db.Extrmal_Sections
                                  .Where(c => c.state == true
                            && ((c.type == MailType) || (mail_type == true))
                            && (c.perent == Perent || perent == true) && (c.id == side_id || sides_id == true))

                                  // on y.Sectionid equals w.id
                                    on ex_dep.side_number equals w.id

                                   //****************end 

                                   select new ArchivesViewModel()
                                   {
                                       summary = x.Mail_Summary,
                                       Flag = m.flag,
                                       Flagn = _db.MailStatuses.Where(p => p.flag == m.flag).Select(p => p.sent).FirstOrDefault().ToString(),
                                       id = x.MailID,
                                       Department = de.DepartmentName,
                                        idDepartment = x.Department_Id, //فيه خطاء
                                        Date_Of_Mail = x.Date_Of_Mail.ToString("yyyy-MM-dd"),

                                         DateTime_of_read = (y.Send_of_Ex_mail.ToString().StartsWith("0001")) ? "لم يتم الاستلام" : y.Send_of_Ex_mail.ToString("yyyy-MM-dd"),
                                         Time_of_read = (y.Send_of_Ex_mail.ToString().EndsWith("0000")) ? "لم يتم الاستلام" : y.Send_of_Ex_mail.ToString("hh:mm:ss"),
                                       delivery = (y.delivery != null) ? y.delivery : "لم يتم التسليم",//هذا بنستقبلهم من الفرونتs
                                        Mail_Number = x.Mail_Number,
                                       side_Name = w.Section_Name,
                                       side_id = w.id,
                                       Perentid = _db.Extrmal_Sections.Where(p => p.id == w.perent).Select(p => p.id).FirstOrDefault(),
                                       PerentName = _db.Extrmal_Sections.Where(p => p.id == w.perent).Select(p => p.Section_Name).FirstOrDefault().ToString(),
                                       note = y.note,
                                       Attachments = y.Attachments,
                                         Number_Of_Copies = y.number_of_copies

                                       //   }).OrderByDescending(v => v.id).Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
                                   }).OrderByDescending(v => v.id).Distinct().ToListAsync();


                //*******
                model.list = listc.OrderByDescending(v => v.id).Skip((page - 1) * pageSize).Take(pageSize).ToList();

                model.total = listc.Count();
               
                //****************
//**************eman تم الغاءه
                //var list = await (from x in _db.Mails.
                //                 Where(a => a.Mail_Type == 2 //t
                //                 && (a.Mail_Number == mail_number || mail_numbers == true) //t/t
                //                && ((a.Date_Of_Mail>= date_time_of_day && a.Date_Of_Mail <= date_time_from) /*|| (date == true)*/)//t
                //                 && (a.Department_Id == department_id || departments_id == true)//t
                //                 && (a.Mail_Summary.Contains(mail_summary) || (Summ == true))
                //                 )
                                 
                //                  join m in _db.Sends.Where(x =>x.to==19 && x.State == true&&x.flag>1) on x.MailID equals m.MailID
                           

                //   join de in _db.Departments on x.Department_Id equals de.Id

                //                   join y in _db.External_Mails
                //                                  on m.MailID equals y.MailID
                //   //&& (c.perent == Perent || perent == true) || (c.state == true)

                //   //************eman 
                //   join ex_dep in _db.external_Departments on x.MailID equals ex_dep.Mail_id
                //   join w in _db.Extrmal_Sections.
                //  // join w in _db.Extrmal_Sections.
                //   Where(c => c.state == true
                //   && ((c.type == MailType) || (mail_type == true)) && (c.perent == Perent || perent == true) && (c.id == side_id || sides_id == true))
                //   on ex_dep.side_number equals w.id
                //   //  on y.Sectionid equals w.id
                //   //****************end



                //   select new ArchivesViewModel()
                //                   {
                //                       summary = x.Mail_Summary,
                //                    //   Flag = m.flag,
                //                      // Flagn = _db.MailStatuses.Where(p => p.flag == m.flag).Select(p => p.sent).FirstOrDefault().ToString(),
                //                       //id = x.MailID,
                //                       //Department = de.DepartmentName,
                //                       //idDepartment = x.Department_Id, //فيه خطاء
                //                       //Date_Of_Mail = x.Date_Of_Mail.ToString("yyyy-MM-dd"),

                //                       //DateTime_of_read = (y.Send_of_Ex_mail.ToString().StartsWith("0001")) ? "لم يتم الاستلام" : y.Send_of_Ex_mail.ToString("yyyy-MM-dd"),
                //                       //Time_of_read = (y.Send_of_Ex_mail.ToString().EndsWith("0000")) ? "لم يتم الاستلام" : y.Send_of_Ex_mail.ToString("hh:mm:ss"),
                //                       //delivery = (y.delivery != null) ? y.delivery : "لم يتم التسليم",//هذا بنستقبلهم من الفرونتs
                //                       //Mail_Number = x.Mail_Number,
                //                      // side_Name = w.Section_Name,
                //                      // side_id = w.id,
                //                      // Perentid = _db.Extrmal_Sections.Where(p => p.id == w.perent).Select(p => p.id).FirstOrDefault(),
                //                      // PerentName = _db.Extrmal_Sections.Where(p => p.id == w.perent).Select(p => p.Section_Name).FirstOrDefault().ToString(),
                //                      // note = y.note,
                //                      // Attachments = y.Attachments,
                //                      // Number_Of_Copies = y.number_of_copies

                //                   }).OrderByDescending(v => v.id).ToListAsync();


//                 var list = await (from x in _db.Mails.
//                                  Where(a => a.Mail_Type == 2 //t
//                                  && (a.Mail_Number == mail_number || mail_numbers == true) //t/t
//  && ((a.Date_Of_Mail >= date_time_of_day && a.Date_Of_Mail <= date_time_from) /*|| (date == true)*/) && (a.Department_Id == department_id || departments_id == true)//t
//                                  && (a.Mail_Summary.Contains(mail_summary) || (Summ == true))
//                                  )
//                                   join m in _db.Sends.Where(x => x.to == 25 && x.State == true) on x.MailID equals m.MailID


//                                   join de in _db.Departments on x.Department_Id equals de.Id

//                                   join y in _db.External_Mails
//                                                  on m.MailID equals y.MailID
//                                   //&& (c.perent == Perent || perent == true) || (c.state == true)
//                                   join w in _db.Extrmal_Sections.
//                    Where(c => c.state == true
//                            && ((c.type == MailType) || (mail_type == true)) && (c.perent == Perent || perent == true) && (c.id == side_id || sides_id == true)


//                    )
//                                   on y.Sectionid equals w.id





//                                   select new ArchivesViewModel()
//                                    {
//                                       summary = x.Mail_Summary,
//                                       Flag = m.flag,
//                                       Flagn = _db.MailStatuses.Where(p => p.flag == m.flag).Select(p => p.sent).FirstOrDefault().ToString(),
//                                       id = x.MailID,
//                                       Department = de.DepartmentName,
//                                       idDepartment = x.Department_Id, //فيه خطاء
//                                       Date_Of_Mail = x.Date_Of_Mail.ToString("yyyy-MM-dd"),

//                                       DateTime_of_read = (y.Send_of_Ex_mail.ToString().StartsWith("0001")) ? "لم يتم الاستلام" : y.Send_of_Ex_mail.ToString("yyyy-MM-dd"),
//                                       Time_of_read = (y.Send_of_Ex_mail.ToString().EndsWith("0000")) ? "لم يتم الاستلام" : y.Send_of_Ex_mail.ToString("HH:mm:ss"),
//                                       delivery = (y.delivery != null) ? y.delivery : "لم يتم التسليم",//هذا بنستقبلهم من الفرونتs
//                                       Mail_Number = x.Mail_Number,
//                                       side_Name = w.Section_Name,
//                                       side_id = w.id,
//                                       Perentid = _db.Extrmal_Sections.Where(p => p.id == w.perent).Select(p => p.id).FirstOrDefault(),
//                                       PerentName = _db.Extrmal_Sections.Where(p => p.id == w.perent).Select(p => p.Section_Name).FirstOrDefault().ToString(),
//                                       note=y.note,
//                                       Attachments=y.Attachments,
//                                       Number_Of_Copies =y.number_of_copies

//                                   }).OrderByDescending(v => v.id).ToListAsync();



             //   model.total = list.Count();
               // model.list = listc;
//**end eman نهاية الالغاء
                return model;
                    
            }
            catch (Exception)
            {

                throw;
            }
        }

   

        public async  Task<bool> UpdateExternal(UpdateArchiveViewModel model)
        {
            try
            {
                //15 قراءة البريد
                //16  مرفقات
                //17  عدد النسخ
                //18 طباعة حافظة
                
                Historyes historyes = new Historyes();
                Historyes historyes1 = new Historyes();
                Historyes historyes2 = new Historyes();
                Historyes historyes3 = new Historyes();
                Historyes historyes4 = new Historyes();

                
                var Ex = await _db.External_Mails.Where(p=> p.MailID== model.MailId).FirstOrDefaultAsync();

                if (Ex != null)
                {

                    var fl = await _db.Sends.Where(p => p.MailID == model.MailId && p.to == 19&& p.State==true).FirstOrDefaultAsync();
                    if (fl.flag!=3)
                    {
                        var ExDat = await _db.External_Mails.Where(p => p.MailID == model.MailId).FirstOrDefaultAsync();
                       
                        historyes.currentUser = model.Current;
                        historyes.HistortyNameID=15;
                        historyes.Time= DateTime.Now;
                        historyes.mailid = model.MailId;
                        bool result= await _history.Add(historyes);


                        fl.flag = 3;
                        _db.Sends.Update(fl);
                        ExDat.Send_of_Ex_mail = DateTime.Now;
                        _db.External_Mails.Update(ExDat);
                        await _db.SaveChangesAsync();



                    }

                    if (model.delevery!=null)
                    {
                        historyes1.currentUser = model.Current;
                        historyes1.HistortyNameID = 24;//ملاحظة غيرها علي الرقم الجديد 
                        historyes1.Time = DateTime.Now;
                        historyes1.mailid = model.MailId;
                        historyes1.changes = model.delevery;
                        bool result = await _history.Add(historyes1);

                        Ex.delivery = model.delevery;
                    }


                    if (Ex.Attachments!=model.Attachments)
                    {
                        historyes2.currentUser = model.Current;
                        historyes2.HistortyNameID = 16;
                        historyes2.Time = DateTime.Now;
                        historyes2.mailid = model.MailId;
                        historyes2.changes = (model.Attachments == true) ?"يوحد مرفقات": "لايوجد مرفقات";
                        bool result = await _history.Add(historyes2);

                        Ex.Attachments = model.Attachments;
                    }


                    if (Ex.number_of_copies!=model.Number_Of_Copies)
                    {
                        historyes3.currentUser = model.Current;
                        historyes3.HistortyNameID = 17;
                        historyes3.Time = DateTime.Now;
                        historyes3.mailid = model.MailId;
                        historyes3.changes = model.Number_Of_Copies.ToString();
                        bool result = await _history.Add(historyes3);

                        Ex.number_of_copies = model.Number_Of_Copies;
                    }


                    if (Ex.note!=model.note)
                    {

                        if (String.IsNullOrWhiteSpace(model.note))
                        {
                            historyes4.changes = "تم الغاء الملاحظة";


                        }

                        else {
                            historyes4.changes = model.note.ToString();

                        }

                        Ex.note = model.note;

                        historyes4.currentUser = model.Current;
                        historyes4.HistortyNameID = 25;
                        historyes4.Time = DateTime.Now;
                        historyes4.mailid = model.MailId;
                        bool result = await _history.Add(historyes4);

                    }
                      

                   
                    await _db.SaveChangesAsync();
                    return true;
            
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public async Task<bool> UpdateExternals(UpdateArchiveViewModel model)
        {
            try
            {
                //15 قراءة البريد
                //16  مرفقات
                //17  عدد النسخ
                //18 طباعة حافظة

                Historyes historyes = new Historyes();
               
               
                   
                        historyes.currentUser = model.Current;
                        historyes.HistortyNameID = 18;
                        historyes.Time = DateTime.Now;



                        bool result = await _history.Add(historyes);
                if (result)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
