using System.ComponentModel.DataAnnotations;

namespace SF.WebAPI.Models.Genres
{
    public class CreateGenreViewModel
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
