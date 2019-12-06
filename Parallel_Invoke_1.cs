using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ManageProgramFlow
{
    public static class Parallel_Invoke_1
    {
        public static void Task1()
        {
            Console.WriteLine("Task 1 is starting");
            Thread.Sleep(2000);
            Console.WriteLine("Task 1 is ending");
        }
        public static void Task2()
        {
            Console.WriteLine("Task 2 is starting");
            Thread.Sleep(2000);
            Console.WriteLine("Task 2 is ending");
        }
    }
}
