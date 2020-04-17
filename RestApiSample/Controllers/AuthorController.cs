using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RestApiSample.Models;
using RestApiSample.Models.Dto;
using RestApiSample.Models.Entities;

namespace RestApiSample.Controllers
{
    [Route("api/v1/authors")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly BookLibraryContext _bookLibrary;
        public AuthorController(BookLibraryContext bookLibrary)
        {
            _bookLibrary = bookLibrary;
        }

        [HttpGet]
        public IEnumerable<Author> Get()
        {
            return _bookLibrary.Authors.ToArray();
        }

        [HttpGet("{id}")]
        public ActionResult<Author> Get(Guid id)
        {
            var author = _bookLibrary.Authors.FirstOrDefault(p => p.Id == id);
            if (author is null) return NotFound();

            return author;
        }

        [HttpPost]
        public ActionResult Post(AuthorCreateDto authorDto)
        {
            var author = new Author { FirstName = authorDto.FirstName, LastName = authorDto.LastName };
            _bookLibrary.Authors.Add(author);
            _bookLibrary.SaveChanges();
            return CreatedAtAction("Get", new { id = author.Id }, author);
        }


        [HttpPut("{id}")]
        public ActionResult Put(Guid id, AuthorUpdateDto authorDto)
        {
            var author = _bookLibrary.Authors.FirstOrDefault(p => p.Id == id);
            if (author is null)
            {
                author = new Author { FirstName = authorDto.FirstName, LastName = authorDto.LastName, Id = id };
                _bookLibrary.Authors.Add(author);
                _bookLibrary.SaveChanges();
                return CreatedAtAction("Get", new { id = id }, author);
            }
            author.FirstName = authorDto.FirstName;
            author.LastName = authorDto.LastName;
            _bookLibrary.SaveChanges();
            return NoContent();
        }

  
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var author = _bookLibrary.Authors.FirstOrDefault(p => p.Id == id);
            if (author is null) return NotFound();

            _bookLibrary.Remove(author);
            _bookLibrary.SaveChanges();
            return NoContent();
        }
    }
}
