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

        Task<bool> SaveResendMail(ResendViewModel t);

    }
}