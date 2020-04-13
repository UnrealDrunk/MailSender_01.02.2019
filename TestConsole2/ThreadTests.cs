using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestConsole2
{
    internal static class ThreadTests
    {
        private static void CheckThread(Thread thread)
        {
            Console.WriteLine("Поток [id:{0}]: {1} - {2}фоновый", thread.ManagedThreadId, thread.Name, thread.IsBackground ? "" : "не");
        }

        public static void Start()
        {
            Thread.CurrentThread.Name = "Главный поток";
            CheckThread(Thread.CurrentThread);

            var clock_thread = new Thread(ClockThreadMethod);
            clock_thread.Name = "Фоновый поток";
            clock_thread.Priority = ThreadPriority.BelowNormal;
            //clock_thread.IsBackground = true;
            clock_thread.Start();

            var message = "Вечер в хату!!!";

            //var printer1_thread = new Thread(new ParameterizedThreadStart(PrinterThread));

            //var printer1_thread = new Thread(PrinterThread);
            //printer1_thread.Start(message);

            //var printer2_thread = new Thread(() => PrintherThread(message));

            //printer2_thread.Start();

            var printer_data = new PrinterData(message);
            var printer3_thread = new Thread(printer_data.Print);
            printer3_thread.Start();


            Console.WriteLine("Главный поток завершился");
            Console.ReadLine();

            if (!clock_thread.Join(50))
            {
                clock_thread.Interrupt();
            }

            _ClockCanWork = false;
            //clock_thread.Abort();
        }


        private static bool _ClockCanWork = true;

        private static void ClockThreadMethod()
        {

            try
            {
                CheckThread(Thread.CurrentThread);
                while (_ClockCanWork)
                {
                    Console.Title = DateTime.Now.ToString();
                    Thread.Sleep(100);
                }

            }
            catch (ThreadInterruptedException)
            {
                Console.WriteLine("Поток был прерван");

            }

            Console.WriteLine("Поток часов завершил свою работу");


        }


        private static void PrinterThread(object parameter)
        {
            PrintherThread((string)parameter);
        }

        private static void PrintherThread(string Message)
        {
            Console.WriteLine("Печать сообщения из потока id: {0} - {1}", Thread.CurrentThread.ManagedThreadId, Message);
            Thread.Sleep(2000);
            Console.WriteLine("Печать сообщения из потока id: {0} - {1} - завершена", Thread.CurrentThread.ManagedThreadId, Message);

        }


        class PrinterData
        {
            private string _Message;

            public PrinterData(string Message) => _Message = Message;

            public void Print() => Console.WriteLine("Печать сообщения из потока id: {0} - {1}", Thread.CurrentThread.ManagedThreadId, _Message);

        }

    }
}
