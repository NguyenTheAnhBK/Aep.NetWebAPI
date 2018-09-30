using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using BooksAPI.DTOs;
using BooksAPI.Models;

namespace BooksAPI.Controllers
{
    [RoutePrefix("api/books")]
    public class BooksController : ApiController
    {
        private BooksAPIContext db = new BooksAPIContext();
        //Expression tree use lambda expression
        private static readonly Expression<Func<Book, BookDto>> asBookDto = x =>
        new BookDto
        {
            title = x.title,
            author = x.author.name,
            genre = x.genre
        };

        [Route("")]
        public IQueryable<BookDto> GetBook()
        {
            return db.books.Include(b => b.author).Select(asBookDto);
        }

        [Route("{id:int}")]
        [ResponseType(typeof(BookDto))]
        public async Task<IHttpActionResult> GetBook(int id)
        {
            BookDto book = await db.books.Include(x => x.author).Where(x => x.bookId == id).Select(asBookDto).FirstOrDefaultAsync();
            if (book == null)
                return NotFound();
            return Ok(book);
        }

        [Route("{id:int}/details")]
        [ResponseType(typeof(BookDetailDto))]
        public async Task<IHttpActionResult> GetBookDetail(int id)
        {
            var book = await db.books.Include(x => x.author).Where(x => x.authorId == id)
                .Select(x => new BookDetailDto
                {
                    title = x.title,
                    genre = x.genre,
                    publishDate = x.publishDate,
                    description = x.description,
                    author = x.author.name,
                    price = x.price,
                }).FirstOrDefaultAsync();
            if (book == null)
                return NotFound();
            return Ok(book);
        }
        //get book by genre
        [Route("{genre}")]
        public IQueryable<BookDto> GetBooksByGenre(string genre)
        {
            return db.books.Include(x => x.author).Where(x => x.genre.Equals(genre, StringComparison.OrdinalIgnoreCase)).Select(asBookDto);
            //StringComparison.OrdinalIgnoreCase: bỏ qua thứ tự
        }
        //get book by author
        [Route("~/api/authors/{authorId:int}/books")]
        public IQueryable<BookDto> GetBooksByAuthor(int authorId)
        {
            return db.books.Include(x => x.author).Where(x => x.authorId == authorId).Select(asBookDto);
        }
        //get books by publication date
        [Route("date/{pubdate:datetime:regex(\\d{4}-\\d{2}-\\d{2})}")]//yyyy-mm-dd
        [Route("date/{*pubdate:datetime:regex(\\d{4}/\\d{2}/\\d{2})}")]//yyyy/mm/dd
        [Route("date/{*pubdate:datetime:regex(\\d{4}\\\\d{2}\\\\d{2})}")]//yyyy\mm\dd
        public IQueryable<BookDto> GetBooks(DateTime pubdate)
        {
            return db.books.Include(x => x.author)
                .Where(x => DbFunctions.TruncateTime(x.publishDate) == DbFunctions.TruncateTime(pubdate))
                .Select(asBookDto);
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
        
    }
}