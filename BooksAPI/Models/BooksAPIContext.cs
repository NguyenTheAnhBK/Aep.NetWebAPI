using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BooksAPI.Models
{
    public class BooksAPIContext:DbContext
    {
        public BooksAPIContext() : base() {
            this.Configuration.LazyLoadingEnabled = true;//sử dụng lazyloading
        }
        public DbSet<Book> books { set; get; }
        public DbSet<Author> authors { set; get; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
        }
    }
}