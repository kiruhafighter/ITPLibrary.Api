using ITPLibrary.Api.Models;

namespace ITPLibrary.Api.Data.Repository.IRepository
{
    public interface IBookRepository 
    {
        Task<ICollection<Book>> GetBooks();
        Task<Book> GetBook(int id);
        Task<Book> GetBook(string title);
        Task<ICollection<Book>> GetPopularBooks();
        Task<bool> BookExists(int id);
        Task<bool> CreateBook(Book book);
        Task<bool> UpdateBook(Book book);
        Task<bool> DeleteBook(Book book);
        Task<bool> Save();
    }
}
