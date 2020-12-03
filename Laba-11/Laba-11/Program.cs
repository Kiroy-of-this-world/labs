using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_11
{
    class Model
    {
        public string Name { get; set; }
        public string Corp { get; set; }
    }
    class Corp
    {
        public string Name { get; set; }
        public string Country { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string[] months = { "January", "February", "March", "April", "May",
                "June", "July", "August", "September", "October", "Novenber", "December" };
            string[] massiv = { "January", "February", "June", "July", "August", "December" };

            Console.WriteLine("Исходный:");
            foreach (string str in months)
                Console.Write(str + "; ");
            Console.Write("\nВведите количество букв в слове: ");//по колличеству букв
            int length = Convert.ToInt32(Console.ReadLine());
            var query1 = months.Where(p => p.Length == length);
            foreach (string str in query1)
                Console.Write(str + "; ");
            Console.WriteLine();

            Console.WriteLine("Летние и зимние:");
            var query2 = months.Intersect<string>(massiv);//находим пересечение между двумя массивами
            foreach (string str in query2)
                Console.Write(str + "; ");
            Console.WriteLine();

            Console.WriteLine("По алфавиту:");
            var query3 = from p in months//по порядку
                         orderby p
                         select p;
            foreach (string str in query3)
                Console.Write(str + "; ");
            Console.WriteLine();

            Console.WriteLine("Месяцы содержащее u и длинной больше 4:");
            var query4 = from p in months//содержащее u и больше 4
                         where p.Length > 4 & p.Contains("u")
                         select p;
            foreach (string str in query4)
                Console.Write(str + "; ");
            Console.WriteLine();
            Console.WriteLine();

            var specialquery = months
                .Intersect<string>(massiv)  //возвращает пересечение двух коллекций, то есть те элементы, которые встречаются в обоих коллекциях
                .Where(p => p.Contains("ary"))
                .OrderBy(p => p).ThenByDescending(p => p.Contains("f")) //сортирует по убыванию и дополнительному параметру
                .Skip(1); //пропускает n элементов, и возвращает последующие
            foreach (string str in specialquery)
                Console.Write(str + "; ");
            Console.WriteLine();
            Console.WriteLine();

            List<Corp> teams = new List<Corp>()
            {
                new Corp { Name = "Apple", Country ="США" },
                new Corp { Name = "Xiaomi", Country ="Китай" }
            };
            List<Model> players = new List<Model>()
            {
                new Model {Name="iPhone", Corp="Apple"},
                new Model {Name="Mi", Corp="Xiaomi"},
                new Model {Name="Redmi", Corp="Xiaomi"}
            };
            var result = players.Join(teams, // второй набор
                p => p.Corp, // свойство-селектор объекта из первого набора
                t => t.Name, // свойство-селектор объекта из второго набора
                (p, t) => new { Name = p.Name, Team = p.Corp, Country = t.Country }); // результат
            foreach (var item in result)
                Console.WriteLine($"{item.Name} - {item.Team} ({item.Country})");
            Console.WriteLine();
            Console.WriteLine();

            List<Bus> mass = new List<Bus>();
            Bus mas1 = new Bus(2);
            Bus mas2 = new Bus(3);
            Bus mas3 = new Bus(4);
            Bus mas4 = new Bus(4);
            mass.Add(mas1);
            mass.Add(mas2);
            mass.Add(mas3);
            mass.Add(mas4);
            Console.WriteLine("Исходные:");
            mas1.Output();
            Console.WriteLine();
            mas2.Output();
            Console.WriteLine();
            mas3.Output();
            Console.WriteLine();
            mas4.Output();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Массив только с чётными элементами:");
            var myquery1 = mass.Where(n => n.Even() == 0);
            foreach (Bus str in myquery1)
                str.Output();
            Console.WriteLine("\n");

            Console.WriteLine("Массив с наибольшей суммой элементов:");
            var mquery2 = mass.Max(n => n.Sum());
            var myquery2 = from n in mass
                           where (n.Sum() >= mquery2)
                           select n;
            foreach (Bus str in myquery2)
                str.Output();
            Console.WriteLine("\n");

            Console.WriteLine("Минимальный массив:");
            var mquery3 = mass.Min(n => n.quantity);
            var myquery3 = from n in mass
                           where (n.quantity <= mquery3)
                           select n;
            foreach (Bus str in myquery3)
                str.Output();
            Console.WriteLine("\n");

            Console.WriteLine("Массивы с элементом '4':");
            var myquery4 = from n in mass
                           where n.Contains(4)
                           select n;
            foreach (Bus str in myquery4)
                str.Output();
            Console.WriteLine("\n");
            var mquery4 = mass.Count(n => n.Contains(4));
            Console.WriteLine($"Количество с элементом '4': {mquery4}");

            List<Bus> s = new List<Bus>();
            Bus s1 = new Bus(mass.Count);
            for (int i = 0; i< mass.Count - 1; i++)
            {
                for (int j = 0; j < mass.Count; j++)
                {
                    int y = mass[i].CompareTo(mass[j]);
                    s1.array[j] = y;

                }
            }
            s.Add(s1);
            var mquery5 = s.Count(n => n.Contains(0));
            Console.WriteLine($"Количество равных массивов: {mquery5 + 1}");
            Console.WriteLine();

            Console.WriteLine("Упорядоченный список массивов по первому элементу:");
            var myquery6 = mass.OrderBy(p => p.array[1]);
            foreach (Bus str in myquery6)
                str.Output();
            Console.WriteLine("\n");

        }
    }
}
