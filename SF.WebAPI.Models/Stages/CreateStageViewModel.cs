using System.ComponentModel.DataAnnotations;

namespace SF.WebAPI.Models.Stages
{
    public class CreateStageViewModel
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
