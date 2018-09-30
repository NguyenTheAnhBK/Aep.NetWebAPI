using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookService.Models
{
    [Table("Books")]
    public class Book
    {
        [Key]
        public int id { set; get; }
        [Required]
        [MaxLength(256)]
        public string title { set; get; }
        public int year { set; get; }
        [MaxLength(200)]
        public string genre { set; get; }
        [Required]
        public int authorId { set; get; }
        public decimal price { set; get; }
        [ForeignKey("authorId")]
        public Author author { set; get; }
    }
}