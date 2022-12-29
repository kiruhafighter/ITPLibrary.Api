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
    public class BookRepository : Repository<Book>, IBookRepository
    {
        private ApplicationDbContext _db;

        public BookRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Book obj)
        {
            //_db.Entry<Book>(obj).State = EntityState.Detached;
            _db.Books.Update(obj);
        }
    }
}
