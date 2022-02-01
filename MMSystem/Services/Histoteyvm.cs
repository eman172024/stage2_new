using MMSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Services
{
    public static class Histoteyvm
    {


        public static string getValue(List<HVModel> list ) {


            string text = "";
           
            //    }

            var ll = list.Where(x => x.newvalue.ToString()!=x.oldvalue.ToString() ).ToList();

            foreach (var item in ll)
            {
                //text = "    " + text +item.newvalue.ToString()+ $" {} الي "+"  " +item.oldvalue.ToString()  +"  من  " + item.name+"  {}تم تغيير";


                text = $"the name change :  {item.name.ToString()}  from  {item.oldvalue.ToString()}  to  {item.newvalue} ";
            }

            return text;
        }
       

    }
}
