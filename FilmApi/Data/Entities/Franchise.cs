using System;
using System.ComponentModel.DataAnnotations;

namespace FilmApi.Data.Entities
{
    public class Franchise
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)] // Set a maximum length for Name
        public string Name { get; set; } = null!;

        [MaxLength(500)] // Set a maximum length for Description
        public string? Description { get; set; }

        // Navigation property
        public ICollection<Movie>? Movies { get; set; }
    }
}