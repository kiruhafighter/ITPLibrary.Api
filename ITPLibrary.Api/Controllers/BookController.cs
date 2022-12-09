using ITPLibrary.Api.Data.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ITPLibrary.Api.Models;
using ITPLibrary.Api.Data.Repository.IRepository;

namespace ITPLibrary.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public BookController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("getpopularbooks")]
        public IEnumerable<Book> GetPopularBooks()
        {
            var popularBooks = _unitOfWork.Book.GetAllWithCondition(n => n.PopularityRate > 9).ToList();
            return popularBooks;
        }

        [HttpGet]
        [Route("getallbooks")]
        public IEnumerable<Book> GetAllBooks()
        {
            var allBooks = _unitOfWork.Book.GetAll().ToList();
            return allBooks;
        }

        [HttpGet("name")]
        public IActionResult GetByName(string name)
        {
            var bookById = _unitOfWork.Book.GetFirstOrDefault(b=>b.Title== name);
            if(bookById == null)
            {
                return NotFound();
            }
            return Ok(bookById);
        }

        [HttpPost("book")]
        public IActionResult Post(Book book)
        {
            if (book != null && book.Id == 0)
            {
                _unitOfWork.Book.Add(book);
                _unitOfWork.Save();
                return Ok(book);
            }
            else
            {
                return BadRequest("Wrong values. Remember : Values except 'id' cannot be null. You cannot assign a value to the 'id' field");
            }
        }

        [HttpDelete("id")]
        public IActionResult Delete(int id)
        {
            if(id==null || id==0)
            {
                return BadRequest("These is no book with a such 'id'");
            }
            var bookFromDb = _unitOfWork.Book.GetFirstOrDefault(b => b.Id == id);
            if(bookFromDb == null)
            {
                return NotFound();
            }
            _unitOfWork.Book.Remove(bookFromDb);
            _unitOfWork.Save();
            return Ok($"{bookFromDb.Title} deleted succesfully");
        }

        [HttpDelete("name")]
        public IActionResult Delete(string name)
        {
            if (name == null || name == "")
            {
                return BadRequest("These is no book with a such 'name'");
            }
            var bookFromDb = _unitOfWork.Book.GetFirstOrDefault(b => b.Title == name);
            if (bookFromDb == null)
            {
                return NotFound();
            }
            _unitOfWork.Book.Remove(bookFromDb);
            _unitOfWork.Save();
            return Ok($"{bookFromDb.Title} deleted succesfully");
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Book book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }
            _unitOfWork.Book.Update(book);
            _unitOfWork.Save();
            return Ok("Book information updated succesfully");
        }




    }
}
