using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Diagnostics.Tracing;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization.Formatters;

namespace Laba_8
{
    class Using
    {
        public int elementD { get; set; }
        public Using(int elem)
        {
            this.elementD = elem;
        }
    }

    interface IRule<T>
    {
        void Add(T element);
        void Delete(int element);
        void Output();
    }

    interface IRuleHere<Using>
    {
        void AddD(Using element);
    }

    public class Lists<T> : IRule<T>
    {
        List<T> someList = new List<T>(); //выделение памяти списка
        public Lists() //конструктор списка
        {
            List<T> someList = new List<T>();
        }
        public void Add(T element) //метод добавления элемента в список
        {
            someList.Add(element);
        }
        public void Output() //метод вывода списка
        {
            foreach (T i in someList)
            {
                Console.WriteLine(i);
            }
        }
        public void Delete(int element) //метод удаления элемента из списка
        {
            someList.RemoveAt(element);
        }
    }
    public class ListT<Using> : IRuleHere<Using> where Using : class
    {
        List<Using> someList1 = new List<Using>(); //выделение памяти списка
        public ListT() //конструктор списка
        {
            List<Using> someList1 = new List<Using>();
        }
        public void AddD(Using element) //метод добавления элемента в список
        {
            someList1.Add(element);
        }
        public void OutputT(int element) //метод вывода списка
        {
            Console.WriteLine(element);
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Cписок с целыми числами:");
                Lists<int> list1 = new Lists<int>();

                list1.Add(3);
                list1.Add(5);
                list1.Add(1);
                list1.Add(6);
                list1.Output();
                Console.WriteLine();
                list1.Delete(1);
                list1.Output();
                Console.WriteLine();

                Console.WriteLine("Cписок со строковыми параметрами:");
                Lists<string> list2 = new Lists<string>();

                list2.Add("a");
                list2.Add("ab");
                list2.Add("abc");
                list2.Add("abcd");
                list2.Output();
                Console.WriteLine();
                list2.Delete(1);
                list2.Output();
                Console.WriteLine();

                Console.WriteLine("Cписок со  пользовательский класс в качестве параметра обобщения:");
                ListT<Using> list3 = new ListT<Using>();
                int Use = 32;
                Using use = new Using(Use);
                list3.AddD(use);
                list3.OutputT(use.elementD);
                Console.WriteLine();

                string path = @"C:\Кирилл\text.txt";
                FileInfo fileInf = new FileInfo(path);
                if (fileInf.Exists)
                {
                    Console.WriteLine($"Имя файла: {fileInf.Name}");
                    Console.WriteLine($"Время создания: {fileInf.CreationTime}");
                    Console.WriteLine($"Размер: {fileInf.Length}");
                }
                using (StreamWriter file = new StreamWriter(path, false, System.Text.Encoding.Default))
                {
                    file.WriteLine("Работа с файлом:");
                    file.WriteLine("Объект обобщённого типа:");
                    file.WriteLine(use.elementD);
                }
                Console.WriteLine();
                using (StreamReader file = new StreamReader(path, System.Text.Encoding.Default))
                {
                    string line;
                    while ((line = file.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }

                Console.WriteLine();
            }
            catch (FormatException) { Console.WriteLine("Внимание! Неверный ввод. Попробуйте ещё раз."); }
            finally { Console.WriteLine("Finally!"); }
        }
    }
}
