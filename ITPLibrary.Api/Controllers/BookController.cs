using ITPLibrary.Api.Data.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ITPLibrary.Api.Models;
using ITPLibrary.Api.Core.Services.IServices;
using ITPLibrary.Api.Core.Dtos;

namespace ITPLibrary.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BookController(IBookService boorService)
        {
            _bookService = boorService;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<BookDto>))]
        public IActionResult GetBooks()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(_bookService.GetBooks());
        }

        [HttpGet]
        [Route("Get Popular Books")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<BookDto>))]
        public IActionResult GetPopularBooks()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(_bookService.GetPopularBooks());
        }

        [HttpGet("id")]
        [ProducesResponseType(200, Type = typeof(BookDto))]
        public IActionResult GetBook(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var book = _bookService.GetBook(id);
            if(book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpGet("title")]
        [ProducesResponseType(200, Type = typeof(BookDto))]
        public IActionResult GetBookByName(string title)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var book = _bookService.GetBook(title);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateBook (BookDto book)
        {
            if(_bookService.CreateBook(book) == null)
            {
                ModelState.AddModelError("", "Something went wrong while creating new book");
                return StatusCode(500, ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(book);
        }

        [HttpPut]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateBook(int bookId, BookDto book)
        {
            if (_bookService.UpdateBook(bookId, book) == null)
            {
                ModelState.AddModelError("", "Something went wrong while updating book");
                return StatusCode(500, ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(book);
        }
        
        [HttpDelete("{bookId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeleteBook(int bookId)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState); 
            }
            if (!_bookService.DeleteBook(bookId))
            {
                ModelState.AddModelError("", "Something went wrong while deleting book");
                return StatusCode(500, ModelState);
            }
            return Ok("Book deleted");
        }
    }
}
