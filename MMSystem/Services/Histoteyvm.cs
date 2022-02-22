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


            string text = "  ";
           
            //    }

            var ll = list.Where(x => x.newvalue.ToString()!=x.oldvalue.ToString() ).ToList();

            foreach (var item in ll)
            {
                //text = "    " + text +item.newvalue.ToString()+ $" {} الي "+"  " +item.oldvalue.ToString()  +"  من  " + item.name+"  {}تم تغيير";

                //text=text+" " +    string.Format($"( " +

                //$" الي " +
                //  $" {item.newvalue} " +
                //$"  من  " +
                //$" {item.oldvalue}  " +
                //$" تم تغيير    {item.name} ) ");
                text  =text+ $"تم تغيير  {item.name} من {item.oldvalue} الي {item.newvalue}";

                //   text = text + $"{item.newvalue} الي ,{item.oldvalue } من  {item.name.ToString()}  تم تغيير ";
            }


           
          //  text.Reverse();
           
        
           //
            return text;
        }
       

    }
}
