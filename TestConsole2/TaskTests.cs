using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace TestConsole2
{
    internal static class TaskTests
    {
        public static void Start()
        {
            #region Пример нелучшего способа работы с задачами (но всё равно работает)
            //var first_thread = new Task(TaskMethod);
            //first_thread.Start();

            //new Task(TaskMethod).Start();

            //const string msg = "Hello World!";

            //var calculation_task = new Task<int>(() => GetMessageLength(msg));
            //calculation_task.Start();

            //var continuation_task = calculation_task.ContinueWith(t => Console.WriteLine("Длинна сообщения {0}", t.Result));
            //continuation_task.ContinueWith(t => Console.WriteLine("Теперь точно конец"));

            //for(int i =0; i< 20; i++)
            //{
            //    Thread.Sleep(30);
            //    Console.WriteLine("Работа в основном потоке");
            //}
            //calculation_task.Wait();

            //var msg_length = calculation_task.Result;
            //Console.WriteLine("Длинна сообщения {0}", msg_length);
            #endregion

            const string msg = "Hello World!";

            #region Примеры работы с задачами не совсем корректным способом. Подразумевается использование там, где это нужно
            //var action_task = Task.Run(() => TaskMethod());

            //var result_task = Task.Run(() => GetMessageLength(msg));
            //result_task.ContinueWith(t => Console.WriteLine("Длинна сообщения {0}", t.Result));

            //var fault_task = Task.Run(() => GetMessageLength(null));
            //fault_task.ContinueWith(t => Console.WriteLine("Длинна сообщения {0}", t.Result, TaskContinuationOptions.OnlyOnRanToCompletion));
            //fault_task.ContinueWith(t => Console.WriteLine("В задаче произошла ошибка: {0}", t.Exception.Message), TaskContinuationOptions.OnlyOnFaulted);

            ////var fault_len = fault_task.Result;
            ////fault_task.Wait();

            //int fault_len = -1;

            //try
            //{
            //    fault_len = fault_task.Result;
            //    fault_task.Wait();
            //}
            //catch (AggregateException e)
            //{

            //    Console.WriteLine(e.Message);
            //}

        }

        #endregion



        public static async void StartAsync()
        {

            //var action_task = Task.Run(() => TaskMethod());
            //await action_task;

            // Синхронная часть метода выполняется в том же самом потоке, откуда был вызван StartAsync

            Console.WriteLine("Подготовка к запуску асинхронной операции ThrID:{0}", Thread.CurrentThread.ManagedThreadId);

            await Task.Run(()=> TaskMethod()).ConfigureAwait(true);// здест стартует задача в параллельном потоке и мы ждём её завершения

            // Выполнение пытается вернуться в тот же самый поток, в котром был да await

            Console.WriteLine("Обработка данных после запуска ThrID:{0}", Thread.CurrentThread.ManagedThreadId);

            var msg_len = await Task.Run(() => GetMessageLength("Hello World!!!")).ConfigureAwait(false);

            Console.WriteLine("Длинна сообщения {0} (ThrID:{1})", msg_len, Thread.CurrentThread.ManagedThreadId);
        }


        public static async void StartDataProcessAsync()
        {
            var messages = Enumerable.Range(1, 300).Select(i => $"Message {i}").ToArray();

            var tasks = messages.Select(msg => Task.Run(() => GetMessageLength(msg, 30)));

            //Task.WaitAll(tasks.ToArray());
            //Task.WaitAny(tasks.ToArray());

            //var complete_all_task = Task.WhenAll(tasks);
            //var complete_all_tasks = Task.WhenAny(tasks);

            var result = await Task.WhenAll(tasks);

            Console.WriteLine("Суммарная длинна сообщений {0}", result.Sum());

            //var tasks_array = tasks.ToArray();

            
        }


        private static void TaskMethod()
        {
            Console.WriteLine("ThrdID:{0} TaskID:{1} - started", Thread.CurrentThread.ManagedThreadId, Task.CurrentId);

            Thread.Sleep(1000);

            Console.WriteLine("ThrdID:{0} TaskID:{1} - started", Thread.CurrentThread.ManagedThreadId, Task.CurrentId);

        }

        private static int GetMessageLength(string msg, int Timeout = 1000)
        {
            Console.WriteLine("Входные данные: \"{0} \"", msg is null? "<null>" : msg);
            if (msg is null) throw new ArgumentNullException(nameof(msg));
            Console.WriteLine("ThrdID:{0} TaskID:{1} - started: msg {2}", Thread.CurrentThread.ManagedThreadId, Task.CurrentId, msg);

            Thread.Sleep(Timeout);

            Console.WriteLine("ThrdID:{0} TaskID:{1} - started: msg {2}", Thread.CurrentThread.ManagedThreadId, Task.CurrentId, msg);

            return msg.Length;
        }



    }

}
