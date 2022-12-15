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
        private readonly IBookService _boorService;
        public BookController(IBookService boorService)
        {
            _boorService = boorService;
        }

        [HttpGet]
        [Route("getpopularbooks")]
        public IEnumerable<BookDto> GetPopularBooks()
        {
            return _boorService.GetPopularBooks();
        }

        [HttpGet]
        [Route("getallbooks")]
        public IEnumerable<BookDto> GetAllBooks()
        {
            return _boorService.GetAllBooks();
        }

        [HttpGet("name")]
        public IActionResult GetByName(string name)
        {
            if (name == null || name.Length == 0)
            {
                return BadRequest();
            }
            if(_boorService.GetByName(name) == null)
            {
                return NotFound();
            }
            return Ok(_boorService.GetByName(name));
        }

        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            if (id == null || id == 0)
            {
                return BadRequest();
            }
            if (_boorService.GetById(id) == null)
            {
                return NotFound();
            }
            return Ok(_boorService.GetById(id));
        }

        [HttpPost("book")]
        public IActionResult Post(Book book)
        {
            var bookToPost = _boorService.Post(book);
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
            var bookToDelete = _boorService.Delete(id);
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
            var bookToDelete = _boorService.Delete(name);
            if (bookToDelete == null)
            {
                return NotFound();
            }
            return Ok(bookToDelete);
        }

        //Old Put Method version
        //[HttpPut("{id}")]
        //public IActionResult Update(int id, Book book)
        //{
        //    if (book.Id == id || !ModelState.IsValid)
        //    { 
        //        return BadRequest();
        //    }
        //    var bookFromDb = _boorService.GetById(id);
        //    if(bookFromDb == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(_boorService.Update(id, book));
        //}


        [HttpPut("{id}")]
        public IActionResult Update(int id, string title, double price, string author, double popularRate)
        {
            var bookToUpdate = _boorService.Update(id, title, price, author, popularRate);
            if(bookToUpdate == null)
            {
                return NotFound();
            }
            return Ok(bookToUpdate);
        }


    }
}
