using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookService.Models
{
    [Table("Authors")]
    public class Author
    {
        [Key]
        public int id { set; get; }
        [Required]
        [MaxLength(256)]
        public string name { set; get; }
        public virtual IEnumerable<Book> books { set; get; }
    }
}