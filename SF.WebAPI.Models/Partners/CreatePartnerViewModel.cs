using System.ComponentModel.DataAnnotations;

namespace SF.WebAPI.Models.Partners
{
    public class CreatePartnerViewModel
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }
    }
}
