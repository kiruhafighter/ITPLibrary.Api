using AutoMapper;
using ITPLibrary.Api.Core.Dtos;
using ITPLibrary.Api.Core.Services.IServices;
using ITPLibrary.Api.Data.Repository.IRepository;
using ITPLibrary.Api.Models;

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

        public ServiceResponse<ICollection<BookDto>> GetBooks()
        {
            var serviceResponse = new ServiceResponse<ICollection<BookDto>>();
            serviceResponse.Data = _mapper.Map<List<BookDto>>(_bookRepository.GetBooks());
            return serviceResponse;
        }

        public ServiceResponse<ICollection<BookDto>> GetPopularBooks()
        {
            var serviceResponse = new ServiceResponse<ICollection<BookDto>>();
            serviceResponse.Data = _mapper.Map<List<BookDto>>(_bookRepository.GetPopularBooks());
            return serviceResponse;
        }

        public ServiceResponse<BookDto> GetBook(int id)
        {
            var serviceResponse = new ServiceResponse<BookDto>();
            if (!_bookRepository.BookExists(id))
            {
                serviceResponse.Success = false;
                serviceResponse.Message = $"Book with id {id} is not found";
            }
            else
            {
                serviceResponse.Data = _mapper.Map<BookDto>(_bookRepository.GetBook(id));
            }
            return serviceResponse;
        }

        public ServiceResponse<BookDto> GetBook(string title)
        {
            var serviceResponse = new ServiceResponse<BookDto>();
            var book = _bookRepository.GetBook(title);
            if(book == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = $"Book with title '{title}' is not found";
            }
            else
            {
                serviceResponse.Data = _mapper.Map<BookDto>(book);
            }
            return serviceResponse;
        }

        public ServiceResponse<AddBookDto> CreateBook (AddBookDto book)
        {
            var serviceResponse = new ServiceResponse<AddBookDto>();
            if(book == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Book value is inappropriate";
            }
            else
            {
                var bookMap = _mapper.Map<Book>(book);
                if (!_bookRepository.CreateBook(bookMap))
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Something went wrong while creating book";
                }
                else
                {
                    serviceResponse.Data = book;
                    serviceResponse.Message = "Book created successfully";
                }
            }
            return serviceResponse;
        }

        public ServiceResponse<BookDto> UpdateBook (int bookId, AddBookDto book)
        {
            var serviceResponse = new ServiceResponse<BookDto>();
            if(book == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Book value is inappropriate";
            }
            else if(!_bookRepository.BookExists(bookId))
            {
                serviceResponse.Success = false;
                serviceResponse.Message = $"Book with id {bookId} is not found";
            }
            else
            {
                var bookMap = _mapper.Map<Book>(book);
                bookMap.Id = bookId;
                if (!_bookRepository.UpdateBook(bookMap))
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = $"Something went wrong while updating book";
                }
                else
                {
                    serviceResponse.Data = _mapper.Map<BookDto>(bookMap);
                    serviceResponse.Message = "Book updated successfully";
                }
            }
            return serviceResponse;
        }

        public ServiceResponse<bool> DeleteBook(int bookId)
        {
            var serviceResponse = new ServiceResponse<bool>();
            if(bookId == null || bookId < 0)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Wrong id value";
            }
            else if (!_bookRepository.BookExists(bookId))
            {
                serviceResponse.Success = false;
                serviceResponse.Message = $"Book with id {bookId} is not found";
            }
            else
            {
                var book = _bookRepository.GetBook(bookId);
                if (!_bookRepository.DeleteBook(book))
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = $"Something went wrong while deleting";
                }
                else
                {
                    serviceResponse.Data = true;
                    serviceResponse.Message = "Book has been deleted successfully";
                }
            }
            return serviceResponse;
        }
    }
}
