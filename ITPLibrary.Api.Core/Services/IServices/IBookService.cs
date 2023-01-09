using ITPLibrary.Api.Core.Dtos;
using ITPLibrary.Api.Models;

namespace ITPLibrary.Api.Core.Services.IServices
{
    public interface IBookService
    {
        ServiceResponse<ICollection<BookDto>> GetBooks();
        ServiceResponse<ICollection<BookDto>> GetPopularBooks();
        ServiceResponse<BookDto> GetBook(int id);
        ServiceResponse<BookDto> GetBook(string title);
        ServiceResponse<AddBookDto> CreateBook(AddBookDto book);
        ServiceResponse<BookDto> UpdateBook(int bookId, AddBookDto book);
        ServiceResponse<bool> DeleteBook(int bookId);
    }
}
