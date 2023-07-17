using Libriary.Constans;
using Libriary.IRepositories;
using Libriary.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Libriary.Repositories
{
    public class UserRepositories : IUserRepositories
    {
        public void Delete(string login, string password)
        {
            string json = File.ReadAllText(Constants.UserJsonPath);
            List<User> users = JsonConvert.DeserializeObject<List<User>>(json);

            var user = users.FirstOrDefault(p =>p.Login == login && p.Password == password);
            users.RemoveAt(users.IndexOf(user));

            string result = JsonConvert.SerializeObject(users);
            File.WriteAllText(Constants.UserJsonPath, result);
        }

        public IEnumerable<User> GetAll()
        {

            string json = File.ReadAllText(Constants.UserJsonPath);
            List<User> users = JsonConvert.DeserializeObject<List<User>>(json);
            return users;
        }

        public IEnumerable<Book> GetAllBooks()
        {
            string booksJson = File.ReadAllText(Constants.BookJsonPath);

            ICollection<Book> books = JsonConvert.DeserializeObject<ICollection<Book>>(booksJson);

            return books;
        }

        public User GetUser(string login,string password)
        {
            string json = File.ReadAllText(Constants.UserJsonPath);
            IList<User> users = JsonConvert.DeserializeObject<IList<User>>(json);

            var user = users.FirstOrDefault(p => p.Login == login && p.Password == password);
            if (user == null)
                return null;
            return user;
        }

        public void GetUserBook(string bookName,string login,string password)
        {

            string json = File.ReadAllText(Constants.UserJsonPath);
            IList<User> users = JsonConvert.DeserializeObject<IList<User>>(json);

            var user = users.FirstOrDefault(p => p.Login == login && p.Password == password);

            string bookJson = File.ReadAllText(Constants.BookJsonPath);
            ICollection<Book> books = JsonConvert.DeserializeObject<ICollection<Book>>(bookJson);

            Book book = books.FirstOrDefault(p => p.BookName == bookName);
            UserBook userBook = new UserBook();

            userBook.BookName = book.BookName;
            userBook.Author = book.Author;
             string checkBookName = user.UserBooks.FirstOrDefault(p=>p.BookName == bookName).BookName;
            if (checkBookName!=null && book.BookCount > 0)
            {

                userBook.BookCount = +1;
                
                book.BookCount -= 1;
                Console.WriteLine("Added book your account!");
                string resultUser = JsonConvert.SerializeObject(users);
                File.WriteAllText(Constants.UserJsonPath, resultUser);
                string resultBook = JsonConvert.SerializeObject(books);
                File.WriteAllText(Constants.BookJsonPath, resultBook);
            }
            else
            {
                if (book.BookCount > 0)
                {
                    userBook.BookCount = +1;
                    user.UserBooks.Add(userBook);
                    book.BookCount -= 1;
                    Console.WriteLine("Added book your account!");
                    string resultUser = JsonConvert.SerializeObject(users);
                    File.WriteAllText(Constants.UserJsonPath, resultUser);
                    string resultBook = JsonConvert.SerializeObject(books);
                    File.WriteAllText(Constants.BookJsonPath, resultBook);
                }
                else
                {
                    Console.WriteLine("There is no this book in library nowadays!");
                }

            }
            
            
        }

        public void Update(string login ,string password)
        {
            string json = File.ReadAllText(Constants.UserJsonPath);
            List<User> users = JsonConvert.DeserializeObject<List<User>>(json);

            User user = users.FirstOrDefault(p => p.Login == login && p.Password == password);

            Console.Write("Enter the new name: ");
            user.Name = Console.ReadLine();
            Console.Write("Enter the new lastname: ");
            user.LastName = Console.ReadLine();
            Console.Write("Enter the new age: ");
            user.Age = int.Parse(Console.ReadLine());
            Console.Write("Enter the new phonenumber: ");
            user.PhoneNumber = Console.ReadLine();
            Console.Write("Enter the new login: ");
            user.Login = Console.ReadLine();
            Console.Write("Enter the new password: ");
            user.Password = Console.ReadLine();

            users.Add(user);

            string result = JsonConvert.SerializeObject(users);
            File.WriteAllText(result, Constants.UserJsonPath);




        }

        
    }
}
