using System.ComponentModel.DataAnnotations;

namespace NabcoPortal.ViewModel.Identity
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}