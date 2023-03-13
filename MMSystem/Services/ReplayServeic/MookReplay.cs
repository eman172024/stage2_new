using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MMSystem.Model;
using MMSystem.Model.Dto;
using MMSystem.Model.ViewModel;
using MMSystem.Model.ViewModel.MailVModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Services.ReplayServeic
{
    public class MookReplay : IReplay

    {
        private IWebHostEnvironment iwebHostEnvironment;

        public int flag;
        public MookReplay(AppDbCon data, IMapper mapper, IWebHostEnvironment environment)
        {
            _data = data;
            _mapper = mapper;
            iwebHostEnvironment = environment;
        }
        public string sub { get; set; }

        private readonly AppDbCon _data;
        private readonly IMapper _mapper;

        public async Task<MVM> GetAllReplay(int depid, int mailId)
        {
            //  try
            //   {

            //    Send_to send_ = await _data.Sends.FirstOrDefaultAsync(x => x.MailID == mailId &&x.to==depid);
            //    MVM mVM = new MVM();
            //    mVM.list = await _data.Replies.OrderBy(x=>x.ReplyId).Where(x=>x.send_ToId==send_.Id).ToListAsync();
            //    List<ReplayDto> replays = _mapper.Map<List<Reply>, List<ReplayDto>>(list);
            //    return replays;
            //}
            //catch (Exception)
            //{

            //    throw;
            //}
            try
            {

                MVM model = new MVM();


                Send_to c = await _data.Sends.Where(x => x.to == depid && x.MailID == mailId && x.State == true ).FirstOrDefaultAsync();

                model.list = await (from x in _data.Replies.Where(x => x.send_ToId == c.Id && x.state.Equals(true) && x.IsSend.Equals(true))
                                        //       join y in _dbCon.Reply_Resources on x.ReplyId equals y.ReplyId
                                    select new RViewModel
                                    {
                                        reply = _mapper.Map<Reply, ReplayDto>(x),
                                        //Resources = _mapper.Map<List<Reply_Resources>, List<Reply_ResourcesDto>>(x._Resources).
                                        Resources=x._Resources.Where(a=>a.State==true&&x.ReplyId==x.ReplyId).Any()
                                    }).ToListAsync();


                //foreach (var item in model.list)
                //{
                //    foreach (var item2 in item.Resources)
                //    {
                //        string x = item2.path;
                //        if (File.Exists(x))
                //        {
                //            item2.path = await tobase64(x);

                //        }

                //    }
                //}


                return model;


            }
            catch (Exception)
            {

                throw;
            }

        }
        public async Task<bool> Add(Reply model)
        {
            try
            {
                if (model != null)


                {
                    await _data.Replies.AddAsync(model);
                    await _data.SaveChangesAsync();
                    return true;

                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<bool> Update(Reply model)
        {

            Reply reply = await _data.Replies.FindAsync(model.ReplyId);

            if (reply != null)
            {

                reply.mail_detail = model.mail_detail;
                reply.state = model.state;
                reply.state = true;
                reply.IsSend = true;

                _data.Replies.Update(reply);
                await _data.SaveChangesAsync();

                return true;
            }
            return false;
        }


        public async Task<bool> DeleteReply(int id,int UserId) 
        {

            try
            {
                Reply reply = await _data.Replies.FindAsync(id);

                if (reply != null)

                {
                    reply.state = false;
                    _data.Replies.Update(reply);
                    await _data.SaveChangesAsync();

                    List<Reply_Resources> replyResours = await _data.Reply_Resources.Where(x => x.ReplyId == reply.ReplyId && x.State == true ).ToListAsync() ;
                    Historyes historyes = new Historyes();

                    if (replyResours.Count != 0)
                    {
                        foreach (var item in replyResours)
                        {

                            item.State = false;
                            _data.Reply_Resources.Update(item);
                            await _data.SaveChangesAsync();

                        }

                        historyes.changes = "  تم حذف الرد مع الصور " + id;
                        historyes.currentUser = UserId;
                        historyes.HistortyNameID = 7;
                        historyes.Time = System.DateTime.Now;
                        historyes.mailid = id;
                        _data.History.Add(historyes);
                        await _data.SaveChangesAsync();
                        return true;
                    }
                    else
                    {
                        historyes.changes ="  تم حذف الرد بدون صور " ;
                        historyes.currentUser = UserId;
                        historyes.HistortyNameID = 7;
                        historyes.Time = System.DateTime.Now;
                        historyes.mailid = id;
                        _data.History.Add(historyes);
                        await _data.SaveChangesAsync();
                        return true;
                    }
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<bool> Delete(int id)
        {
            try
            {
                Reply reply = await _data.Replies.FindAsync(id);


                if (reply != null)

                {

                    reply.state = false;
                    _data.Replies.Update(reply);
                    await _data.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ReplayDto> Get(int id)
        {
            try
            {
                Reply reply = await _data.Replies.FindAsync(id);

                if (reply != null)
                {

                    ReplayDto dto = _mapper.Map<Reply, ReplayDto>(reply);

                    return dto;
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<ReplayDto>> GetAll()
        {
            try
            {
                List<Reply> list = await _data.Replies.ToListAsync();
                List<ReplayDto> listDto = _mapper.Map<List<Reply>, List<ReplayDto>>(list);
                return listDto;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> UpdateReplay(ReplyViewModel model)
        {


            bool result;
            if (model.reply.ReplyId != 0)
            {
                model.reply.send_ToId = model.send_ToId;
                model.reply.Date = DateTime.Now;
                model.reply.state = true;
                model.reply.IsSend = true;
                model.reply.mail_detail = model.reply.mail_detail;

                result = await Update(model.reply);
                if (result)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                result = await Add(model.reply);
                if (result)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }


        public async Task<bool> AddReplay(ReplyViewModel model)
        {
            Send_to send = await _data.Sends.FindAsync(model.send_ToId);

            switch (model.from)
            {
                case 1:
                    flag = 5;
                    break;
                case 2:
                    flag = 4;
                    break;
                default: break;
            }


            if (send != null)
            {

                send.flag = flag;
                send.update_At = DateTime.Now;
                model.reply.send_ToId = model.send_ToId;
                model.reply.Date = DateTime.Now;
                model.reply.state = true;
                model.reply.UserId = model.userId;
                send.time_of_read = model.reply.Date;
                model.reply.IsSend = true;

                _data.Update(send);
                await _data.SaveChangesAsync();

                bool result = await UpdateReplay(model);

                if (result)
                {

                    return true;
                }
                return false;

            }
            return false;
        }


        public async Task<bool> AddReplayFromDesktop(ReplyViewModel model)
        {
            Send_to send = await _data.Sends.FindAsync(model.send_ToId);

            switch (model.from)
            {
                case 1:
                    flag = 5;
                    break;
                case 2:
                    flag = 4;
                    break;
                default: break;
            }


            if (send != null)
            {

                // send.flag = flag;

                model.reply.send_ToId = model.send_ToId;
                model.reply.Date = DateTime.Now;
                model.reply.state = true;
                model.reply.IsSend = false;
                // send.time_of_read  = model.reply.Date;

                //  _data.Update(send);
                // await _data.SaveChangesAsync();

                bool result = await Add(model.reply);

                if (result)
                {

                    return true;
                }
                return false;
            }
            return false;
        }

        public async Task<bool> UpdateResources(Reply model)
        {

            Reply reply = await _data.Replies.FindAsync(model.ReplyId);

            if (reply != null)
            {
                List<Reply_Resources> resources = await _data.Reply_Resources.Where(x => x.ReplyId == model.ReplyId && x.State == true).ToListAsync();

                if (resources != null)
                {
                    foreach (var item in resources)
                    {
                        item.IsSend = true;
                        _data.Reply_Resources.Update(item);
                    }
                    await _data.SaveChangesAsync();

                    return true;
                }
                return false;
            }
            return false;
        }
        public async Task<bool> AddResources(Reply_Resources resources)
        {
            try
            {
                if (resources != null)

                {
                    await _data.Reply_Resources.AddAsync(resources);
                    await _data.SaveChangesAsync();
                    return true;

                }

                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }



        public async Task<bool> Uplode(Uplode file)
        {
            try
            {

                bool result = false;

                string year = DateTime.Now.Year.ToString();
                string Month = DateTime.Now.Month.ToString();
                string day = DateTime.Now.Day.ToString();

                string name = "Reply_photos";

                string x1 = Path.Combine(this.iwebHostEnvironment.WebRootPath, name).ToLower();

                string y = Path.Combine(x1, year);
                string z = Path.Combine(y, Month);
                string last = Path.Combine(z, day);

                if (!Directory.Exists(x1))
                {
                    Directory.CreateDirectory(x1);
                }

                if (!Directory.Exists(y))
                {
                    Directory.CreateDirectory(y);

                }

                if (!Directory.Exists(z))
                    Directory.CreateDirectory(z);


                if (!Directory.Exists(last))
                    Directory.CreateDirectory(last);



                else { }



                if (file.list.Count > 0)
                {
                    foreach (var item in file.list)
                    {
                        var index = item.baseAs64.IndexOf(',');
                        var bsee64string = item.baseAs64.Substring(index + 1);
                        index = item.baseAs64.IndexOf(';');
                        var base64signtuer = item.baseAs64.Substring(0, index);
                        index = item.baseAs64.IndexOf('/');
                        var extention = base64signtuer.Substring(index + 1);
                        byte[] bytes = Convert.FromBase64String(bsee64string);
                        Guid guid = Guid.NewGuid();
                        string xx = guid.ToString();
                        var path = Path.Combine(last, xx + ".");


                        await File.WriteAllBytesAsync(path + extention, bytes);
                        Reply_Resources reply = new Reply_Resources();
                        reply.ReplyId = file.mail_id;
                        reply.path = path + extention;
                        reply.order = item.index;
                        reply.State = true;
                        reply.IsSend = false;


                        bool res = await AddResources(reply);
                        if (res)
                        {
                            result = true;
                        }
                        else
                        {
                            File.Delete(reply.path);
                            result = false;


                        }
                    }

                }

                return result;

            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<List<RViewModel>> GetResourse(int id)
        {
            try
            {
                List<RViewModel> list = await (from x in _data.Replies.Where(x => x.send_ToId == id && x.state.Equals(true) && x.IsSend.Equals(true))
                                               join y in _data.Reply_Resources.Where(x => x.State.Equals(true) && x.IsSend.Equals(true)) on x.ReplyId equals y.ReplyId
                                               select new RViewModel
                                               {
                                                   reply = _mapper.Map<Reply, ReplayDto>(x),
                                                   Resources = x._Resources.Where(a => a.State == true && x.ReplyId == x.ReplyId).Any()

                                               }).ToListAsync();

                //foreach (var item in list)
                //{
                //    foreach (var item2 in item.Resources)
                //    {
                //        string x1 = item2.path;
                //        item2.path = await tobase64(x1);
                //    }
                //}

                return list;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<string> tobase64(string patj)
        {

            try
            {
                var attachmentType = System.IO.Path.GetExtension(patj);
                var Type = attachmentType.Substring(1, attachmentType.Length - 1);
                var filePath = System.IO.Path.Combine(patj);
                byte[] fileBytes = await System.IO.File.ReadAllBytesAsync(filePath);
                var ImageBase64 = "data:image/" + Type + ";base64," + Convert.ToBase64String(fileBytes);
                return ImageBase64;
            }
            catch (Exception)
            {

                throw;
            }


        }

        // public async Task<int> AddReplayWithPhoto(ReplayPhotoVM replay)
        public async Task<Replayid> AddReplayWithPhoto(ReplayPhotoVM replay)
        {
            try
            {
                Reply reply1 = await _data.Replies.FirstOrDefaultAsync(x => x.send_ToId.Equals(replay.send_ToId) && x.IsSend == false && x.state == true && x.UserId == replay.userId);

                ReplyViewModel reply = new ReplyViewModel();
                reply.send_ToId = replay.send_ToId;
                reply.from = replay.from;
                reply.userId = replay.userId;
                if (reply1 != null) { reply.reply = reply1; reply.reply.mail_detail = replay.reply.mail_detail; } else { reply.reply = replay.reply; }
                
                bool result = await AddReplay(reply);

                //***********5/3/2023
                Replayid replayid = new Replayid();

                //*******end 5/3/2023

                if (result)
                {

                    Historyes historyes = new Historyes();
                    historyes.mailid = replay.mailId;
                    historyes.currentUser = replay.userId;
                    historyes.HistortyNameID = 6;
                    historyes.Time = DateTime.Now;

                    await _data.History.AddAsync(historyes);
                    await _data.SaveChangesAsync();

                    if (reply1 != null)
                    {
                        bool res1 = await UpdateResources(reply.reply);

                        if (res1)
                        {
                            //*******5/3/2023
                            //return 1;
                            replayid.result1 = 1;
                            replayid.replyid = reply.reply.ReplyId;


                            return replayid;
                            //*end 5/3/2023
                        }
                        //*******5/3/2023
                        //return 2;
                        replayid.result1 = 2;
                        replayid.replyid = reply.reply.ReplyId;


                        return replayid;
                        //****end 5/3/2023
                    }
                    else
                    {
                        replay.file.mail_id = reply.reply.ReplyId;

                        if (replay.file.list.Count > 0)
                        {
                            bool res = await Uplode(replay.file);
                            if (res)
                            {
                                //****5/3/2023
                                //return 1;
                                replayid.result1 = 1;
                                replayid.replyid = reply.reply.ReplyId;


                                return replayid;
                                //*end 5/3/2023
                            }
                            //****5/3/2023
                            //return 2;
                            replayid.result1 = 2;
                            replayid.replyid = reply.reply.ReplyId;


                            return replayid;
                            //*end 5/3/2023
                        }
                    }
                }
                //*********5/3/2023
                //return 3;
                replayid.result1 = 3;
                replayid.replyid = 0;


                return replayid;
                //********end 5/3/2023
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<int> AddReplayWithPhotoFromDeskApp(ReplayPhotoVM replay)
        {
            try
            {

                ReplyViewModel reply = new ReplyViewModel();
                reply.send_ToId = replay.send_ToId;
                reply.from = replay.from;

                reply.reply = replay.reply;

                bool result = await AddReplayFromDesktop(reply);

                if (result)
                {
                    replay.file.mail_id = reply.reply.ReplyId;
                    if (replay.file.list.Count > 0)
                    {

                        bool res = await Uplode(replay.file);
                        if (res)
                        {
                            return 1;
                        }
                        return 2;
                    }
                }
                return 3;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteNotSendedReply(ReplayPhotoVM replayPhotoVM)
        {
            try
            {
                Reply reply = await _data.Replies.FirstOrDefaultAsync(x => x.IsSend.Equals(false) && x.state.Equals(true)&&x.To.Equals(replayPhotoVM.reply.To) && x.UserId.Equals(replayPhotoVM.reply.UserId) && x.send_ToId.Equals(replayPhotoVM.send_ToId));

                if (reply != null)
                {
                    List<Reply_Resources> resourse = await _data.Reply_Resources.Where(x => x.IsSend.Equals(false) && x.State.Equals(true) && x.ReplyId.Equals(reply.ReplyId)).ToListAsync();
          
                      reply.state = false;
                     _data.Replies.Update(reply);                  
                    await _data.SaveChangesAsync();

                    if (resourse.Count !=0 )
                    {
                        foreach (var item1 in resourse)
                        {
                            item1.State = false;
                            _data.Reply_Resources.Update(item1);
                        }
                    }
                    await _data.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<Page_Reply_Resources> GetResources_ById(int id,int page_number) {
            Page_Reply_Resources model = new Page_Reply_Resources();
            model.total  =  _data.Reply_Resources.Where(x => x.State.Equals(true) && x.ReplyId == id).ToList().Count();

            model.date =await _data.Reply_Resources.Where(x => x.State.Equals(true) && x.ReplyId == id).Select(z=>new Reply_ResourcesDto
            { 
            
            ID=z.ID,
            order=z.order,
            path=z.path,
            ReplyId=z.ReplyId
            
            
            }).Skip((page_number - 1) * 1).Take(1).ToListAsync();


            foreach (var item in model.date)
            {
                  string x1 = item.path;
                item.path = await tobase64(x1);
                

            }




            return model;

        }
        //*******************27/2/2023
        public async Task<bool> update_replay(ReplayPhotoVM replay)
        {
            try
            {
                ReplyViewModel reply = new ReplyViewModel();
                replay.file.mail_id = replay.id_of_reply;


                if (replay.file.list.Count > 0)
                {
                    bool res = await Uplode(replay.file);
                    //    if (res)
                    //    {
                    //        return 1;
                    //    }
                    //    return 2;
                    //}
                    //return 3;
                    return res;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
        //************end 27/2/2023
    }
}
