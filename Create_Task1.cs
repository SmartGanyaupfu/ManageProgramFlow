using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ManageProgramFlow
{
    public class Create_Task1
    {
        public void DoWork()
        {
            Console.WriteLine("Work starting");
            Thread.Sleep(2000);
            Console.WriteLine("Work finished");


        }
        public int Work()
        {
            Console.WriteLine("Work starting");
            Thread.Sleep(2000);
            Console.WriteLine("Work finished");
            return 1989;

        }
    }
}
