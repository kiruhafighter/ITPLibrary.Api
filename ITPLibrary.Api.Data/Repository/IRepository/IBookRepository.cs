using ITPLibrary.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITPLibrary.Api.Data.Repository.IRepository
{
    public interface IBookRepository 
    {
        ICollection<Book> GetBooks();
        Book GetBook(int id);
        Book GetBook(string title);
        ICollection<Book> GetPopularBooks();
        bool BookExists(int id);
        bool CreateBook(Book book);
        bool UpdateBook(Book book);
        bool DeleteBook(Book book);
        bool Save();
    }
}
