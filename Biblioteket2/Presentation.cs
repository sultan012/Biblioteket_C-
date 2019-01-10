using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteket2
{
    class Presentation
    {
        public static void ViewBooks(List<Book> BookList, int bookid)
        {
            Console.Clear();
            int c = 0;
            if (bookid == -1)
            {
                foreach (var book in BookList)
                {
                    c++;
                    Console.WriteLine($"{c}\t{book.Count} stycken({book.InitialCount})\t{book.Title}({book.Author})");
                }
            }
            else
            {
                Console.WriteLine($"{BookList[bookid].Title}\r\n{BookList[bookid].Author} ");

                if (BookList[bookid] is Fictional)
                {
                    Console.WriteLine($"Språk: {((Fictional)BookList[bookid]).Language}");
                }

                if (BookList[bookid] is Children)
                {
                    Console.WriteLine($"Bilderbok: {((Children)BookList[bookid]).Pictures}");
                }
                if (BookList[bookid] is Fact)
                {
                    Console.WriteLine($"Ämne: {((Fact)BookList[bookid]).Topic}");
                }
                Console.WriteLine($"Antal i biblioteket just nu: {BookList[bookid].Count} av {BookList[bookid].InitialCount}");

            }
           
        }
    }
}
