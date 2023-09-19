using MMSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Services.ResendMail
{
    public class MockResendMail : IResendMail
    {
        public MockResendMail(AppDbCon data)
        {
            _data = data;

        }
        private AppDbCon _data { get; }



    }
}
