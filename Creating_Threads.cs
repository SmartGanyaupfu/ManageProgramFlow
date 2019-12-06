using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ManageProgramFlow
{
    public class Creating_Threads
    {
        public void HellThread()
        {
            Console.WriteLine("Hello from the thread");
            Thread.Sleep(1000);
        }

        public void DoWork(object obj)
        {
            Console.WriteLine($"working on {obj}");
            Thread.Sleep(1000);
        }
    }
}
