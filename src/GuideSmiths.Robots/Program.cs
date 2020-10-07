using GuideSmiths.Robots.Application.Robot;
using GuideSmiths.Robots.Application.Surface;
using GuideSmiths.Robots.Application.Utils;
using GuideSmiths.Robots.Assets;
using System;
using System.Collections.Generic;
using System.Threading;

namespace GuideSmiths.Robots
{
    public class Program
    {
        
        public Program()
        {            
        }
        static void Main(string[] args)
        {
            var exit = "";
            Console.Title = "rOBOt";
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.ForegroundColor = ConsoleColor.Green;
            PaintSurface paintSurface = new PaintSurface();
            SurfaceBase surfaceDimensions = new SurfaceBase();
            Questionaries questionary = new Questionaries();
            List<Coordinates> poisonCoordinates = new List<Coordinates>();

            Console.WriteLine(Tittle.MartianRobot);
            Console.ResetColor();
            Thread.Sleep(50);


            surfaceDimensions = questionary.DefineSurface();


            while (exit != "E")
            {
                paintSurface.Paint(surfaceDimensions, poisonCoordinates);

                Console.SetCursorPosition(0, 0);                
                Console.WriteLine("Escriba 'E' para salir:");
                exit = Console.ReadLine().ToString().ToUpper();
                Console.Clear();
            }

            Console.WriteLine($"Poisoned:");
            Console.WriteLine($"--------");
            foreach (var poisonUbication in poisonCoordinates)
            {
                Console.WriteLine($"X: {poisonUbication.XPosition}, Y: {poisonUbication.YPosition} ");
            }

            Thread.Sleep(6000);
            CloseProgram.Close();
        }      
    }
}
