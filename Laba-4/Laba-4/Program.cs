using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Laba_4
{
    public class Lists
    {
        List<int> someList = new List<int>(); //выделение памяти списка
        public Lists() //конструктор списка
        {
            List<int> someList = new List<int>();
        }
        public void Add(int element) //метод добавления элемента в список
        {
            someList.Add(element);
        }
        public void Output() //метод вывода списка
        {
            foreach (int i in someList)
            {
                Console.WriteLine(i);
            }
        }
        public void Delete(int element) //метод удаления элемента из списка
        {
            someList.RemoveAt(element);
        } 
        public int Count() //метод возвращает количество элементов списка
        {
            return someList.Count();

        }
        public int Element(int i) //метод возвращает элемент списка
        {
            if (someList[i] <= someList.Count()) return someList[i];
            else return someList[i];
        }
        public void Revers() //метод инверсии списка
        {
            someList.Reverse();
        }
        public static Lists operator +(Lists l1, Lists l2) //перегрузка оператора
        {
            var UnitedList = new Lists();
            for (int i = 0; i < l1.Count(); i++)
            {
                int element = l1.Element(i);
                UnitedList.Add(element);
            }
            for (int i = 0; i < l2.Count(); i++)
            {
                int element = l2.Element(i);
                UnitedList.Add(element);
            }
            return UnitedList;
        }
        public static Lists operator <(Lists l1, Lists l2) //перегрузка оператора
        {
            for (int i = 0; i < l2.Count(); i++)
            {
                int element = l2.Element(i);
                l1.Add(element);
            }
            return l1;
        }
        public static Lists operator >(Lists l1, Lists l2) //перегрузка оператора
        {
            for (int i = 0; i < l1.Count(); i++)
            {
                int element = l1.Element(i);
                l2.Add(element);
            }
            return l2;
        }
        public static Lists operator !(Lists l1) //перегрузка оператора
        {
            l1.Revers();
            return l1;
        }
        public static bool operator ==(Lists l1, Lists l2) //перегрузка оператора
        {
            int count = 0;
            if (l1.Count() != l2.Count()) return false;
            else
            {
                for (int i = 0; i < l1.Count(); i++)
                {
                    if (l1.Element(i) == l2.Element(i)) count += 1;
                }
                if (count == l1.Count()) return true;
                else return false;
            }
        }
            public static bool operator !=(Lists l1, Lists l2) //перегрузка оператора
        {
            int count = 0;
            if (l1.Count() != l2.Count()) return true;
            else
            {
                for (int i = 0; i < l1.Count(); i++)
                {
                    if (l1.Element(i) == l2.Element(i)) count += 1;
                }
                if (count == l1.Count()) return false;
                else return true;
            }
        }
                
        public class Owner //вложенный объект owner
        {
            private int _Id;
            private string _Name;
            private string _Organization;

            public int ID //свойство возвращает идентификатор (из-за private полей)
            {
                get
                {
                    return _Id;
                }

            }
            public string Name //свойство возвращает имя (из-за private полей)
            {
                get
                {
                    return _Name;
                }

            }
            public string Organization //свойство возвращает организацию (из-за private полей)
            {
                get
                {
                    return _Organization;
                }

            }
            public Owner(int Id, string Name, string Organization) //конструктор создания полей
            {
                _Id = Id;
                _Name = Name;
                _Organization = Organization;
            }
        }
        public static Owner owner; //выделение памяти
        public static Date date; //выделение памяти
        public class Date //вложенный объект Date
        {
            private string dateOfCreation;

            public string DateOfCreation //свойство возвращает дату
            {
                get
                {
                    return dateOfCreation;
                }
            }

            public Date(string _dateOfCreation) //конструктор создания полей
            {
                dateOfCreation = _dateOfCreation;
            }
        }
        static Lists() //статический конструктор
        {
            owner = new Owner(24, "Кирилл", "Kiroy Inc.");
            date = new Date(DateTime.Now.ToString());
        }
        public static void OwnerInfo() //метод вывода информации
        {
            Console.WriteLine($"Владелец: {owner.Name}\nИдентификатор владельца: {owner.ID}\nКомпания владельца: {owner.Organization}\nДата создания: {date.DateOfCreation}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var FirstList = new Lists();
            var SecondList = new Lists();
            var UnitedList = new Lists();
            FirstList.Add(6);
            FirstList.Add(3);
            FirstList.Add(8);
            FirstList.Add(1);
            FirstList.Output();
            Console.WriteLine();
            SecondList.Add(2);
            SecondList.Add(9);
            SecondList.Add(5);
            SecondList.Add(4);
            SecondList.Add(7);
            SecondList.Output();
            Console.WriteLine();
            FirstList.Delete(2);
            FirstList.Output();
            Console.WriteLine();
            UnitedList = FirstList + SecondList;
            UnitedList.Output();
            Console.WriteLine();
            SecondList = FirstList > SecondList;
            SecondList.Output();
            Console.WriteLine();
            FirstList = !FirstList;
            FirstList.Output();
            Console.WriteLine();
            if (FirstList == SecondList) Console.WriteLine("Списки равны");
            else Console.WriteLine("Списки не равны");
            Lists.OwnerInfo();
            Console.WriteLine();
            UnitedList.Sum();
            UnitedList.Difference();
            UnitedList.Ccount();
            string str = "Кирилл";
            str.Truncation(3);
            UnitedList.Ssum();
        }
    }
    public static class StatisticOperation
    {
        internal static void Sum(this Lists List) //статический метод
        {
            int sum = 0;
            for (int i = 0; i < List.Count(); i++)
            {
                sum += List.Element(i);
            }
            Console.WriteLine($"Cумма элементов списка: {sum}");
        }
        internal static void Difference(this Lists List) //статический метод
        {
            int dif;
            int i = List.Count();
            dif = (List.Element(i-1)) - (List.Element(0));
            Console.WriteLine($"Разница последнего и первого элементов списка: {dif}");
        }
        internal static void Ccount(this Lists List) //статический метод
        {
            Console.WriteLine($"Количество элементов списка: {List.Count()}");
        }
    }
    public static class StringExtension
    {
        public static string Truncation(this string str, int Length) //метод расширения string
        {
            string newString = null;
            if (Length < str.Length)
            {
                for (int index = 0; index < Length; index++)
                {
                    newString += str[index];
                }
                Console.WriteLine($"Усечение строки до заданного значения: {newString}");
                return null;
            }
            else Console.WriteLine($"Усечения строки не получилось (дурак, введи нормальные данные!!!)\n:): {str}");
            return null;
        }
    }
    public static class IntExtension //метод расширения int
    {
        public static int Ssum(this Lists List)
        {
            int sum = 0;
            for (int i = 0; i < List.Count(); i++)
            {
                sum += List.Element(i);
            }
            Console.WriteLine($"Cумма элементов списка: {sum}");
            return 0;
        }
    }
}

