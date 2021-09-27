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

        public async Task<ArchiveVModelWithPag> GetAll(int page, int pageSize)
        {
            try
            {
                ArchiveVModelWithPag model = new ArchiveVModelWithPag();


                var list = await (from x in _db.Mails.Where(x => x.Mail_Type == 2)
                                    join y in _db.External_Mails on x.MailID equals y.MailID

                                    select new ArchivesViewModel()
                                    {
                                        id = y.ID,
                                        Date_Of_Mail = x.Date_Of_Mail.ToString("yyyy-MM-dd"),
                                        DateTime_of_read = y.Send_of_Ex_mail.ToString("yyyy-MM-dd"),
                                        Time_of_read = y.Send_of_Ex_mail.ToString("hh-mm-ss"),
                                        delivery = y.delivery,
                                        Mail_Number = x.Mail_Number,
                                        Section_Name = y.sectionName,
                                    }).ToListAsync();
                model.total = list.Count();


                model.list  = await (from x in _db.Mails.Where(x => x.Mail_Type == 2)
                                                      join y in _db.External_Mails on x.MailID equals y.MailID
                                                      
                                                      select new ArchivesViewModel() 
                                                      {
                                                          id=y.ID,
                                                          Date_Of_Mail = x.Date_Of_Mail.ToString("yyyy-MM-dd"),
                                                          DateTime_of_read = y.Send_of_Ex_mail.ToString("yyyy-MM-dd"),
                                                          Time_of_read = y.Send_of_Ex_mail.ToString("hh-mm-ss"),
                                                          delivery = y.delivery,Mail_Number=x.Mail_Number,
                                                          Section_Name=y.sectionName,
                                                      }).OrderByDescending(x=>x.id).Skip((page-1)&pageSize).Take(pageSize).ToListAsync();
     
 
                return model;
                    
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<ArchivesViewModel>> GetByNum(int id)
        {
           
            throw new NotImplementedException();
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
