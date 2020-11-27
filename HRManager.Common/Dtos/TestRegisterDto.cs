using System.ComponentModel.DataAnnotations;

namespace HRManager.Common.Dtos
{
    public class TestRegisterDto
    {
        [Required(ErrorMessage = "A valid email is required")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "A valid password is required")]
        public string Password { get; set; }
        [Required]
        [Compare(nameof(Password), ErrorMessage = "Passwords don't match")]
        public string ConfirmPassword { get; set; }
    }
}
