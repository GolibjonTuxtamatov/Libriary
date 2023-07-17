using Libriary.Constans;
using Libriary.IRepositories;
using Libriary.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libriary.Repositories
{
    public class BookRepository : IBookRepository
    {

        public void AddNewBook(Book book)
        {
            string bookJson = File.ReadAllText(Constants.BookJsonPath);
            ICollection<Book> books = JsonConvert.DeserializeObject<ICollection<Book>>(bookJson);

            books.Add(book);
            string result = JsonConvert.SerializeObject(books);
            File.WriteAllText(Constants.BookJsonPath,result);
        }
    }
}
