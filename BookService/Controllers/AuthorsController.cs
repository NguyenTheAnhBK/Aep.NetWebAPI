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

namespace BookService.Controllers
{
    public class AuthorsController : ApiController
    {
        private BookServiceContext db = new BookServiceContext();

        public IQueryable<Author> GetAuthors()
        {
            return db.authors;
        }
        [ResponseType(typeof(Author))]
        public async Task<IHttpActionResult> GetAuthor(int id)
        {
            var author = await db.authors.FindAsync(id);
            if (author == null)
                return NotFound();
            return Ok(author);
        }
        [ResponseType(typeof(Author))]
        public async Task<IHttpActionResult> PostAuthor(Author author)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            db.authors.Add(author);
            await db.SaveChangesAsync();
            return CreatedAtRoute("DefaultApi", new { id = author.id }, author);
        }
        [ResponseType(typeof(Author))]
        public async Task<IHttpActionResult> DeleteAuthor(int id)
        {
            var author = await db.authors.FindAsync(id);
            if (author == null)
                return BadRequest();
            db.authors.Remove(author);
            await db.SaveChangesAsync();
            return Ok(author);
        }
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();
            base.Dispose(disposing);
        }
        //// GET: api/Authors
        //public IQueryable<Author> Getauthors()
        //{
        //    return db.authors;
        //}

        //// GET: api/Authors/5
        //[ResponseType(typeof(Author))]
        //public async Task<IHttpActionResult> GetAuthor(int id)
        //{
        //    Author author = await db.authors.FindAsync(id);
        //    if (author == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(author);
        //}

        //// PUT: api/Authors/5
        //[ResponseType(typeof(void))]
        //public async Task<IHttpActionResult> PutAuthor(int id, Author author)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != author.id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(author).State = EntityState.Modified;

        //    try
        //    {
        //        await db.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!AuthorExists(id))
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

        //// POST: api/Authors
        //[ResponseType(typeof(Author))]
        //public async Task<IHttpActionResult> PostAuthor(Author author)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.authors.Add(author);
        //    await db.SaveChangesAsync();

        //    return CreatedAtRoute("DefaultApi", new { id = author.id }, author);
        //}

        //// DELETE: api/Authors/5
        //[ResponseType(typeof(Author))]
        //public async Task<IHttpActionResult> DeleteAuthor(int id)
        //{
        //    Author author = await db.authors.FindAsync(id);
        //    if (author == null)
        //    {
        //        return NotFound();
        //    }

        //    db.authors.Remove(author);
        //    await db.SaveChangesAsync();

        //    return Ok(author);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool AuthorExists(int id)
        //{
        //    return db.authors.Count(e => e.id == id) > 0;
        //}
    }
}