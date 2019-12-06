using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ManageProgramFlow
{
    public class Cancel_task
    {
        CancellationTokenSource cts = new CancellationTokenSource();
        public void Clock( CancellationToken token)
        {
            int count = 0;
            while (!token.IsCancellationRequested && count<10)
            {
                count++;
                Console.WriteLine("Tiktok");
                Thread.Sleep(200);
            }
            token.ThrowIfCancellationRequested();
        }
        
    }
}
