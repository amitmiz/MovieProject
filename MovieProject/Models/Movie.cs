using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieProject.Models
{
    public class Movie
    {
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        [DataType(DataType.Date)]
        [Required]
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }

        [Range(0, 250.99)]
        public decimal Price { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public int Length { get; set; }
        [Range(10,120)]
        public int MinimalAge { get; set; }

        [ForeignKey("Supplier")]
        public virtual Supplier MovieSupplier { get; set; }
    }
}