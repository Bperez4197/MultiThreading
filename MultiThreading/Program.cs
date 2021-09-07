using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MultiThreading
{
    class Program
    {

        private static bool count = true;
        static void Main(string[] args)
        {
            Thread threadA = new Thread(ThreadA);
            Thread threadB = new Thread(ThreadB);

            Console.WriteLine("Upon pressing enter, this application will count as high as" +
              " it can until you press enter again.");
            ConsoleKeyInfo userKey = Console.ReadKey();
            if(userKey.Key == ConsoleKey.Enter)
            {
                threadA.Start();
                threadB.Start();
            }

            userKey = Console.ReadKey();
            if(userKey.Key == ConsoleKey.Enter)
            {
                count = false;
            }

            Console.ReadLine();
            
           
        }

        static void ThreadA()
        {
            int num = 0;
            while(num < int.MaxValue && count)
            {
                num++;
            }

            Console.WriteLine($"A: {num}");
        }

        static void ThreadB()
        {
            int num = 0;
            while(count && num < int.MaxValue)
            {
                num++;
            }

            Console.WriteLine($"B: {num}");
        }
    }
}
