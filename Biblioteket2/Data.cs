using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Biblioteket2
{
    class Data
    {
        public static List<Book> CreateData()
        {
            List<Book> BookList = new List<Book>();

            BookList.Add(new Fictional { Title = "Som pesten", Author = "Hanne-Vibeke Holst ", Language = "Svenska", Published = new DateTime(2018, 10, 2), Count = 5, InitialCount = 5 });
            BookList.Add(new Fictional { Title = "Professor Wille Vingmutter, mästerdetektiv", Author = "Leif G W Persson", Language = "Svenska", Published = new DateTime(2018, 06, 29), Count = 3, InitialCount = 3 });
            BookList.Add(new Children { Title = "Tsatsiki och farsan", Author = "Moni Nilson", Age = 8, Pictures = false, Count = 2, InitialCount = 2 });
            BookList.Add(new Children { Title = "Barnens sånger och sagor", Author = "Catarina Kruusval", Age = 3, Pictures = true, Count = 3, InitialCount = 3 });
            BookList.Add(new Fact { Title = "Liv 3.0 : att vara människa i den artificiella intelligensens tid ", Author = "Max Tegmark", Topic = "AI", Count = 4, InitialCount = 4 });
            BookList.Add(new Fact { Title = "Klockboken", Author = "Carl Hallvarsson", Topic = "Klockor", Count = 5, InitialCount = 5 });

            return BookList;
        }

        public static bool SaveData(List<Book> booklist)
        {
            string fileName = "library.json";

            var settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Objects,
                Formatting = Formatting.Indented
            };

            string json = JsonConvert.SerializeObject(booklist.ToArray(), settings);
            System.IO.File.WriteAllText(@"..\..\storage\" + fileName, json);

            return true;
        }

        public static List<Book> GetData()
        {
            string fileName = "library.json";
            string filepath = @"..\..\storage\" + fileName;

            List<Book> data;
            if (System.IO.File.Exists(filepath))
            {
                var settings = new JsonSerializerSettings()
                {
                    TypeNameHandling = TypeNameHandling.Objects
                };
                var json = System.IO.File.ReadAllText(filepath);
                data = JsonConvert.DeserializeObject<List<Book>>(json, settings);
            }
            else
            {
                data = CreateData();
            }
            return data;
        }

        
    }
}
