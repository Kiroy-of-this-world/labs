using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_13
{
    static class YKAFileInfo
    {
        public static void FullDirection(StreamWriter streamWriter, string f)//выводим полный путь до файла
        {
            YKALog.YKAWriter(streamWriter, "Полный путь");
            FileInfo fi = new FileInfo(f);
            if (fi.Exists)
            {
                Console.WriteLine($"Полное направление: {fi.DirectoryName}\\{fi.Name}");
            }
        }
        public static void FileInfo(StreamWriter streamWriter, string f)//Размер, расширение, имя
        {
            YKALog.YKAWriter(streamWriter, "Информация о файле");
            FileInfo fi = new FileInfo(f);
            if (fi.Exists)
            {
                Console.WriteLine($"Размер: {fi.Length}, Расширение: {fi.Extension}, Имя: {fi.Name}");
            }
        }
        public static void CreationTime(StreamWriter streamWriter, string f)//Время создания файла
        {
            YKALog.YKAWriter(streamWriter, "Время создания");
            FileInfo fi = new FileInfo(f);
            if (fi.Exists)
            {
                Console.WriteLine($"Время создания: {fi.CreationTime}");
            }
        }
    }
}
