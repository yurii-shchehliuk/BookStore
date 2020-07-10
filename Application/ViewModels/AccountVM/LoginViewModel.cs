using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels.AccountVM
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Please enter username or email")]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter password")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
