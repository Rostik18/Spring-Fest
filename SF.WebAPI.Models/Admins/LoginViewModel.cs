using System.ComponentModel.DataAnnotations;

namespace SF.WebAPI.Models.Admins
{
    public class LoginViewModel
    {
        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
