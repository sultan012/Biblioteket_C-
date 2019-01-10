using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteket2
{
    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Count { get; set; }
        public int InitialCount { get; set; }
    }
    class Fictional : Book
    {
        public DateTime Published{ get; set; }
        public string Language { get; set; }
    }
    class Children : Book
    {
        public int Age { get; set; }
        public bool Pictures { get; set; }
    }
    class Fact : Book
    {
        public string Topic { get; set; }
    }

    class IdAction
    {
        public int id { get; set; }
        public string action { get; set; }

        public IdAction()
        {
            this.id = -1;
        }
    }
}
