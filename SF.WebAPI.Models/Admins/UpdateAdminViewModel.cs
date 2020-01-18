using System.ComponentModel.DataAnnotations;

namespace SF.WebAPI.Models.Admins
{
    public class UpdateAdminViewModel
    {
        [Required]
        public int Id { get; set; }
        public string NewLogin { get; set; }
        public string NewPassword { get; set; }
        
        [Compare(nameof(NewPassword), ErrorMessage = "ConfirmNewPassword does not match NewPassword.")]
        public string ConfirmNewPassword { get; set; }
    }
}
