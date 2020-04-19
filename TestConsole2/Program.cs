using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole2
{
    class Program
    {
        static void Main(string[] args)
        {
            //ThreadTests.Start();
            //ThreadPoolTests.Start();

            SynchronizationTests.Start();
            Console.ReadLine();
            Console.WriteLine("Приложение должно быть закрыто");

        }
    }
}
