using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyPast
{
    class Program
    {
        static void Main(string[] args)
        {
            System.IO.DirectoryInfo infoFirst = new System.IO.DirectoryInfo(@"N:\TAMUZ8\Pictures\");
            System.IO.FileInfo[] filesFirst = infoFirst.GetFiles();

            System.IO.DirectoryInfo infoSecond = new System.IO.DirectoryInfo(@"W:\Tamuz8\PICTURES\");
            System.IO.FileInfo[] filesSecond = infoSecond.GetFiles();
            int count = 0;

            Stopwatch stopWatch = new Stopwatch();
            

            if (Directory.GetFiles(infoSecond.ToString()).Length != Directory.GetFiles(infoFirst.ToString()).Length)
            {
                Console.WriteLine("Start!");

                foreach (FileInfo x in filesFirst)
                {
                    stopWatch.Start();
                    Console.WriteLine("Working...");

                    if (!File.Exists(infoSecond.ToString() + x.Name))
                    {
                        Console.WriteLine("Find!");
                        File.Copy(infoFirst.ToString() + x.Name, infoSecond.ToString() + x.Name);
                        Console.WriteLine("Name: {0}", x.Name);
                        count++;
                    }
                }
            }
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);

            Console.WriteLine("New files: {0}", count);
            Console.ReadLine();

        }
    }
}
