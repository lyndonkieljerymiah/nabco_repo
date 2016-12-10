using System.ComponentModel.DataAnnotations;

namespace NabcoPortal.ViewModel.Identity
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}