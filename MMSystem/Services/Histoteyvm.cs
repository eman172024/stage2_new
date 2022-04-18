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

                //text = text + " " + string.Format($" " +

                //            $"  {item.newvalue}  الي   {item.oldvalue}  " +



                //$" تم تغيير    {item.name}  ");

               // text = text +item.oldvalue + "الى " + item.oldvalue + "من " + item.name+ "تم تغيير "    ;
                text = text + "  تم تغيير  " + item.name + "  من " + item.oldvalue + "  الى  " + item.newvalue ;

            }



            //  text.Reverse();


            //
            return text;
        }
       

    }
}
