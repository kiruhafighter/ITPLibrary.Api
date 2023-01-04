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
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public ICollection<BookDto> GetBooks()
        {
            return _mapper.Map<List<BookDto>>(_bookRepository.GetBooks());
        }

        public ICollection<BookDto> GetPopularBooks()
        {
            return _mapper.Map<List<BookDto>>(_bookRepository.GetPopularBooks());
        }

        public BookDto GetBook(int id)
        {
            if (!_bookRepository.BookExists(id))
            {
                return null;
            }
            return _mapper.Map<BookDto>(_bookRepository.GetBook(id));
        }

        public BookDto GetBook(string title)
        {
            var book = _bookRepository.GetBook(title);
            if(book == null)
            {
                return null;
            }
            return _mapper.Map<BookDto>(book);
        }

        public BookDto CreateBook (BookDto book)
        {
            if(book == null)
            {
                return null;
            }
            var bookMap = _mapper.Map<Book>(book);
            if (!_bookRepository.CreateBook(bookMap))
            {
                return null;
            }
            return book;
        }

        public BookDto UpdateBook (int bookId, BookDto book)
        {
            if(book == null)
            {
                return null;
            }
            if(!_bookRepository.BookExists(bookId))
            {
                return null;
            }
            if(bookId != book.Id)
            {
                return null;
            }
            var bookMap = _mapper.Map<Book>(book);
            if (!_bookRepository.UpdateBook(bookMap))
            {
                return null;
            }
            return book;
        }
    }
}
