using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Model.ViewModel.ArchivesReport
{
    public class ArchivesViewModel
    {
        //الحالة
        public int Flag { get; set; }

        public int id { get; set; }
        //رقم الصادر
        public int Mail_Number { get; set; }
        //تاريخ الصادر
        public string Date_Of_Mail { get; set; }
        //الادارة المرسل اليها 
        public int To { get; set; }
        //الجهة الموجه اليها 
        public string Section_Name { get; set; }
        //القطاع التابع له
        //**********************هل المقصود الجهات خاصة /عامة / فرع رقابة **************************
        public int Perent { get; set; }
        //تاريخ استلام الرسالة
        public string DateTime_of_read { get; set; }
        //وقت استلام الرسالة
        public string Time_of_read { get; set; }
    
        public string delivery { get; set; }

    }
}
