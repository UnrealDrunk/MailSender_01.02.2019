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
            //SynchronizationTests.Start();
            //TPLTests.Start();
            //TaskTests.Start();
            //TaskTests.StartAsync();

            TaskTests.StartDataProcessAsync();

            Console.ReadLine();


            Console.WriteLine("Приложение должно быть закрыто");
        }

        


    }
}
