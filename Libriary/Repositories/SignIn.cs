using Libriary.Constans;
using Libriary.IRepositories;
using Libriary.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Libriary.Repositories
{
    public class SignIn : ISignIn
    {
        public bool EnteranceUser(string login, string password)
        {
            string json = File.ReadAllText(Constants.UserJsonPath);
            ICollection<User> users = JsonConvert.DeserializeObject<ICollection<User>>(json);
            var user = users.FirstOrDefault(p => p.Login == login && p.Password == password);
            return users.Contains(user);
            
        }
    }
}
