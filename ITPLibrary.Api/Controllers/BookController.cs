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
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ServiceResponse<IEnumerable<BookDto>>))]
        public async Task<IActionResult> GetBooks()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(await _bookService.GetBooks());
        }

        [HttpGet]
        [Route("Get Popular Books")]
        [ProducesResponseType(200, Type = typeof(ServiceResponse<IEnumerable<BookDto>>))]
        public async Task<IActionResult> GetPopularBooks()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(await _bookService.GetPopularBooks());
        }

        [HttpGet("id")]
        [ProducesResponseType(200, Type = typeof(ServiceResponse<BookDto>))]
        public async Task<IActionResult> GetBook(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var book = await _bookService.GetBook(id);
            if(book.Success != true)
            {
                return NotFound(book);
            }
            return Ok(book);
        }

        [HttpGet("title")]
        [ProducesResponseType(200, Type = typeof(ServiceResponse<BookDto>))]
        public async Task<IActionResult> GetBookByName(string title)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var book = await _bookService.GetBook(title);
            if (book.Success != true)
            {
                return NotFound(book);
            }
            return Ok(book);
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(ServiceResponse<AddBookDto>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateBook (AddBookDto book)
        {
            var response = await _bookService.CreateBook(book);
            if (response.Success != true)
            {
                return BadRequest(response);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(response);
        }

        [HttpPut]
        [ProducesResponseType(200, Type = typeof(ServiceResponse<BookDto>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateBook(int bookId, AddBookDto book)
        {
            var updBook = await _bookService.UpdateBook(bookId, book);
            if (updBook.Success != true)
            {
                return BadRequest(updBook);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(updBook);
        }
        
        [HttpDelete("{bookId}")]
        [ProducesResponseType(200, Type = typeof(ServiceResponse<bool>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteBook(int bookId)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState); 
            }
            var response = await _bookService.DeleteBook(bookId);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
