using System.ComponentModel.DataAnnotations;

namespace SF.WebAPI.Models.Admins
{
    public class LoginViewModel
    {
        /// <example>MasterOfPuppets</example>
        [Required]
        public string Login { get; set; }

        /// <example>Admin12345</example>
        [Required]
        public string Password { get; set; }
    }
}
