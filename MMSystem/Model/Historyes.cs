using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Model
{
    public class Historyes
    {
     [Key]
        public int Id { get; set; }
        public int currentUser { get; set; }
        public DateTime Time { get; set; }
        public int mailid { get; set; }         
        public int HistortyNameID { get; set; }
        public string changes { get; set; }
        public HistortyName HistortyName { get; set; }
    }
}
