using AutoMapper;
using MMSystem.Model;
using MMSystem.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Services
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Mail, MailDto>().
                ForMember(ds=>ds.Date_Of_Mail,sr=>sr.MapFrom(x=>x.Date_Of_Mail.ToString("yyyy-MM-dd")
                
                
                )
                
                ).ForMember(ds => ds.mail_year, ss => ss.MapFrom(x => x.Date_Of_Mail.Date.Year));
        
            CreateMap<External_Mail, ExternalDto>();
            CreateMap<Extrenal_inbox, Extrenal_inboxDto>().
                ForMember(ds => ds.Send_time, sr => sr.MapFrom(x => x.Send_time.ToString("yyyy-MM-dd")));
            CreateMap<Administrator, AdministratorDto>();
            CreateMap<Role,RoleDto>();

            CreateMap<Department, DepartmentDto>();
            CreateMap<Extrmal_Section, Extrmal_SectionDto>();
            
            CreateMap<Mail_Resourcescs, Mail_ResourcescsDto>();
         //   CreateMap<Reply,ReplayDto>();
            CreateMap<ClasificationSubject, ClasificationSubjectDto>();
            CreateMap<Measures, MeasuresDto>();
            CreateMap<Reply, ReplayDto>().
                  ForMember(ds => ds.Date, sr => sr.MapFrom(x => x.Date.ToString("yyyy-MM-dd:hh:mm"))); ;
            CreateMap<Reply_Resources, Reply_ResourcesDto>();

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
