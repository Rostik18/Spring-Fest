﻿using SF.WebAPI.Models.CustomValidations;
using System.ComponentModel.DataAnnotations;

namespace SF.WebAPI.Models.Genres
{
    public class UpdateGenreViewModel
    {
        [Required]
        [GreaterThanZero]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
