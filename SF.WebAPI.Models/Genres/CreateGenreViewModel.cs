using System.ComponentModel.DataAnnotations;

namespace SF.WebAPI.Models.Genres
{
    public class CreateGenreViewModel
    {
        [Required]
        public string Name { get; set; }
    }
}
