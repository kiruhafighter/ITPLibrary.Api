using ITPLibrary.Api.Core.Dtos;
using ITPLibrary.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITPLibrary.Api.Core.Services.IServices
{
    public interface IBookService
    {
        IEnumerable<BookDto> GetPopularBooks();
        IEnumerable<BookDto> GetAllBooks();
        BookDto GetByName(string name);
        BookDto GetById(int id);
        BookDto Post(Book book);
        BookDto Delete(int id);
        BookDto Delete(string name);
        BookDto Update(int id, string title, double price, string author, double popularRate);
        BookDto Update(int id, Book book);
    }
}
