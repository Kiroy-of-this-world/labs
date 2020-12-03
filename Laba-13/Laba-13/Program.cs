using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_13
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamWriter file = YKALog.CreateStream("YKAlogfile.txt");

            YKADiskInfo.FreeSpace(file);
            YKADiskInfo.FileSystemInfo(file);
            YKADiskInfo.DiskInfo(file); Console.WriteLine();

            YKAFileInfo.FullDirection(file, "YKAlogfile.txt");
            YKAFileInfo.FileInfo(file, "YKAlogfile.txt");
            YKAFileInfo.CreationTime(file, "YKAlogfile.txt"); Console.WriteLine();

            YKADirInfo.CreationTime(file, "..");
            YKADirInfo.FileCount(file, "..");
            YKADirInfo.DirCount(file, "..");
            YKADirInfo.ParentsCount(file, ".."); Console.WriteLine();

            try
            {
                YKAFileManager.DiskReader(file, "C://");
            }
            catch (IOException) { };
            file.Close(); Console.WriteLine();

            StreamReader fileR = YKALog.CreateStreamR("YKAlogfile.txt");
            YKAFinder.SearcherWord(fileR, "Запись"); fileR.Close();
            Console.WriteLine();

            StreamReader fileR1 = YKALog.CreateStreamR("YKAlogfile.txt");
            YKAFinder.Searcher(fileR1, 1, 5); fileR1.Close();
            Console.WriteLine();

            StreamReader fileR2 = YKALog.CreateStreamR("YKAlogfile.txt");
            YKAFinder.SearcherDate(fileR2, 2, 10);
            fileR2.Close();
        }
    }
}
