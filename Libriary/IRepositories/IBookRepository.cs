using Libriary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libriary.IRepositories
{
    public interface IBookRepository
    {
        public void AddNewBook(Book book);
    }
}
