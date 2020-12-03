using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_13
{
    class YKADirInfo
    {
        public static void CreationTime(StreamWriter streamWriter, string s)
        {
            YKALog.YKAWriter(streamWriter, "Время создания");
            DirectoryInfo dir = new DirectoryInfo(s);
            if (dir.Exists)
                Console.WriteLine($"Время создания: {dir.CreationTime}");
            else Console.WriteLine("Каталог не существует");
        }
        public static void FileCount(StreamWriter streamWriter, string s)
        {
            YKALog.YKAWriter(streamWriter, "Количество файлов");
            DirectoryInfo dir = new DirectoryInfo(s);
            if (dir.Exists)
            {
                FileInfo[] fi = dir.GetFiles();
                Console.WriteLine($"Количество файлов: {fi.Length}");
            }
        }
        public static void DirCount(StreamWriter streamWriter, string s)
        {
            YKALog.YKAWriter(streamWriter, "Количество каталогов");
            DirectoryInfo dir = new DirectoryInfo(s);
            if (dir.Exists && dir.Extension == "")
            {
                DirectoryInfo[] d = dir.GetDirectories();
                Console.WriteLine($"Количество каталогов: {d.Length}");
            }
        }
        public static void ParentsCount(StreamWriter streamWriter, string s)
        {
            YKALog.YKAWriter(streamWriter, "Количество родительских каталогов");
            DirectoryInfo dir = new DirectoryInfo(s);
            if (dir.Exists)
            {
                Console.WriteLine($"Корень: {dir.Root}");
            }
        }
    }
}
