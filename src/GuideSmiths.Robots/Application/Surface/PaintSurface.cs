﻿using GuideSmiths.Robots.Application.Robot;
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
        

        Coordinates initialRobotPosition;
        Coordinates robotPositionInMarthSurface;
        Coordinates previousRobotPositionInMarthSurface;
        Coordinates previousRobotPosition;
        Coordinates actualPosition;
        Coordinates newCoordinates;
        MoveRobotForward nextPosition;
        Orientation orientation;
        string currentOrientation;
        bool stopTheRobot;

        MotionFactory motionFactory;
        Questionaries questionary;
        
        public PaintSurface()
        {
            cursorPositionList = new List<Coordinates>();
       
            initialRobotPosition = new Coordinates();
            robotPositionInMarthSurface = new Coordinates();
            previousRobotPositionInMarthSurface = new Coordinates();
            previousRobotPosition = new Coordinates();
            actualPosition = new Coordinates();
            newCoordinates = new Coordinates();
            orientation = new Orientation();
            currentOrientation = "";
            stopTheRobot = false;
            motionFactory = new MotionFactory();
            questionary = new Questionaries();
        }
                
        public void Paint(SurfaceBase SurfaceDimensions, List<Coordinates> poisonCoordinates)
        {          
            Console.Clear();
            Console.Title = "rOBOt";
            Console.ForegroundColor = ConsoleColor.Green;           
            Console.WriteLine(Tittle.MartianRobot);
            Thread.Sleep(50);
            Console.ResetColor();                     
            Console.CursorVisible = false;

            
            var robotInitial = questionary.RobotPositionAndCommands();
            stopTheRobot = false;
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

           
            int xLeft = cursorPositionList[0].XPosition + 1;
            int yUp = cursorPositionList[0].YPosition + SurfaceDimensions.MaximunYAxis;

             
            initialRobotPosition.XPosition = xLeft + robotPositionInMarthSurface.XPosition;
            initialRobotPosition.YPosition = yUp - robotPositionInMarthSurface.YPosition;
            previousRobotPosition = initialRobotPosition;

            Console.SetCursorPosition(initialRobotPosition.XPosition, initialRobotPosition.YPosition); 


            var robotState = orientation.GetSymbolAndOrientation(robotInitial.instructions[0], initialRobotPosition.Orientation);
            var robotInitialPhoto = orientation.GetOrientationSymbol(initialRobotPosition.Orientation);
        
            Console.Write(robotInitialPhoto);
            Thread.Sleep(300);
    
            Console.SetCursorPosition(initialRobotPosition.XPosition, initialRobotPosition.YPosition);
            Console.Write(" ");

           

            foreach (char command in robotInitial.instructions)
            {
                previousRobotPositionInMarthSurface = robotPositionInMarthSurface;
                switch (command)
                {
                    case 'L':

                        robotState = orientation.GetSymbolAndOrientation('L', initialRobotPosition.Orientation);
                        initialRobotPosition.Orientation = robotState.orientation;
                        newCoordinates.XPosition = initialRobotPosition.XPosition;
                        newCoordinates.YPosition = initialRobotPosition.YPosition;
                        actualPosition = newCoordinates;

                        break;
                    case 'R': 

                        robotState = orientation.GetSymbolAndOrientation('R', initialRobotPosition.Orientation);
                        initialRobotPosition.Orientation = robotState.orientation;
                        newCoordinates.XPosition = initialRobotPosition.XPosition;
                        newCoordinates.YPosition = initialRobotPosition.YPosition;
                        actualPosition = newCoordinates;

                        break;
                    case 'F':

                        previousRobotPosition = (new Coordinates { XPosition = actualPosition.XPosition, YPosition = actualPosition.YPosition });
                        
                        currentOrientation = initialRobotPosition.Orientation;
                        nextPosition = motionFactory.MoveRobotByOrientation(currentOrientation);


                        if(currentOrientation == "N")
                        {
                            var manageRobot =
                                nextPosition.GetNewCoordinates(initialRobotPosition, robotPositionInMarthSurface, SurfaceDimensions.MaximunYAxis, poisonCoordinates);
                            newCoordinates = manageRobot.nextRobotPosition;
                            stopTheRobot = manageRobot.isLost;
                            poisonCoordinates = manageRobot.getPoisonCoordinates;
                        }
                        if (currentOrientation == "E")
                        {
                            var manageRobot =
                                nextPosition.GetNewCoordinates(initialRobotPosition, robotPositionInMarthSurface, SurfaceDimensions.MaximunXAxis, poisonCoordinates);
                            newCoordinates = manageRobot.nextRobotPosition;
                            stopTheRobot = manageRobot.isLost;
                            poisonCoordinates = manageRobot.getPoisonCoordinates;
                        }

                        if (currentOrientation == "W")
                        {
                            var manageRobot =
                                nextPosition.GetNewCoordinates(initialRobotPosition, robotPositionInMarthSurface, SurfaceDimensions.MinimumXAxis, poisonCoordinates);
                            newCoordinates = manageRobot.nextRobotPosition;
                            stopTheRobot = manageRobot.isLost;
                            poisonCoordinates = manageRobot.getPoisonCoordinates;
                        }

                        if (currentOrientation == "S")
                        {
                            var manageRobot =
                                nextPosition.GetNewCoordinates(initialRobotPosition, robotPositionInMarthSurface, SurfaceDimensions.MinimumYAxis, poisonCoordinates);
                            newCoordinates = manageRobot.nextRobotPosition;
                            stopTheRobot = manageRobot.isLost;
                            poisonCoordinates = manageRobot.getPoisonCoordinates;
                        }
                        
                        actualPosition = newCoordinates;

                        break;
                }

                Console.SetCursorPosition(newCoordinates.XPosition, newCoordinates.YPosition);

                if(stopTheRobot == true)                 
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("X");
                    Console.ResetColor();

                    Console.SetCursorPosition(previousRobotPosition.XPosition, previousRobotPosition.YPosition);
                    Console.Write(" ");

                    Console.SetCursorPosition(5, 20);
                    Console.WriteLine($"X: {previousRobotPositionInMarthSurface.XPosition}," +
                      $" Y: {previousRobotPositionInMarthSurface.YPosition}, Orientation: {robotState.orientation} LOST !");
                    Thread.Sleep(3000);
                    break;
                }                

                if(stopTheRobot == false)
                {
                    Console.Write(robotState.symbol);
                    Console.SetCursorPosition(previousRobotPosition.XPosition, previousRobotPosition.YPosition);

                    if (initialRobotPosition.XPosition != previousRobotPosition.XPosition &&
                       initialRobotPosition.YPosition != previousRobotPosition.YPosition)
                    {
                        Console.Write(" ");
                    }
                    if (actualPosition.XPosition != previousRobotPosition.XPosition ||
                       actualPosition.YPosition != previousRobotPosition.YPosition)
                    {
                        Console.Write(" ");
                    }

                    Thread.Sleep(300);
                }
                 
            }
            if (stopTheRobot == false)
            {
                Console.SetCursorPosition(5, 20);
                Console.WriteLine($"X: {robotPositionInMarthSurface.XPosition}," +
                                  $" Y: {robotPositionInMarthSurface.YPosition}, Orientation: {robotState.orientation} ");
                Thread.Sleep(3000);
            }
                

            Console.ResetColor();
        }
        
    }
}