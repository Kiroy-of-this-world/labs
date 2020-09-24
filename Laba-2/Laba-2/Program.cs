using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Laba_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Типы данных

            bool b = true;
            int i = -10;
            uint ui = 10;
            byte by = 255;
            sbyte sb = -120;
            long li = -20000;
            ulong ul = 20000;
            short sh = -100;
            ushort ush = 100;
            decimal dec = 10.6m;
            double db = 2e10;
            float fl = 10.7f;
            char ch = '!';

            Console.WriteLine("Заранее инициализированные значения");
            Console.WriteLine($"Логический тип данных bool: {b}");
            Console.WriteLine($"Логический тип данных int: {i}");
            Console.WriteLine($"Логический тип данных uint: {ui}");
            Console.WriteLine($"Логический тип данных long: {li}");
            Console.WriteLine($"Логический тип данных ulong: {ul}");
            Console.WriteLine($"Логический тип данных short: {sh}");
            Console.WriteLine($"Логический тип данных ushort: {ush}");
            Console.WriteLine($"Логический тип данных byte: {by}");
            Console.WriteLine($"Логический тип данных sbyte: {sb}");
            Console.WriteLine($"Логический тип данных decimal: {dec}");
            Console.WriteLine($"Логический тип данных double: {db}");
            Console.WriteLine($"Логический тип данных float: {fl}");
            Console.WriteLine($"Логический тип данных char: {ch}");
            Console.WriteLine();

            //Console.WriteLine("Введите значения типа bool (true/false):");
            //b = Convert.ToBoolean(Console.ReadLine());
            //Console.WriteLine($"Введите значения типа int:");
            //i = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("Введите значения типа uint:");
            //ui = Convert.ToUInt32(Console.ReadLine());
            //Console.WriteLine("Введите значения типа long:");
            //li = Convert.ToInt64(Console.ReadLine());
            //Console.WriteLine("Введите значения типа ulong:");
            //ul = Convert.ToUInt64(Console.ReadLine());
            //Console.WriteLine("Введите значения типа short:");
            //sh = Convert.ToInt16(Console.ReadLine());
            //Console.WriteLine("Введите значения типа ushort:");
            //ush = Convert.ToUInt16(Console.ReadLine());
            //Console.WriteLine("Введите значения типа byte:");
            //by = Convert.ToByte(Console.ReadLine());
            //Console.WriteLine("Введите значения типа sbyte:");
            //sb = Convert.ToSByte(Console.ReadLine());
            //Console.WriteLine("Введите значения типа decimal:");
            //dec = Convert.ToDecimal(Console.ReadLine());
            //Console.WriteLine("Введите значения типа double:");
            //db = Convert.ToDouble(Console.ReadLine());
            //Console.WriteLine("Введите значения типа float:");
            //fl = Convert.ToSingle(Console.ReadLine());
            //Console.WriteLine("Введите значения типа char:");
            //ch = Convert.ToChar(Console.ReadLine());

            //Console.WriteLine("Значения введенные с консоли");
            //Console.WriteLine($"Логический тип данных bool: {b}");
            //Console.WriteLine($"Логический тип данных int: {i}");
            //Console.WriteLine($"Логический тип данных uint: {ui}");
            //Console.WriteLine($"Логический тип данных long: {li}");
            //Console.WriteLine($"Логический тип данных ulong: {ul}");
            //Console.WriteLine($"Логический тип данных short: {sh}");
            //Console.WriteLine($"Логический тип данных ushort: {ush}");
            //Console.WriteLine($"Логический тип данных byte: {by}");
            //Console.WriteLine($"Логический тип данных sbyte: {sb}");
            //Console.WriteLine($"Логический тип данных decimal: {dec}");
            //Console.WriteLine($"Логический тип данных double: {db}");
            //Console.WriteLine($"Логический тип данных float: {fl}");
            //Console.WriteLine($"Логический тип данных char: {ch}");
            //Console.WriteLine();

            Console.WriteLine("Неяное приведение типов");
            li = i;
            i = sh;
            ui = ush;
            fl = by;
            db = sb;
            Console.WriteLine($"Неяное приведение int к long: {li}");
            Console.WriteLine($"Неяное приведение short к int: {i}");
            Console.WriteLine($"Неяное приведение ushort к uint: {ui}");
            Console.WriteLine($"Неяное приведение byte к float: {fl}");
            Console.WriteLine($"Неяное приведение sbyte к double: {db}");
            Console.WriteLine();

            Console.WriteLine("Явное преобразование");
            ul = (ulong)ui;
            by = (byte)ch;
            db = (double)fl;
            dec = (decimal)ush;
            li = (long)sb;
            Console.WriteLine($"Явное приведение uint к ulong: {ul}");
            Console.WriteLine($"Явное приведение char к byte: {by}");
            Console.WriteLine($"Явное приведение float к double: {db}");
            Console.WriteLine($"Явное приведение ushort к decimal: {dec}");
            Console.WriteLine($"Явное приведение sbyte к long: {li}");
            Console.WriteLine();

            Console.WriteLine("Упаковка и распаковка значимых типов");
            object obj = ui;
            Console.WriteLine($"Упаковка: {obj}");
            uint ut = (uint)obj;
            Console.WriteLine($"Распаковка: {ut}");
            Console.WriteLine();

            Console.WriteLine("Неявно типизированная переменная");
            var variable = 10.2m;
            Console.WriteLine($"Неявно типизированная переменная с помощью ключевого слова var {variable}");
            Console.WriteLine();

            Console.WriteLine("Nullable переменная");
            int? nu = null;
            Console.WriteLine($"Значение nullable переменной {nu}");
            nu = 666;
            Console.WriteLine($"Значение nullable переменной {nu}");
            Console.WriteLine();

            //Ошибка при присвоении переменной типа var значения другого типа
            //var err = 23;
            //err = 2.54f; // - ошибка, не удается неявно преобразовать "float" в "int"

            //Строки

            Console.WriteLine("Сравнение строк");
            string str1, str2;
            Console.WriteLine("Введите первую строку: ");
            str1 = Console.ReadLine();
            Console.WriteLine("Введите вторую строку: ");
            str2 = Console.ReadLine();
            Console.WriteLine("Результат сравнения строк: " + (str1 == str2));
            Console.WriteLine();
            string str3, str4, str5;
            Console.WriteLine("Введите строку: ");
            str3 = Console.ReadLine();
            Console.WriteLine("Введите строку: ");
            str4 = Console.ReadLine();
            Console.WriteLine("Введите строку: ");
            str5 = Console.ReadLine();
            Console.WriteLine();
            string text = str1 + str2 + str3;
            Console.WriteLine($"Cцепление: {text}");
            str4 = String.Copy(str3);
            Console.WriteLine($"Копирование: {str4}");
            Console.WriteLine("Выделение подстроки:" + (text.Substring(0, 4)));
            string[] words = str1.Split(' ');
            Console.WriteLine("Певрое слово:" + words[0]);
            Console.WriteLine("Второе слово:" + words[1]);
            string modif1 = str2.Insert(6, str1);
            Console.WriteLine("После вставки подстроки: " + modif1);
            string modif2 = str2.Remove(2, 6);
            Console.WriteLine("После удаления подстроки: " + modif2);
            Console.WriteLine("Проверка на пустоту: ");
            string str6 = null;
            string str7 = "";
            Console.WriteLine(string.IsNullOrEmpty(str6));
            Console.WriteLine(string.IsNullOrEmpty(str7));
            Console.WriteLine();
            StringBuilder sbu = new StringBuilder("Юркевич Кирилл Александрович 20 декабря");
            Console.WriteLine("Исходная строка: " + sbu);
            sbu.Remove(4, 20);
            Console.WriteLine("Удаляем определенную позицию: " + sbu);
            sbu.Insert(0, "Студент: ");
            sbu.Insert(sbu.Length, " - дата рождения.");
            Console.WriteLine("Добавляем новые символы в начало и конец строки: " + sbu);
            Console.WriteLine();

            //Массивы

            Console.WriteLine("Матрица:");
            int[,] Matrix = new int[4, 4];
            Random Elem = new Random();
            for (int I = 0; I < 4; I++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Matrix[I, j] = Elem.Next(1, 10);
                    Console.Write("{0}  ", Matrix[I, j]);
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            string[] arrOfStr = new string[] { "Hello", "Programming", "World", "String", "Parachute" };

            foreach (string el in arrOfStr)
            {
                Console.Write(el + ", ");
            }
            Console.WriteLine();


            int n = 0;
            bool flag = true;
            Console.WriteLine($"Длина массива: {arrOfStr.Length}");
            flag = true;
            Console.WriteLine("Введите индекс строки в массиве, которую вы хотите заменить:");

            while (flag)
            {
                n = Convert.ToInt32(Console.ReadLine());
                if (n < arrOfStr.Length)
                {
                    flag = false;
                }
            }

            Console.WriteLine("Введите новую строку!");
            str3 = Console.ReadLine();

            for (int I = 0; I < arrOfStr.Length; I++)
            {
                if (I == n)
                {
                    arrOfStr[I] = str3;
                    break;
                }
            }
            Console.WriteLine();

            Console.WriteLine("Измененный массив:");

            foreach (string el in arrOfStr)
            {
                Console.Write(el + ", ");
            }

            int[][] step = new int[3][];
            step[0] = new int[2];
            step[1] = new int[3];
            step[2] = new int[4];
            Console.WriteLine();
            Console.WriteLine("Заполнение ступенчатого массива:");

            for (int I = 0; I < step[0].Length; I++)
            {
                Console.WriteLine("Введите число: ");
                step[0][I] = Convert.ToInt32(Console.ReadLine());
            }
            for (int I = 0; I < step[1].Length; I++)
            {
                Console.WriteLine("Введите число: ");
                step[1][I] = Convert.ToInt32(Console.ReadLine());
            }
            for (int I = 0; I < step[2].Length; I++)
            {
                Console.WriteLine("Введите число: ");
                step[2][I] = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine();
            Console.WriteLine("Ступенчатый массив: ");
            for (int I = 0; I < step[0].Length; I++)
                Console.Write($"{step[0][I]} ");
            Console.WriteLine();
            for (int I = 0; I < step[1].Length; I++)
                Console.Write($"{step[1][I]} ");
            Console.WriteLine();
            for (int I = 0; I < step[2].Length; I++)
                Console.Write($"{step[2][I]} ");
            Console.WriteLine();
            Console.WriteLine();

            var varString = "Greetings";
            Console.WriteLine($"Неявно типизированная переменная для хранения данных типа String: {varString}");
            var Arr = new[] { 2, 3, 4 };
            Console.WriteLine($"Неявно типизированная переменная для хранения массива с данными типа int: {0}, {1}, {2}", Arr[0], Arr[1], Arr[2]);
            Console.WriteLine();

            //Кортежи

            (int, string, char, string, ulong) T = (5, "Tuple", '!', "Laboratory", 454252536);
            Console.WriteLine($"Элементы кортежа: {T.Item1}, {T.Item2}, {T.Item3}, {T.Item4}, {T.Item5}");
            (int a1, string a2, char a3, string a4, ulong a5) Tu = (5, "Tuple", '!', "Laboratory", 454252536);
            Console.WriteLine($"Элементы кортежа: { Tu.a1}, { Tu.a2}, { Tu.a3}, { Tu.a4}, { Tu.a5}");
            if (T == Tu)
            {
                Console.WriteLine("Кортежи равны!");
            }
            else Console.WriteLine("Кортежи не равны!");
            var w = ("123", 456);
            (string b1, double b2) = w;
            Console.WriteLine($"{b1},{b2}");
            Console.WriteLine();

            //локальная функция

            int[] mam = new int[] { 23, 43, 5, 12, 7 };
            string ste = "Юркевич";
            var kor = localFunc(mam, ste);
            Console.WriteLine($"Элементы кортежа: {kor.Item1}, {kor.Item2}, {kor.Item3}, {kor.Item4}");
            Console.WriteLine();

            (int, int, int, string) localFunc(int[] ma, string st)
            {
                (int Max, int Min, int Sum, string First) result = (ma[0], ma[0], 0, " ");
                result.First = st.Remove(1); //вырезаем 1 букву из строки
                for (i = 0; i < ma.Length; i++)
                {
                    result.Sum += ma[i];
                }
                for (i = 0; i < ma.Length; i++)
                {
                    if (result.Max < ma[i])
                    {
                        result.Max = ma[i];
                    }
                }
                for (i = 0; i < ma.Length; i++)
                {
                    if (result.Min > ma[i])
                    {
                        result.Min = ma[i];
                    }
                }
                return result;
            }
        }
        //static (int, int, int, string) localFunc(int[] ma, string st)
        //{
        //    (int Max, int Min, int Sum, string First) result = (ma[0], ma[0], 0, " ");
        //    result.First = st.Remove(1); //вырезаем 1 букву из строки
        //    for (int i = 0; i<ma.Length; i++)
        //    {
        //        result.Sum += ma[i];
        //    }
        //    for (int i = 0; i<ma.Length; i++)
        //    {
        //        if (result.Max<ma[i])
        //        {
        //            result.Max = ma[i];
        //        }
        //    }
        //    for (int i = 0; i < ma.Length; i++)
        //    {
        //        if (result.Min > ma[i])
        //        {
        //            result.Min = ma[i];
        //        }
        //    }
        //    return result;
        //}
    }
}