using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BooksAPI.Models
{
    [Table("Books")]
    public class Book
    {
        [Key]
        public int bookId { set; get; }
        [Required]
        [MaxLength(256)]
        public string title { set; get; }
        
        public decimal price { set; get; }
        [MaxLength(100)]
        public string genre { set; get; }//genreration: tái bản
        public DateTime publishDate { set; get;}
        public string description { set; get; }
        [Required]
        public int authorId { set; get; }
        [ForeignKey("authorId")]
        public Author author { set; get; }
    }
}