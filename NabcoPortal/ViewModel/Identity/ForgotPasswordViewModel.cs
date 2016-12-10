using System.ComponentModel.DataAnnotations;

namespace NabcoPortal.ViewModel.Identity
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
