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
    public class UserPanel
    {
        
        public void Enterence()
        {
            //Console.Clear();
            Console.WriteLine("1.SignUp  2.SignIn  3.Exit");
            int enternce = int.Parse(Console.ReadLine());
            if (enternce == 1)
            {
                SignUp();
            }
            else if (enternce == 2)
            {
                SignIn();
            }
            else if (enternce == 3)
            {
                Exit();
            }
        }
        public void SignUp()
        {
            //Console.Clear();
            Console.Write("Enter your name:");
            string name = Console.ReadLine();
            Console.Write("Enter your lastname:");
            string lastname = Console.ReadLine();
            Console.Write("Enter your age:");
            int age = int.Parse(Console.ReadLine());
            Console.Write("Enter your phone number:(+998)");
            string phoneNumber = Console.ReadLine();
            Console.Write("Enter login:");
            string login = Console.ReadLine();
            Console.Write("Enter password (at least 8 characters):");
            string password = Console.ReadLine();
            User user = new User()
            {
                Name = name,
                LastName = lastname,
                Age = age,
                PhoneNumber = "+998" + phoneNumber,
                Login = login,
                Password = password

            };
            ISignUp signUp = new SignUp();
            signUp.Create(user);
            Enterence();

        }
        public void SignIn()
        {
            //Console.Clear();
            Console.Write("Etner login:");
            string login = Console.ReadLine();
            Console.Write("Enter password:");
            string password = Console.ReadLine();
            SignIn signIn = new SignIn();
            bool check = signIn.EnteranceUser(login, password);
            if (check)
            {
                //Console.Clear();
                Comands();

            }
            else
            {
                // Console.Clear();
                Console.WriteLine("There is no User like this!");
                Enterence();


            }

        }
        public void Comands()
        {
            Console.WriteLine("1.ShowAllBooksNames 2.DeleteYourAccount 3.UpdateYourAccount 4.GetBook 5.GetDataAboutYou 6.MainPage 7.Exit");
            Console.Write("Enter the comand number:");
            int enterence = int.Parse(Console.ReadLine());
            if (enterence == 1)
            {
                //Console.Clear();
                IUserRepositories userRepositories = new UserRepositories();

                IEnumerable<Book> books = userRepositories.GetAllBooks();

                foreach (Book book in books)
                {
                    Console.WriteLine(book.BookName + " " + book.Author);
                }
                Comands();

            }
            else if (enterence == 2)
            {
                IUserRepositories userRepositories = new UserRepositories();
                Console.Write("Enter the login: ");
                string login = Console.ReadLine();
                Console.Write("Enter the password: ");
                string password = Console.ReadLine();
                userRepositories.Delete(login, password);
                Console.WriteLine("Your account is deleted!");


                Enterence();
            }
            else if (enterence == 3)
            {
                IUserRepositories userRepositories = new UserRepositories();
                Console.Write("Enter the login: ");
                string login = Console.ReadLine();
                Console.Write("Enter the password: ");
                string password = Console.ReadLine();
                userRepositories.Update(login, password);

                Comands();
            }
            else if (enterence == 4)
            {
                IUserRepositories userRepositories = new UserRepositories();
                IEnumerable<Book> books = userRepositories.GetAllBooks();
                foreach (Book book in books)
                {
                    Console.WriteLine(book.BookName + " " + book.Author);
                }
                Console.Write("Enter the book name: ");
                string bookName = Console.ReadLine();
                Console.Write("Enter the login: ");
                string login = Console.ReadLine();
                Console.Write("Enter the password: ");
                string password = Console.ReadLine();
                userRepositories.GetUserBook(bookName, login, password);

                Comands();

            }
            else if (enterence == 5)
            {
                IUserRepositories userRepositories = new UserRepositories();
                Console.Write("Enter the login: ");
                string login = Console.ReadLine();
                Console.Write("Enter the password: ");
                string password = Console.ReadLine();
                User user = userRepositories.GetUser(login, password);
                Console.WriteLine(user.Name);
                Console.WriteLine(user.LastName);
                Console.WriteLine(user.Age);
                Console.WriteLine(user.PhoneNumber);
                Console.WriteLine(user.Login);
                Console.WriteLine(user.Password);

                Comands();

            }
            else if (enterence == 6)
            {
                Enterence();
            }
            else if (enterence == 7)
            {
                Exit();
            }
        }
        public void Exit()
        {
            return;
        }

        
    }
}
