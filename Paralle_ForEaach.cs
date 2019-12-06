using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using static System.Console;

namespace ManageProgramFlow
{
    /*
     The Task.Parallel class also provides a ForEeach method that performs a parallel implementation
of the foreach loop construction, in which the WorkOnItem method
is called to process each of the items in a list.
         */
    public class Paralle_ForEaach
    {
        public void WorkOnItem(object item)
        {
            WriteLine($"started working on: {item} >item" );
            Thread.Sleep(2000);
            WriteLine($"Finished working on: {item} >item");
        }
    }
}
