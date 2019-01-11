using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Script.Serialization;

namespace Biblioteket2
{
    class Data
    {
        private static readonly string FilePath = @"ERAN SÖKVÄG TILL FILEN\library.json";

        public static List<Book> CreateData()
        {
            List<Book> BookList = new List<Book>
           {
               new Fictional { Title = "Som pesten", Author = "Hanne-Vibeke Holst ", Language = "Svenska", Published = new DateTime(2018, 10, 2), Count = 5, InitialCount = 5 },
               new Fictional { Title = "Professor Wille Vingmutter, mästerdetektiv", Author = "Leif G W Persson", Language = "Svenska", Published = new DateTime(2018, 06, 29), Count = 3, InitialCount = 3 },
               new Children { Title = "Tsatsiki och farsan", Author = "Moni Nilson", Age = 8, Pictures = false, Count = 2, InitialCount = 2 },
               new Children { Title = "Barnens sånger och sagor", Author = "Catarina Kruusval", Age = 3, Pictures = true, Count = 3, InitialCount = 3 },
               new Fact { Title = "Liv 3.0 : att vara människa i den artificiella intelligensens tid ", Author = "Max Tegmark", Topic = "AI", Count = 4, InitialCount = 4 },
               new Fact { Title = "Klockboken", Author = "Carl Hallvarsson", Topic = "Klockor", Count = 5, InitialCount = 5 },
               new Horror { Title = "The Shining", Author = "Stephen King", Serialkiller = "Jack Nicholson", Count = 8, InitialCount = 8 }
           };

            if (SaveData(BookList))
                Console.WriteLine("New data saved!");
            else
                Console.WriteLine("The data was not saved!");

            return BookList;
        }

        public static bool SaveData(List<Book> booklist)
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            string json = ser.Serialize(booklist);

            try
            {
                File.WriteAllText(FilePath, json);
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be written to:");
                Console.WriteLine(e.Message);
            }

            return true;
        }

        public static List<Book> GetData()
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            string json = string.Empty;
            List<Book> listOfBooks = new List<Book>();

            if (File.Exists(FilePath))
            {
                try
                {
                    using (StreamReader sr = new StreamReader(FilePath))
                    {
                        string line;

                        while ((line = sr.ReadLine()) != null)
                        {
                            json += line;
                        }
                    }
                    listOfBooks = ser.Deserialize<List<Book>>(json);
                }
                catch (Exception e)
                {
                    Console.WriteLine("The file could not be read:");
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                listOfBooks = CreateData();
            }

            return listOfBooks;
        }
    }
}
Sorry, glömde skicka ut return false; i SaveData när den inte spara, så här ska det självklart vara.
public static bool SaveData(List<Book> booklist)
{
    JavaScriptSerializer ser = new JavaScriptSerializer();
    string json = ser.Serialize(booklist);

    try
    {
        File.WriteAllText(FilePath, json);
    }
    catch (Exception e)
    {
        Console.WriteLine("The file could not be written to:");
        Console.WriteLine(e.Message);
        return false;
    }

    return true;
}