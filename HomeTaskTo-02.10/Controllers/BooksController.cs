using HomeTaskTo_02._10.Models;
using HomeTaskTo_02._10.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeTaskTo_02._10.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("get")]
        public IActionResult GetAll()
        {
            var result = _bookService.GetAll();
            return Ok(result); 
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var existedBook = _bookService.Get(id);
            return (existedBook == null) ? NotFound("Book was not found") : Ok(existedBook);    
        }

        [HttpPost("create")]
        public IActionResult CreateBook(Book book)
        {
            var isSuccessfullyCreated  = _bookService.Create(book);
            return isSuccessfullyCreated ? Ok(book) : NotFound("Book was not created");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(string id, Book book)
        {
            var isSuccessfullyUpdated = _bookService.Update(id, book);
            return isSuccessfullyUpdated ? Ok(book) : NotFound("book was not found, update was unsuccessful");
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveBook(string id)
        {
            var isSuccessfullyDeleted = _bookService.Remove(id);
            return isSuccessfullyDeleted ? Ok() : NotFound("book was not found, update was unsuccessful");
        }





    }
}
