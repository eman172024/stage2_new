﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Model.ViewModel
{
    public class ReplayPhotoVM
    {

        public int mailId { get; set; }
        public int userId { get; set; }
        public int from { get; set; }
        public int send_ToId { get; set; }

        public Reply reply { get; set; }

      public Uplode file { get; set; }



    }
}
