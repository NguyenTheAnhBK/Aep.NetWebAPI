namespace BooksAPI.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using BooksAPI.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<BooksAPI.Models.BooksAPIContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BooksAPI.Models.BooksAPIContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.authors.AddOrUpdate(new Author() { authorId = 1, name = "Rall, Kim" }
            , new Author() { authorId = 2, name = "Corets, Eva" }
            , new Author() { authorId = 3, name = "Rundall, Cynthia" }
            , new Author() { authorId = 4, name = "Thurman, Paula" });
            context.books.AddOrUpdate(new Book()
            {
                bookId = 1,
                title = "Midnight Rain",
                genre = "Fantasy",
                publishDate = new DateTime(2000, 12, 16),
                authorId = 1,
                description =
                "A former architect battles an evil sorceress.",
                price = 14.95M
            },

        new Book()
        {
            bookId = 2,
            title = "Maeve Ascendant",
            genre = "Fantasy",
            publishDate = new DateTime(2000, 11, 17),
            authorId = 2,
            description =
            "After the collapse of a nanotechnology society, the young" +
            "survivors lay the foundation for a new society.",
            price = 12.95M
        },

        new Book()
        {
            bookId = 3,
            title = "The Sundered Grail",
            genre = "Fantasy",
            publishDate = new DateTime(2001, 09, 10),
            authorId = 2,
            description =
            "The two daughters of Maeve battle for control of England.",
            price = 12.95M
        },

        new Book()
        {
            bookId = 4,
            title = "Lover Birds",
            genre = "Romance",
            publishDate = new DateTime(2000, 09, 02),
            authorId = 3,
            description =
            "When Carla meets Paul at an ornithology conference, tempers fly.",
            price = 7.99M
        },

        new Book()
        {
            bookId = 5,
            title = "Splish Splash",
            genre = "Romance",
            publishDate = new DateTime(2000, 11, 02),
            authorId = 4,
            description =
            "A deep sea diver finds true love 20,000 leagues beneath the sea.",
            price = 6.99M
        });
        }
    }
}
