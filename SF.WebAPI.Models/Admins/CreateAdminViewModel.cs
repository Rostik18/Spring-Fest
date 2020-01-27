using System.ComponentModel.DataAnnotations;

namespace SF.WebAPI.Models.Admins
{
    public class CreateAdminViewModel
    {
        [Required]
        [MaxLength(100)]
        public string Login { get; set; }

        [Required]
        [MaxLength(100)]
        public string Password { get; set; }

        [Required]
        [Compare(nameof(Password), ErrorMessage = "ConfirmPassword does not match Password.")]
        public string ConfirmPassword { get; set; }
    }
}
