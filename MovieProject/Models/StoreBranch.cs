using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieProject.Models
{
    public class StoreBranch
    {
        public int ID { get; set; }
        public string BrnachName { get; set; }
        public string OpeningHours { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
    }
}