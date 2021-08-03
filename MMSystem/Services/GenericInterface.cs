using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Services
{
   public interface GenericInterface<Model,dto>
    {
        Task<bool> Add(Model t);
        Task<bool> Delete(int id);
        Task<dto> Get(int id);
        Task<List<dto>> GetAll();
        Task<bool> Update(Model model);


    }

}

