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
                ForMember(ds=>ds.Date_Of_Mail,sr=>sr.MapFrom(x=>x.Date_Of_Mail.ToString("yyyy-MM-dd")));
            CreateMap<External_Mail, ExternalDto>();
            CreateMap<Extrenal_inbox, Extrenal_inboxDto>();
            CreateMap<Administrator, AdministratorDto>();
            CreateMap<Role, RoleDto>();

            CreateMap<Department, DepartmentDto>();
            CreateMap<Extrmal_Section, Extrmal_SectionDto>();
            
            CreateMap<Mail_Resourcescs, Mail_ResourcescsDto>();
            CreateMap<Reply,ReplayDto>();
            CreateMap<ClasificationSubject, ClasificationSubjectDto>();
            CreateMap<Measures, MeasuresDto>();

        }

    }
}
