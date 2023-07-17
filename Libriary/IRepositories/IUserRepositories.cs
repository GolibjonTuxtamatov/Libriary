using Libriary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libriary.IRepositories
{
    public interface IUserRepositories
    {
        public User GetUser(string login,string password);

        public void Delete(string login,string password);

        public void Update(string login ,string password);

        public IEnumerable<User> GetAll();

        public IEnumerable<Book> GetAllBooks();

        public void GetUserBook(string bookName, string login,string password);
    }
}
