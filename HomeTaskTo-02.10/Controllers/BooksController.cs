using HomeTaskTo_02._10.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeTaskTo_02._10.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private static List<Book> _books = new List<Book>();

        [HttpGet("Book/book/get")]
        public List<Book> Get()
        {
            return _books;
        }
        [HttpGet("Book/book/{book.id}")]
        public IActionResult Get(string id)
        {
            var existingBook = _books.FirstOrDefault(x => x.Id == id);
            if (existingBook == null)
            {
                return NotFound("book was not found");
            }
            return Ok(existingBook);
        }

        [HttpPost("book/create")]
        public IActionResult CreateBook(Book book)
        {
            if (book == null)
            {
                return NotFound("book info is null");
            }
            _books.Add(book);
            return Ok(book);
        }
        [HttpPut("Book/book/{id}")]
        public void UpdateBook(string id, Book book)
        {
            var existingBook = _books.FirstOrDefault(x => x.Id == id);
            existingBook.BookName = book.BookName;
            existingBook.Price = book.Price;
            existingBook.Category = book.Category;
            existingBook.Author = book.Author;
        }

        [HttpDelete("Book/book/{id}")]
        public void RemoveBook(string id)
        {
            var existingBook = _books.FirstOrDefault(x => x.Id == id);
            _books.Remove(existingBook);
        }





    }
}
