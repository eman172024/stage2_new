using AutoMapper;
using MMSystem.Model;
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

        public MockReports(AppDbCon data, IMapper mapper)
        {
            _data = data;

            _mapper = mapper;

        }
        private AppDbCon _data { get; }
        private IMapper _mapper { get; }
        public async Task<TotalCounts> GetAllSystemCount()
        {

            TotalCounts totalCounts = new TotalCounts();

            totalCounts.TotalOfMassage = _data.Mails.Where(x => x.state == true).Count();
            
            totalCounts.TotalOfReplay = (from hus in _data.Sends.Where(x => x.flag != 0)
                                        join
                                        hu in _data.Replies on hus.Id equals hu.send_ToId
                                        select  hu.ReplyId  ).Count();

            totalCounts.TotalOfReplay = (from hus in _data.Sends.Where(x => x.flag != 0)
                                         join
                                         hu in _data.Replies  on hus.Id equals hu.send_ToId
                                         group hu by hu.send_ToId).Count();

            totalCounts.TotalOfNotReplay = decimal.ToInt32(totalCounts.TotalOfMassage - totalCounts.TotalOfReplay);

            totalCounts.Average = totalCounts.TotalOfReplay / totalCounts.TotalOfMassage * 100;

            return totalCounts;
        }

        public async Task<List<SectionReport>> GetAllDepartmentReports(DateTime? fromdate, DateTime? todate, int ? MailType, string SendedOrRecieved = "recieved")
        {
            try
            {
                List<Department> departments = _data.Departments.Where(x => x.state == true).ToList();

                SectionReport sectionsreport = new SectionReport();
              
                List<SectionReport> List1 = new List<SectionReport>();

                if (SendedOrRecieved == "recieved")
                {
                    foreach (var item in departments)
                    {
                        sectionsreport.DepartmentName = item.DepartmentName;

                        sectionsreport.TotalOfReceived.TotalOfMassage =(from hus in _data.Mails.Where(x => x.state == true && x.Mail_Type == MailType)
                                                                        join hu  in _data.Sends.Where(x => x.to == item.Id && x.Send_time >= fromdate && x.Send_time <= todate)
                                                                        on hus.MailID equals hu.MailID
                                                                        select hu.MailID).Count();

                        int massageReplaied = (from hu in _data.Sends.Where(x => x.to == item.Id && x.Send_time >= fromdate && x.Send_time <= todate)
                                               join
                                               g in _data.Replies on hu.Id equals g.send_ToId
                                               select g.ReplyId
                                               ).ToList().Count();

                        sectionsreport.TotalOfReceived.TotalOfReplay = massageReplaied;

                        sectionsreport.TotalOfReceived.TotalOfNotReplay = decimal.ToInt32(sectionsreport.TotalOfReceived.TotalOfMassage - sectionsreport.TotalOfReceived.TotalOfReplay);

                        sectionsreport.TotalOfReceived.Average = (sectionsreport.TotalOfReceived.TotalOfReplay / sectionsreport.TotalOfReceived.TotalOfMassage) * 100;

                        List1.Add(sectionsreport);
                    }
                }
                else if (SendedOrRecieved == "sended")
                {
                    foreach (var item in departments)
                    {
                        sectionsreport.DepartmentName = item.DepartmentName;

                        sectionsreport.TotalOfReceived.TotalOfMassage = _data.Mails.Where(x => x.Department_Id == item.Id && x.state == true || x.Mail_Type == MailType).Count();

                        int massageReplaied = (from hu in _data.Sends.Where(x => x.to == item.Id)
                                               join
                                               g in _data.Replies on hu.Id equals g.send_ToId
                                               select g.ReplyId
                                               ).ToList().Count();

                        sectionsreport.TotalOfReceived.TotalOfReplay = massageReplaied;

                        sectionsreport.TotalOfReceived.TotalOfNotReplay = decimal.ToInt32(sectionsreport.TotalOfReceived.TotalOfMassage - sectionsreport.TotalOfReceived.TotalOfReplay);

                        sectionsreport.TotalOfReceived.Average = (sectionsreport.TotalOfReceived.TotalOfReplay / sectionsreport.TotalOfReceived.TotalOfMassage) * 100;

                        List1.Add(sectionsreport);
                    }


                }

                    return List1;

            }
            catch
            {

                throw;
            }

        }

        public async Task<List<SectionReport>> GetMySectionReport(int id, DateTime ? fromdate, DateTime ? todate, int? MailType, string  SendedOrRecieved = "sended")
        {
            try
            {
                    List<Department> departments = _data.Departments.Where(x => x.state == true && x.Id != id).ToList();

                    SectionReport mysectionreport = new SectionReport();

                    List<SectionReport> List1 = new List<SectionReport>();

                if (SendedOrRecieved == "sended")
                {
                    foreach (var item in departments)
                    {
                        mysectionreport.DepartmentName = item.DepartmentName;

                        mysectionreport.TotalOfReceived.TotalOfMassage = (from hus in _data.Mails.Where(x => x.Department_Id == id && x.state == true || x.Mail_Type == MailType)
                                                                          join
                                                                          g in _data.Sends.Where(x => x.flag != 0 && x.to == item.Id && (x.Send_time >= fromdate && x.Send_time <= todate)) 
                                                                          on hus.MailID equals g.MailID
                                                                          select g.MailID).ToList().Count();

                        int massageReplaied = (from hus in _data.Mails.Where(x => x.Department_Id == id && x.state == true)
                                               join
                                               hu in _data.Sends.Where(x => x.flag != 0 && x.to == item.Id) on hus.MailID equals hu.MailID
                                               join
                                               g in _data.Replies on hu.Id equals g.send_ToId
                                               select g.ReplyId

                                               ).ToList().Count();

                        mysectionreport.TotalOfReceived.TotalOfReplay = massageReplaied;


                        mysectionreport.TotalOfReceived.TotalOfNotReplay = decimal.ToInt32(mysectionreport.TotalOfReceived.TotalOfMassage - mysectionreport.TotalOfReceived.TotalOfReplay);

                        mysectionreport.TotalOfReceived.Average = (mysectionreport.TotalOfReceived.TotalOfReplay / mysectionreport.TotalOfReceived.TotalOfMassage) * 100;

                        List1.Add(mysectionreport);
                    }
        
                }
                else if(SendedOrRecieved == "recieved") {

                 
                    foreach (var item in departments)
                    {
                        mysectionreport.DepartmentName = item.DepartmentName;

                        mysectionreport.TotalOfReceived.TotalOfMassage = (from hus in _data.Mails.Where(x =>( x.Department_Id == item.Id && x.state == true )|| x.Mail_Type == MailType)
                                                                          join
                                                                          g in _data.Sends.Where(x => x.flag != 0 && x.to == id && ((x.Send_time >= fromdate && x.Send_time <= todate)))
                                                                          on hus.MailID equals g.MailID
                                                                          select g.MailID).ToList().Count();

                        int massageReplaied = (from hus in _data.Mails.Where(x => (x.Department_Id == item.Id && x.state == true )|| x.Mail_Type == MailType)
                                               join
                                               hu in _data.Sends.Where(x => x.flag != 0 && x.to == id && ((x.Send_time >= fromdate && x.Send_time <= todate))) on hus.MailID equals hu.MailID
                                               join
                                               g in _data.Replies on hu.Id equals g.send_ToId
                                               select g.ReplyId

                                               ).ToList().Count();

                        mysectionreport.TotalOfReceived.TotalOfReplay = massageReplaied;


                        mysectionreport.TotalOfReceived.TotalOfNotReplay = decimal.ToInt32(mysectionreport.TotalOfReceived.TotalOfMassage - mysectionreport.TotalOfReceived.TotalOfReplay);

                        mysectionreport.TotalOfReceived.Average = (mysectionreport.TotalOfReceived.TotalOfReplay / mysectionreport.TotalOfReceived.TotalOfMassage) * 100;

                        List1.Add(mysectionreport);
                    }
                }
                return List1;
            }
            catch
            {

                throw;
            }
        }


        public async Task<UserReports> GetAllUserMassageReport(int userid, DateTime? fromdate, DateTime? todate, int ? MailType, string SendedOrRecieved)
        {
            try
            {
                Administrator user = _data.Administrator.FirstOrDefault(x => x.state == true && x.UserId == userid);

                UserReports userreport = new UserReports();

                if (!fromdate.HasValue)
                {
                    fromdate = DateTime.Parse("2019-01-01");
                }

                if (!todate.HasValue)
                {
                    todate = DateTime.Now;
                }

                if (SendedOrRecieved == "sended")
                {
                    if (MailType == null)
                    {


                        userreport.UserName = user.UserName;
                   
                 
                        userreport.information1 = (from hus in _data.Mails.Where(x => x.state == true && x.userId == user.UserId)
                                                   join
                                                   g in _data.Sends.Where(x => x.Send_time >= fromdate && x.Send_time <= todate)
                                                   on hus.MailID equals g.MailID
                                                   select new UserMailInfo
                                                   {
                                                       Mail_Summary = hus.Mail_Summary,
                                                       Send_To = g.to,
                                                       Date_Of_Mail = hus.Date_Of_Mail,
                                                       Mail_Number = hus.Mail_Number
                                                   }).ToList();

               
                    }
                    else {
                        userreport.information1 = (from hus in _data.Mails.Where(x => x.state == true && x.userId == user.UserId && x.Mail_Type == MailType)
                                                   join
                                                   g in _data.Sends.Where(x => x.Send_time >= fromdate && x.Send_time <= todate)
                                                   on hus.MailID equals g.MailID
                                                   select new UserMailInfo
                                                   {
                                                       Mail_Summary = hus.Mail_Summary,
                                                       Send_To = g.to,
                                                       Date_Of_Mail = hus.Date_Of_Mail,
                                                       Mail_Number = hus.Mail_Number
                                                   }).ToList();

                        userreport.UserName = user.UserName;


                    }

                }
                else if (SendedOrRecieved == "recieved")
                {
                    userreport.UserName = user.UserName;

                    if (MailType == null)
                    {

                        userreport.information1 = (from hus in _data.Mails.Where(x => x.state == true && x.userId != user.UserId)
                                                   join
                                                   hu in _data.Sends.Where(x => x.Send_time >= fromdate && x.Send_time <= todate)
                                                   on hus.MailID equals hu.MailID
                                                   join
                                                   g in _data.Replies.Where(x => x.UserId == user.UserId) on hu.Id equals g.send_ToId
                                                    select  new  UserMailInfo
                                                   {
                                                       Mail_Summary = hus.Mail_Summary,
                                                       Send_To = hu.to,
                                                       Date_Of_Mail = hus.Date_Of_Mail,
                                                       Mail_Number = hus.Mail_Number
                                                   }).ToList();
                    }
                    else {

                        userreport.information1 = (from hus in _data.Mails.Where(x => x.state == true && x.userId != user.UserId && x.Mail_Type == MailType)
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
                                                   }).ToList();



                    }
                    //int massageReplaied = (from hus in _data.Mails.Where(x => x.state == true && x.userId != user.UserId && x.Mail_Type == MailType)
                    //                       join
                    //                       hu in _data.Sends.Where(x => x.Send_time >= fromdate && x.Send_time <= todate)
                    //                       on hus.MailID equals hu.MailID
                    //                       join
                    //                       g in _data.Replies.Where(x => x.UserId == user.UserId) on hu.Id equals g.send_ToId
                    //                       select g.ReplyId
                    //                          ).ToList().Count();


                }
                return userreport;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<UsersConclsionReport> GetAllUserCount(int departmentid, DateTime? fromdate, DateTime? todate, int ? MailType, string RecievedOrSended)
        {
            try
            {

              List<Administrator> user = _data.Administrator.Where(x => x.state == true && x.DepartmentId == departmentid).ToList();

                UsersConclsionReport userreport = new UsersConclsionReport();

                if(!fromdate.HasValue){
                    fromdate =DateTime.Parse( "2020-01-01");
                }

                if (!todate.HasValue)
                {
                    todate = DateTime.Now;
                }
                int information;
                int massageReplaied;

                if(RecievedOrSended == "sended")
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

                            massageReplaied = (from hus in _data.Mails.Where(x => x.state == true && x.userId == item1.UserId)
                                               join
                                               hu in _data.Sends.Where(x => x.Send_time >= fromdate && x.Send_time <= todate)
                                               on hus.MailID equals hu.MailID
                                               join
                                               g in _data.Replies.Where(x => x.UserId != item1.UserId) on hu.Id equals g.send_ToId
                                               group g by g.send_ToId
                                               ).Count();

                            //userreport.Last_date = (from hus in _data.Mails.Where(x => x.state == true && x.userId == item1.UserId )
                            //                        join
                            //                        g in _data.Sends.OrderByDescending(x => x.time_of_read).Where(x => x.Send_time >= fromdate && x.Send_time <= todate)
                            //                        on hus.MailID equals g.MailID
                            //                        select g.time_of_read
                            //                  ).ToList().First();
                        }
                        else
                        {
                            information = (from hus in _data.Mails.Where(x => x.state == true && x.userId == item1.UserId && x.Mail_Type == MailType)
                                           join
                                           g in _data.Sends.Where(x => x.Send_time >= fromdate && x.Send_time <= todate)
                                           on hus.MailID equals g.MailID
                                           select hus.Mail_Number
                                                      ).ToList().Count();

                            massageReplaied = (from hus in _data.Mails.Where(x => x.state == true && x.userId == item1.UserId && x.Mail_Type == MailType)
                                               join
                                               hu in _data.Sends.Where(x => x.Send_time >= fromdate && x.Send_time <= todate )
                                               on hus.MailID equals hu.MailID
                                               join
                                               g in _data.Replies.Where(x => x.UserId != item1.UserId) on hu.Id equals g.send_ToId
                                               group g by g.send_ToId
                                                       ).Count();

                            //userreport.Last_date = (from hus in _data.Mails.Where(x => x.state == true && x.userId == item1.UserId && x.Mail_Type == MailType)
                            //                        join
                            //                        g in _data.Sends.OrderByDescending(x => x.time_of_read).Where(x => x.Send_time >= fromdate && x.Send_time <= todate)
                            //                        on hus.MailID equals g.MailID
                            //                        select g.time_of_read
                            //                  ).ToList().First();
                        }
                        userreport.Total_Count.TotalOfMassage = information;
                        userreport.Total_Count.TotalOfReplay = massageReplaied;
                        userreport.Total_Count.TotalOfNotReplay = decimal.ToInt32(userreport.Total_Count.TotalOfMassage - userreport.Total_Count.TotalOfReplay);
                        if (userreport.Total_Count.TotalOfMassage != 0)
                        {
                            userreport.Total_Count.Average = (userreport.Total_Count.TotalOfReplay / userreport.Total_Count.TotalOfMassage) * 100;
                        }
                        else
                        {
                            userreport.Total_Count.Average = 0;
                        }


                         
                      
                    }


                }
                else if (RecievedOrSended == "recieved")
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

                            massageReplaied = (from hus in _data.Mails.Where(x => x.state == true && x.userId != item.UserId)
                                               join
                                               hu in _data.Sends.Where(x => x.Send_time >= fromdate && x.Send_time <= todate && x.to == item.DepartmentId)
                                               on hus.MailID equals hu.MailID
                                               join
                                               g in _data.Replies.Where(x => x.UserId == item.UserId) on hu.Id equals g.send_ToId
                                               group g by g.send_ToId).Count();
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

                            massageReplaied = (from hus in _data.Mails.Where(x => x.state == true && x.userId != item.UserId && x.Mail_Type == MailType)
                                               join
                                               hu in _data.Sends.Where(x => x.Send_time >= fromdate && x.Send_time <= todate)
                                               on hus.MailID equals hu.MailID
                                               join
                                               g in _data.Replies.Where(x => x.UserId == item.UserId) on hu.Id equals g.send_ToId
                                               group g by g.send_ToId
                                                     ).Count();
                        }



                        userreport.Total_Count.TotalOfMassage = information;
                        userreport.Total_Count.TotalOfReplay = massageReplaied;
                        userreport.Total_Count.TotalOfNotReplay = decimal.ToInt32(userreport.Total_Count.TotalOfMassage - userreport.Total_Count.TotalOfReplay);

                        if (userreport.Total_Count.TotalOfMassage != 0)
                        {
                            userreport.Total_Count.Average = (userreport.Total_Count.TotalOfReplay / userreport.Total_Count.TotalOfMassage) * 100;
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
    }
}
