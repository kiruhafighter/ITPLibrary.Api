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

        [HttpGet(Name = "GetPopularBooks")]
        public IEnumerable<Book> Get()
        {
            var popularBooks = _unitOfWork.Book.GetAllWithCondition(n => n.PopularityRate > 9).ToList();
            return popularBooks;
        }


    }
}
