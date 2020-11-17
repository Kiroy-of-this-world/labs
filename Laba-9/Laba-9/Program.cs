using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_9
{
    public delegate int Upgrading();
    public delegate bool Working();
    public class iPadOs
    {
        public iPadOs(int version)
        {
            Version = version;
            IsWorking = false;
        }
        public static int Version { get; set; }
        public static bool IsWorking { get; set; }
        public Upgrading OnUpgrade = () =>
        {
            Version++;
            Console.WriteLine($"Версия обновлена до iPadOS {Version}");
            return Version;
        };
        public Working OnWork = () =>
        {

            IsWorking = true;
            Console.WriteLine("ПО запущено");
            return IsWorking;
        };
    }
    public class iOs
    {
        public iOs(int version)
        {
            Version = version;
            IsWorking = false;
        }
        public static int Version { get; set; }
        public static bool IsWorking { get; set; }
        public Upgrading OnUpgrade = () =>
        {
            Version++;
            Console.WriteLine($"Версия обновлена до iOs {Version}");
            return Version;
        };
        public Working OnWork = () =>
        {

            IsWorking = true;
            Console.WriteLine("ПО запущено");
            return IsWorking;
        };
    }
    public class macOs
    {
        public macOs(int version)
        {
            Version = version;
            IsWorking = false;
        }
        public static int Version { get; set; }
        public static bool IsWorking { get; set; }
        public Upgrading OnUpgrade = () =>
        {
            Version++;
            Console.WriteLine($"Версия обновлена до macOs {Version}");
            return Version;
        };
        public Working OnWork = () =>
        {

            IsWorking = true;
            Console.WriteLine("ПО запущено");
            return IsWorking;
        };
    }
    public class User
    {
        public event Upgrading Upgrade;
        public event Working Work;
        public void CommandUpgrade()
        {
            Console.WriteLine("Обновление запущено");
            Upgrade();
            Console.WriteLine();
        }
        public void CommandWork()
        {
            Console.WriteLine("Работа запущена");
            Work();
            Console.WriteLine();
        }
    }
    static public class ChangeString
    {
        public static string OneSpace(string str)
        {
            int del = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == ' ')
                    if (str[i + 1] == ' ')
                        del = i + 1;
            }
            str = str.Remove(del, 1);
            return str;
        }
        public static void AddLetter(string str, char letter)
        {
            str = str + letter;
            Console.WriteLine(str);
        }
        public static string AddPoint(string str)
        {
            str = str + ".";
            return str;
        }
        public static string MyToApper(string str)
        {
            str = str.ToUpper();
            return str;
        }
        public static string Oo(string str)
        {
            str = str.Replace("Е", "е");
            return str;
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            User user = new User();
            iOs iOs = new iOs(14);
            iPadOs iPadOs = new iPadOs(13);
            macOs macOs = new macOs(10);

            Console.WriteLine($"Версия iPadOs {iPadOs.Version}");
            Console.WriteLine($"Версия iOs {iOs.Version}");
            Console.WriteLine($"Версия macOs {macOs.Version}");
            if (iPadOs.IsWorking == true) Console.WriteLine($"iPadOs запущена");
            else Console.WriteLine($"iPadOs не запущена");
            if (iPadOs.IsWorking == true) Console.WriteLine($"iOs запущена");
            else Console.WriteLine($"iOs не запущена");
            if (iPadOs.IsWorking == true) Console.WriteLine($"macOs запущена");
            else Console.WriteLine($"macOs не запущена");
            Console.WriteLine();

            user.Upgrade += iPadOs.OnUpgrade;
            user.Work += iOs.OnWork;
            user.Upgrade += macOs.OnUpgrade;
            user.Work += macOs.OnWork;
            user.CommandUpgrade();
            user.CommandWork();

            Console.WriteLine($"Версия iPadOs {iPadOs.Version}");
            Console.WriteLine($"Версия iOs {iOs.Version}");
            Console.WriteLine($"Версия macOs {macOs.Version}");
            if (iPadOs.IsWorking == true) Console.WriteLine($"iPadOs запущена");
            else Console.WriteLine($"iPadOs не запущена");
            if (iOs.IsWorking == true) Console.WriteLine($"iOs запущена");
            else Console.WriteLine($"iOs не запущена");
            if (macOs.IsWorking == true) Console.WriteLine($"macOs запущена");
            else Console.WriteLine($"macOs не запущена");
            Console.WriteLine();

            string str1 = "ДдоброЕ утр";
            Console.WriteLine(str1);
            Func<string, string> func;
            Action<string, char> action;
            func = ChangeString.OneSpace;
            str1 = func(str1);
            Console.WriteLine(str1);
            action = ChangeString.AddLetter;
            action(str1, 'о');
            func += ChangeString.Oo;
            str1 = func(str1);
            Console.WriteLine(str1);
            func += ChangeString.MyToApper;
            str1 = func(str1);
            Console.WriteLine(str1);
            func += ChangeString.AddPoint;
            str1 = func(str1);
            Console.WriteLine(str1);
        }
    }
}
