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

            //var send = await (from x in DbCon.Mails.Where(x => x.Department_Id == ManagementId)
            //               join y in DbCon.Sends.Where(y => y.flag >1 && y.isMulti == true) on x.MailID equals y.MailID

            //               select x).ToListAsync();
            //int sends = send.Count();

            //var Received = await (from x in DbCon.Mails
            //                      join y in DbCon.Sends.Where(x => x.to == ManagementId && x.flag >= 2 ) on x.MailID equals y.MailID
            //                      select y).ToListAsync();
            //int Receive = Received.Count();

            //var NotSend = await (from x in DbCon.Mails.Where(x => x.Department_Id == ManagementId)
            //               join y in DbCon.Sends.Where(y => y.flag ==1 && y.isMulti == true) on x.MailID equals y.MailID

            //               select x).ToListAsync();
            //int NotSends = NotSend.Count();













            var internil =await (from x in DbCon.Mails.Where(x=> x.Department_Id == ManagementId && x.Mail_Type==1 && x.state == true )
                  join y in DbCon.Sends.Where(y => y.flag >= 1 && y.isMulti == true  ) on x.MailID equals y.MailID
                                 select x).ToListAsync();
            int inern = internil.Count();

            var not_sended = await (from x in DbCon.Mails.Where(x => x.Department_Id == ManagementId && x.Mail_Type == 1)
                                  join y in DbCon.Sends.Where(y => y.flag ==1 && y.isMulti == true) on x.MailID equals y.MailID
                                  select x).ToListAsync();
            int notsende = not_sended.Count();


            var is_sended = await (from x in DbCon.Mails.Where(x => x.Department_Id == ManagementId && x.Mail_Type == 1)
                                    join y in DbCon.Sends.Where(y => y.flag > 1 && y.isMulti == true) on x.MailID equals y.MailID
                                    select x).ToListAsync();
            int issended = is_sended.Count();

            var not_response_tome = await (from x in DbCon.Mails.Where(x => x.Department_Id == ManagementId && x.Mail_Type == 1)
                                    join y in DbCon.Sends.Where(y => y.flag < 4 && y.flag!= 1 && y.isMulti == true) on x.MailID equals y.MailID
                                    select x).ToListAsync();
            int notResme = not_response_tome.Count();

            var incoming = await (from x in DbCon.Mails.Where(x =>  x.Mail_Type == 1 )
                                           join y in DbCon.Sends.Where(y => y.flag >=2  && y.to== ManagementId) on x.MailID equals y.MailID
                                           select x).ToListAsync();
            int incom = incoming.Count();


            var idint_responde = await (from x in DbCon.Mails.Where(x =>  x.Mail_Type == 1)
                                  join y in DbCon.Sends.Where(y => y.flag < 4 && y.flag != 1  && y.to == ManagementId) on x.MailID equals y.MailID
                                  select x).ToListAsync();
            int not_res = idint_responde.Count();



            var extirnel = await (from x in DbCon.Mails.Where(x => x.Department_Id == ManagementId && x.Mail_Type == 2 && x.state == true)
                                  join y in DbCon.Sends.Where(y => y.flag >= 1 && y.isMulti == true) on x.MailID equals y.MailID
                                  select x).ToListAsync();
            int ex = extirnel.Count();

            var not_sended_externl = await (from x in DbCon.Mails.Where(x => x.Department_Id == ManagementId && x.Mail_Type == 2)
                                    join y in DbCon.Sends.Where(y => y.flag == 1 && y.isMulti == true) on x.MailID equals y.MailID
                                    select x).ToListAsync();
            int notsendeex = not_sended_externl.Count();

            var is_sended_externl = await (from x in DbCon.Mails.Where(x => x.Department_Id == ManagementId && x.Mail_Type == 2)
                                            join y in DbCon.Sends.Where(y => y.flag > 1 && y.isMulti == true) on x.MailID equals y.MailID
                                            select x).ToListAsync();
            int issendeex = is_sended_externl.Count();

            var not_response_tome_externil = await (from x in DbCon.Mails.Where(x => x.Department_Id == ManagementId && x.Mail_Type == 2)
                                           join y in DbCon.Sends.Where(y => y.flag < 4 && y.flag != 1 && y.isMulti == true) on x.MailID equals y.MailID
                                           select x).ToListAsync();
            int notResmeex = not_response_tome_externil.Count();

            var incoming_externil = await (from x in DbCon.Mails.Where(x => x.Mail_Type == 2)
                                  join y in DbCon.Sends.Where(y => y.flag >=2  && y.to == ManagementId) on x.MailID equals y.MailID
                                  select x).ToListAsync();
            int incomex = incoming_externil.Count();


            var idint_responde_extrinl = await (from x in DbCon.Mails.Where(x =>  x.Mail_Type == 2)
                                        join y in DbCon.Sends.Where(y => y.flag < 4  && y.to == ManagementId) on x.MailID equals y.MailID
                                        select x).ToListAsync();
            int not_resex = idint_responde_extrinl.Count();



            var extirnelIn = await (from x in DbCon.Mails.Where(x => x.Department_Id == ManagementId && x.Mail_Type == 3 && x.state == true)
                                  join y in DbCon.Sends.Where(y => y.flag >= 1 && y.isMulti == true) on x.MailID equals y.MailID
                                  select x).ToListAsync();
            int exIn = extirnelIn.Count();

            var not_sended_externlIn = await (from x in DbCon.Mails.Where(x => x.Department_Id == ManagementId && x.Mail_Type == 3)
                                            join y in DbCon.Sends.Where(y => y.flag == 1  && y.isMulti == true) on x.MailID equals y.MailID
                                            select x).ToListAsync();
            int notsendeexIn = not_sended_externlIn.Count();


            var is_sended_externlIn = await (from x in DbCon.Mails.Where(x => x.Department_Id == ManagementId && x.Mail_Type == 3)
                                              join y in DbCon.Sends.Where(y => y.flag > 1 && y.isMulti == true) on x.MailID equals y.MailID
                                              select x).ToListAsync();
            int issendeexIn = is_sended_externlIn.Count();

            var not_response_tome_externilIn = await (from x in DbCon.Mails.Where(x => x.Department_Id == ManagementId && x.Mail_Type == 3)
                                                    join y in DbCon.Sends.Where(y => y.flag < 4 && y.isMulti == true) on x.MailID equals y.MailID
                                                    select x).ToListAsync();
            int notResmeexIn = not_response_tome_externilIn.Count();

            var incoming_externilIn = await (from x in DbCon.Mails.Where(x => x.Mail_Type == 3)
                                           join y in DbCon.Sends.Where(y => y.flag >= 2 &&  y.to == ManagementId) on x.MailID equals y.MailID
                                           select x).ToListAsync();
            int incomexIn = incoming_externilIn.Count();


            var idint_responde_extrinlIn = await (from x in DbCon.Mails.Where(x => x.Mail_Type == 3)
                                                join y in DbCon.Sends.Where(y => y.flag < 4  && y.to == ManagementId) on x.MailID equals y.MailID
                                                select x).ToListAsync();
            int not_resexIn = idint_responde_extrinlIn.Count();


            //Dashbord.TotaleReceived = Receive;
            //Dashbord.TotaleSender = sends;
            //Dashbord.TotaleExpord = NotSends;

            Dashbord.Totale_Internal = inern ;
            Dashbord.not_sended = notsende;
            Dashbord.is_sended = issended;
            Dashbord.Not_response_to_me = notResme;
            Dashbord.incoming = incom;
            Dashbord.Not_response_from_you = not_res;


            Dashbord.extirnel = ex ;
            Dashbord.not_sended_externl = notsendeex;
            Dashbord.is_sended_externl = issendeex;
            Dashbord.Not_response_to_me_external = notResmeex;
            Dashbord.incoming_externil = incomex;
            Dashbord.Not_response_from_you_externil = not_resex;

            Dashbord.extirnelInbox = exIn ;
            Dashbord.not_sended_externlInbox = notsendeexIn;
            Dashbord.is_sended_externlInbox = issendeexIn;
            Dashbord.Not_response_to_me_externlInbox = notResmeexIn;
            Dashbord.incoming_externilInbox = incomexIn;
            Dashbord.Not_response_from_you_extrinlInbox = not_resexIn;
            return Dashbord;
        }
    }
}
