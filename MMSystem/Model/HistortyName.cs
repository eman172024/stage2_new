using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Model
{
    public class HistortyName
    {

        public int ID { get; set; }

        public string name  { get; set; }

        public List<Historyes> Historyes { get; set; }
    }
}
