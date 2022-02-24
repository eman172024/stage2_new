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
   public interface IRportInterface
    {

        Task<List<SectionReport>> GetAllDepartmentReports( DateTime? fromdate, DateTime? todate, int ? MailType , string SendedOrRecieved);
        Task<List<SectionReport>> GetMySectionReport(int  id, DateTime  fromdate, DateTime  todate, int ? MailType , string ? SendedOrRecieved);
        Task<UserReports> GetAllUserMassageReport(int id, DateTime? fromdate, DateTime? todate, int ? MailType, string SendedOrRecieved);      
        Task<TotalCounts> GetAllSystemCount();
        Task<UsersConclsionReport> GetAllUserCount(int departmentid, DateTime? fromdate, DateTime? todate, int ? MailType, string RecievedOrSended);

    }
}
