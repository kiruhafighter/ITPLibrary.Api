using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [Range(1,12, ErrorMessage = "Rating must be between 1 and 12")]
        public double Price { get; set; }
        [Required]
        public string Author { get; set; }
        public string? Thumbnail { get; set; }
        [Required]
        [DisplayName("Popularity Rating")]
        public double PopularityRate { get; set; }
        public DateTime? AddingTime { get; set; } = DateTime.Now;
        public bool RecentlyAdded { get; set; } = false;


    }
}
