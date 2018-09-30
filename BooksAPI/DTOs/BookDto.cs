using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BooksAPI.DTOs
{
    //DTO: Data transfer object
    public class BookDto
    {
        public string author { set; get; }
        public string title { set; get; }
        public string genre { set; get; }
    }
}