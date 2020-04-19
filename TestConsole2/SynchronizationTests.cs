using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.CompilerServices;
using System.IO;
using System.Runtime.Remoting.Contexts;

namespace TestConsole2
{
    internal static class SynchronizationTests
    {

        public static void Start()
        {
            var threads = new Thread[10];

            for (var i =0; i < threads.Length; i++)
            {
                var i0 = i;
                threads[i] = new Thread(()=> Printer3($"Message {i0}"));
            }

            Array.ForEach(threads, thread => thread.Start());

        }

        private static readonly object _SyncRoot = new object();

        private static void Printer(string Message, int Count =20)
        {
            for (var i =0; i <Count; i++)
            {
                lock (_SyncRoot)
                {
                    Console.Write("id: {0}", Thread.CurrentThread.ManagedThreadId);
                    Console.Write(" - msg({0}):", i);
                    Console.WriteLine("\"{0}\"", Message);
                }
         
            }
        }


        [MethodImpl(MethodImplOptions.Synchronized)]
        private static void Printer3(string Message, int Count = 20)
        {
            for (var i = 0; i < Count; i++)
            {
                lock (_SyncRoot)
                {
                    Console.Write("id: {0}", Thread.CurrentThread.ManagedThreadId);
                    Console.Write(" - msg({0}):", i);
                    Console.WriteLine("\"{0}\"", Message);
                }
                //Thread.SpinWait(100000);
            }
        }


    }

    [Synchronization]
    internal class Logger: ContextBoundObject
    {
        private string _FilePath;

        public string FilePath
        {
            get => _FilePath;
            set
            {
                if (!File.Exists(value))
                {
                    throw new FileNotFoundException("Файл не найден", value);
                }
                _FilePath = value;
            }
        }

        public Logger(string Path) => _FilePath = Path;

        //[MethodImpl(MethodImplOptions.Synchronized)]
        public void Log(string Message)
        {
            //lock (this)
            //{
            //    File.AppendAllText(_FilePath, Message);
            //}

            File.AppendAllText(_FilePath, Message);


        }


    }

}
