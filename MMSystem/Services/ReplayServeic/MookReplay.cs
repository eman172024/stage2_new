using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MMSystem.Model;
using MMSystem.Model.Dto;
using MMSystem.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Services.ReplayServeic
{
    public class MookReplay : IReplay

    {


        public MookReplay(AppDbCon data, IMapper mapper, IWebHostEnvironment environment)
        {
            _data = data;
            _mapper = mapper;
            _environment = environment;
        }
        public string sub { get; set; }

        private readonly AppDbCon _data;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _environment;

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
            Send_to send = await _data.Sends.FindAsync(model.RepluId);

            if (send != null) {

                model.reply.Date = DateTime.Now;
                model.reply.state = true;

                bool result = await Add(model.reply);
                if (result) {

                    return false;
                }
                return false;
            
            }
            return false;
        }

        public async Task<List<ReplayDto>> GetAllReplay(int id)
        {
            try
            {
                List<Reply> list = await _data.Replies.Where(x => x.send_ToId == id).ToListAsync();
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

                        var path = Path.Combine(_environment.WebRootPath, "images", image);

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
    }
}
