using GuideSmiths.Robots.Application.Robot;
using GuideSmiths.Robots.Application.Robot.Factory;
using GuideSmiths.Robots.Assets;
using System;
using System.Collections.Generic;
using System.Threading;
using static GuideSmiths.Robots.Application.Robot.Contracts.Motion;

namespace GuideSmiths.Robots.Application.Surface
{
    public class PaintSurface
    {
        List<Coordinates> cursorPositionList;
        //List<Coordinates> robotPath;
        Coordinates initialRobotPosition;
        Coordinates robotPositionInMarthSurface;
        Coordinates previousRobotPosition;
        Coordinates actualPosition;
        Coordinates newCoordinates;
        MoveRobotForward nextPosition;
        Orientation orientation;
        //Motion motion;
        MotionFactory motionFactory;
        Questionaries questionary;
        
        public PaintSurface()
        {
            cursorPositionList = new List<Coordinates>();
           // robotPath = new List<Coordinates>();
            initialRobotPosition = new Coordinates();
            robotPositionInMarthSurface = new Coordinates();
            previousRobotPosition = new Coordinates();
            actualPosition = new Coordinates();
            newCoordinates = new Coordinates();
            orientation = new Orientation();
            //motion = new Motion();
            
            motionFactory = new MotionFactory();
            questionary = new Questionaries();
        }
                
        public void Paint(SurfaceBase SurfaceDimensions)
        {          
            Console.Clear();
            Console.Title = "ASCII Art";
            Console.ForegroundColor = ConsoleColor.Green;           
            Console.WriteLine(Tittle.MartianRobot);
            Thread.Sleep(50);
            Console.ResetColor();                     
            Console.CursorVisible = false;


            var robotInitial = questionary.RobotPositionAndCommands();
            robotPositionInMarthSurface = robotInitial.robotPositionInMarthSurface;
            initialRobotPosition = robotInitial.initialRobotPosition;

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
             
            var robotState = orientation.GetSymbolAndOrientation(robotInitial.instructions[0], initialRobotPosition.Orientation);
            Console.Write(robotState.symbol);
            Thread.Sleep(1000);
            Console.SetCursorPosition(initialRobotPosition.XPosition, initialRobotPosition.YPosition);
            Console.Write(" ");

            foreach (char command in robotInitial.instructions)
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
                        var orientationType = initialRobotPosition.Orientation;
                        nextPosition = motionFactory.MoveRobotByOrientation(orientationType);
                        newCoordinates = nextPosition.GetNewCoordinates(initialRobotPosition, robotPositionInMarthSurface, initialRobotPosition.Orientation);
                        actualPosition = newCoordinates;
                        break;
                }

                Console.SetCursorPosition(newCoordinates.XPosition, newCoordinates.YPosition);

                if (robotPositionInMarthSurface.XPosition >= SurfaceDimensions.MaximunXAxis ||
                 robotPositionInMarthSurface.YPosition >= SurfaceDimensions.MaximunYAxis ||
                 robotPositionInMarthSurface.XPosition < SurfaceDimensions.MinimumXAxis ||
                 robotPositionInMarthSurface.YPosition < SurfaceDimensions.MinimumYAxis
                 )
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("X");
                    Thread.Sleep(4000);
                    break;
                }
                Console.Write(robotState.symbol);
             
                Console.SetCursorPosition(previousRobotPosition.XPosition, previousRobotPosition.YPosition);
                Console.Write(" ");

                Thread.Sleep(1000);
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