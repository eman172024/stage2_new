using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace MMSystem.Model
{
    public class Administrator
    {[Key]
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; }
       
        public string password { get; set; } 
        public string FirstMACAddress { get; set; }
        public string SecandMACAddress { get; set; }
        [MaxLength(12)]
        public string nationalNumber { get; set; }
        public int DepartmentId { get; set; }
        public bool state { get; set; }
        public string userNetwork { get; set; }

        public Department Department { get; set; }
        public List<UserRoles> userRoles { get; set; }

    }
}
