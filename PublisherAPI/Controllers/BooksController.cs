using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PublisherWebAPI.Services;
using PublisherWebAPI.Models;

namespace PublisherWebAPI.Controllers
{
    [Route("api/publishers")]
    public class BooksController : Controller
    {
        private IBookstoreRepository _rep;

        public BooksController(IBookstoreRepository rep)
        {
            _rep = rep;
        }

        [HttpGet("{publisherId}/books")]
        public IActionResult Get(int publisherId)
        {
            var books = _rep.GetBooks(publisherId);
            return Ok(books);
        }

        [HttpGet("{publisherId}/books/{id}")]
        public IActionResult Get(int publisherId, int id)
        {
            var book = _rep.GetBook(publisherId, id);

            if (book == null) return NotFound();

            return Ok(book);
        }

        [HttpPost("{publisherId}/books")]
        public IActionResult Post(int publisherId, [FromBody]BookCreateDTO book)
        {
            if (book == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var publisherExists = _rep.PublisherExists(publisherId);
            if (!publisherExists) return NotFound();

            var bookToAdd = new BookDTO
            {
                PublisherId = publisherId,
                Title = book.Title
            };

            _rep.AddBook(bookToAdd);
            _rep.Save();

            return CreatedAtRoute("GetBook", new
            {
                publisherId = publisherId,
                id = bookToAdd.Id
            }, bookToAdd);
        }// end of POST method

        [HttpPut("{publisherId}/books/{id}")]
        public IActionResult Put(int publisherId, int id, 
            [FromBody]BookUpdateDTO book)
        {
            if (book == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var bookToUpdate = _rep.GetBook(publisherId, id);
            if (bookToUpdate == null) return NotFound();
            _rep.UpdateBook(publisherId, id, book);
            _rep.Save();
            return NoContent();
        }
    }
}
