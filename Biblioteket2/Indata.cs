using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteket2
{
    class Indata
    {

        public static void EnterBook()
        {
            List<Book> Books = Data.GetData();     

            Console.WriteLine("\n\n----------------Ny Bok!------------");
           
            Console.WriteLine("Ange Titel:");
            String title= Console.ReadLine();

            Console.WriteLine("Ange Author:");
            String author= Console.ReadLine();

            Console.WriteLine("Ange InitialCount:");
            int initialCount= Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("välja bok typ skriv en sifra mellan 1-3");
            Console.WriteLine(" 1 .. Fictional \n 2 .. Children \n 3 .. Fact");

            Console.WriteLine("Ange bok type nummer:");
            int typeNo=  Convert.ToInt32(Console.ReadLine());
                switch (typeNo)
                {
                    case 1:
                        Console.WriteLine("Language:");
                        String language= Console.ReadLine();

                         Console.WriteLine("Published: 'Ange datum på format 2001-01-01'");
                         String strPublished= Console.ReadLine();
                         DateTime published= DateTime.Parse(strPublished);

                       // Stringl language= Console.ReadLine();
                        
                        Books.Add(new Fictional { Title = title, Author = author, Language = language, Published =published , Count = 5, InitialCount = 5 });

                        break;
                    case 2:
                        Console.WriteLine("Age:");
                        int age=  Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Pictures: Y/ N :");
                        String strPictures= Console.ReadLine();
                        bool pictures = false ;
                            if (strPictures.ToLower() == "y")
                            {
                            pictures = true;
                            } else if (strPictures.ToLower() == "n")
                            {
                            pictures = false;
                            }
                        
                       Books.Add(new Children { Title = title, Author = author, Age = age, Pictures = pictures, Count = initialCount, InitialCount = initialCount });
                        break;

                    case 3:
                       Console.WriteLine("Topic:");
                       String topic= Console.ReadLine();
                       Books.Add(new Fact { Title = title, Author = author, Topic = topic, Count = initialCount, InitialCount = initialCount });                     
                       break;                   
                }
              Data.SaveData(Books);

        }
       
        public static void RemoveBook(int id)
        {
            List<Book> Books = Data.GetData(); 
            if(id==-1)
            {
                bool valid = false;
                do {
                    Console.WriteLine("Ange boknummer:");
                    string input = Console.ReadLine();
                    valid = int.TryParse(input, out id);
                } while(! valid);
            
            }

                

            Books.RemoveAt(id-1);
            Data.SaveData(Books);
        }

        }

    }
        
   
