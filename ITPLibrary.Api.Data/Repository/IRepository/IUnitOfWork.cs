using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITPLibrary.Api.Data.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IBookRepository Book { get; }


        void Save();
    }
}
