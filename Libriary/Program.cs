using Libriary.Constans;
using Libriary.IRepositories;
using Libriary.Models;
using Libriary.Panel;
using Libriary.Repositories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Libriary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("1.AdminPanel  2.UserPanel: ");
            int commadNum = int.Parse(Console.ReadLine());
            if (commadNum == 1)
            {
                AdminPanel adminPanel = new AdminPanel();
                adminPanel.Enterence();
            }
            else if (commadNum == 2)
            {
                UserPanel userPanel = new UserPanel();
                userPanel.Enterence();
            }
            else if (commadNum == 3)
            {
                UserPanel userPanel = new UserPanel();
                userPanel.Exit();
            }
            //string login = "admin";
            //string password = "admincha";
            //string jsonUser = File.ReadAllText(Constants.UserJsonPath);

            //IList<User> users = JsonConvert.DeserializeObject<IList<User>>(jsonUser);

            //User user = users.FirstOrDefault(p => p.Login == login && p.Password == password);

            //string jsonBook = File.ReadAllText(Constants.BookJsonPath);
            //IList<Book> books = JsonConvert.DeserializeObject<IList<Book>>(jsonBook);
            //Book book = books.FirstOrDefault(p => p.BookName == "Shum bola");

            //UserBook userBook = new UserBook();

            //userBook.BookName = book.BookName;
            //userBook.Author = book.Author;


            //if (user.UserBooks.Contains(userBook))
            //    Console.WriteLine("Ok");
            //else Console.WriteLine("Null");

            //IList<UserBook> userBooks = user.UserBooks;
            //foreach(UserBook book1 in userBooks)
            //{
            //    Console.WriteLine(book.BookName);
            //}



        }


    }
}
