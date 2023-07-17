using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libriary.Models
{
    public class UserBook
    {
        public string BookName { get; set; }

        public string Author { get; set; }

        public int BookCount { get; set; } = 0;
    }
}
