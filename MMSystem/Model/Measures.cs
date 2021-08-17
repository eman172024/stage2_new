using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Model
{
    public class Measures
    {
        [Key]
        public int MeasuresId { get; set; }

        [MaxLength(18)]


        public string MeasuresName { get; set; }


        public bool state { get; set; }

     
    }
}
