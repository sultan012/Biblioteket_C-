using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteket2
{
    class UI
    {
        public static IdAction Input(int PreviousId)
        {
            IdAction ia = new IdAction();
            ia.action = "show";
            int id = -1;


            string key = Console.ReadLine();

            bool success = int.TryParse(key, out id);

            if(!success)
            {
                ia.id = PreviousId;
                switch (key.ToLower())
                {
                    case "r":
                        ia.action = "return";
                        break;
                    case "l":
                        ia.action = "lend";
                        break;
                    case "n":
                        Indata.EnterBook();
                       
                        break;
                    case "d":
                       // BookList.RemoveAt(ia.id);
                        ia.action = "delete";
                        break;
                }

            }
            else
            {
                ia.id = id - 1;
            }

            return ia;
        }
    }
}
