using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MMSystem.Model;
using MMSystem.Model.Dto;
using MMSystem.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Services.MailServeic
{
    public class MooKMail_Resourcescs : IMail_Resourcescs
    {
        private readonly AppDbCon _dbCon;
        private readonly IMapper _mapper;

        public MooKMail_Resourcescs(AppDbCon dbCon,IMapper mapper)
        {
            _dbCon = dbCon;
            _mapper = mapper;
        }
        public async Task<bool> Add(Mail_Resourcescs t)
        {
            try
            {
                Mail mail =await _dbCon.Mails.FindAsync(t.MailID);

                if (mail != null) {

                    t.State = true;
                    await _dbCon.Mail_Resourcescs.AddAsync(t);
                    await _dbCon.SaveChangesAsync();
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

                Mail_Resourcescs mailResourse = await _dbCon.Mail_Resourcescs.FindAsync(id);
                if (mailResourse != null)
                {
                    mailResourse.State = false;
                    _dbCon.Mail_Resourcescs.Update(mailResourse);
                    await _dbCon.SaveChangesAsync();
                    return true;

                }
                return false;


            }
            catch (Exception)
            {

                throw;
            }
        
        }

        public async Task<Mail_ResourcescsDto> Get(int id)
        {
            Mail_Resourcescs mail = await _dbCon.Mail_Resourcescs.FindAsync(id);
            if (mail != null) {
                Mail_ResourcescsDto resourse = _mapper.Map<Mail_Resourcescs, Mail_ResourcescsDto>(mail);

                return resourse;


            }
            return null;
        }

        public Task<List<Mail_ResourcescsDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Mail_ResourcescsDto>> GetAll(int id)
        {
            try
            {
                List<Mail_Resourcescs> _Resourcescs = await _dbCon.Mail_Resourcescs.Where(x => x.MailID == id && x.State == true).ToListAsync();
                List<Mail_ResourcescsDto> mail_ResourcescsDtos = _mapper.Map<List<Mail_Resourcescs>, List<Mail_ResourcescsDto>>(_Resourcescs);



                foreach (var xx in mail_ResourcescsDtos)
                {
                    string x = xx.path;

                    if (File.Exists(xx.path))
                    {
                        xx.path = await tobase64(x);

                    }
                    else
                    {






                    }

                }
                return mail_ResourcescsDtos;

            }
            catch (Exception)
            {

                throw;
            }
          
        }

        public async Task<bool> Update(Mail_Resourcescs mail_Resourcescs)
        {
            try
            {
                Mail_Resourcescs resourcescs = await _dbCon.Mail_Resourcescs.FindAsync(mail_Resourcescs.ID);
                if (mail_Resourcescs != null) {

                    _dbCon.Mail_Resourcescs.Update(mail_Resourcescs);
                    await _dbCon.SaveChangesAsync();
                    return true;
                }
                return false;
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
                //**********28/11/2022
                if (System.IO.File.Exists(filePath))
                {

                    byte[] fileBytes = await System.IO.File.ReadAllBytesAsync(filePath);
                    var ImageBase64 = "data:image/" + Type + ";base64," + Convert.ToBase64String(fileBytes);
                    return ImageBase64;
                }
                else
                    return null;
                //*********end 28/11/2022


            }
            catch (Exception)
            {

                throw;
            }


        }

        public async Task<List<Mail_ResourcescsDto>> GetAllRes(int id)
        {
            try
            {
                var list = await GetAll(id);

               foreach (var xx in list)
               {
                string x = xx.path;
               xx.path = await tobase64(x);
               }


                return list;

            }
            catch (Exception)
            {

                throw;
            }
           
        }

      

        public async Task<List<Mail_ResourcescsDto>> GetAllRes(int id, int userId)
        {
            try
            {
                List<Mail_Resourcescs> _Resourcescs = await _dbCon.Mail_Resourcescs.Where(x => x.MailID == id && x.State == true).ToListAsync();
                List<Mail_ResourcescsDto> mail_ResourcescsDtos = _mapper.Map<List<Mail_Resourcescs>, List<Mail_ResourcescsDto>>(_Resourcescs);



               

                foreach (var xx in mail_ResourcescsDtos)
                {
                    string x = xx.path;

                    if (File.Exists(xx.path))
                    {
                        xx.path = await tobase64(x);

                    }
                    else
                    {






                    }
                 

                }


                if (mail_ResourcescsDtos.Count > 0)
                {
                    Historyes historyes = new Historyes();
                    historyes.currentUser = userId;

                    historyes.mailid = id;
                    historyes.changes = $" تم عرض الصورة   {id} ";
                    historyes.Time = DateTime.Now;
                    historyes.HistortyNameID = 13;
                    await _dbCon.History.AddAsync(historyes);

                    await _dbCon.SaveChangesAsync();

                    return mail_ResourcescsDtos;

                }
                else {

                    return mail_ResourcescsDtos;
                }

                

                return mail_ResourcescsDtos;

            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<bool> print(int mailid,int userId,int type)
        {

            try
            {

                Historyes historyes = new Historyes();
                historyes.mailid = mailid;
                historyes.Time = DateTime.Now;
                historyes.currentUser = userId;

                switch (type) {

                    case 1:

                        historyes.HistortyNameID = 22;
                        
                        break;
                    case 2:

                        historyes.HistortyNameID = 23;
                        break;
                    case 3:

                        historyes.HistortyNameID = 21;

                        break;
                    default:break;
                
                
                }

                await _dbCon.History.AddAsync(historyes);
                int res = await _dbCon.SaveChangesAsync();
                if (res!=0) {
                    return true;
                
                
                }

                return false;
            }
            catch (Exception)
            {

                throw;
            }


        }

        public async Task<RessPage> GetAllResss(int id,int pageNumber)
        {
            try
            {
                
                RessPage ressPage = new RessPage();


                ressPage.total = _dbCon.Mail_Resourcescs.Where(x => x.State.Equals(true) && x.MailID == id).ToList().Count();

                var list = await _dbCon.Mail_Resourcescs.
                 Where(x => x.MailID == id).Skip((pageNumber - 1) * 1).Take(1).ToListAsync();

                if (list.Count > 0)
                {

                    ressPage.data = _mapper.Map<List<Mail_Resourcescs>, List<Mail_ResourcescsDto>>(list);

                    foreach (var xx in list)
                    {
                        string x = xx.path;
                        xx.path = await tobase64(x);
                    }
                    return ressPage;

                }

                else {
                    return ressPage;

                }



            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task<RessObj> GetAllResswithPage(int id, int pageNumber)
        {
            try
            {

                RessObj ressPage = new RessObj();


                ressPage.total = _dbCon.Mail_Resourcescs.Where(x => x.State.Equals(true) && x.MailID == id).ToList().Count();

                var list = await _dbCon.Mail_Resourcescs.OrderBy(x=>x.order).
                 Where(x => x.MailID == id&&x.State==true).Skip((pageNumber - 1) * 1).Take(1).ToListAsync();

                if (list.Count > 0)
                {

                   var data= _mapper.Map<List<Mail_Resourcescs>, List<Mail_ResourcescsDto>>(list);

                    foreach (var xx in list)
                    {
                        string pat = xx.path;
                        xx.path = await tobase64(pat);
                    }


                    ressPage.data = data.FirstOrDefault();
                    string x = ressPage. data.path;

                    ressPage.data.path = await tobase64(x);


                    return ressPage;

                }

                else
                {
                    return ressPage;

                }



            }
            catch (Exception ex)
            {

                throw;
            }

        }




        public async Task<RessObj> GetAllResswithPage1(int id, int pageNumber)
        {
            try
            {

                RessObj ressPage = new RessObj();


                ressPage.total = _dbCon.Mail_Resourcescs.Where(x => x.State.Equals(true) && x.ID == id).ToList().Count();

                var list = await _dbCon.Mail_Resourcescs.
                 Where(x => x.MailID == id && x.State == true).Skip((pageNumber - 1) * 1).Take(1).ToListAsync();

                if (list.Count > 0)
                {

                    var data = _mapper.Map<List<Mail_Resourcescs>, List<Mail_ResourcescsDto>>(list);

                    foreach (var xx in list)
                    {
                        string pat = xx.path;
                        xx.path = await tobase64(pat);
                    }


                    ressPage.data = data.FirstOrDefault();
                    string x = ressPage.data.path;

                    ressPage.data.path = await tobase64(x);


                    return ressPage;

                }

                else
                {
                    return ressPage;

                }



            }
            catch (Exception ex)
            {

                throw;
            }

        }



        public async Task<dynamic> delete_all_image(int id,int userid)
        {
            try
            {
                bool IsDelete = false;
                string massage = "";

                List<Mail_Resourcescs> mailResourse = await _dbCon.Mail_Resourcescs.Where(x=>x.MailID==id&&x.State.Equals(true)).ToListAsync();
                if (mailResourse .Count>0)
                {


                    foreach (var item in mailResourse)
                    {
                        item.State = false;

                        _dbCon.Mail_Resourcescs.Update(item);
                   int res=     await _dbCon.SaveChangesAsync();
                        if (res != 0)
                        {
                            IsDelete = true;
                            Historyes histor = new Historyes();
                            histor.mailid = id;
                            histor.currentUser = userid;
                            histor.changes = "حدف جميع الصور " +  "  "+ id.ToString();
                            histor.Time = DateTime.Now;
                            histor.HistortyNameID = 5;
                            await _dbCon.History.AddAsync(histor);
                            await _dbCon.SaveChangesAsync();



                         

                            massage = "تمت العملية بنجاح";

                        }
                        else {

                            massage = "حدث خطأ";


                        }


                    }


                    return new { IsDelete,massage};

                }
                massage = "لايوجد صور";

                return new { IsDelete, massage };


            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<bool> order_images(List<ResViewModel> list)
        {

            int order = 1;
            bool isUpdate = false;
            foreach (var item in list)
            {

                var obj = await _dbCon.Mail_Resourcescs.FindAsync(item.id);

                if (obj != null) {
                    obj.order = order;
                    _dbCon.Mail_Resourcescs.Update(obj);

                    await _dbCon.SaveChangesAsync();

                    isUpdate = true;
                    order++;


                }



            }

            return isUpdate;
        }



        public async Task<List<ResViewModel>> Get_Mail_Resourcescs_orders(int id)
        {
           List<ResViewModel> list = await _dbCon.Mail_Resourcescs.Where(x => x.MailID == id && x.State == true).OrderBy(z=>z.order).Select(z=>new ResViewModel { 
                
                
                
                id=z.ID,
                order=z.order
                
                
                
                } ).ToListAsync();


            return list;

        }

        public async Task<RessObj> GetSingleImage( int id)
        {
            try
            {

                RessObj ressPage = new RessObj();


                ressPage.total = _dbCon.Mail_Resourcescs.Where(x => x.State.Equals(true) &&x.ID==id).ToList().Count();

                var list = await _dbCon.Mail_Resourcescs.OrderBy(x => x.order).
                 Where(x => x.ID == id && x.State == true).Take(1).ToListAsync();

                if (list.Count > 0)
                {

                    var data = _mapper.Map<List<Mail_Resourcescs>, List<Mail_ResourcescsDto>>(list);

                    foreach (var xx in list)
                    {
                        string pat = xx.path;
                        xx.path = await tobase64(pat);
                    }


                    ressPage.data = data.FirstOrDefault();
                    string x = ressPage.data.path;

                    ressPage.data.path = await tobase64(x);


                    return ressPage;

                }

                else
                {
                    return ressPage;

                }



            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
