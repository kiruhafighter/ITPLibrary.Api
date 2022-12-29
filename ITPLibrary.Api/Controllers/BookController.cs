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
        [Route("getpopularbooks")]
        public IEnumerable<BookDto> GetPopularBooks()
        {
            return _bookService.GetPopularBooks();
        }

        [HttpGet]
        [Route("getallbooks")]
        public IEnumerable<BookDto> GetAllBooks()
        {
            return _bookService.GetAllBooks();
        }

        [HttpGet("name")]
        public IActionResult GetByName(string name)
        {
            if (name == null || name.Length == 0)
            {
                return BadRequest();
            }
            if(_bookService.GetByName(name) == null)
            {
                return NotFound();
            }
            return Ok(_bookService.GetByName(name));
        }

        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            if (id == null || id == 0)
            {
                return BadRequest();
            }
            if (_bookService.GetById(id) == null)
            {
                return NotFound();
            }
            return Ok(_bookService.GetById(id));
        }

        [HttpPost("book")]
        public IActionResult Post(Book book)
        {
            var bookToPost = _bookService.Post(book);
            if (bookToPost == null)
            {
                return BadRequest();
            }
            return Ok(bookToPost);
        }

        [HttpDelete("id")]
        public IActionResult Delete(int id)
        {
            if (id == null || id == 0)
            {
                return BadRequest();
            }
            var bookToDelete = _bookService.Delete(id);
            if (bookToDelete == null)
            {
                return NotFound();
            }
            return Ok(bookToDelete);
        }

        [HttpDelete("name")]
        public IActionResult Delete(string name)
        {
            if (name == null || name.Length == 0)
            { 
                return BadRequest();
            }
            var bookToDelete = _bookService.Delete(name);
            if (bookToDelete == null)
            {
                return NotFound();
            }
            return Ok(bookToDelete);
        }

        //Old Put Method version
        [HttpPut("{id}")]
        public IActionResult Update(int id, BookDto book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var bookToUpdate = _bookService.Update(id, book);
            if(bookToUpdate == null)
            {
                return NotFound();
            }
            return Ok(bookToUpdate);
        }


        //[HttpPut("{id}")]
        //public IActionResult Update(int id, string title, double price, string author, double popularRate)
        //{
        //    var bookToUpdate = _bookService.Update(id, title, price, author, popularRate);
        //    if (bookToUpdate == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(bookToUpdate);
        //}


    }
}
