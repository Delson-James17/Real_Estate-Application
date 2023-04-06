using Microsoft.AspNetCore.Identity;
using Real_Estate.ViewModels;

namespace Real_Estate.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public DateTime? DOB { get; set; }
        public string UrlImages { get; set; }
    }
}
