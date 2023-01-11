using ITPLibrary.Api.Core.Dtos;
using ITPLibrary.Api.Models;

namespace ITPLibrary.Api.Core.Services.IServices
{
    public interface IBookService
    {
        Task<ServiceResponse<ICollection<BookDto>>> GetBooks();
        Task<ServiceResponse<ICollection<BookDto>>> GetPopularBooks();
        Task<ServiceResponse<BookDto>> GetBook(int id);
        Task<ServiceResponse<BookDto>> GetBook(string title);
        Task<ServiceResponse<AddBookDto>> CreateBook(AddBookDto book);
        Task<ServiceResponse<BookDto>> UpdateBook(int bookId, AddBookDto book);
        Task<ServiceResponse<bool>> DeleteBook(int bookId);
    }
}
