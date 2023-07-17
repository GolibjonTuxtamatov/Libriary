using Libriary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libriary.IRepositories
{
    public interface ISignIn
    {
        public bool EnteranceUser (string login, string password);

    }
}
