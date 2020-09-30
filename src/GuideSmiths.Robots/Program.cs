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
            Console.Title = "ASCII Art";
            Console.ForegroundColor = ConsoleColor.Green;
            string tittle = @"
   _   __  _   ___  _____ __  _   _  __  ___   _   ___   _  _____
  / \,' /.' \ / o |/_  _// /.' \ / |/ / / o |,' \ / o.),' \/_  _/
 / \,' // o //  ,'  / / / // o // || / /  ,'/ o |/ o \/ o | / /  
/_/ /_//_n_//_/`_\ /_/ /_//_n_//_/|_/ /_/`_\|_,'/___,'|_,' /_/   
                                                                 
";

            Console.WriteLine(tittle);
            System.Threading.Thread.Sleep(50);
            Console.ResetColor();
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            var exit = "";
            SurfaceBase SurfaceDimensions = new SurfaceBase();
            Console.WriteLine("Enter a value for the X");
            SurfaceDimensions.MaximunXAxis = Convert.ToInt32(Console.ReadLine());
            System.Threading.Thread.Sleep(10);
            Console.WriteLine("Enter a value for the Y");
            SurfaceDimensions.MaximunYAxis = Convert.ToInt32(Console.ReadLine());
            System.Threading.Thread.Sleep(10);
            while (exit != "e")
            {
                PaintSurface.Paint(SurfaceDimensions);

                Console.SetCursorPosition(0, 0);                
                Console.WriteLine("Escriba 'e' para salir:");
                exit = Console.ReadLine().ToString();
                Console.Clear();
            }
            CloseProgram.Close();
        }      
    }
}
