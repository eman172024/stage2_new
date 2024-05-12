using Microsoft.EntityFrameworkCore;
using MMSystem.Model;
using MMSystem.Model.Dto;
using MMSystem.Model.ViewModel;
using MMSystem.Model.ViewModel.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Services.Reports
{
    public class MockReports : IRportInterface
    {

        public MockReports(AppDbCon data)
        {
            _data = data;

        }
        private AppDbCon _data { get; }
  /// <summary>
  /// لم تتم إضافتها الي المنظومة بعد
  /// </summary>
  /// <returns> جميع الاميلات التي تم تداولها بي المنظومة </returns>
        public async Task<TotalCounts> GetAllSystemCount()
        {

            TotalCounts totalCounts = new TotalCounts();

            totalCounts.TotalOfMassage =await _data.Mails.Where(x => x.state == true).CountAsync();
            
            totalCounts.TotalOfReplay = await (from hus in _data.Sends.Where(x => x.flag != 0)
                                        join
                                        hu in _data.Replies on hus.Id equals hu.send_ToId
                                        select  hu.ReplyId  ).CountAsync();

            totalCounts.TotalOfReplay = await(from hus in _data.Sends.Where(x => x.flag != 0)
                                         join
                                         hu in _data.Replies  on hus.Id equals hu.send_ToId
                                         group hu by hu.send_ToId).CountAsync();

            totalCounts.TotalOfNotReplay = decimal.ToInt32(totalCounts.TotalOfMassage - totalCounts.TotalOfReplay);

            totalCounts.Average = totalCounts.TotalOfReplay / totalCounts.TotalOfMassage * 100;

            return totalCounts;
        }
  
        public async Task<List<SectionReport>> GetAllDepartmentReports(DateTime fromdate, DateTime todate, int ? MailType, string SendedOrRecieved)
        {
            try
            {
            
                List<Department> departments =await _data.Departments.Where(x => x.state == true).ToListAsync();

                SectionReport sectionsreport = new SectionReport();
              
                List<SectionReport> List1 = new List<SectionReport>();

                if (fromdate.Date > DateTime.Now.Date)
                {
                    fromdate = DateTime.Now;
                }


                int massageReplaied =0;


               if (SendedOrRecieved == "sended")
                {
                    

                    foreach (var item in departments)
                    {
                        sectionsreport.DepartmentName = item.DepartmentName;


                        if (MailType == null)
                        {
                            sectionsreport.TotalOfReceived.TotalOfMassage =await _data.Mails.Where(x => x.Department_Id == item.Id && x.state == true ).CountAsync();


                           massageReplaied = await (from hus in _data.Replies.Where(x => x.To == item.Id)
                                               join
                                               hu in _data.Sends.Where(x => x.Send_time >= fromdate && x.Send_time <= todate)
                                               on hus.send_ToId equals hu.Id
                                               join
                                               g in _data.Mails.Where(x => x.state == true) on hu.MailID equals g.MailID
                                               select  hus.send_ToId
                                               ).Distinct().CountAsync();

                            
                        }
                        else {

                            sectionsreport.TotalOfReceived.TotalOfMassage = _data.Mails.Where(x => x.Department_Id == item.Id && x.state == true && x.Mail_Type == MailType).Count();


                            massageReplaied = await (from hus in _data.Replies.Where(x=>x.To == item.Id ) 
                                               join
                                               hu in _data.Sends.Where(x=>x.Send_time >= fromdate && x.Send_time <= todate ) 
                                               on hus.send_ToId equals hu.Id
                                               join
                                               g in _data.Mails.Where(x=> x.state ==true && x.Mail_Type == MailType) on hu.MailID equals g.MailID
                                               group hus by hus.send_ToId
                                               ).CountAsync();

                        }

                        sectionsreport.TotalOfReceived.TotalOfReplay = massageReplaied;

                        sectionsreport.TotalOfReceived.TotalOfNotReplay = decimal.ToInt32(sectionsreport.TotalOfReceived.TotalOfMassage - sectionsreport.TotalOfReceived.TotalOfReplay);
                        if (sectionsreport.TotalOfReceived.TotalOfMassage != 0)
                        {
                            sectionsreport.TotalOfReceived.Average = (sectionsreport.TotalOfReceived.TotalOfReplay / sectionsreport.TotalOfReceived.TotalOfMassage) * 100;
                        }
                        else {
                            sectionsreport.TotalOfReceived.Average = 0;
                        }

                        List1.Add(new SectionReport
                        {
                            DepartmentName = sectionsreport.DepartmentName,
                            TotalOfReceived = new TotalCounts
                            {
                                TotalOfMassage = sectionsreport.TotalOfReceived.TotalOfMassage,
                                TotalOfReplay = sectionsreport.TotalOfReceived.TotalOfReplay,
                                TotalOfNotReplay = sectionsreport.TotalOfReceived.TotalOfNotReplay,
                                Average = sectionsreport.TotalOfReceived.Average
                            }
                        });
                       

                    }
                 

                }
                else
                if (SendedOrRecieved == "recieved")
                {
                   
                    foreach (var item1 in departments)
                    {
                       
                        sectionsreport.DepartmentName = item1.DepartmentName;

                        List<Administrator> users =await _data.Administrator.Where(x => x.DepartmentId == item1.Id && x.state == true).ToListAsync();


                        if (MailType == null)
                        {

                            sectionsreport.TotalOfReceived.TotalOfMassage = await (from hus in _data.Mails.Where(x => x.state == true)
                                                                             join hu in _data.Sends.Where(x => x.to == item1.Id && x.Send_time >= fromdate && x.Send_time <= todate)
                                                                             on hus.MailID equals hu.MailID
                                                                             select hu.MailID).CountAsync();

                            for (int i = 0; i < users.Count; i++)
                            {
                                massageReplaied =await (from hus in _data.Replies.Where(x => x.UserId == users[i].UserId)
                                                   join
                                                   hu in _data.Sends.Where(x => x.to == item1.Id && x.Send_time >= fromdate && x.Send_time <= todate)
                                                   on hus.send_ToId equals hu.Id
                                                   join
                                                   g in _data.Mails.Where(x => x.state == true) 
                                                   on hu.MailID equals g.MailID
                                                   select hus.send_ToId
                                                    ).Distinct().CountAsync();
                            }
                           
                        }
                        else {

                           sectionsreport.TotalOfReceived.TotalOfMassage =await (from hus in _data.Mails.Where(x => x.state == true && x.Mail_Type == MailType)
                                                                            join hu in _data.Sends.Where(x => x.to == item1.Id && x.Send_time >= fromdate && x.Send_time <= todate)
                                                                            on hus.MailID equals hu.MailID
                                                                            select hu.MailID).CountAsync();

                            for (int i = 0; i < users.Count; i++)
                            {
                                massageReplaied =await (from hus in _data.Replies.Where(x => x.UserId == users[i].UserId )
                                                   join
                                                   hu in _data.Sends.Where(x => x.Send_time >= fromdate && x.Send_time <= todate)
                                                   on hus.send_ToId equals hu.Id
                                                   join
                                                   g in _data.Mails.Where(x => x.state == true && x.Mail_Type == MailType) on hu.MailID equals g.MailID
                                                   group hus by hus.send_ToId
                                                  ).CountAsync();

                             
                            }
                        }
                        sectionsreport.TotalOfReceived.TotalOfReplay = massageReplaied;

                        sectionsreport.TotalOfReceived.TotalOfNotReplay = decimal.ToInt32(sectionsreport.TotalOfReceived.TotalOfMassage - sectionsreport.TotalOfReceived.TotalOfReplay);
                      
                        if (sectionsreport.TotalOfReceived.TotalOfMassage != 0)
                        {
                            sectionsreport.TotalOfReceived.Average = (sectionsreport.TotalOfReceived.TotalOfReplay / sectionsreport.TotalOfReceived.TotalOfMassage) * 100;
                        }
                        else
                        {
                            sectionsreport.TotalOfReceived.Average = 0;
                        }

                        List1.Add(new SectionReport
                        {
                            DepartmentName = sectionsreport.DepartmentName,
                            TotalOfReceived = new TotalCounts {  TotalOfMassage = sectionsreport.TotalOfReceived.TotalOfMassage ,
                            TotalOfReplay= sectionsreport.TotalOfReceived.TotalOfReplay,
                            TotalOfNotReplay = sectionsreport.TotalOfReceived.TotalOfNotReplay,
                            Average= sectionsreport.TotalOfReceived.Average
                            }
                        });
                        massageReplaied = 0;
                    }
                }
            

                return List1;

            }
            catch
            {

                throw;
            }

        }

        /// <summary>
        ///   التقرير الاحصائي 
        /// </summary>
        /// <param name="departmentid"> رقم الإدارة</param>
        /// <param name="fromdate"> من التاريخ </param>
        /// <param name="todate"> إلي التاريخ </param>
        /// <param name="MailType"> نوع البريد</param>
        /// <param name="SendedOrRecieved"> مرسل او مستقبل </param>
        /// <returns>  SectionReportWithTotal </returns>
        public async Task<SectionReportWithTotal> GetMySectionReport(int departmentid, DateTime  fromdate, DateTime  todate, int? MailType, string  SendedOrRecieved)
        {
            try
            {
                bool HasNoValue = false;


                decimal  total_not_reply = 0, total_reply = 0, total_massege = 0;
                int massageReplaied = 0;
                List<Department> Rmv_Dublicate_Dep = new List<Department>();
                List<Department> departments = new List<Department>();
                 SectionReport mysectionreport = new SectionReport();
                 List<SectionReport> List1 = new List<SectionReport>();
                SectionReportWithTotal AllSectionWithTotal = new SectionReportWithTotal();  
                
                if (fromdate > DateTime.Now.Date)
                {
                    fromdate = DateTime.Now.Date;
                }

                if (!MailType.HasValue)
                {
                    HasNoValue = true;

                }
                   
                    departments = await (from hu in _data.Mails.Where(x => x.Department_Id == departmentid && x.state.Equals(true) &&( x.Mail_Type == MailType|| HasNoValue))
                                         join
                                         g in _data.Sends.Where(x => x.State.Equals(true) &&x.flag > 1 && x.to != departmentid && (x.Send_time.Date >= fromdate && x.Send_time.Date <= todate))
                                         on hu.MailID equals g.MailID
                                         join
                                         hus in _data.Departments.Where(x => x.state.Equals(true) && x.Id != departmentid)
                                         on g.to equals hus.Id
                                         select new Department
                                         {
                                             DepartmentName = hus.DepartmentName,
                                             Id = hus.Id,
                                             state = hus.state,
                                             perent = hus.perent,
                                             Users = hus.Users
                                         }).ToListAsync();


                    foreach (var item in departments)
                    {
                        if (!Rmv_Dublicate_Dep.Any(x => x.Id == item.Id))

                            Rmv_Dublicate_Dep.Add(new Department
                            {
                                Id = item.Id,
                                DepartmentName = item.DepartmentName,
                                perent = item.perent,
                                state = item.state
                            });

                    }    
        
                if (SendedOrRecieved == "sended")
                {
                    foreach (var item in Rmv_Dublicate_Dep)
                    {
                        mysectionreport.DepartmentName = item.DepartmentName;                       
                      
                            mysectionreport.TotalOfReceived.TotalOfMassage = (from hus in _data.Mails.Where(x => x.Department_Id == departmentid && x.state == true &&(x.Mail_Type == MailType || HasNoValue))
                                                                              join
                                                                              g in _data.Sends.Where(x => x.flag > 1 && x.to == item.Id && (x.Send_time.Date >= fromdate.Date && x.Send_time.Date <= todate.Date))
                                                                              on hus.MailID equals g.MailID
                                                                              select g.MailID).ToList().Count();

                             massageReplaied = await (from hus in _data.Mails.Where(x => x.Department_Id == departmentid && x.state == true && (x.Mail_Type == MailType || HasNoValue))
                                                   join
                                                   hu in _data.Sends.Where(x => x.flag == 4 && x.to == item.Id && (x.Send_time.Date >= fromdate.Date && x.Send_time.Date <= todate.Date)) 
                                                   on hus.MailID equals hu.MailID
                                                   join
                                                   g in _data.Replies on hu.Id equals g.send_ToId
                                                   select g.send_ToId
                                                   ).Distinct().CountAsync();
                      
                        if (mysectionreport.TotalOfReceived.TotalOfMassage != 0)
                        {
                            mysectionreport.TotalOfReceived.TotalOfReplay = massageReplaied;
                       
                            mysectionreport.TotalOfReceived.TotalOfNotReplay = decimal.ToInt32(mysectionreport.TotalOfReceived.TotalOfMassage - mysectionreport.TotalOfReceived.TotalOfReplay);
                       
                            mysectionreport.TotalOfReceived.Average = Math.Round((mysectionreport.TotalOfReceived.TotalOfReplay / mysectionreport.TotalOfReceived.TotalOfMassage) * 100,2);
                         
                        }
                        else {
                            mysectionreport.TotalOfReceived.TotalOfNotReplay = 0;
                            mysectionreport.TotalOfReceived.Average = 0;
                        }
                        List1.Add(new SectionReport
                        {
                            DepartmentName = mysectionreport.DepartmentName,
                            TotalOfReceived = new TotalCounts
                            {
                                TotalOfMassage = mysectionreport.TotalOfReceived.TotalOfMassage,
                                TotalOfReplay = mysectionreport.TotalOfReceived.TotalOfReplay,
                                TotalOfNotReplay = mysectionreport.TotalOfReceived.TotalOfNotReplay,
                                Average = mysectionreport.TotalOfReceived.Average
                            }
                        });                    
                    }
                    foreach (var item in List1)
                    {
                        total_massege += item.TotalOfReceived.TotalOfMassage;
                        total_reply += item.TotalOfReceived.TotalOfReplay;
                        total_not_reply += item.TotalOfReceived.TotalOfNotReplay;

                    }
                    AllSectionWithTotal.TotalOfTotal.TotalOfMassage = total_massege;
                    AllSectionWithTotal.TotalOfTotal.TotalOfReplay = total_reply;
                    AllSectionWithTotal.TotalOfTotal.TotalOfNotReplay = total_not_reply;
                  
                    if (AllSectionWithTotal.TotalOfTotal.TotalOfMassage != 0)
                    {
                        AllSectionWithTotal.TotalOfTotal.Average = Math.Round((AllSectionWithTotal.TotalOfTotal.TotalOfReplay / AllSectionWithTotal.TotalOfTotal.TotalOfMassage) * 100, 2);
                    }
                    else
                    {
                        AllSectionWithTotal.TotalOfTotal.Average = 0;
                    }         
                    AllSectionWithTotal.SectionReport = List1;
                }
                else if(SendedOrRecieved == "recieved") {
                
                    foreach (var item in Rmv_Dublicate_Dep)
                    {
                        mysectionreport.DepartmentName = item.DepartmentName;
                    
                            mysectionreport.TotalOfReceived.TotalOfMassage =  (from hus in _data.Mails.Where(x => (x.Department_Id == item.Id && x.state == true) ||( x.Mail_Type == MailType || HasNoValue))
                                                                              join
                                                                              g in _data.Sends.Where(x => x.flag != 0 && x.to == departmentid && (x.Send_time.Date >= fromdate.Date && x.Send_time.Date <= todate.Date))
                                                                              on hus.MailID equals g.MailID
                                                                              select g.MailID).ToList().Count();

                            massageReplaied = await (from hus in _data.Mails.Where(x => (x.Department_Id == item.Id && x.state == true) && (x.Mail_Type == MailType || HasNoValue))
                                               join
                                               hu in _data.Sends.Where(x => x.flag != 0 && x.to == departmentid && (x.Send_time.Date >= fromdate.Date && x.Send_time.Date <= todate.Date))
                                               on hus.MailID equals hu.MailID
                                               join
                                               g in _data.Replies on hu.Id equals g.send_ToId
                                               select g.send_ToId
                                                ).Distinct().CountAsync();
                   
                        mysectionreport.TotalOfReceived.TotalOfReplay = massageReplaied;
                        mysectionreport.TotalOfReceived.TotalOfNotReplay = decimal.ToInt32(mysectionreport.TotalOfReceived.TotalOfMassage - mysectionreport.TotalOfReceived.TotalOfReplay);
                        if (mysectionreport.TotalOfReceived.TotalOfMassage != 0)
                        {
                            mysectionreport.TotalOfReceived.Average = Math.Round((mysectionreport.TotalOfReceived.TotalOfReplay / mysectionreport.TotalOfReceived.TotalOfMassage) * 100,2);
                        }
                        else {
                            mysectionreport.TotalOfReceived.Average = 0;
                        }
                        List1.Add(new SectionReport
                        {
                            DepartmentName = mysectionreport.DepartmentName,
                            TotalOfReceived = new TotalCounts
                            {
                                TotalOfMassage = mysectionreport.TotalOfReceived.TotalOfMassage,
                                TotalOfReplay = mysectionreport.TotalOfReceived.TotalOfReplay,
                                TotalOfNotReplay = mysectionreport.TotalOfReceived.TotalOfNotReplay,
                                Average = mysectionreport.TotalOfReceived.Average
                            }
                        });
                    }
                    foreach (var item in List1)
                    {
                        total_massege += item.TotalOfReceived.TotalOfMassage;
                        total_reply += item.TotalOfReceived.TotalOfReplay;
                        total_not_reply += item.TotalOfReceived.TotalOfNotReplay;                     
                    }
                    AllSectionWithTotal.TotalOfTotal.TotalOfMassage = total_massege;
                    AllSectionWithTotal.TotalOfTotal.TotalOfReplay = total_reply;
                    AllSectionWithTotal.TotalOfTotal.TotalOfNotReplay = total_not_reply;
                    if (AllSectionWithTotal.TotalOfTotal.TotalOfMassage != 0)
                    {
                        AllSectionWithTotal.TotalOfTotal.Average = Math.Round((AllSectionWithTotal.TotalOfTotal.TotalOfReplay / AllSectionWithTotal.TotalOfTotal.TotalOfMassage) * 100, 2);
                    }
                    else
                    {
                        AllSectionWithTotal.TotalOfTotal.Average = 0;
                    }                
                    AllSectionWithTotal.SectionReport = List1;
                }
                return AllSectionWithTotal;
            }
            catch
            {

                throw;
            }
        }


        /// <summary>
        /// لم تتم إضافتها الي المنظومة بعد
        /// </summary>
        /// <param name="userid"> رقم المستخدم</param>
        /// <param name="fromdate"> من التاريخ </param>
        /// <param name="todate"> إلي التاريخ </param>
        /// <param name="MailType"> نوع البريد</param>
        /// <param name="SendedOrRecieved"> مرسل او مستقبل </param>
        /// <returns>ترد المستخد والايميلات اللي اتعامل امعاها </returns>
        public async Task<UserReports> GetAllUserMassageReport(int userid, DateTime fromdate, DateTime todate, int ? MailType, string SendedOrRecieved)
        {
            try
            {
                Administrator user = await _data.Administrator.FirstOrDefaultAsync(x => x.state == true && x.UserId == userid);

                UserReports userreport = new UserReports();

                if (fromdate.Date > DateTime.Now.Date)
                {
                    fromdate = DateTime.Now;
                }


                if (SendedOrRecieved == "sended")
                {
                    if (MailType == null)
                    {
                        userreport.UserName = user.UserName;
                                   
                        userreport.information1 = await (from hus in _data.Mails.Where(x => x.state == true && x.userId == user.UserId)
                                                   join
                                                   g in _data.Sends.Where(x => x.Send_time >= fromdate && x.Send_time <= todate)
                                                   on hus.MailID equals g.MailID
                                                   select new UserMailInfo
                                                   {
                                                       Mail_Summary = hus.Mail_Summary,
                                                       Send_To = g.to,
                                                       Date_Of_Mail = hus.Date_Of_Mail,
                                                       Mail_Number = hus.Mail_Number
                                                   }).Distinct().ToListAsync();               
                    }
                    else {

                        userreport.UserName = user.UserName;

                        userreport.information1 =await (from hus in _data.Mails.Where(x => x.state == true && x.userId == user.UserId && x.Mail_Type == MailType)
                                                   join
                                                   g in _data.Sends.Where(x => x.Send_time >= fromdate && x.Send_time <= todate)
                                                   on hus.MailID equals g.MailID
                                                   select new UserMailInfo
                                                   {
                                                       Mail_Summary = hus.Mail_Summary,
                                                       Send_To = g.to,
                                                       Date_Of_Mail = hus.Date_Of_Mail,
                                                       Mail_Number = hus.Mail_Number
                                                   }).ToListAsync();                   
                    }

                }
                else if (SendedOrRecieved == "recieved")
                {
                    userreport.UserName = user.UserName;

                    if (MailType == null)
                    {
                        userreport.information1 = await(from hus in _data.Mails.Where(x => x.state == true && x.userId != user.UserId)
                                                   join
                                                   hu in _data.Sends.Where(x => x.Send_time >= fromdate && x.Send_time <= todate)
                                                   on hus.MailID equals hu.MailID
                                                   join
                                                   g in _data.Replies.Where(x => x.UserId == user.UserId) on hu.Id equals g.send_ToId                                                  
                                                   select new UserMailInfo
                                                   {
                                                       Mail_Summary = hus.Mail_Summary,
                                                       Send_To = hu.to,
                                                       Date_Of_Mail = hus.Date_Of_Mail,
                                                       Mail_Number = hus.Mail_Number

                                                   }).Distinct().ToListAsync();
                    }
                    else
                    {

                        userreport.information1 = await (from hus in _data.Mails.Where(x => x.state == true && x.userId != user.UserId && x.Mail_Type == MailType)
                                                   join
                                                   hu in _data.Sends.Where(x => x.Send_time >= fromdate && x.Send_time <= todate)
                                                   on hus.MailID equals hu.MailID
                                                   join
                                                   g in _data.Replies.Where(x => x.UserId == user.UserId) on hu.Id equals g.send_ToId
                                                   select new UserMailInfo
                                                   {
                                                       Mail_Summary = hus.Mail_Summary,
                                                       Send_To = hu.to,
                                                       Date_Of_Mail = hus.Date_Of_Mail,
                                                       Mail_Number = hus.Mail_Number

                                                   }).ToListAsync();
                    }

                }
                return userreport;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// لم تتم إضافتها إلي المنظومة بعد
        /// </summary>
        /// <param name="departmentid"> رقم الإدارة</param>
        /// <param name="fromdate"> من التاريخ </param>
        /// <param name="todate"> إلي التاريخ </param>
        /// <param name="MailType"> نوع البريد</param>
        /// <param name="SendedOrRecieved"> مرسل او مستقبل </param>
        /// <returns> جميع مستخدمي الادارة والتقرير الاحصائي امتعهم</returns>
        public async Task<UsersConclsionReport> GetAllUserCount(int departmentid, DateTime fromdate, DateTime todate, int ? MailType, string SendedOrRecieved)
        {
            try
            {
                List<Administrator> user = await _data.Administrator.Where(x => x.state == true && x.DepartmentId == departmentid).ToListAsync();

                UsersConclsionReport userreport = new UsersConclsionReport();

                if (fromdate.Date > DateTime.Now.Date)
                {
                    fromdate = DateTime.Now;
                }
                int information;
                int massageReplaied;

                if(SendedOrRecieved == "sended")
                {

                    foreach (var item1 in user)
                    {
                        userreport.UserName = item1.UserName;
                        if (MailType == null)
                        {
                            information = (from hus in _data.Mails.Where(x =>x.state == true && x.userId == item1.UserId)
                                           join
                                           g in _data.Sends.Where(x => x.Send_time >= fromdate && x.Send_time <= todate)
                                           on hus.MailID equals g.MailID
                                           select hus.Mail_Number
                                           ).ToList().Count();

                            massageReplaied = await (from hus in _data.Mails.Where(x => x.state == true && x.userId == item1.UserId)
                                               join
                                               hu in _data.Sends.Where(x => x.Send_time >= fromdate && x.Send_time <= todate)
                                               on hus.MailID equals hu.MailID
                                               join
                                               g in _data.Replies.Where(x => x.UserId != item1.UserId) on hu.Id equals g.send_ToId
                                               select  g.send_ToId
                                               ).Distinct().CountAsync();
                        
                        }
                        else
                        {
                            information = (from hus in _data.Mails.Where(x => x.state == true && x.userId == item1.UserId && x.Mail_Type == MailType)
                                           join
                                           g in _data.Sends.Where(x => x.Send_time >= fromdate && x.Send_time <= todate)
                                           on hus.MailID equals g.MailID
                                           select hus.Mail_Number
                                                      ).ToList().Count();

                            massageReplaied = await(from hus in _data.Mails.Where(x => x.state == true && x.userId == item1.UserId && x.Mail_Type == MailType)
                                               join
                                               hu in _data.Sends.Where(x => x.Send_time >= fromdate && x.Send_time <= todate )
                                               on hus.MailID equals hu.MailID
                                               join
                                               g in _data.Replies.Where(x => x.UserId != item1.UserId) on hu.Id equals g.send_ToId
                                               select g.send_ToId
                                                       ).Distinct().CountAsync();                            
                        }
                        userreport.Total_Count.TotalOfMassage = information;
                        userreport.Total_Count.TotalOfReplay = massageReplaied;
                        userreport.Total_Count.TotalOfNotReplay = decimal.ToInt32(userreport.Total_Count.TotalOfMassage - userreport.Total_Count.TotalOfReplay);
                        if (userreport.Total_Count.TotalOfMassage != 0)
                        {
                            userreport.Total_Count.Average = Math.Round((userreport.Total_Count.TotalOfReplay / userreport.Total_Count.TotalOfMassage) * 100,2);
                        }
                        else
                        {
                            userreport.Total_Count.Average = 0;
                        } 
                    }
                }
                else if (SendedOrRecieved == "recieved")
                {
                    foreach (var item in user)
                    {
                        userreport.UserName = item.UserName;

                        if (MailType == null)
                        {
                            information = (from hus in _data.Mails.Where(x => x.state == true && x.userId != item.UserId)
                                           join
                                           hu in _data.Sends.Where(x => x.Send_time >= fromdate && x.Send_time <= todate && x.to == item.DepartmentId)
                                           on hus.MailID equals hu.MailID
                                           select hus.MailID
                                                 ).ToList().Count();

                            massageReplaied = await (from hus in _data.Mails.Where(x => x.state == true && x.userId != item.UserId)
                                               join
                                               hu in _data.Sends.Where(x => x.Send_time >= fromdate && x.Send_time <= todate && x.to == item.DepartmentId)
                                               on hus.MailID equals hu.MailID
                                               join
                                               g in _data.Replies.Where(x => x.UserId == item.UserId) on hu.Id equals g.send_ToId
                                               select g.send_ToId).Distinct().CountAsync();
                        }
                        else
                        {

                            information = (from hus in _data.Mails.Where(x => x.state == true && x.userId != item.UserId && x.Mail_Type == MailType)
                                           join
                                           hu in _data.Sends.Where(x => x.Send_time >= fromdate && x.Send_time <= todate)
                                           on hus.MailID equals hu.MailID
                                           join
                                           g in _data.Replies.Where(x => x.UserId == item.UserId) on hu.Id equals g.send_ToId
                                           select hus.Mail_Number
                                              ).ToList().Count();

                            massageReplaied = await (from hus in _data.Mails.Where(x => x.state == true && x.userId != item.UserId && x.Mail_Type == MailType)
                                               join
                                               hu in _data.Sends.Where(x => x.Send_time >= fromdate && x.Send_time <= todate)
                                               on hus.MailID equals hu.MailID
                                               join
                                               g in _data.Replies.Where(x => x.UserId == item.UserId) on hu.Id equals g.send_ToId
                                               select g.send_ToId
                                                     ).Distinct().CountAsync();
                        }

                        userreport.Total_Count.TotalOfMassage = information;
                        userreport.Total_Count.TotalOfReplay = massageReplaied;
                        userreport.Total_Count.TotalOfNotReplay = decimal.ToInt32(userreport.Total_Count.TotalOfMassage - userreport.Total_Count.TotalOfReplay);

                        if (userreport.Total_Count.TotalOfMassage != 0)
                        {
                            userreport.Total_Count.Average = Math.Round((userreport.Total_Count.TotalOfReplay / userreport.Total_Count.TotalOfMassage) * 100,2);
                        }
                        else
                        {
                            userreport.Total_Count.Average = 0;
                        }
                    }
                }
                return userreport;

            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public async Task<List<ReportViewModel>> ReportForDep(int departmentid,DateTime? fromm, DateTime? to ,
            int? Department_filter, int? mailnum, int? mailnum_bool, string? summary, int? mail_Readed,
            int? mailReaded, int? mailnot_readed , int? mail_type, int? Measure_filter, int? Classfication
 , int? mail_state, int? genral_incoming_num,int? TheSection, int? entity_reference_number, bool? Replay_Date)
        {

            bool dep_filter = false;
            bool mail_accept = false;
            bool mailtype = true;
            bool meas_filter = false;
            bool clasf_filter = false;
            bool State_filter = false;
            bool mangmentrole = false;
            bool sectionstate = false;
            bool entity_number = false;
            bool rep_all = false;

            if (Replay_Date == null || Replay_Date == false)
            {
                rep_all = true;

            }
            else
            {
                rep_all = false;

            }

            if (entity_reference_number == null)
            {
                entity_number = true;
            }
            else { entity_number = false; }


            if (genral_incoming_num == null )
            {
                mangmentrole = true;
            }
            else
            {
                mangmentrole = false;
            }

            if (mail_state == null)
            {
                State_filter = true;
            }
            else { State_filter = false; }



            if (Classfication == null)
            {
                clasf_filter = true;
            }
            else { clasf_filter = false; }



            if (Measure_filter == null)
            {
                meas_filter = true;
            }
            else { meas_filter = false; }



            if (mail_type== null)
            {
                mailtype = true;
            }
            else
            {
                mailtype = false;
            }



            if (mail_Readed == null)
            {
                mail_accept = true;
                mailReaded = -1;
                mailnot_readed = -1;
            }
            else if (mail_Readed == 2)
            {
                mail_accept = false;
                mailReaded = 2;
                mailnot_readed = 5;
            }
            else if (mail_Readed == 1)
            {
                mail_accept = false;
                mailnot_readed = 1;
                mailReaded = 1;
            }


            if (summary == null)
            { summary = " "; }


            if (mailnum != null)
            {
                mailnum_bool = 0;
            }
            else
            {
                mailnum_bool = 1;
            }



            if (Department_filter == null)
            {

                dep_filter = true;

            }
            else { dep_filter = false; }



            //***********update eman
            if (mail_type == 1)
            { TheSection = null; }

            if (TheSection == null)
            {
                sectionstate = true;
            }
            else
            {
                sectionstate = false;
            }
            //***********end update eman

            List<ReportViewModel> list  = new List<ReportViewModel>(){};
          //  List<ReportViewModel> clear = new List<ReportViewModel>();



            bool fr = false;

            bool t = false;

            if (fromm == null) {

                fr = true;


            }
            if (to == null)
            {

                t = true;


            }





            //*************code stop 14/12/2023
            //  var dep = await _data.Departments.Where(x => x.Id != departmentid).ToListAsync();
            //  var listOfStautes = await _data.MailStatuses.ToListAsync();



            //  foreach (var item in dep)
            //          {


            //      var sc = await (from x in _data.Mails.Where(x => x.Department_Id == departmentid&& ((x.Date_Of_Mail <= to || fr == true) && (x.Date_Of_Mail >= fromm) || fr == true)&&
            //                      (mailnum_bool == 1 || x.Mail_Number == mailnum)&& (x.Mail_Summary.Contains(summary)) && (mailtype==true|| x.Mail_Type == mail_type)
            //                      && (clasf_filter == true || x.clasification == Classfication )&& (x.Genaral_inbox_Number == genral_incoming_num || mangmentrole == true))
            //                      join


            //z in _data.Sends.Where(p => p.to == item.Id&&p.State==true && ((p.flag >= mailReaded && p.flag <= mailnot_readed) || mail_accept == true) &&
            //(p.flag == mail_state || (State_filter == true &&p.flag!=1))) on x.MailID equals z.MailID
            //                      join n in _data.Departments.Where(x => (x.Id == Department_filter || dep_filter == true)) on z.to equals n.Id
            //                      join dx in _data.measures.Where(x => (x.MeasuresId == Measure_filter || (meas_filter == true && x.MeasuresId != 1))) on z.type_of_send equals dx.MeasuresId


            //                      //**************
            //                      join ex_Dep in _data.external_Departments on x.MailID equals ex_Dep.Mail_id into m_ex_dep
            //                      from m_ex_dep1 in m_ex_dep.DefaultIfEmpty()
            //                          //******************

            //                      select new DepartmentViewModelDto
            //                      {

            //                          dateOfSend = z.Send_time.ToString("yyyy-MM-dd"),
            //                          Mail_Number = x.Mail_Number,
            //                          Mail_Summary = x.Mail_Summary,
            //                          TimeOfSend = z.Send_time.ToString("HH:mm:ss"),
            //                          mail_state = (z.flag==1)? "لم ترسل " : (z.flag == 2)? "لم تقرأ" :
            //                          (z.flag == 3) ? "قرأت " : (z.flag == 4) ? "تم الرد":(z.flag == 5)?
            //                          "تم الرد من قبلك": (z.flag ==6) ?" تم السحب":""




            //                      }).ToListAsync();

            //              list.Add(new ReportViewModel
            //              {

            //                  data = sc,
            //                  DepartmentName = item.DepartmentName,
            //                  total = sc.Count()



            //              }) ;


            //          }



            //  foreach (var item in list)
            //  {
            //      if (item.data.Count()!= 0) {

            //          clear.Add(item);
            //      }


            //  }

            //***************************end code stop 14/12/2023

            //*************update 14/12/2023
           // PagenationSendedEmail<Sended_Maill> pag = new PagenationSendedEmail<Sended_Maill>();

            //***********************update
            var ca = (from mail in _data.Mails.Where(x => x.Department_Id == departmentid && x.state == true && x.Mail_Summary.Contains(summary)
                        && ((x.insert_at.Date >= fromm && x.insert_at.Date <= to) || rep_all == false) && ((x.Mail_Type == mail_type) || mailtype == true)
                      //&& ((x.insert_at.Date >= fromm && x.insert_at.Date <= to)) && ((x.Mail_Type == mail_type) || mailtype == true)
                      && (mailnum_bool == 1 || x.Mail_Number == mailnum) && (x.clasification == Classfication || clasf_filter == true)
                      && (x.Genaral_inbox_Number == genral_incoming_num || mangmentrole == true))

                      join ex in _data.Extrenal_Inboxes on mail.MailID equals ex.MailID into mail_ex
                      from mex in mail_ex.DefaultIfEmpty()

                     // join send in _data.Sends on mail.MailID equals send.MailID into msg1

            
                      join send in _data.Sends.Where(x=>x.State== true && x.flag != 1) on mail.MailID equals send.MailID into msg1
                      from ms in msg1.DefaultIfEmpty()

                      join rep in _data.Replies on ms.Id equals rep.send_ToId into rep_send1
                      from rep_send in rep_send1.DefaultIfEmpty()

                      join ex_Dep in _data.external_Departments on mail.MailID equals ex_Dep.Mail_id into m_ex_dep
                      from m_ex_dep1 in m_ex_dep.DefaultIfEmpty()

                          //*******add code 12/5/2024
                      join ex_s in _data.Extrmal_Sections.Where(x => x.state == true) on m_ex_dep1.side_number equals ex_s.id into m_ex_s
                      from m_ex_s1 in m_ex_s.DefaultIfEmpty()
                          //*End 12/5/2024


                          //**************************************
                      join depart in _data.Departments.Where(x=>x.state == true) on ms.to equals depart.Id // into depart_s

                     


                          // from depart_s1 in m_ex_dep.DefaultIfEmpty()
                          //**************************************
                      where (ms.to == Department_filter || dep_filter == true) && (ms.flag == mail_state || State_filter == true) && (ms.type_of_send == Measure_filter || meas_filter == true)
                      //&&(ms.State==true)&&(ms.flag>1)
                      && (mex.entity_reference_number == entity_reference_number || entity_number == true) 
                      && ((m_ex_dep1.state == true && m_ex_dep1.side_number == TheSection) || sectionstate == true)
                      && (((rep_send.Date >= fromm && rep_send.Date <= to) && (rep_send.state == true)) || rep_all == true)
                      // && (((rep_send.Date >= fromm && rep_send.Date <= to) && (rep_send.state == true)) )

                      select new DepartmentViewModelDto
                      {
                          //**add 12/5/2024
                          section_name=m_ex_s1.Section_Name,
                          //*****end 12/5/2024
                          dateOfSend = ms.Send_time.ToString("yyyy-MM-dd"),
                          Mail_Number = mail.Mail_Number,
                          Mail_Summary = mail.Mail_Summary,
                          TimeOfSend = ms.Send_time.ToString("HH:mm:ss"),

                          send_to_name= depart == null ? "" : depart.DepartmentName,
                          send_to = ms == null ? 0 : ms.to,

                          mail_state = (ms.flag == 1) ? "لم ترسل " : (ms.flag == 2) ? "لم تقرأ" :
                                                    (ms.flag == 3) ? "قرأت " : (ms.flag == 4) ? "تم الرد" : (ms.flag == 5) ?
                                                    "تم الرد من قبلك" : (ms.flag == 6) ? " تم السحب" : ""



                      }).Distinct();


            // 
           // var c = await ca.OrderByDescending(v => v.date2).Skip((pagenum - 1) * size).Take(size).ToListAsync();
            //  var c = await ca.OrderByDescending(v => v.date2).ToListAsync();

           // pag.mail = c;

            var kk = await ca.ToListAsync() ;
           // var jj = kk.GroupBy(x => x.send_to);
            var bb = kk.ToLookup(x => x.send_to_name);
           // var nn = from g in bb orderby g.Count() select new { cccc = g.Key, coun = g.Count(), hh = g.ToList() };


           // var clear = (from g in bb orderby g.Count() select new ReportViewModel  { DepartmentName = g.Key.ToString(), total = g.Count(), data = g.ToList() }).ToList();

            var clear = (from g in bb  orderby g.Count() select new ReportViewModel { DepartmentName = g.Key.ToString(), total = g.Count(), data = g.ToList() }).ToList();
            // List<ReportViewModel> clear = new List<ReportViewModel>() {data=nn.ToList() };
            //clear = new ReportViewModel
            //{
            //    data = nn.Select(x=>x.hh).ToList(),
            //    //  DepartmentName = g.Key.ToString(),
            //    total = nn.Count()
            //};


            //*********end update 14/12/2023



            return clear;     
        
        
        
        
        }



        public async Task<Report_View_Model> Get_main_statistics_Report(DateTime from,DateTime to)
        {

            Report_View_Model model = new Report_View_Model();



            model.total_of_mail = await _data.Mails.Where(x => x.state == true && x.Date_Of_Mail >= from && x.Date_Of_Mail <= to&&x.Mail_Type==1).AsNoTracking().CountAsync();
            model.total_of_External_Mail = await _data.Mails.Where(x => x.state == true && x.Date_Of_Mail >= from && x.Date_Of_Mail <= to && x.Mail_Type == 2).AsNoTracking().CountAsync();
            model.total_Extrenal_inbox= await _data.Mails.Where(x => x.state == true && x.Date_Of_Mail >= from && x.Date_Of_Mail <= to && x.Mail_Type == 3).AsNoTracking().CountAsync();



            return model;
        }


        public async Task<List<Report_details_view_model>> Get_Detailes_statistics_Report(DateTime from, DateTime to)
        {

          List<  Report_details_view_model>  list = new List< Report_details_view_model>();

            var total_of_mail = await _data.Mails.Where(x => x.state == true && x.Date_Of_Mail >= from && x.Date_Of_Mail <= to ).AsNoTracking().ToListAsync();
            var department = await _data.Departments.Where(x => x.state == true).AsNoTracking().ToListAsync();
                 
            foreach (var item in department)
            {
                list.Add(new Report_details_view_model
                {


                    department_name = item.DepartmentName,
                    data = new Report_View_Model
                    {

                        total_Extrenal_inbox = total_of_mail.Where(x => x.Department_Id == item.Id && x.Mail_Type == 3).Count(),
                        total_of_mail = total_of_mail.Where(x => x.Department_Id == item.Id && x.Mail_Type == 1).Count(),
                        total_of_External_Mail = total_of_mail.Where(x => x.Department_Id == item.Id && x.Mail_Type == 2).Count(),




                    }


                });

            }



            return list;
        }
        
    }
}
