using ITPLibrary.Api.Data.Data;
using ITPLibrary.Api.Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITPLibrary.Api.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public IBookRepository Book { get; private set; }
        public UnitOfWork(ApplicationDbContext db) 
        {
            _db = db;
            Book = new BookRepository(_db);
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
