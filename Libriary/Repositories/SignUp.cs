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
    public class SignUp : ISignUp
    {
        public void Create(User user)
        {
            string json = File.ReadAllText(Constants.UserJsonPath);
            IList<User> users = JsonConvert.DeserializeObject<IList<User>>(json);
            
            if (!users.Where<User>(p => p.Login == user.Login && p.Password == user.Password).Any())
            {
                users.Add(user);
            }
            else
            {
                Console.WriteLine("There is User like this please choose other login or password!");
            }

            var result = JsonConvert.SerializeObject(users);

            File.WriteAllText(Constants.UserJsonPath, result);
        }

        
    }

}
