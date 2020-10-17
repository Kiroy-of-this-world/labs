using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Laba_3
{
    partial class Bus //partial - частичный
    {
        string Family;
        string Initials;
        int NumberOfBus;
        int NumberOfRoute;
        string MarkOfBus;
        int YearOfOperation;
        int Mileage;
        //private Bus() //для предотвращения вызыва конструктора без параметра
        //{
        //    Console.WriteLine("Это закрытый конструктор");
        //}
        public Bus() //конструктор без параметров
        {
            Family = "Лозюк";
            Initials = "И.Д.";
            NumberOfBus = 2354;
            NumberOfRoute = 40;
            MarkOfBus = "МАЗ";
            YearOfOperation = 2010;
            Mileage = 777666;
            Count++;
        }
        public Bus(string Family, string Initials, int NumberOfBus, int NumberOfRoute, string MarkOfBus, int YearOfOperation, int Mileage) //c параметрами
        {
            this.Family = Family;
            this.Initials = Initials;
            this.NumberOfBus = NumberOfBus;
            this.NumberOfRoute = NumberOfRoute;
            this.MarkOfBus = MarkOfBus;
            this.YearOfOperation = YearOfOperation;
            this.Mileage = Mileage;
            Count++;
        }
        public Bus(string Family, string Initials, int NumberOfBus, int NumberOfRoute, int YearOfOperation, int Mileage = 666555, string MarkOfBus = "МАЗ")//с параметрами по умолчанию
        {
            this.Family = Family;
            this.Initials = Initials;
            this.NumberOfBus = NumberOfBus;
            this.NumberOfRoute = NumberOfRoute;
            this.MarkOfBus = MarkOfBus;
            this.YearOfOperation = YearOfOperation;
            this.Mileage = Mileage;
            Count++;
        }
        static Bus() 
        {
            Console.WriteLine("Это статический конструктор");
            Count++;
        }
        static readonly string Message = "Это поле ReadOnly"; //поле только для чтения
        public const int Age = 20;//константное поле
        public int Duration //свойство
        {
            get
            {
                return NumberOfBus;
            }
            set
            {
                NumberOfBus = 40;
            }
        }
        public void AgeOfBus(ref Bus One, out int Age) //метод с ref и оut параметрами
        {
            Age = 2020 - YearOfOperation;
        }
        static int Count;//статическое поле
        public static void InfoOfClass()//статический метод
        {
            Console.WriteLine($"Количество экземляров {Count}");
        }
        
    }

    partial class Bus
    {
        public void Output()
        {
            Console.WriteLine($"ФИО: {this.Family} {Initials}," +
                $" Номер автобуса: {this.NumberOfBus}," +
                $" Номер маршрута: {this.NumberOfRoute}," +
                $" Марка автобуса: {this.MarkOfBus}," +
                $" Год начала эксплуатации: {this.YearOfOperation}," +
                $" Пробег: {this.Mileage}.");
        }
        public void FindTheWay(Bus[] Buses, int way, int Size)
        {
            for (int i = 0; i < Size; i++)
            {
                if (way == Buses[i].NumberOfRoute)
                {
                    Buses[i].Output();
                }
            }
        }
        public void FindTheOlderBuses(Bus[] Buses, int age, int Size)
        {
            for (int i = 0; i < Size; i++)
            {
                if (age < (2020 - Buses[i].YearOfOperation))
                {
                    Buses[i].Output();
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int Size;
            Console.Write("Введите размер массива: ");
            Size = Convert.ToInt32(Console.ReadLine());
            Bus[] Buses = new Bus[Size];
            int Age,  NumberOfBus, NumberOfRoute, YearOfOperation, Mileage; //определяем переменные
            string Family, Initials, MarkOfBus;

            for (int i = 0; i < Size; i++)
            {
                Console.WriteLine("Введите фамилию водителя: ");
                Family = Console.ReadLine();
                Console.WriteLine("Введите инициалы водителя: ");
                Initials = Console.ReadLine();
                Console.WriteLine("Введите номер автобуса: ");
                NumberOfBus = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите номер маршрута: ");
                NumberOfRoute = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите марку автобуса: ");
                MarkOfBus = Console.ReadLine();
                Console.WriteLine("Введите год начала эксплуатации автобуса: ");
                YearOfOperation = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите километраж автобуса: ");
                Mileage = Convert.ToInt32(Console.ReadLine());

                Buses[i] = new Bus(Family, Initials, NumberOfBus, NumberOfRoute, MarkOfBus, YearOfOperation, Mileage);
            }
            Buses[0].AgeOfBus(ref Buses[0], out Age);
            Console.WriteLine();
            for (int i = 0; i < Size; i++)
            {
                Buses[i].Output();
            }
            Bus.InfoOfClass();
            Console.WriteLine($"Автобус в эксплуатации {Age}");
            Console.WriteLine($"Строка представляющая объект Bus: {Buses[0].ToString()}");
            Console.WriteLine($"Экземпляры Buses[0] и Buses[1] равны: {Buses[0].Equals(Buses[1])}");
            Console.WriteLine($"Хеш-код экземпляра Buses[0]: {Buses[0].GetHashCode()}");
            Console.WriteLine($"Тип экземпляра Buses[0]: {Buses[0].GetType()}");
            Console.WriteLine($"Номер автобуса из ф-ции Get/Set: {Buses[0].Duration}");
            Console.WriteLine();
            Console.WriteLine("Введите номер маршрута, ктоорый будем искать: ");
            int NumberOfFindsWay = Convert.ToInt32(Console.ReadLine());
            Buses[0].FindTheWay(Buses, NumberOfFindsWay, Size);
            Console.WriteLine();
            Console.WriteLine("Автобусы срок эксплуатации которых превышает 20 лет: ");
            Buses[0].FindTheOlderBuses(Buses, Bus.Age, Size);
        }
    }
}
