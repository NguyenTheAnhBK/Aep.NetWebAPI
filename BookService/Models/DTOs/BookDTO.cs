using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookService.Models.DTOs
{
    public class BookDTO
    {
        public int id { set; get; }
        public string title { set; get; }
        public string name { set; get; }
    }
}