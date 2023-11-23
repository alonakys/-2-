using System;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.IO;

namespace lab5_1_2
{
    class Program
    {
        static void Main()
        {
            MyTime myTime = new MyTime(0, 0, 0);
            Console.WriteLine(myTime);
            Console.WriteLine(MyTime.TimeSinceMidnight(myTime));
            Console.WriteLine(MyTime.TimeSinceMidnight(56749));
            Console.WriteLine(MyTime.AddOneSecond(myTime));
            Console.WriteLine(MyTime.AddOneMinute(myTime));
            Console.WriteLine(MyTime.AddOneHour(myTime));
            Console.WriteLine(MyTime.AddSeconds(myTime, 12));
            Console.WriteLine();
        }
        
    }
}
