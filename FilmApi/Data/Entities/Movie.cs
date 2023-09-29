using System;
using System.ComponentModel.DataAnnotations;

namespace FilmApi.Data.Entities
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)] // Set a maximum length for Title
        public string Title { get; set; } = null!;

        [Required]
        public string Genre { get; set; } = null!;

        [Required]
        [Range(1900, 2100)] // Set a range for ReleaseYear
        public int ReleaseYear { get; set; }

        [Required]
        [MaxLength(100)] // Set a maximum length for Director
        public string Director { get; set; } = null!;

        public string? PictureUrl { get; set; }

        public string? TrailerUrl { get; set; }

        // Navigation properties
        public int FranchiseId { get; set; }
        public Franchise Franchise { get; set; }

        public ICollection<Character> Characters { get; set; }
    }
}