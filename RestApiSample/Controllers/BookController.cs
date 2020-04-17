using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestApiSample.Models;
using RestApiSample.Models.Dto;
using RestApiSample.Models.Entities;

namespace RestApiSample.Controllers
{
    [Route("api/v1/authors/{authorId}/books")]
    [ApiController]
    public class BookController : ControllerBase
    {

        private readonly BookLibraryContext _bookLibrary;
        public BookController(BookLibraryContext bookLibrary)
        {
            _bookLibrary = bookLibrary;
        }


        public ActionResult<IEnumerable<Book>> Get(Guid authorId)
        {
            return _bookLibrary.Books.Where(p => p.AuthorId == authorId).ToArray();
        }

        [HttpGet("{id}")]
        public ActionResult<Book> Get(Guid authorId, Guid id)
        {
            var author = _bookLibrary.Books.FirstOrDefault(p => p.AuthorId == authorId && p.Id == id);
            if (author is null) return NotFound();

            return author;
        }

        [HttpPost]
        public ActionResult Post(Guid authorId, BookCreateDto bookDto)
        {

            var book = new Book { Name = bookDto.Name, AuthorId = authorId, Id = Guid.NewGuid() };
            _bookLibrary.Books.Add(book);
            _bookLibrary.SaveChanges();
            return CreatedAtAction("Get", new { id = book.Id, authorId = authorId }, book);
        }


        [HttpPut("{id}")]
        public ActionResult Put(Guid authorId, Guid id, BookUpdateDto bookDto)
        {
            var author = _bookLibrary.Authors.FirstOrDefault(p => p.Id == authorId);
            if (author is null) return NotFound();

            var book = _bookLibrary.Books.FirstOrDefault(p => p.Id == id);
            if (book is null)
            {
                book = new Book { Name = bookDto.Name, AuthorId = authorId, Id = id };
                _bookLibrary.Books.Add(book);
                _bookLibrary.SaveChanges();
                return CreatedAtAction("Get", new { id = book.Id, authorId = authorId }, book);
            }
            book.Name = bookDto.Name;
            _bookLibrary.SaveChanges();
            return NoContent();
        }


        [HttpDelete("{id}")]
        public ActionResult Delete(Guid authorId, Guid id)
        {
            var author = _bookLibrary.Authors.FirstOrDefault(p => p.Id == authorId);
            if (author is null) return NotFound();

            var book = _bookLibrary.Books.FirstOrDefault(p => p.Id == id);
            if (book is null) return NotFound();

            _bookLibrary.Remove(book);
            _bookLibrary.SaveChanges();
            return NoContent();
        }
    }
}