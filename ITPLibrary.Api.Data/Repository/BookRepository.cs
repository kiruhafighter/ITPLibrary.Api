using ITPLibrary.Api.Data.Data;
using ITPLibrary.Api.Data.Repository.IRepository;
using ITPLibrary.Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITPLibrary.Api.Data.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _context;

        public BookRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool BookExists(int id)
        {
            return _context.Books.Any(b => b.Id == id);
        }

        public ICollection<Book> GetBooks()
        {
            return _context.Books.ToList();
        }

        public Book GetBook (int id)
        {
            return _context.Books.SingleOrDefault(b => b.Id == id);
        }

        public Book GetBook (string title)
        {
            return _context.Books.FirstOrDefault(b => b.Title == title);
        }

        public ICollection<Book> GetPopularBooks()
        {
            return _context.Books.Where(b => b.PopularityRate > 9).ToList();
        }

        public bool CreateBook(Book book)
        {
            _context.Books.Add(book);
            return Save();
        }

        public bool UpdateBook(Book book)
        {
            _context.Books.Update(book);
            return Save();
        }

        public bool DeleteBook(Book book)
        {
            _context.Remove(book);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
