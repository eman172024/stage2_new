﻿using Microsoft.EntityFrameworkCore;
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
 , int? mail_state, int? genral_incoming_num)
        {

            bool dep_filter = false;
            bool mail_accept = false;
            bool mailtype = true;
            bool meas_filter = false;
            bool clasf_filter = false;
            bool State_filter = false;
            bool mangmentrole = false;


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


            List<ReportViewModel> list  = new List<ReportViewModel>(){};
            List<ReportViewModel> clear = new List<ReportViewModel>();



            bool fr = false;

            bool t = false;

            if (fromm == null) {

                fr = true;


            }
            if (to == null)
            {

                t = true;


            }


          



            var dep = await _data.Departments.Where(x => x.Id != departmentid).ToListAsync();
            var listOfStautes = await _data.MailStatuses.ToListAsync();



            foreach (var item in dep)
                    {


                var sc = await (from x in _data.Mails.Where(x => x.Department_Id == departmentid&& ((x.Date_Of_Mail <= to || fr == true) && (x.Date_Of_Mail >= fromm) || fr == true)&&
                                (mailnum_bool == 1 || x.Mail_Number == mailnum)&& (x.Mail_Summary.Contains(summary)) && (mailtype==true|| x.Mail_Type == mail_type)
                                && (clasf_filter == true || x.clasification == Classfication )&& (x.Genaral_inbox_Number == genral_incoming_num || mangmentrole == true))
                                join


          z in _data.Sends.Where(p => p.to == item.Id&&p.State==true && ((p.flag >= mailReaded && p.flag <= mailnot_readed) || mail_accept == true) &&
          (p.flag == mail_state || (State_filter == true &&p.flag!=1))) on x.MailID equals z.MailID
                                join n in _data.Departments.Where(x => (x.Id == Department_filter || dep_filter == true)) on z.to equals n.Id
                                join dx in _data.measures.Where(x => (x.MeasuresId == Measure_filter || (meas_filter == true && x.MeasuresId != 1))) on z.type_of_send equals dx.MeasuresId
                                select new DepartmentViewModelDto
                                {

                                    dateOfSend = z.Send_time.ToString("yyyy-MM-dd"),
                                    Mail_Number = x.Mail_Number,
                                    Mail_Summary = x.Mail_Summary,
                                    TimeOfSend = z.Send_time.ToString("HH:mm:ss"),
                                    mail_state = (z.flag==1)? "لم ترسل " : (z.flag == 2)? "لم تقرأ" :
                                    (z.flag == 3) ? "قرأت " : (z.flag == 4) ? "تم الرد":(z.flag == 5)?
                                    "تم الرد من قبلك": (z.flag ==6) ?" تم السحب":""




                                }).ToListAsync();

                        list.Add(new ReportViewModel
                        {

                            data = sc,
                            DepartmentName = item.DepartmentName,
                            total = sc.Count()



                        }) ;


                    }



            foreach (var item in list)
            {
                if (item.data.Count()!= 0) {

                    clear.Add(item);
                }


            }




                

            return clear;     
        
        
        
        
        }

      
    }
}
