using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PublisherWebAPI.Services;

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
    }
}
