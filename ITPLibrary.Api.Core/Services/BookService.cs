using AutoMapper;
using ITPLibrary.Api.Core.Dtos;
using ITPLibrary.Api.Core.Services.IServices;
using ITPLibrary.Api.Data.Repository.IRepository;
using ITPLibrary.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITPLibrary.Api.Core.Services
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BookService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<BookDto> GetPopularBooks()
        {
            var popularBooks = _mapper.Map<List<BookDto>>(_unitOfWork.Book.GetAllWithCondition(n => n.PopularityRate > 9).ToList());
            return popularBooks;
        }

        public IEnumerable<BookDto> GetAllBooks()
        {
            var allBooks = _mapper.Map<List<BookDto>>(_unitOfWork.Book.GetAll().ToList());
            return allBooks;
        }

        public BookDto GetByName(string name)
        {
            var bookByName = _mapper.Map<BookDto>(_unitOfWork.Book.GetFirstOrDefault(b => b.Title == name));
            if (bookByName == null)
            {
                return null;
            }
            return bookByName;
        }

        public BookDto GetById(int id)
        {
            var bookById = _mapper.Map<BookDto>(_unitOfWork.Book.GetFirstOrDefault(b => b.Id == id));
            if (bookById == null)
            {
                return null;
            }
            return bookById;
        }

        public BookDto Post(Book book)
        {
            if (book == null || book.Id != 0)
            {
                return null;
            }
            _unitOfWork.Book.Add(book);
            _unitOfWork.Save();
            return _mapper.Map<BookDto>(book);
        }

        public BookDto Delete(int id)
        {
            var bookFromDb = _unitOfWork.Book.GetFirstOrDefault(b => b.Id == id);
            if(bookFromDb== null)
            {
                return null;
            }
            _unitOfWork.Book.Remove(bookFromDb);
            _unitOfWork.Save();
            return _mapper.Map<BookDto>(bookFromDb);
        }
        

        public BookDto Delete(string name)
        {
            var bookFromDb = _unitOfWork.Book.GetFirstOrDefault(b => b.Title == name);
            if (bookFromDb == null)
            {
                return null;
            }
            _unitOfWork.Book.Remove(bookFromDb);
            _unitOfWork.Save();
            return _mapper.Map<BookDto>(bookFromDb);
        }

        public BookDto Update(int id, string title, double price, string author, double popularRate)
        {
            var bookToUpdate = _unitOfWork.Book.GetFirstOrDefault(b => b.Id == id);
            if (bookToUpdate == null)
            {
                return null;
            }
            bookToUpdate.Title = title;
            bookToUpdate.Price = price;
            bookToUpdate.Author = author;
            bookToUpdate.Thumbnail = " ";
            bookToUpdate.PopularityRate = popularRate;
            if (bookToUpdate.AddingTime < DateTime.Now.AddDays(-14))
            {
                bookToUpdate.RecentlyAdded = true;
            }
            else
            {
                bookToUpdate.RecentlyAdded = false;
            }
            _unitOfWork.Book.Update(bookToUpdate);
            _unitOfWork.Save();
            return _mapper.Map<BookDto>(bookToUpdate);
        }

        //???The instance of entity type 'Book' cannot be tracked because another
        //instance with the same key value for {'Id'} is already being tracked???
        //public BookDto Update(int id, Book book)
        //{
        //    if (BookExists(id))
        //    {
        //        _unitOfWork.Book.Update(book);
        //        _unitOfWork.Save();
        //        return _mapper.Map<BookDto>(book);
        //    }
        //    return null;
        //}


        public BookDto Update(int id, BookDto book)
        {
            if (BookExists(id))
            {
                var bookToUpdate = _unitOfWork.Book.GetFirstOrDefault(b => b.Id == id);
                bookToUpdate.Title = book.Title;
                bookToUpdate.Price = book.Price;
                bookToUpdate.Author = book.Author;
                bookToUpdate.PopularityRate = book.PopularityRate;
                _unitOfWork.Book.Update(bookToUpdate);
                _unitOfWork.Save();
                return _mapper.Map<BookDto>(bookToUpdate);
            }
            return null;
        }


        //???The instance of entity type 'Book' cannot be tracked because another
        //instance with the same key value for {'Id'} is already being tracked???
        //public BookDto Update(int id, BookDto book)
        //{
        //    if (BookExists(id))
        //    {
        //        book.Id = id;
        //        _unitOfWork.Book.Update(_mapper.Map<Book>(book));
        //        _unitOfWork.Save();
        //        return book;
        //    }
        //    return null;
        //}

        public bool BookExists (int id)
        {
            var book = _unitOfWork.Book.GetFirstOrDefault(b => b.Id == id);
            if(book == null)
            {
                return false;
            }
            return true;
        }
    }
}
