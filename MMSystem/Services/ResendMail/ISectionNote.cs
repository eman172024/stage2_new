using MMSystem.Model;
using MMSystem.Model.Dto;
using MMSystem.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace MMSystem.Services.ResendMail
{
    public interface ISectionNote
    {
        Task<bool> AddNotes(Section_Notes t);

    }
}
