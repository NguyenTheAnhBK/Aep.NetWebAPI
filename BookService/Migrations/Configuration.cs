namespace BookService.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using BookService.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<BookService.Models.BookServiceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BookService.Models.BookServiceContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.authors.AddOrUpdate(
                new Author() { id = 1, name = "Jane Austen" },
                new Author() { id = 2, name = "Charles Dickens" },
                new Author() { id = 3, name = "Miguel de Cervantes" }
                );
            context.books.AddOrUpdate(
                new Book() { id = 1, title = "Pride and Prejudice", year = 1813, authorId = 1, price = 9.99M, genre = "Comedy of manners" },
                new Book() { id = 2, title = "Northanger Abbey", year = 1817, authorId = 1, price = 12.95M, genre = "Gothic parody" },
                new Book() { id = 5, title = "Pride and Prejudice", year = 1813, authorId = 1, price = 9.99M, genre = "Comedy of manners" },
                new Book() { id = 6, title = "Don Quixote", year = 1617, authorId = 3, price = 8.95M, genre = "Picaresque" }
                );
        }
    }
}
