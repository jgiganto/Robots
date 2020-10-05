using GuideSmiths.Robots.Application.Surface;
using GuideSmiths.Robots.Application.Utils;
using GuideSmiths.Robots.Assets;
using System;

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
            Console.Title = "ASCII Art";
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.ForegroundColor = ConsoleColor.Green;
            PaintSurface paintSurface = new PaintSurface();
            SurfaceBase surfaceDimensions = new SurfaceBase();
            Questionaries questionary = new Questionaries();


            Console.WriteLine(Tittle.MartianRobot);
            Console.ResetColor();
            System.Threading.Thread.Sleep(50);


            surfaceDimensions = questionary.DefineSurface();


            while (exit != "E")
            {
                paintSurface.Paint(surfaceDimensions);

                Console.SetCursorPosition(0, 0);                
                Console.WriteLine("Escriba 'E' para salir:");
                exit = Console.ReadLine().ToString();
                Console.Clear();
            }
            CloseProgram.Close();
        }      
    }
}
