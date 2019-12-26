using System.Collections.Generic;
using BookMongoAPI.Models;
using BookMongoAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookMongoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public ActionResult<List<Book>> Get() => _bookRepository.Get();

        [HttpGet("{id:length(24)}", Name = "GetBook")]
        public ActionResult<Book> Get(string id)
        {
            var book = _bookRepository.Get(id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        [HttpPost]
        public ActionResult<Book> Create(Book book)
        {
            _bookRepository.Create(book);

            return CreatedAtRoute("GetBook", new { id = book.Id.ToString() }, book);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Book bookIn)
        {
            var book = _bookRepository.Get(id);

            if (book == null)
            {
                return NotFound();
            }

            _bookRepository.Update(id, bookIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var book = _bookRepository.Get(id);

            if (book == null)
            {
                return NotFound();
            }

            _bookRepository.Remove(book.Id);

            return NoContent();
        }
    }
}