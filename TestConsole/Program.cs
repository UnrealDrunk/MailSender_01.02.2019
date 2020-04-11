using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestConsole
{
    class Program
    {
        private static void CheckThread(Thread thread)
        {
            Console.WriteLine("Поток [{0}]: {1} - {2}фоновый", thread.ManagedThreadId, thread.Name , thread.IsBackground ? "" : "не");
        }




        static void Main(string[] args)
        {
            Thread.CurrentThread.Name = "Главный поток";
            CheckThread(Thread.CurrentThread);

            var first_thread = new Thread(FirstThreadMethod);
            first_thread.Name = "Фоновый поток";
            first_thread.Priority = ThreadPriority.BelowNormal;
            first_thread.IsBackground = true;
            first_thread.Start();


            Console.WriteLine("Главный поток завершился");
            Console.ReadLine();
        }

        private static void FirstThreadMethod()
        {
            CheckThread(Thread.CurrentThread);
            while (true)
            {
                Console.Title = DateTime.Now.ToString();
                Thread.Sleep(100);
            }


        }


    }

}
