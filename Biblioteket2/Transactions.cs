using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteket2
{
    class Transactions
    {
        public static Book LendReturn(Book book, string action)
        {
            if(action == "lend" && book.Count > 0)
            {
                book.Count--;
            }
            if(action == "return" && book.InitialCount > book.Count)
            {
                book.Count++;
            }
            return book;
        }
    }
}
