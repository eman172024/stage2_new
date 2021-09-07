using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Model
{
    public class UserRoles
    {
        [Key]

        public int Id { get; set; }

        [ForeignKey("RoleId")]
        public int RoleId { get; set; }

        public Role Role { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }

        public Administrator User { get; set; }


    }
}
