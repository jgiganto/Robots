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
            DrawGame paintSurface = new DrawGame();
            SurfaceBase surfaceDimensions = new SurfaceBase();
            Questionaries questionary = new Questionaries();
            List<Coordinates> dangerCoordinates = new List<Coordinates>();

            Console.WriteLine(Tittle.MartianRobot);
            Console.ResetColor();
            Thread.Sleep(50);

            surfaceDimensions = questionary.DefineSurface();

            while (exit != "E")
            {

                paintSurface.Paint(surfaceDimensions, dangerCoordinates, null, null, null);

                Console.SetCursorPosition(5, 24);
                Console.WriteLine("Enter to continue. For Exit type `E`:");
                exit = Console.ReadLine().ToString().ToUpper();
                Console.Clear();
            }

            Console.WriteLine($"Danger coordinates:");
            Console.WriteLine($"--------");
            foreach (var dangerUbication in dangerCoordinates)
            {
                Console.WriteLine($"X: {dangerUbication.XPosition}, Y: {dangerUbication.YPosition} ");
            }

            Thread.Sleep(6000);
            CloseProgram.Close();
        }      
    }
}
