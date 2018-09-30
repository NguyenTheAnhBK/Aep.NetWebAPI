using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BooksAPI.Models
{
    [Table("Authors")]
    public class Author
    {
        [Key]
        public int authorId { set; get; }
        [Required]
        [MaxLength(256)]
        public string name { set; get; }

        public virtual IEnumerable<Book> Book { set; get; }
    }
}