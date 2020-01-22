using System.ComponentModel.DataAnnotations;

namespace SF.WebAPI.Models.Stages
{
    public class CreateStageViewModel
    {
        [Required]
        public string Name { get; set; }
    }
}
