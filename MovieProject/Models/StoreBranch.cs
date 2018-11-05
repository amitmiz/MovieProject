using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieProject.Models
{
    public class StoreBranch
    {
        public int ID { get; set; }
        [Required]
        public string BrnachName { get; set; }
        [Required]
        public string OpeningHours { get; set; }
        [Range(34,35)]
        [Required]
        public string Longitude { get; set; }
        [Range(32, 33)]
        [Required]
        public string Latitude { get; set; }
    }
}