using Real_Estate.Models;

namespace Real_Estate.ViewModels
{
    public class RoleViewModel
    {
        public string Id { get; set; } // Global UniqueID MAC + Timestamp
        public string UserId { get; set; } 
        public string Name { get; set; }
        public bool IsSelected { get; set; }

   
    }
}

