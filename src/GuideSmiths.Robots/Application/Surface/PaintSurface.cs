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
            Console.CursorVisible = false;

            SurfaceBase SurfaceDimensions = new SurfaceBase();

            Console.WriteLine("Enter a value for the X");
            SurfaceDimensions.MaximunXAxis = Convert.ToInt32(Console.ReadLine());


            Console.WriteLine("Enter a value for the Y");
            SurfaceDimensions.MaximunYAxis = Convert.ToInt32(Console.ReadLine());


            Console.WriteLine($"eje X: {SurfaceDimensions.MaximunXAxis}  eje Y: {SurfaceDimensions.MaximunYAxis}");
            Console.WriteLine($"eje X: {SurfaceDimensions.MinimumXAxis}  eje Y: {SurfaceDimensions.MinimumYAxis}");

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

            var nave = "Q";
            var xpos = -1;
            for (int i = cursorPositionList[0].XPosition + 1; i < cursorPositionList[1].XPosition - 1; i++)
            {
                xpos++;
                //if (i != cursorPositionList[0].XPosition + 1)
                //{
                //    //Delete the previous char by setting it to a space

                //    Console.SetCursorPosition(i - 1, cursorPositionList[0].YPosition + 1);

                //    Console.Write(" ");
                //}

                // Write the new char
                Console.CursorVisible = false;
                //Console.SetCursorPosition(20, 9);
                Console.SetCursorPosition(i, cursorPositionList[1].YPosition - 1);
                Console.Write(xpos);

                System.Threading.Thread.Sleep(200);
            }

            var ypos = -1;
            //for (int i = cursorPositionList[0].YPosition + 1; i < cursorPositionList[1].YPosition ; i++)
                for (int i = cursorPositionList[1].YPosition - 1; i > cursorPositionList[0].YPosition ; i--)
                {
                ypos++;
                //if (i != cursorPositionList[1].YPosition - 1)
                //{
                //    //Delete the previous char by setting it to a space

                //    Console.SetCursorPosition(cursorPositionList[1].XPosition - 2, i + 1);

                //    Console.Write(" ");
                //}

                // Write the new char
                Console.CursorVisible = false;
                //Console.SetCursorPosition(20, 9);
                Console.SetCursorPosition(cursorPositionList[0].XPosition + 1, i);
                Console.Write(ypos);

                System.Threading.Thread.Sleep(200);
            }



            //Console.SetCursorPosition(cursorPositionList[0].XPosition + 1, cursorPositionList[0].YPosition + 1);
            //Console.Write("B");
            //Console.SetCursorPosition(cursorPositionList[1].XPosition - 2, cursorPositionList[1].YPosition - 1);
            //Console.Write("E");

        }
        
    }
}
