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
        public async Task<TotalCounts> GetAllCount()
        {
            
           
            TotalCounts totalCounts = new TotalCounts();

            totalCounts.TotalOfMassage   =  _data.Mails.Where(x => x.state == true).Count();

            totalCounts.TotalOfNotReplay = _data.Replies.Where(x=> x.state == false).Count();
            
            totalCounts.TotalOfReplay    =  _data.Sends.Where(x=> x.flag == 1).Count();

            return totalCounts;
        }

        public async Task<List<MySectionReport>> GetAllDepartmentReports()
        {
            try
            {
                List<Department> departments = _data.Departments.Where(x => x.state == true).ToList();

                MySectionReport mysectionreport = new MySectionReport();
              
                TotalCounts totalCounts = new TotalCounts();
               
                List<Send_to> sends = new List<Send_to>();
              
                List<MySectionReport> List1 = new List<MySectionReport>();

                foreach (var item in departments)
                {
                    mysectionreport.DepartmentName = item.DepartmentName;

                    mysectionreport.TotalOfReceived.TotalOfMassage = _data.Sends.Where(x => x.to == item.Id).Count();

                    int massageReplaied = (from hu in _data.Sends.Where(x => x.to == item.Id)
                                           join
                                           g in _data.Replies on hu.Id equals g.send_ToId
                                           select g.ReplyId
                                           ).ToList().Count();
                    mysectionreport.TotalOfReceived.TotalOfReplay = massageReplaied;


                    mysectionreport.TotalOfReceived.TotalOfNotReplay = mysectionreport.TotalOfReceived.TotalOfMassage - mysectionreport.TotalOfReceived.TotalOfReplay;

                    mysectionreport.TotalOfReceived.Average = (mysectionreport.TotalOfReceived.TotalOfReplay / mysectionreport.TotalOfReceived.TotalOfMassage) * 100;

                    List1.Add(mysectionreport);
                }



                return List1;

            }
            catch
            {

                throw;
            }

        }

        public async Task<UserReports> GetAllUserMassageReport(int id, DateTime fromdate, DateTime todate, string MailType, string SendedOrRecieved)
        {
            throw new NotImplementedException();
        }

        public async Task<MySectionReport> GetMySectionReport(int id, DateTime fromdate, DateTime todate, string MailType, string SendedOrRecieved)
        {
            throw new NotImplementedException();
        }
    }
}
