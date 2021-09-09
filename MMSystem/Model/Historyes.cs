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
        public string User { get; set; }
        public DateTime Time { get; set; }
        public string Transaction { get; set; }
        public int RowTransaction { get; set; }
        public string OldValue { get; set; }
    }
}
