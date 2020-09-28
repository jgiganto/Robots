using GuideSmiths.Robots.Application.Robot;
using GuideSmiths.Robots.Application.Surface;
using GuideSmiths.Robots.Application.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;

namespace GuideSmiths.Robots
{
    class Program
    {
        
        public Program()
        {            
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            var exit = "";

            while (exit != "e")
            {
                PaintSurface.Paint();

                Console.WriteLine(); Console.WriteLine(); Console.WriteLine(); Console.WriteLine();
                Console.WriteLine("e para salir---");

                exit = Console.ReadLine().ToString();
                Console.Clear();

            }
            CloseProgram.Close();
        }      
    }
}
