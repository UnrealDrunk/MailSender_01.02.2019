using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestConsole2
{
    class Program
    {
        static void Main(string[] args)
        {
            //ThreadTests.Start();
            //ThreadPoolTests.Start();

            //Первый способ реализации асинхронных операций
            //new Thread(() => { Console.WriteLine("Печать внутри потока"); }) { IsBackground=true}.Start();


            //Второй способ реализации асинхронных операций
            Action<string> printer = str => Console.WriteLine("Печать сообщения из потока{0}:{1}", Thread.CurrentThread.ManagedThreadId, str);
            //printer("Message 1");
            //printer.Invoke("Messsage 2");

            //IAsyncResult result = null;
            //result = printer.BeginInvoke("Message 3", r=> printer.EndInvoke(result), null);


            //Третий способ реализации асинхронных операций
            //var worker = new BackgroundWorker();
            //worker.DoWork += (s, e) => {/* Здесь выполняется сама асинхронная операция*/};
            //worker.ProgressChanged += (s, e) => { /*Выполняются действи по изменению  UI при изменении програесса операции*/};
            //worker.RunWorkerCompleted - при завершении опреации
            //worker.RunWorkerAsync();

            //SynchronizationTests.Start();

            //Parallel.Invoke(
            //    ParallelInvokeMethod,
            //    ParallelInvokeMethod,
            //    ParallelInvokeMethod,
            //    ()=> Console.WriteLine("Ещё один параллельный вызов"));

            //Parallel.Invoke(
            //    new ParallelOptions { MaxDegreeOfParallelism = 2},
            //    () => { Console.WriteLine("Действие 1"); },
            //    () => { Console.WriteLine("Действие 2"); },
            //    () => { Console.WriteLine("Действие 3"); }
            //);

            //Parallel.Invoke(
            //    new ParallelOptions { MaxDegreeOfParallelism=3},
            //    Enumerable.Repeat(new Action(ParallelInvokeMethod), 100).ToArray());

            //var messages = Enumerable.Range(1, 100).Select(i => $"Message {i:000}.").ToArray();

            //Parallel.For(0, 100,
            //    new ParallelOptions { MaxDegreeOfParallelism = 3},
            //    i => ParallelInvokeMethod($"Message {i}"));

            var for_result = Parallel.For(0, 100,
             new ParallelOptions { MaxDegreeOfParallelism = 3 },
             (i, state) =>
             {
                 if (i > 15) state.Break();
                 ParallelInvokeMethod($"Message {i}");
             });

            Console.WriteLine("Выполнилось {0} итераций", for_result.LowestBreakIteration);
            Console.ReadLine();
            Console.WriteLine("Приложение должно быть закрыто");

        }

        private static void ParallelInvokeMethod()
        {
            Console.WriteLine("ThrID: {0} - started", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(250);
            Console.WriteLine("ThrID:{0} - finished", Thread.CurrentThread.ManagedThreadId);
        }

        private static void ParallelInvokeMethod(string msg)
        {
            Console.WriteLine("ThrID: {0} - started: {1}", Thread.CurrentThread.ManagedThreadId, msg);
            Thread.Sleep(250);
            Console.WriteLine("ThrID:{0} - finished: {1}", Thread.CurrentThread.ManagedThreadId, msg);
        }


    }
}
