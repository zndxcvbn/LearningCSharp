using System.Diagnostics.Metrics;
using System.Xml.Linq;

namespace Lesson5
{
    internal class Program
    {
        private static List<Abonent> dataBase = new List<Abonent>();

        private static void DeleteNumber(int id)
        {
            dataBase.RemoveAt(id);
        }

        private static void CreateNumber( int id, string name, long number, string country )
        {
            dataBase.Add(new Abonent(id, name, number, country));
        }

        private static void WriteToFile()
        {
            string path = @"C:\Users\artem\Desktop\PhoneNumber_Database.txt";

            using (StreamWriter stream = new StreamWriter(path, true))
            {
                stream.WriteLine("asdasd");
            }
        }

        private static void ShowDatabase()
        {
            foreach (Abonent el in dataBase)
            {
                Console.WriteLine(el.id + "\t" + el.Year + "\t" + el.Sex + "\t" + el.YearsOld);
            }
        }



        static void Main(string[] args)
        {
            Console.WriteLine("База данных номеров телефонов");
            CreateNumber(1, "Artem Medvedev", 79195046481, "Russian");
            ShowDatabase();
        }
    }
}