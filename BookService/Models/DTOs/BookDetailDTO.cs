using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookService.Models.DTOs
{
    public class BookDetailDTO
    {
        public int id { set; get; }
        public string title { set; get; }
        public int year { set; get; }
        public string genre { set; get;}
        public string authorName { set; get; }
        public decimal price { set; get; }
    }
}