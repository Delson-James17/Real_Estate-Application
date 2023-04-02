using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Real_Estate.ViewModels
{
    public class LoginUserViewModel
    {
        // view for login

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}

