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
                default:break;
            }


            if (send != null) {

                send.flag =flag;

                model.reply.send_ToId = model.send_ToId;
                model.reply.Date = DateTime.Now;
                model.reply.state = true;
                send.time_of_read = model.reply.Date;
                
                _data.Update(send);
                await _data.SaveChangesAsync();

                bool result = await Add(model.reply);
                if (result) {

                    return true;
                }
                return false;
            
            }
            return false;
        }

        public async Task<List<ReplayDto>> GetAllReplay( int depid,int mailId)
        {
            try
            {

                Send_to send_ = await _data.Sends.FirstOrDefaultAsync(x => x.MailID == mailId &&x.to==depid);

                List<Reply> list = await _data.Replies.OrderBy(x=>x.ReplyId).Where(x=>x.send_ToId==send_.Id).ToListAsync();
                List<ReplayDto> replays = _mapper.Map<List<Reply>, List<ReplayDto>>(list);
                return replays;
            }
            catch (Exception)
            {

                throw;
            }
      
            
        }


        public async Task<List<ReplayDto>> GetAllReplay(int depid, int mailId,int to)
        {
            try
            {

                Send_to send_ = await _data.Sends.FirstOrDefaultAsync(x => x.MailID == mailId && x.to == depid&&x.to==to);

                List<Reply> list = await _data.Replies.OrderBy(x => x.ReplyId).Where(x => x.send_ToId == send_.Id).ToListAsync();
                List<ReplayDto> replays = _mapper.Map<List<Reply>, List<ReplayDto>>(list);
                return replays;
            }
            catch (Exception)
            {

                throw;
            }


        }

        public Task<bool> Update(Reply model)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AddResources(Reply_Resources resources)
        {
            try
            {
                if(resources!=null)

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

        public async Task<bool> Upload(int id, List<IFormFile> listOfPhotes)
        {
            try
            {
                int order = 1;
                if (listOfPhotes.Count > 0)
                {
                    foreach (var file in listOfPhotes)
                    {
                        sub = "";

                        IEnumerable<char> takeFiveChar = file.FileName.TakeLast(5);

                        foreach (var item in takeFiveChar)
                        {
                            sub = sub + item.ToString();

                        }

                        Guid guid = Guid.NewGuid();
                        string image = guid.ToString() + "" + sub;

                        var path = Path.Combine(this.iwebHostEnvironment.WebRootPath, "images", image);

                        //  file.FileName.Replace(file.FileName,x);
                        var stream = new FileStream(path, FileMode.Create);

                        await file.CopyToAsync(stream);
                        Reply_Resources mail = new Reply_Resources();
                        mail.ReplyId = id;
                        mail.path = "wwwroot/images/" + image;
                        mail.order = order;
                        bool res = await AddResources(mail);


                        order += 1;
                    }
                    return true;

                }
                return false;

            }
            catch
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

                string name = "ReplyResources";
              
                string x = Path.Combine(this.iwebHostEnvironment.WebRootPath, name).ToLower();
                string y = Path.Combine(x, year);
                string z = Path.Combine(y, Month);
                string last = Path.Combine(z, day);

                if (Directory.Exists(x))
                    if (!Directory.Exists(y)) {
                        Directory.CreateDirectory(y);

                    }

                if (!Directory.Exists(z))
                    Directory.CreateDirectory(z);


                if (!Directory.Exists(last))
                    Directory.CreateDirectory(last);

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
                        bool res = await AddResources(reply);
                        if (res)
                        {

                            result= true;
                        }
                        else {
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
                List<RViewModel> list = await(from x in _data.Replies.Where(x => x.send_ToId == id)
                                              join y in _data.Reply_Resources on x.ReplyId equals y.ReplyId
                                              select new RViewModel
                                              {
                                                  reply = _mapper.Map<Reply, ReplayDto>(x),
                                                  Resources = _mapper.Map<List<Reply_Resources>, List<Reply_ResourcesDto>>(_data.Reply_Resources.Where(x => x.ReplyId == x.ID).ToList())
                                              }).ToListAsync();

                foreach (var item in list)
                {
                    foreach (var item2 in item.Resources)
                    {
                        string x1 = item2.path;
                        item2.path = await tobase64(x1);
                    }
                }

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
    }
}
