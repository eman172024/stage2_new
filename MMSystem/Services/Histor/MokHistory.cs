using Microsoft.EntityFrameworkCore;
using MMSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Services.Histor
{
    public class MokHistory:IHistory
    {
      
        public MokHistory(AppDbCon dbCon)
        {
            DbCon = dbCon;
        }
        private AppDbCon DbCon { get; }

        public async Task<bool> Add(Historyes historyes)
        {
            try
            {
                if (historyes!=null)
                {
                    await DbCon.History.AddAsync(historyes);
                    await DbCon.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }


            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Historyes>> GetAll()
        {
            var History = await DbCon.History.ToListAsync();
            return History;
        }

        public Task<Historyes> GetDate(DateTime Timefirst, DateTime TimeLast)
        {
            throw new NotImplementedException();
        }
    }
}
