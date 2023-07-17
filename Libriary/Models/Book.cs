using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libriary.Models
{
    public class Book
    {
        public Guid BookId { get; set; } = Guid.NewGuid();

        public string BookName { get; set; }

        public string Author { get; set; }

        public int BookCount { get; set; } = 0;
    }
}
