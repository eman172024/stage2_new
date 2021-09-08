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
    interface IRportInterface
    {

 
        Task<List<MySectionReport>> GetAllDepartmentReports();
        Task<MySectionReport> GetMySectionReport(int id, DateTime fromdate, DateTime todate, string MailType, string SendedOrRecieved);

        Task<UserReports> GetAllUserMassageReport(int id, DateTime fromdate, DateTime todate, string MailType,string SendedOrRecieved);
       
        Task<TotalCounts> GetAllCount();
            

    }
}
