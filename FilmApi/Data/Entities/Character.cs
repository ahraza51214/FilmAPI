using System;
using System.ComponentModel.DataAnnotations;

namespace FilmApi.Data.Entities
{
    // Character entity that represents the characters table in database
    public class Character
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)] // Set a maximum length for FullName
        public string FullName { get; set; } = null!;

        [MaxLength(50)] // Set a maximum length for Alias
        public string? Alias { get; set; }

        [Required]
        [StringLength(10)] // Set a fixed length for Gender (e.g., "Male" or "Female")
        public string Gender { get; set; } = null!;

        public string? PictureUrl { get; set; }

        // Navigation property
        public ICollection<Movie>? Movies { get; set; }
    }
}