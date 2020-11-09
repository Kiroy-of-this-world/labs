using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Laba_7
{
    public struct Enum
    {
        public enum Numbers : int
        {
            first = 1, second = 2, three = 3, fourth = 4, ten = 10
        }
    }
    public interface IMessage
    {
        string[] Message();
        void MainMessage();
    }
    abstract public partial class Tennis : IMessage
    {
        string[] IMessage.Message()
        {
            return new string[] { "Это теннис" };
        }
        public override string ToString()
        {
            return "Tennis";
        }
        public string Year { get; set; }
    }
    public class Equipment : Tennis, IMessage
    {
        string[] IMessage.Message()
        {
            return new string[] { "Это инвентарь" };
        }
        public override string ToString()
        {
            return "Equipment";
        }
        public override void MainMessage()
        {
            Console.WriteLine("Это одноимённый метод из абстрактного класса");
        }
        void IMessage.MainMessage()
        {
            Console.WriteLine("Это одноимённый метод из интерфейса");
        }

    }
    public partial class Bench : Equipment, IMessage
    {
        string[] IMessage.Message()
        {
            return new string[] { "Это скамейка" };
        }
        public override string ToString()
        {
            return "Bench";
        }
    }
    public class Bars : Bench, IMessage
    {
        string[] IMessage.Message()
        {
            return new string[] { "Это брусья" };
        }
        public override string ToString()
        {
            return "Bars";
        }
    }
    public class Ball : Equipment, IMessage
    {
        string[] IMessage.Message()
        {
            return new string[] { "Это мяч" };
        }
        public override string ToString()
        {
            return "Ball";
        }
    }
    public class TennisBall : Ball, IMessage
    {
        public int numberOfBall;
        public int price;
        public TennisBall(int numberOfBall, int price)
        {
            this.numberOfBall = numberOfBall;
            this.price = price;
        }
        string[] IMessage.Message()
        {
            return new string[] { "Это баскетбольный мяч" };
        }
        public override string ToString()
        {
            return "BasketballBall";
        }
    }
    sealed class Mats : Equipment, IMessage
    {
        string[] IMessage.Message()
        {
            return new string[] { "Это маты" };
        }
        public override string ToString()
        {
            return "Mats";
        }
    }
    public class Printer
    {
        public string IAmPrinting(IMessage set)
        {
            if (set is Tennis)
            {
                return String.Format("{0} - это инвентарь. {1}.",
                    set.ToString(),
                    String.Join(", ", set.Message()));
            }
            else
            {
                return String.Format("Ошибка.");
            }
        }
    }
    public class Gym
    {
        public List<TennisBall> gym = new List<TennisBall>();
        public Gym()
        {
            int sum = 0;
            do
            {
                Console.WriteLine("Введите номер и цену мяча");
                int number = Convert.ToInt32(Console.ReadLine());
                int price = Convert.ToInt32(Console.ReadLine());
                sum += price;
                if (sum < 50)
                {
                    TennisBall tennisBall1 = new TennisBall(number, price);
                    gym.Add(tennisBall1);
                }
            }
            while (sum < 50);
        }
        public void Add(TennisBall t)
        {
            gym.Add(t);
        }
        public void Delete(int index)
        {
            gym.RemoveAt(index);
        }
        public void Output()
        {
            foreach (TennisBall i in gym)
            {
                Console.WriteLine(i.numberOfBall);
                Console.WriteLine(i.price);
            }
        }
        public int Count()
        {
            return Convert.ToInt32(gym.Count);
        }
    }
    class Controller
    {
        public static void Sort(List<TennisBall> g)
        {
            TennisBall temp;
            for (int i = 0; i < g.Count; i++)
            {
                for (int j = i + 1; j < g.Count; j++)
                {
                    if (g[i].price > g[j].price)
                    {
                        temp = g[j];
                        g[j] = g[i];
                        g[i] = temp;
                    }
                    if (g[i].price < g[j].price)
                    {
                        temp = g[i];
                        g[i] = g[j];
                        g[j] = temp;
                    }
                }
            }
        }
        public static void Search(List<TennisBall> g)
        {
            for (int i = 0; i < g.Count; i++)
            {
                if (g[i].price > 10)
                {
                    if (g[i].price < 20)
                    {
                        Console.WriteLine(g[i].numberOfBall);
                        Console.WriteLine(g[i].price);
                    }
                }

            }
        }
    }
    class Player : Tennis
    {
        public override void MainMessage()
        {
            Console.WriteLine();
        }
        private int age;
        public int Age
        {
            get { return age; }
            set
            {
                if (value < 18)
                    throw new PlayerExceptions("Вы не можете играть, пока вам нет 18!");
                else
                    age = value;
            }
        }
    }
    public partial class Bench
    {
        private int productionYear;
        public int ProductionYear
        {
            get { return productionYear; }
            set
            {
                if (value < 1998)
                    throw new BenchExceptions("Скамейка слишком старa!");
                else
                    productionYear = value;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<IMessage> objects = new List<IMessage>();
            objects.Add(new Equipment());
            objects.Add(new Bench());
            objects.Add(new Bars());
            objects.Add(new Ball());
            objects.Add(new TennisBall(1, 10));
            objects.Add(new Mats());

            Printer Print = new Printer();
            foreach (IMessage count in objects)
            {
                Console.WriteLine(Print.IAmPrinting(count));
            }

            Console.WriteLine($"Это номер {(int)Enum.Numbers.ten} из перечисления");

            Gym gym1 = new Gym();
            Console.WriteLine("Вывод списка:");
            gym1.Output();
            Console.WriteLine();

            Controller.Sort(gym1.gym);
            Console.WriteLine("Вывод списка:");
            gym1.Output();
            Console.WriteLine();

            Console.WriteLine("Вывод списка по диапазону:");
            Controller.Search(gym1.gym);
            Console.WriteLine();

            //три стандартных исключения  
            try
            {
                int tmp = 10;
                int result = tmp / 0;
            }
            catch (DivideByZeroException) { Console.WriteLine("EXCEPTION! Нельзя делить на ноль"); }

            try
            {
                int[] numbers = new int[3];
                int index = numbers[10];
            }
            catch (IndexOutOfRangeException) { Console.WriteLine("EXCEPTION! Неверный индекс"); }

            try
            {
                object you = "you";
                int youI = (int)you;
            }
            catch (InvalidCastException) { Console.WriteLine("EXCEPTION! Вы не можете привести объект к примитивному типу int"); }
            Console.WriteLine();

            try
            {
                string tmp1 = null;
                if (tmp1 == null) throw new CommonException("NullReferenceException");
            }
            catch
            {
                Console.WriteLine("Исключение найдено");
            }
            Console.WriteLine();


            //исключение ограничения по возрасту
            try
            {
                Player player = new Player();
                Console.Write("Введите свой возраст: ");
                player.Age = Convert.ToInt32(Console.ReadLine());
                Debug.Assert(player.Age <= 90);
            }
            catch (PlayerExceptions ex)
            {
                Console.WriteLine("Исключение: " + ex.message);
                Console.WriteLine("Место исключения: " + ex.GetType().FullName);
                Console.WriteLine("Диагностика, как избежать: " + ex.howToAvoid);
            }
            Console.WriteLine();

            //исключение по возрасту скамьи
            try
            {
                Bench bench = new Bench();
                bench.ProductionYear = 1989;
            }
            catch (BenchExceptions ex)
            {
                Console.WriteLine("Исключение: " + ex.message);
                Console.WriteLine("Место исключения: " + ex.GetType().FullName);
                Console.WriteLine("Диагностика, как избежать: " + ex.howToAvoid);
            }
            finally
            {
                Console.WriteLine("Finally!");
            }
        }

    }
}
