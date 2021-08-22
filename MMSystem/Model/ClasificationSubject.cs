using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Model
{
    public class ClasificationSubject
    {[Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public bool state { get; set; }
    }
}
