using MMSystem.Model.Dto;
using MMSystem.Model.ViewModel;
using MMSystem.Model.ViewModel.Reports;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MMSystem.Services.Reports
{
   public interface IRportInterface
    {
        Task<List<SectionReport>> GetAllDepartmentReports( DateTime fromdate, DateTime todate, int ? MailType , string SendedOrRecieved);
        Task<SectionReportWithTotal> GetMySectionReport(int  id, DateTime  fromdate, DateTime  todate, int ? MailType , string  SendedOrRecieved);
        Task<UserReports> GetAllUserMassageReport(int id, DateTime fromdate, DateTime todate, int ? MailType, string SendedOrRecieved);      
        Task<TotalCounts> GetAllSystemCount();
        Task<UsersConclsionReport> GetAllUserCount(int departmentid, DateTime fromdate, DateTime todate, int ? MailType, string RecievedOrSended);

        Task<List<ReportViewModel>> ReportForDep(int departmenti_d, DateTime? from, DateTime? to, int? Department_filter, int? mailnum, int? mailnum_bool, string? summary, int? mail_Readed,
            int? mailReaded, int? mailnot_readed, int? mail_type, int? Measure_filter, int? Classfication
 , int? mail_state, int? genral_incoming_num,int? thesection, int? entity_reference_number, bool? Replay_Date);

        Task<Report_View_Model> Get_main_statistics_Report(DateTime from, DateTime to);
        Task<List<Report_details_view_model>> Get_Detailes_statistics_Report(DateTime from, DateTime to);
    }
}
