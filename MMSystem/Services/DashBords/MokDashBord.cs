using Microsoft.EntityFrameworkCore;
using MMSystem.Model;
using MMSystem.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Services.DashBords
{
    public class MokDashBord :IDashBord
    {
        private AppDbCon DbCon { get; }

        public MokDashBord(AppDbCon dbCon)
        {
            DbCon = dbCon;
        }

        public async Task<Dashbord> GetDashbord(int ManagementId)
        {
            Dashbord Dashbord = new Dashbord();

            var send = await (from x in DbCon.Mails.Where(x => x.Department_Id == ManagementId)
                           join y in DbCon.Sends.Where(y => y.flag == 1) on x.MailID equals y.MailID

                           select y).ToListAsync();
            int sends = send.Count();

            var Received = await DbCon.Sends.Where(x => x.to == ManagementId && x.flag == 1).ToListAsync();
            int Receive = Received.Count();

            var NotSend = await (from x in DbCon.Mails.Where(x => x.Department_Id == ManagementId)
                           join y in DbCon.Sends.Where(y => y.flag == 0) on x.MailID equals y.MailID

                           select y).ToListAsync();
            int NotSends = NotSend.Count();
            
            Dashbord.TotaleReceived = Receive;
            Dashbord.TotaleSender = sends;
            Dashbord.TotaleExpord = NotSends;

            return Dashbord;
        }
    }
}
