using Libriary.IRepositories;
using Libriary.Models;
using Libriary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libriary.Panel
{
    public class AdminPanel
    {
        public void Enterence()
        {
            Console.WriteLine("1.GetAllUser  2.AddNewBookInLibrary  3.Exit");
            Console.Write("Enter: ");
            int commandNum = int.Parse(Console.ReadLine());
            if (commandNum == 1)
            {
                IUserRepositories userRepositories = new UserRepositories();
                IEnumerable<User> users = userRepositories.GetAll();

                foreach (User user in users)
                {
                    Console.WriteLine(user.Name);
                    Console.WriteLine(user.LastName);
                    Console.WriteLine(user.Age);
                    Console.WriteLine(user.PhoneNumber);
                    Console.WriteLine(user.Login);
                    Console.WriteLine(user.Password);
                    
                    foreach (UserBook book in user.UserBooks)
                    {
                        Console.WriteLine(book.BookName +" "+book.Author);
                    }

                }
                Enterence();
            }
            else if (commandNum == 2)
            {
                Console.Write("Enter the book name: ");
                string bookName = Console.ReadLine();
                Console.Write("Enter the book author: ");
                string author = Console.ReadLine();
                Console.Write("Enter the book count: ");
                int bookCount = int.Parse(Console.ReadLine());
                Book book = new Book()
                {
                    BookName = bookName,
                    Author = author,
                    BookCount = bookCount

                };
                IBookRepository bookRepository = new BookRepository();
                bookRepository.AddNewBook(book);
                Enterence();
            }
            else if(commandNum == 3)
            {
                UserPanel userPanel = new UserPanel();
                userPanel.Exit();
            }
            
        }
    }
}
