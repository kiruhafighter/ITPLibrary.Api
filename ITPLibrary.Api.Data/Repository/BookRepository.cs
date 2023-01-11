using ITPLibrary.Api.Data.Data;
using ITPLibrary.Api.Data.Repository.IRepository;
using ITPLibrary.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace ITPLibrary.Api.Data.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _context;

        public BookRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> BookExists(int id)
        {
            return await _context.Books.AnyAsync(b => b.Id == id);
        }

        public async Task<ICollection<Book>> GetBooks()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book> GetBook (int id)
        {
            return await _context.Books.SingleOrDefaultAsync(b => b.Id == id);
        }

        public async Task<Book> GetBook (string title)
        {
            return await _context.Books.FirstOrDefaultAsync(b => b.Title == title);
        }

        public async Task<ICollection<Book>> GetPopularBooks()
        {
            return await _context.Books.Where(b => b.PopularityRate > 9).ToListAsync();
        }

        public async Task<bool> CreateBook(Book book)
        {
            _context.Books.Add(book);
            return await Save();
        }

        public async Task<bool> UpdateBook(Book book)
        {
            _context.Books.Update(book);
            return await Save();
        }

        public async Task<bool> DeleteBook(Book book)
        {
            _context.Remove(book);
            return await Save();
        }

        public async Task<bool> Save()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }
    }
}
