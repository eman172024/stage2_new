﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Model.ViewModel.Reports
{
    public class UserMailInfo
    {
        public int Mail_Number { get; set; }
        public string Mail_Summary { get; set; }
        public int Send_To { get; set; }
        public DateTime Date_Of_Mail { get; set; }
    }
}
