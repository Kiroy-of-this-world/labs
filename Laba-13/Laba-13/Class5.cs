using System;
using System.IO;
using System.IO.Compression;

namespace Laba_13
{
    class YKAFileManager
    {
        public static void DiskReader(StreamWriter streamWriter, string str)
        {
            YKALog.YKAWriter(streamWriter, "Создание YKAInspect");//пишем в файл YKAlogfile.txt о создании YKAInspect
            Directory.CreateDirectory("YKAInspect");//создаем необходимый каталог
            FileStream fs = File.Create("YKAInspect\\YKAdirinfo.txt");//создаем файл
            fs.Close();

            YKALog.YKAWriter(streamWriter, "Создание YKAdirinfo.txt");//пишем в файл создание YKAdirinfo.txt
            StreamWriter sw = new StreamWriter("YKAInspect\\YKAdirinfo.txt");// в каталог в файл YKAdirinfo.txt открываем поток
            DirectoryInfo dir = new DirectoryInfo(str);//получаем информацию о директории

            if (dir.Exists)
            {
                DirectoryInfo[] d = dir.GetDirectories();//если существует получаем каталоги и файлы
                FileInfo[] f = dir.GetFiles();

                for (int i = 0; i < d.Length; i++)//выводим все каталоги и файлы
                {
                    Console.WriteLine(d[i].Name);
                    sw.WriteLine(d[i].Name);
                }
                for (int i = 0; i < f.Length; i++)
                {
                    Console.WriteLine(f[i].Name);
                    sw.WriteLine(f[i].Name);
                }
                sw.Close();

                YKALog.YKAWriter(streamWriter, "Скопировано из YKAdirinfo в YKAdirinfocopy");//пишем в файл "копирование каталога"
                if (File.Exists("YKAInspect\\YKAdirinfocopy.txt"))//перемещаем файл создавая его копию, после удаляем 
                {
                    File.Delete("YKAInspect\\YKAdirinfocopy.txt");
                }
                FileInfo q = new FileInfo("YKAInspect\\YKAdirinfo.txt");
                q.CopyTo("YKAInspect\\YKAdirinfocopy.txt");
                
                Directory.CreateDirectory("YKAFiles");
                q.CopyTo("YKAFiles\\YKAmove.txt");
                File.Delete("YKAInspect\\YKAdirinfo.txt");

                YKALog.YKAWriter(streamWriter, "Создание YKAFiles");
                YKALog.YKAWriter(streamWriter, "Запись в YKAFile");

                //срабатывает исключение при не первом запуске... удалить перед работой
                
                DirectoryInfo d1 = new DirectoryInfo("YKAFiles");//перемещаем директорий
                d1.MoveTo("YKAInspectMe");
                YKALog.YKAWriter(streamWriter, "Перемещение YKAFiles");

                YKALog.YKAWriter(streamWriter, "Архивация YKAFiles");
                ZipFile.CreateFromDirectory("YKAInspect", "YKA.zip");

                YKALog.YKAWriter(streamWriter, "Разархивация YKAFiles");
                ZipFile.ExtractToDirectory("YKA.zip", "YKAEnd");
            }
        }
    }
}
