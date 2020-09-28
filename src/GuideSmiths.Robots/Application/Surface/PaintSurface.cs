using GuideSmiths.Robots.Application.Robot;
using System;
using System.Collections.Generic;

namespace GuideSmiths.Robots.Application.Surface
{
    public class PaintSurface
    {
        public static void Paint()
        {
            List<Coordinates> cursorPositionList = new List<Coordinates>();
            Orientation orientation = new Orientation();
            Console.CursorVisible = false;
            int robotx = 0;
            int roboty = 0;
             


            SurfaceBase SurfaceDimensions = new SurfaceBase();

            Console.WriteLine("Enter a value for the X");
            SurfaceDimensions.MaximunXAxis = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter a value for the Y");
            SurfaceDimensions.MaximunYAxis = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the initial coordinates of the robot and It´s orientation N, S, E, W");
            Console.WriteLine("X: ");
            robotx = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Y: ");
            roboty = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Orientation: ");
            var robotOrientation = Console.ReadLine();
            Console.WriteLine("Give the instructions for the Robot (L/R/F): ");
            var robotPath = Console.ReadLine();




            //Console.WriteLine($"eje X: {SurfaceDimensions.MaximunXAxis}  eje Y: {SurfaceDimensions.MaximunYAxis}");
            //Console.WriteLine($"eje X: {SurfaceDimensions.MinimumXAxis}  eje Y: {SurfaceDimensions.MinimumYAxis}");

            var surfaceUp = "╔";
            var space = "";
            var surfaceDown = "╚";
            var bottomLine = "";
            var marginLeft = "                    ";

            for (int i = SurfaceDimensions.MinimumXAxis; i < SurfaceDimensions.MaximunXAxis; i++)
            {
                surfaceUp += "═";
                space += $" ";
                bottomLine += "═";

            }
            surfaceUp += "╗";
            //Console.WriteLine(); 

            Console.Write(marginLeft);

            cursorPositionList.Add(new Coordinates()
            {
                XPosition = Console.CursorLeft,
                YPosition = Console.CursorTop
            });

            Console.Write(surfaceUp);
            Console.WriteLine();




            for (int i = SurfaceDimensions.MinimumYAxis; i < SurfaceDimensions.MaximunYAxis; i++)
            {
                Console.WriteLine(marginLeft + "║" + space + "║");
            }
            Console.Write(marginLeft + surfaceDown + bottomLine + "╝");

            cursorPositionList.Add(new Coordinates()
            {
                XPosition = Console.CursorLeft,
                YPosition = Console.CursorTop
            });

            //PaintCoordinatesNumbers.PaintNumbers(cursorPositionList);
            int xLeft = cursorPositionList[0].XPosition + 1;
            int yUp = cursorPositionList[0].YPosition + SurfaceDimensions.MaximunYAxis;
            Console.SetCursorPosition(xLeft + robotx ,yUp - roboty);
            Console.ForegroundColor = ConsoleColor.Red;

            var symbol = orientation.CalculateOrientation(robotPath, robotOrientation);
            Console.Write(symbol);
            Console.ResetColor();



            //Console.SetCursorPosition(cursorPositionList[0].XPosition + 1, cursorPositionList[0].YPosition + 1);
            //Console.Write("B");
            //Console.SetCursorPosition(cursorPositionList[1].XPosition - 2, cursorPositionList[1].YPosition - 1);
            //Console.Write("E");

        }
        
    }
}
