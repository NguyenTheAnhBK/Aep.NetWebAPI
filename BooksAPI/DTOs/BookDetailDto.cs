using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BooksAPI.DTOs
{
    public class BookDetailDto
    {
        public string title { set; get; }
        public string genre { set; get; }
        public DateTime publishDate { set; get; }
        public string description { set; get; }
        public string author { set; get; }
        public decimal price { set; get; }
    }
}