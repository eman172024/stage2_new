using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Model.ViewModel
{
    public class Pagenation<T>
    {
        public int Count { get; set; }

        public List<T> list { get; set; }

    }
}
