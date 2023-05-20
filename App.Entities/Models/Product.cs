using App.Core.Abstract;
using System.ComponentModel.DataAnnotations;

namespace App.Entities.Models
{
    public class Product : IEntity
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public double DiscountPercentage { get; set; }
        [Required]
        public double Rating { get; set; }
        [Required]
        public int Stock { get; set; }
        [Required]
        public string? Brand { get; set; }
        [Required]
        public string? Category { get; set; }
        [Required]
        public string? ThumbnailURL { get; set; }
    }
}