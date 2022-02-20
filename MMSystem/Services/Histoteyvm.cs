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


                text = text+"  "+$"تم تغير القيمة  :  {item.name.ToString()}  من  {item.oldvalue.ToString()}  الي  {item.newvalue} ";
            }

            return text;
        }
       

    }
}
