using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_5
{
    public interface IMessage
    {
        string[] Message();
        void MainMessage();
    }
    abstract public class Tennis : IMessage
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
        public override int GetHashCode()
        {
            return Year.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;
            else return true;
        }
        public abstract void MainMessage();
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
    public class Bench : Equipment, IMessage
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
    public class BasketballBall : Ball, IMessage
    {
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
    class Printer
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
                return String.Format($"Ошибка.");
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
            objects.Add(new BasketballBall());
            objects.Add(new Mats());

            Printer Print = new Printer();
            foreach (IMessage count in objects)
            {
                Console.WriteLine(Print.IAmPrinting(count));
            }
        }
    }

}
