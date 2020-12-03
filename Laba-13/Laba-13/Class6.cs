using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_13
{
    class YKAFinder
    {
        public static void Searcher(StreamReader streamReader, int n1, int n2)//по часовому промежутку
        {
            int tmphour;
            string str, tmp = "";
            int i = 0, k = 0;
            while (!streamReader.EndOfStream)
            {
                i = 0;
                k++;
                str = streamReader.ReadLine();// считываем пока не натыкаемся на : => это наш час
                try
                {
                    while (str[i] != ':')
                    {
                        tmp += str[i];
                        i++;
                    }
                }
                catch (IndexOutOfRangeException) { };

                i++;
                try
                {

                    tmphour = Convert.ToInt32(tmp);
                    tmp = "";
                    if (tmphour < n2 && tmphour > n1) //ищем час по заданному промежутку и выводим запись
                    {
                        str = streamReader.ReadLine();
                        Console.WriteLine(str);
                    }
                    else
                        str = streamReader.ReadLine();
                }
                catch (FormatException) { };
            }
            Console.WriteLine(k + " запесей");
        }
        public static void SearcherDate(StreamReader streamReader, int day, int month)
        {
            int tmpday, tmpminute;
            string str, tmp = "";
            int i = 0, k = 0, m = 0;

            while (!streamReader.EndOfStream)
            {
                m = 0;
                i = 0;
                k++;
                str = streamReader.ReadLine();
                while (m < 2)
                {
                    if (str[i] == ':')
                    {
                        m++;
                    }
                    i++;
                }
                while (str[i] != ':')
                {
                    tmp += str[i];
                    i++;
                }
                i++;
                tmpday = Convert.ToInt32(tmp);
                tmp = "";
                for (int j = i; str[j] != ':'; j++)
                {
                    tmp += str[j];
                }
                tmpminute = Convert.ToInt32(tmp);
                tmp = "";
                if (day == tmpday && month == tmpminute)
                {
                    str = streamReader.ReadLine();
                    Console.WriteLine(str);
                }
                else
                    str = streamReader.ReadLine();
            }
            Console.WriteLine(k + " записей");
        }
        public static void SearcherWord(StreamReader streamReader, string word)
        {
            int counter = 0;
            string tmp;
            while (!streamReader.EndOfStream)
            {
                streamReader.ReadLine();
                tmp = streamReader.ReadLine();
                if (tmp.Contains(word))
                {
                    Console.WriteLine(tmp);
                    counter++;
                }
            }
            if (counter == 0) Console.WriteLine("В файле нет такой строки");
        }
    }
}
