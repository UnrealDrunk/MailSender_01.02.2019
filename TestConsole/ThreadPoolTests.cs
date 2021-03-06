﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestConsole
{
    class ThreadPoolTests
    {
        public static void Start()
        {

            var messages = Enumerable.Range(1, 100).Select(i => $"Message #{i}").ToArray();

            var threads = new Thread[messages.Length];
            for(var i =0; i < threads.Length; i++)
            {
                var i1 = i;
                threads[i] = new Thread(() => PrintherThread(messages[i1]));
            }

            for(var i = 0; i <threads.Length; i++)
            {
                threads[i].Start();
            }

            for (var i = 0; i < threads.Length; i++)
            {
                threads[i].Join();
            }



        }

        private static void PrintherThread(string Message)
        {
            Console.WriteLine("id: {0} - {1}", Thread.CurrentThread.ManagedThreadId, Message);
            Thread.Sleep(2000);
            Console.WriteLine("id: {0} - {1} - завершена", Thread.CurrentThread.ManagedThreadId, Message);

        }



    }
}
