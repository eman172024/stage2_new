using MMSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Services.Histor
{
    public  interface IHistory
    {
        Task<bool> Add(Historyes historyes);
        Task<Historyes> GetDate(DateTime Timefirst, DateTime TimeLast);
        Task <List<Historyes>> GetAll();

    }
}
