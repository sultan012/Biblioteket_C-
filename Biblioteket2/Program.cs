using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteket2
{
    class Program
    {
        static void Main(string[] args)
        {
            IdAction ia = new IdAction();

           

            while (true)
            {
                 List<Book> Books = Data.GetData();
                // Presenterar vald bok, eller alla böcker om ia.id = -1

                Presentation.ViewBooks(Books, ia.id);
                
                    

                // Väntar på tangenttryckning och returnerar id och action
                ia = UI.Input(ia.id);
                if(ia.action != "show" )
                {
                    Books[ia.id] = Transactions.LendReturn(Books[ia.id], ia.action);
                    Data.SaveData(Books);

                    
                }
            }

            
        }
    }
}
