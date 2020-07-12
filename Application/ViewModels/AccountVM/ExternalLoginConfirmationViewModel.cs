using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels.AccountVM
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
