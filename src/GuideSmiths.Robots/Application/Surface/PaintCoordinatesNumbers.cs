using GuideSmiths.Robots.Application.Robot;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuideSmiths.Robots.Application.Surface
{
    public class PaintCoordinatesNumbers
    {
        public static void PaintNumbers(List<Coordinates> cursorPositionList)
        {
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
            for (int i = cursorPositionList[1].YPosition - 1; i > cursorPositionList[0].YPosition; i--)
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
        }
    }
}
