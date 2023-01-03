using ITPLibrary.Api.Core.Dtos;
using ITPLibrary.Api.Models;

namespace ITPLibrary.Api.Core.Services.IServices
{
    public interface IBookService
    {
        IEnumerable<BookDto> GetPopularBooks();
        IEnumerable<BookDto> GetAllBooks();
        BookDto GetByName(string name);
        BookDto GetById(int id);
        BookDto Post(Book book);
        BookDto Delete(int id);
        BookDto Delete(string name);
        BookDto Update(int id, string title, double price, string author, double popularRate);
        BookDto Update(int id, BookDto book);
        BookDto Update (BookDto book);
        bool BookExists(int id);

    }
}
