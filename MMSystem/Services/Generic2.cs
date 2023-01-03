using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Services
{
  public  interface Generic2<Model, dto>
    {
      
        Task<bool> Delete(int id);
        Task<dto> Get(int id);
        Task<List<dto>> GetAll();
        Task<bool> Update(Model model);

        Task<List<dto>> getsub(int par);
        Task<bool> add( Model model);
       
        Task<Model> find(int id);


       


    }

}
