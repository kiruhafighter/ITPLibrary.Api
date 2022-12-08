using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITPLibrary.Api.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string Author { get; set; }
        public string? Thumbnail { get; set; }
        [Required]
        [DisplayName("Popularity Rating")]
        [Range(1, 12, ErrorMessage = "Rating must be between 1 and 12")]
        public double PopularityRate { get; set; }
        public DateTime? AddingTime { get; set; } = DateTime.Now;
        public bool RecentlyAdded { get; set; } = false;


    }
}
