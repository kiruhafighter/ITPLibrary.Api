using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITPLibrary.Api.Core.Dtos
{
    public class BookDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public double Price { get; set; }

        public string Author { get; set; }

        public double PopularityRate { get; set; }
    }
}
