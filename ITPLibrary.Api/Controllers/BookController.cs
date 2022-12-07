using ITPLibrary.Api.Data.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace ITPLibrary.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public BookController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet(Name = "GetPopularBooks")]
        public IEnumerable<Book> Get()
        {
            var popularBooks = _db.Books.Where(n => n.PopularityRate > 7).ToList();
            return popularBooks;
        }
    }
}
