using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CopyPast
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread Thread1 = new Thread(Compare);
            Thread Thread2 = new Thread(Compare);
            Thread Thread3 = new Thread(Compare);

            Thread1.Start();
            Thread2.Start();
            Thread3.Start();

            Console.ReadLine();
        }

        static void Compare()
        {
            System.IO.DirectoryInfo infoFirst = new System.IO.DirectoryInfo(@"C:\Users\druzhinin\Desktop\test\");
            System.IO.FileInfo[] filesFirst = infoFirst.GetFiles();

            System.IO.DirectoryInfo infoSecond = new System.IO.DirectoryInfo(@"C:\Users\druzhinin\Desktop\test\2\");
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
                        try
                        {
                            File.Copy(infoFirst.ToString() + x.Name, infoSecond.ToString() + x.Name);
                            Console.WriteLine("Find!");
                            Console.WriteLine("Name: {0}", x.Name);
                            Console.WriteLine(String.Format("{0}", stopWatch.Elapsed));
                            count++;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
            }
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);

            Console.WriteLine("New files: {0}", count);
        }
    }
}
