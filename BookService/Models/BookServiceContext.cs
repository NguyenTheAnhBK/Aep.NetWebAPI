using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BookService.Models
{
    public class BookServiceContext:DbContext
    {
        public BookServiceContext() : base("BookServiceConnection")
        {
            //this.Configuration.LazyLoadingEnabled = true;
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }
        public DbSet<Book> books { set; get; }
        public DbSet<Author> authors { set; get; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
        }
    }
}