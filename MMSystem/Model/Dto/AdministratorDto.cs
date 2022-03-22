

namespace MMSystem.Model.Dto
{
    public class AdministratorDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FirstMACAddress { get; set; }
        public string SecandMACAddress { get; set; }
        public string nationalNumber { get; set; }
        public int DepartmentId { get; set; }
        public string userNetwork { get; set; }
        public string password { get; set; }
        public bool state { get; set; }

        
    }
}
