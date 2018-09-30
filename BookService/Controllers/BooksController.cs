using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using BookService.Models;
using BookService.Models.DTOs;

namespace BookService.Controllers
{
    public class BooksController : ApiController
    {
        private BookServiceContext db = new BookServiceContext();

        [ResponseType(typeof(BookDTO))]
        public IQueryable<BookDTO> GetBooks()
        {
            var books = db.books.Include(x => x.author).Select(x => new BookDTO
            {
                id = x.id,
                title = x.title,
                name = x.author.name
            });
            return books;
        }
        //[Route("{id:int}")]
        [ResponseType(typeof(BookDetailDTO))]
        public async Task<IHttpActionResult> GetBook(int id)
        {
            var book = await db.books.Include(x => x.author)
                .Select(x => new BookDetailDTO
                {
                    id = x.id,
                    title = x.title,
                    year = x.year,
                    genre = x.genre,
                    authorName = x.author.name,
                    price = x.price
                }).SingleOrDefaultAsync(x => x.id == id);
            if (book == null)
                return NotFound();
            return Ok(book);
        }
        [ResponseType(typeof(BookDTO))]
        //this is method convert DTOs manually, Another option is to use a library like AutoMapper
        public async Task<IHttpActionResult> PostBook(Book book)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            db.books.Add(book);
            await db.SaveChangesAsync();
            db.Entry(book).Reference(x => x.author).Load();
            var dto = new BookDTO()
            {
                id= book.id,
                title=book.title,
                name=book.author.name
            };
            return CreatedAtRoute("DefaultApi", new { id=book.id }, dto);
        }
        [ResponseType(typeof(Book))]
        public async Task<IHttpActionResult> DeleteBook(int id)
        {
            Book book = await db.books.FindAsync(id);
            if (book == null)
                return NotFound();
            db.books.Remove(book);
            await db.SaveChangesAsync();
            return Ok(book);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();
            base.Dispose(disposing);
        }
        //// GET: api/Books
        //public IQueryable<Book> Getbooks()
        //{
        //    //eager loading, EF loads elated entities as part of the initial database query. 
        //    //Use System.Data.Entity.Include 
        //    return db.books.Include(x => x.author);
        //}

        //// GET: api/Books/5
        //[ResponseType(typeof(Book))]
        //public async Task<IHttpActionResult> GetBook(int id)
        //{
        //    Book book = await db.books.FindAsync(id);
        //    if (book == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(book);
        //}

        //// PUT: api/Books/5
        //[ResponseType(typeof(void))]
        //public async Task<IHttpActionResult> PutBook(int id, Book book)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != book.id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(book).State = EntityState.Modified;

        //    try
        //    {
        //        await db.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!BookExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST: api/Books
        //[ResponseType(typeof(Book))]
        //public async Task<IHttpActionResult> PostBook(Book book)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.books.Add(book);
        //    await db.SaveChangesAsync();

        //    return CreatedAtRoute("DefaultApi", new { id = book.id }, book);
        //}

        //// DELETE: api/Books/5
        //[ResponseType(typeof(Book))]
        //public async Task<IHttpActionResult> DeleteBook(int id)
        //{
        //    Book book = await db.books.FindAsync(id);
        //    if (book == null)
        //    {
        //        return NotFound();
        //    }

        //    db.books.Remove(book);
        //    await db.SaveChangesAsync();

        //    return Ok(book);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool BookExists(int id)
        //{
        //    return db.books.Count(e => e.id == id) > 0;
        //}
    }
}