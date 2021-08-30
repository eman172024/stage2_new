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
            CreateMap<Mail, MailDto>();
            CreateMap<External_Mail, ExternalDto>();
            CreateMap<Extrenal_inbox, Extrenal_inboxDto>();
            CreateMap<Administrator, AdministratorDto>();
         CreateMap<Mail_Resourcescs, Mail_ResourcescsDto>();
            CreateMap<Reply,ReplayDto>();

        }

    }
}
