using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieProject.Models
{
    public class Movie
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
        public string Director { get; set; }
        public int Length { get; set; }
        public int MinimalAge { get; set; }

        [Display(Name = "Supplier")]
        public int SupplierId { get; set; }

        
        public virtual Supplier MovieSupplier { get; set; }
    }
}