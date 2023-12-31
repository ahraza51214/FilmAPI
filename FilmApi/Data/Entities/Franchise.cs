﻿using System;
using System.ComponentModel.DataAnnotations;

namespace FilmApi.Data.Entities
{
    // Franchise entity that represents the franchises table in database
    public class Franchise
    {
        [Key]
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