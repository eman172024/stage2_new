using Microsoft.EntityFrameworkCore;
using MMSystem.Model;
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
            DateTime? date_time_from, int? department_id, int? side_id, string? mail_summary,int?get_all)
        {
            bool mail_numbers=false;
            bool date=true;
            bool sides_id = false;
            bool departments_id = false;
            if (side_id == null)
            {
                sides_id = true;
            }
            if (department_id == null)
            {
                departments_id = true;
            }
            if (get_all!=1)
            {
                if (date_time_of_day == null)
                {
                    date_time_of_day = DateTime.Now;
                }

                if (date_time_from == null)
                {
                    date_time_from = DateTime.Now;
                }
            }
            
            if (mail_number==null)
            {
                mail_numbers = true;
            }

            if (mail_summary == null) {

                mail_summary = " ";
            }

            if (side_id == 0) { 
            
            
            
            }

            try
            {
                ArchiveVModelWithPag model = new ArchiveVModelWithPag();


                var list = await (from x in _db.Mails.
                                  Where(a => a.Mail_Type == 2 //t
                                  && (a.Mail_Number==mail_number || mail_numbers==true) //t/t
                                  &&((a.Date_Of_Mail>=date_time_of_day&& a.Date_Of_Mail <= date_time_from) //
                                  || (date==true))//t
                                  &&(a.Department_Id==department_id||departments_id==true)//t
                                  
                                  )
                                  join m in _db.Sends.Where(x=>x.isMulti==true &&x.State==true ) on x.MailID equals m.MailID
                                                  

                                  join y in _db.External_Mails
                                                   on x.MailID equals y.MailID
                                  
                                                   join w in _db.Extrmal_Sections.
                                  Where(c => c.id==side_id ||sides_id==true)
                                                   on y.Sectionid equals w.id

                                  select new ArchivesViewModel()
                                    {
                                      To=m.to,
                                      Flag=m.flag,

                                        id = y.ID,
                                        Date_Of_Mail = x.Date_Of_Mail.ToString("yyyy-MM-dd"),
                                        DateTime_of_read = y.Send_of_Ex_mail.ToString("yyyy-MM-dd"),
                                        Time_of_read = y.Send_of_Ex_mail.ToString("hh-mm-ss"),
                                        delivery = y.delivery,
                                        Mail_Number = x.Mail_Number,
                                        Section_Name = w.Section_Name,
                                          Perent=y.Sectionid,
                                    }).OrderByDescending(v => v.id).ToListAsync();

                page = 1;
                pageSize = 3;

                var listc = await (from x in _db.Mails.
                                 Where(a => a.Mail_Type == 2 //t
                                 && (a.Mail_Number == mail_number || mail_numbers == true) //t/t
                                 && ((a.Date_Of_Mail >= date_time_of_day && a.Date_Of_Mail <= date_time_from) //
                                 || (date == true))//t
                                 && (a.Department_Id == department_id || departments_id == true)//t

                                 )
                                 join m in _db.Sends.Where(x => x.isMulti == true && x.State == true) on x.MailID equals m.MailID


                                 join y in _db.External_Mails
                                                  on x.MailID equals y.MailID

                                 join w in _db.Extrmal_Sections.
                Where(c => c.id == side_id || sides_id == true)
                                 on y.Sectionid equals w.id

                                 select new ArchivesViewModel()
                                 {
                                     To = m.to,
                                     Flag = m.flag,

                                     id = y.ID,
                                     Date_Of_Mail = x.Date_Of_Mail.ToString("yyyy-MM-dd"),
                                     DateTime_of_read = y.Send_of_Ex_mail.ToString("yyyy-MM-dd"),
                                     Time_of_read = y.Send_of_Ex_mail.ToString("hh-mm-ss"),
                                     delivery = y.delivery,
                                     Mail_Number = x.Mail_Number,
                                     Section_Name = w.Section_Name,
                                     Perent = y.Sectionid,
                                 }).OrderByDescending(v => v.id).Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

                //}).OrderByDescending(v => v.id).Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

                model.total = listc.Count();
                model.list = list;

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
                var Ex = await _db.External_Mails.FindAsync(model.Id);

                if (Ex != null)
                {
                    Ex.delivery = model.delevery;
                    Ex.Attachments = model.Attachments;

                    Ex.Send_of_Ex_mail = model.Send_of_Ex_mail;
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
