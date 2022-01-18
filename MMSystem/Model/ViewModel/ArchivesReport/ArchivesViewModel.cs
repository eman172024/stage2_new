using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Model.ViewModel.ArchivesReport
{
    public class ArchivesViewModel
    {
        //الادارة المرسلة رقم فقط
        public string Department { get; set; }
        //الحالة
        public int Flag { get; set; }
        public string Flagn { get; set; }

        public string summary { get; set; }
       

        public int idDepartment { get; set; }
        public int id { get; set; }
        //رقم الصادر
        public int Mail_Number { get; set; }
        //تاريخ الصادر
        public string Date_Of_Mail { get; set; }
        //الادارة المرسل اليها 
        public int side_id { get; set; }
        //الجهة الموجه اليها 
        public string side_Name { get; set; }
        //القطاع التابع له
        //**********************هل المقصود الجهات خاصة /عامة / فرع رقابة **************************
        public int Perentid { get; set; }
        public string PerentName { get; set; }
        //تاريخ استلام الرسالة
        public string DateTime_of_read { get; set; }
        //وقت استلام الرسالة
        public string Time_of_read { get; set; }
    
        public string delivery { get; set; }
        public string note { get; set; }
        public int Number_Of_Copies { get; set; }
        public bool Attachments { get; set; }

    }
}
