﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.ComponentModel;


namespace TestConsole2
{
    internal static class TPLTests
    {

        public static void Start()
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


            //Parallel.For(0, 100,
            //    new ParallelOptions { MaxDegreeOfParallelism = 3},
            //    i => ParallelInvokeMethod($"Message {i}"));

            //var for_result = Parallel.For(0, 100,
            // new ParallelOptions { MaxDegreeOfParallelism = 3 },
            // (i, state) =>
            // {
            //     if (i > 15) state.Break();
            //     ParallelInvokeMethod($"Message {i}");
            // });

            //Console.WriteLine("Выполнилось {0} итераций", for_result.LowestBreakIteration);


            var messages = Enumerable.Range(0, 100).Select(i => $"Message {i:000}");//.ToArray();
                                                                                    //Parallel.ForEach(messages, ParallelInvokeMethod);
            Parallel.ForEach(messages, s => ParallelInvokeMethod(s));
            var foreach_result = Parallel.ForEach(messages, (s, state) =>
            {
                if (s.EndsWith("20")) state.Break();
                ParallelInvokeMethod(s);
            });

            Console.WriteLine("Выполнилось {0} итераций", foreach_result.LowestBreakIteration);

            //var selected_messages = messages.Select(m => (msg: m, length: m.Length)).Where(m => m.msg.EndsWith("20")).ToArray();

            
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