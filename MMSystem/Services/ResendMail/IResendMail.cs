﻿using MMSystem.Model;
using MMSystem.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Services.ResendMail
{
    public interface  IResendMail
    {
        Task<bool> SendResendMail(int mail_id,int user_id);
        Task<bool> deleteSectionsSender(int mail_id, int departmentId, int userid);

        Task<bool> Add(Send_to t);
        Task<bool> SaveResendMail(ResendViewModel t);
        Task<bool> UpdateResendMail(ResendViewModel t);

    }
}
