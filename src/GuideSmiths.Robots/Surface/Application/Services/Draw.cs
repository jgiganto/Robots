using GuideSmiths.Robots.Application.Robot;
using System;
using System.Collections.Generic;

namespace GuideSmiths.Robots.Surface.Application.Services
{
    public class Draw
    {
        public static string Surface(int minimumXAxis, int maximunXAxis, List<Coordinates> cursorPositionList)
        {
            var surfaceUp = "╔";
            var space = "";
            var surfaceDown = "╚";
            var bottomLine = "";
            var marginLeft = "                    ";

            for (int i = minimumXAxis; i < maximunXAxis; i++)
            {
                surfaceUp += "═";
                space += $" ";
                bottomLine += "═";

            }
            surfaceUp += "╗";

            Console.Write(marginLeft);

            cursorPositionList.Add(new Coordinates()
            {
                XPosition = Console.CursorLeft,
                YPosition = Console.CursorTop
            });

            Console.Write(surfaceUp);
            Console.WriteLine();


            for (int i = minimumXAxis; i < maximunXAxis; i++)
            {
                Console.WriteLine(marginLeft + "║" + space + "║");
            }

            return (marginLeft + surfaceDown + bottomLine + "╝");
        }
    }
}
