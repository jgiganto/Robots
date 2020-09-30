using GuideSmiths.Robots.Application.Robot;
using System;
using System.Collections.Generic;

namespace GuideSmiths.Robots.Application.Surface
{
    public class PaintSurface
    {
       
        public static void Paint(SurfaceBase SurfaceDimensions)
        {
            Console.Clear();
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
            Console.ResetColor();
            
            List<Coordinates> cursorPositionList = new List<Coordinates>();
            List<Coordinates> robotPath = new List<Coordinates>();
            Coordinates initialRobotPosition = new Coordinates();
            Coordinates robotPositionInMarthSurface = new Coordinates();
            Coordinates previousRobotPosition = new Coordinates();
            Orientation orientation = new Orientation();
            Motion motion = new Motion();
            Console.CursorVisible = false;
            Coordinates actualPosition = new Coordinates();
            

            Console.WriteLine("Now initial coordinates of the robot and It´s orientation (N, S, E, W)");
            Console.Write("Enter the X: ");
            robotPositionInMarthSurface.XPosition = Convert.ToInt32(Console.ReadLine());
            System.Threading.Thread.Sleep(10);

            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.Write("              ");
            Console.Write("Enter the Y: ");
            robotPositionInMarthSurface.YPosition = Convert.ToInt32(Console.ReadLine());
            System.Threading.Thread.Sleep(10);
          
            Console.Write("Enter the Orientation of Robot(N, S, E, W): "); 
            initialRobotPosition.Orientation = Console.ReadLine();
            System.Threading.Thread.Sleep(10);
          
            Console.Write("Give the instructions for the Robot (L/R/F): ");
            var instructions = Console.ReadLine();
            System.Threading.Thread.Sleep(10);
            



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

             
            initialRobotPosition.XPosition = xLeft + robotPositionInMarthSurface.XPosition;
            initialRobotPosition.YPosition = yUp - robotPositionInMarthSurface.YPosition;
            previousRobotPosition = initialRobotPosition;

            Console.SetCursorPosition(initialRobotPosition.XPosition, initialRobotPosition.YPosition);
             
            var robotState = orientation.GetSymbolAndOrientation(instructions[0], initialRobotPosition.Orientation);
            Console.Write(robotState.symbol);
            System.Threading.Thread.Sleep(400);
            Console.SetCursorPosition(initialRobotPosition.XPosition, initialRobotPosition.YPosition);
            Console.Write(" ");

            foreach (char command in instructions)
            {
                

                switch (command)
                {
                    case 'L':
                        robotState = orientation.GetSymbolAndOrientation('L', initialRobotPosition.Orientation);
                        initialRobotPosition.Orientation = robotState.orientation;
                        break;
                    case 'R':
                        robotState = orientation.GetSymbolAndOrientation('R', initialRobotPosition.Orientation);
                        initialRobotPosition.Orientation = robotState.orientation;
                        break;
                    case 'F':
                        previousRobotPosition = (new Coordinates { XPosition = actualPosition.XPosition, YPosition = actualPosition.YPosition });
                        actualPosition = motion.MoveRobotForward(initialRobotPosition, robotPositionInMarthSurface, initialRobotPosition.Orientation);
                        break;
                }
                //robotState = orientation.GetSymbolAndOrientation(command, initialRobotPosition.Orientation);

                Console.SetCursorPosition(actualPosition.XPosition, actualPosition.YPosition);

                if (robotPositionInMarthSurface.XPosition >= SurfaceDimensions.MaximunXAxis ||
                 robotPositionInMarthSurface.YPosition >= SurfaceDimensions.MaximunYAxis ||
                 robotPositionInMarthSurface.XPosition < SurfaceDimensions.MinimumXAxis ||
                 robotPositionInMarthSurface.YPosition < SurfaceDimensions.MinimumYAxis
                 )
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("X");
                    System.Threading.Thread.Sleep(4000);
                    break;
                }
                Console.Write(robotState.symbol);
             
                Console.SetCursorPosition(previousRobotPosition.XPosition, previousRobotPosition.YPosition);
                Console.Write(" ");


             

                System.Threading.Thread.Sleep(400);
            }

            

            Console.ResetColor();

        }
        
    }
}


//Console.SetCursorPosition(cursorPositionList[0].XPosition + 1, cursorPositionList[0].YPosition + 1);
//Console.Write("B");
//Console.SetCursorPosition(cursorPositionList[1].XPosition - 2, cursorPositionList[1].YPosition - 1);
//Console.Write("E");
//Console.ForegroundColor = ConsoleColor.Red;


//Console.WriteLine($"eje X: {SurfaceDimensions.MaximunXAxis}  eje Y: {SurfaceDimensions.MaximunYAxis}");
//Console.WriteLine($"eje X: {SurfaceDimensions.MinimumXAxis}  eje Y: {SurfaceDimensions.MinimumYAxis}");