using SF.WebAPI.Models.CustomValidations;
using System.ComponentModel.DataAnnotations;

namespace SF.WebAPI.Models.Stages
{
    public class UpdateStageViewModel
    {
        [Required]
        [GreaterThanZero]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
