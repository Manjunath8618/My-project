using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApp.Dto
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string CoverImageUrl { get; set; }
        public DateTime PublishedDate { get; set; }
        public string AuthorName { get; set; }
        public string CategoryName { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
        public double AverageRating { get; set; }
        public int ReviewCount { get; set; }
    }
}
