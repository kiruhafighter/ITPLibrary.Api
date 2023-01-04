using ITPLibrary.Api.Core.Dtos;
using ITPLibrary.Api.Models;

namespace ITPLibrary.Api.Core.Services.IServices
{
    public interface IBookService
    {
        ICollection<BookDto> GetBooks();
        ICollection<BookDto> GetPopularBooks();
        BookDto GetBook(int id);
        BookDto GetBook(string title);
        BookDto CreateBook(BookDto book);
        BookDto UpdateBook(int bookId, BookDto book);

    }
}
