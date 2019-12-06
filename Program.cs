using System;
using System.Threading.Tasks;

using System.Threading;
using System.Collections.Generic;
using System.Linq;

namespace ManageProgramFlow
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Parallel.Invoke(() => Parallel_Invoke_1.Task1(), ()=>Parallel_Invoke_1.Task2());

            //Parallel ForEach
            Paralle_ForEaach paralle_ForEaach = new Paralle_ForEaach();
            paralle_ForEaach.WorkOnItem("Normal");
            List<int> myList = new List<int>();
            for(int i = 0; i < 5; i++)
            {
                myList.Add(i);
            }
            var items = Enumerable.Range(5, 10); 
            /*
             The Parallel.ForEach method accepts two parameters. The first parameter is an
IEnumerable
collection (in this case the list myList). The second parameter provides the action to be performed on each item in the list. You can see some of the output from this program
below. Note that the tasks are not completed in the same order that they were started.
             */
            Parallel.ForEach(myList, item => { paralle_ForEaach.WorkOnItem(item); });
            Console.WriteLine("Tetsing from enumarable");
           // Parallel.ForEach(items, item => { paralle_ForEaach.WorkOnItem(item); });

            /*
             The Parallel.For method can be used to parallelize the execution of a for loop, which is governed
by a control variable.

                This implements a counter starting at 0 (the first parameter of the Parallel.For method),
for the length of the items array (the second parameter of the Parallel.For method). The third
parameter of the method is a lambda expression, which is passed a variable that provides the
counter value for each iteration.
             */

            var items3 = Enumerable.Range(100, 5).ToArray();
            //   Parallel.For(1, items3.Length, i => { paralle_ForEaach.WorkOnItem(items3[i]); });

            Create_Task1 myTask = new Create_Task1();
            Task newTask1 = new Task(() => myTask.DoWork());
            newTask1.Start();
            newTask1.Wait();
            /*
             
             The Task.Run method uses the TaskFactory.StartNew method to create and start the task,
using the default task scheduler that uses the .NET framework thread pool. The Task class
exposes a Factory property that refers to the default task scheduler.
You can create your own task scheduler or run a task scheduler in the synchronization
context of another processor. You can also create your own TaskFactory if you want to create a
number of tasks with the same configuration. The Run method, however, is the preferred way to
create a simple task, particularly if you want to use the task with async and await (covered later
in this chapter).*/
            Task<int> newTask2 = Task.Run(() => { return myTask.Work(); });

            Console.WriteLine(newTask2.Result);
            Creating_Threads ct = new Creating_Threads();

            Thread myThread = new Thread(ct.HellThread);
            myThread.Start();

            /* passing data to athread */
            ParameterizedThreadStart parameterizedThreadStart = new ParameterizedThreadStart(ct.DoWork);
            Thread thread = new Thread(parameterizedThreadStart);
            thread.Start(89);

            //same as with lamda expression
            Thread t = new Thread(my =>
            {
                ct.DoWork(my);
            });
            t.Start(2000);

            for (int i = 300; i < 306; i++)
            {
                int state = i;
                ThreadPool.QueueUserWorkItem((s) => ct.DoWork(state));
            }

            /* Canceling a task */
            CancellationTokenSource myCTS = new CancellationTokenSource();
            Cancel_task myCT = new Cancel_task();
            Task clock = Task.Run(() => myCT.Clock(myCTS.Token));
            Console.WriteLine("press any key to end");
            Console.ReadKey();
            if (clock.IsCompleted)
            {
                Console.WriteLine("clock completed");
            }
            else
            {
                try
                {
                    myCTS.Cancel();
                    clock.Wait();
                }
                catch(AggregateException ex)
                {
                    Console.WriteLine($"clock stopped nhaikaaaa : {ex.InnerExceptions[0].ToString()}");
                }
            }



        }
    }
}
