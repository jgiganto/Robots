using System;
using System.Threading;

namespace GuideSmiths.Robots.Application.Utils
{
    public class LinesCleaner
    {
        public static void Clean()
        {
            int left = Console.CursorLeft;
            Thread.Sleep(10);
            Console.SetCursorPosition(left, Console.CursorTop - 1);
            BlankLine();
            Console.SetCursorPosition(left, Console.CursorTop - 1);
        }

        public static void BlankLine()
        {           
            Console.WriteLine(new string(' ', Console.WindowWidth));             
        }      
    }
}
