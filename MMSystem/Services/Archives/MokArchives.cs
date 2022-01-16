using Microsoft.EntityFrameworkCore;
using MMSystem.Model;
using MMSystem.Model.Dto;
using MMSystem.Model.ViewModel.ArchivesReport;
using MMSystem.Model.ViewModel.ArchiveVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Services.Archives
{
    public class MokArchives : IArchives
    {
        private readonly AppDbCon _db;

        public MokArchives(AppDbCon db)
        {
            _db = db;
        }

        public async Task<ArchiveVModelWithPag> GetAll(int page, int pageSize, int? mail_number, DateTime? date_time_of_day,
            DateTime? date_time_from, int? department_id, int? side_id, string? mail_summary,int?get_all, int? MailType ,int? Perent)
        {
            bool mail_numbers = false;
            bool Summ = false;
            bool date = false;
            bool perent = false;
          
            bool sides_id = false;
            bool mail_type = false;
            bool departments_id = false;
            if (side_id == null)
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
                 
                    date = true;
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
            if (Perent==null)
            {
                perent = true;
            }
             
            try
            {
                ArchiveVModelWithPag model = new ArchiveVModelWithPag();





                var listc = await (from x in _db.Mails.
                                 Where(a => a.Mail_Type == 2 //t
                                 && (a.Mail_Number == mail_number || mail_numbers == true) //t/t
                                 && ((a.Date_Of_Mail >= date_time_of_day && a.Date_Of_Mail <= date_time_from) || (date == true))//t
                                 && (a.Department_Id == department_id || departments_id == true)//t
                                 && (a.Mail_Summary.Contains(mail_summary) || (Summ == true))
                                 )
                                   join m in _db.Sends.Where(x =>x.isMulti==true && x.State == true) on x.MailID equals m.MailID


                                   join de in _db.Departments on x.Department_Id equals de.Id

                                   join y in _db.External_Mails
                                                  on m.MailID equals y.MailID
                                                   //&& (c.perent == Perent || perent == true) || (c.state == true)
                                   join w in _db.Extrmal_Sections.
                                   Where(c => c.state == true
                                   && (c.type == MailType) || (mail_type == true)
                                   && (c.perent == Perent || perent == true)
                                   && (c.id == side_id || sides_id == true)


                           )
                                   on y.Sectionid equals w.id



                                   select new ArchivesViewModel()
                                   {
                                       summary = x.Mail_Summary,
                                       Flag = m.flag,
                                       Flagn = _db.MailStatuses.Where(p => p.flag == m.flag).Select(p => p.sent).FirstOrDefault().ToString(),
                                       id = x.MailID,
                                       Department = de.DepartmentName,
                                       idDepartment = x.Department_Id, //فيه خطاء
                                       Date_Of_Mail = x.Date_Of_Mail.ToString("yyyy-MM-dd"),

                                       DateTime_of_read = (y.Send_of_Ex_mail.ToString().StartsWith("0001")) ? "لم يتم الاستلام":y.Send_of_Ex_mail.ToString("yyyy-MM-dd"),
                                       Time_of_read = (y.Send_of_Ex_mail.ToString().EndsWith("0000")) ? "لم يتم الاستلام" : y.Send_of_Ex_mail.ToString("hh-mm-ss"),
                                       delivery = (y.delivery !=null)?y.delivery :"لم يتم التسليم" ,//هذا بنستقبلهم من الفرونتs
                                       Mail_Number = x.Mail_Number,
                                       side_Name = w.Section_Name,
                                       side_id = w.id,
                                       Perentid = _db.Extrmal_Sections.Where(p => p.id == w.perent).Select(p => p.id).FirstOrDefault(),
                                       PerentName = _db.Extrmal_Sections.Where(p => p.id == w.perent).Select(p => p.Section_Name).FirstOrDefault().ToString(),


                                   }).OrderByDescending(v => v.id).Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();



                var list = await (from x in _db.Mails.
                                 Where(a => a.Mail_Type == 2 //t
                                 && (a.Mail_Number == mail_number || mail_numbers == true) //t/t
                                 && ((a.Date_Of_Mail >= date_time_of_day && a.Date_Of_Mail <= date_time_from) || (date == true))//t
                                 && (a.Department_Id == department_id || departments_id == true)//t
                                 && (a.Mail_Summary.Contains(mail_summary) || (Summ == true))
                                 )
                                  join m in _db.Sends.Where(x => x.isMulti == true && x.State == true) on x.MailID equals m.MailID


                                  join de in _db.Departments on x.Department_Id equals de.Id

                                  join y in _db.External_Mails
                                                 on m.MailID equals y.MailID
                                  //&& (c.perent == Perent || perent == true) || (c.state == true)
                                  join w in _db.Extrmal_Sections.
                   Where(c =>  c.state == true
                   && (c.type == MailType ) || (mail_type == true)
                   && (c.perent == Perent || perent == true)
                   && (c.id == side_id || sides_id == true)

                   )
                                  on y.Sectionid equals w.id





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
                                       Time_of_read = (y.Send_of_Ex_mail.ToString().EndsWith("0000")) ? "لم يتم الاستلام" : y.Send_of_Ex_mail.ToString("hh-mm-ss"),
                                       delivery = (y.delivery != null) ? y.delivery : "لم يتم التسليم",//هذا بنستقبلهم من الفرونتs
                                       Mail_Number = x.Mail_Number,
                                      side_Name = w.Section_Name,
                                      side_id = w.id,
                                      Perentid = _db.Extrmal_Sections.Where(p => p.id == w.perent).Select(p => p.id).FirstOrDefault(),
                                      PerentName = _db.Extrmal_Sections.Where(p => p.id == w.perent).Select(p => p.Section_Name).FirstOrDefault().ToString(),


                                  }).OrderByDescending(v => v.id).ToListAsync();



                model.total = list.Count();
                model.list = listc;

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
                var Ex = await _db.External_Mails.Where(p=> p.MailID== model.MailId).FirstOrDefaultAsync();

                if (Ex != null)
                {
                    if (model.Send_of_Ex_mail!=null)
                    {
                        var fl = await _db.Sends.Where(p => p.MailID == model.MailId&&p.to==25).FirstOrDefaultAsync();
                        
                    }
                    Ex.delivery = model.delevery;
                    Ex.Attachments = model.Attachments;
                    Ex.number_of_copies = model.Number_Of_Copies;
                    Ex.Send_of_Ex_mail = model.Send_of_Ex_mail;
                    Ex.note = model.note;
                    _db.External_Mails.Update(Ex);
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
    }
}
