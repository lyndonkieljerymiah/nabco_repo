using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace NabcoPortal.ViewModel.Identity
{
    public class RegisterViewModel
    {

        private IEnumerable<SelectListItem> _roles;

        public static RegisterViewModel CreateWithRoles(IEnumerable<SelectListItem> roles)
        {
            return new RegisterViewModel(roles);
        }

        internal RegisterViewModel(IEnumerable<SelectListItem> roles)
        {
            this._roles = roles;
        }

        public RegisterViewModel()
        {
            
        }
        

        [Display(Name = "Full Name")]
        [Required]
        public string FullName { get; set; }

        [Display(Name = "User Name")]
        [Required]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [System.ComponentModel.DataAnnotations.Compare("Password",
             ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string RoleId { get; set; }

        public IEnumerable<SelectListItem> RolesList
        {
            get { return  new SelectList(_roles,"Value","Text"); }
        }
    }
}