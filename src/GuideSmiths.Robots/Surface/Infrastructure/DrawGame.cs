using GuideSmiths.Robots.Application.Robot;
using GuideSmiths.Robots.Application.Robot.Factory;
using GuideSmiths.Robots.Assets;
using GuideSmiths.Robots.Robot.Domain;
using GuideSmiths.Robots.Surface.Application.Services;
using GuideSmiths.Robots.Utils;
using System;
using System.Collections.Generic;
using System.Threading;
using static GuideSmiths.Robots.Application.Robot.Contracts.Motion;

namespace GuideSmiths.Robots.Application.Surface
{
    public class DrawGame
    {
        List<Coordinates> cursorPositionList;
        Coordinates initialRobotPositionOnScreen;
        Coordinates robotPositionInMarthSurface;
        Coordinates previousRobotPositionInMarthSurface;
        Coordinates previousRobotPosition;
        Coordinates actualPosition;
        Coordinates newCoordinates;
        MoveRobotForward nextPosition;
        Orientation orientation;
        string currentOrientation;
        bool stopTheRobot;
        RobotInitial robotInitial;
        MotionFactory motionFactory;
        Questionaries questionary;
        

        public DrawGame()
        {
            cursorPositionList = new List<Coordinates>();
       
            initialRobotPositionOnScreen = new Coordinates();
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
            robotInitial = new RobotInitial();
            
        }
                
        public string Paint(SurfaceBase SurfaceDimensions,
            List<Coordinates> dangerCoordinates,
            Coordinates robotPositionInMarthSurface,
            Coordinates initialRobotPositionOnScreen,
            string instructions
            )
        {
            var isLaunchedFromTest = UnitTestDetector.IsRunningFromNUnit;

            #region Runnin when comes from Test
            if (isLaunchedFromTest)
            { 
                string result = ""; 
                if (robotPositionInMarthSurface == null && instructions == null)
                {
                    robotInitial = questionary.RobotPositionAndCommands();
                }
                else
                {
                    robotInitial.RobotPositionInMarthSurface = robotPositionInMarthSurface;
                    robotInitial.InitialRobotPositionOnScreen = initialRobotPositionOnScreen;
                    robotInitial.Instructions = instructions;
                }

                stopTheRobot = false;
                robotPositionInMarthSurface = robotInitial.RobotPositionInMarthSurface;
                initialRobotPositionOnScreen = robotInitial.InitialRobotPositionOnScreen;

                cursorPositionList.Add(new Coordinates()
                {
                    XPosition = 0 ,
                    YPosition = 0
                });

                var manageCursor =
                    Coordinates.GetPositionOnScreen(SurfaceDimensions.MaximunXAxis, robotPositionInMarthSurface, cursorPositionList);

                initialRobotPositionOnScreen.XPosition = manageCursor.XPositionOnScreen;
                initialRobotPositionOnScreen.YPosition = manageCursor.YPositionOnScreen;
                previousRobotPosition = initialRobotPositionOnScreen;                 

                var robotState = orientation.GetSymbolAndOrientation(robotInitial.Instructions[0], initialRobotPositionOnScreen.Orientation);
                var robotInitialPhoto = orientation.GetOrientationSymbol(initialRobotPositionOnScreen.Orientation);            

                foreach (char command in robotInitial.Instructions)
                {
                    previousRobotPositionInMarthSurface = robotPositionInMarthSurface;
                    switch (command)
                    {
                        case 'L':

                            robotState = orientation.GetSymbolAndOrientation('L', initialRobotPositionOnScreen.Orientation);
                            initialRobotPositionOnScreen.Orientation = robotState.orientation;
                            newCoordinates.XPosition = initialRobotPositionOnScreen.XPosition;
                            newCoordinates.YPosition = initialRobotPositionOnScreen.YPosition;
                            actualPosition = newCoordinates;

                            break;
                        case 'R':

                            robotState = orientation.GetSymbolAndOrientation('R', initialRobotPositionOnScreen.Orientation);
                            initialRobotPositionOnScreen.Orientation = robotState.orientation;
                            newCoordinates.XPosition = initialRobotPositionOnScreen.XPosition;
                            newCoordinates.YPosition = initialRobotPositionOnScreen.YPosition;
                            actualPosition = newCoordinates;

                            break;
                        case 'F':

                            previousRobotPosition = (new Coordinates { XPosition = actualPosition.XPosition, YPosition = actualPosition.YPosition });

                            currentOrientation = initialRobotPositionOnScreen.Orientation;
                            nextPosition = motionFactory.MoveRobotByOrientation(currentOrientation);


                            if (currentOrientation == "N")
                            {
                                var manageRobot =
                                    nextPosition.GetNewCoordinates(initialRobotPositionOnScreen, robotPositionInMarthSurface, SurfaceDimensions.MaximunYAxis, dangerCoordinates);
                                newCoordinates = manageRobot.nextRobotPosition;
                                stopTheRobot = manageRobot.isLost;
                                dangerCoordinates = manageRobot.getDangerCoordinates;
                            }
                            if (currentOrientation == "E")
                            {
                                var manageRobot =
                                    nextPosition.GetNewCoordinates(initialRobotPositionOnScreen, robotPositionInMarthSurface, SurfaceDimensions.MaximunXAxis, dangerCoordinates);
                                newCoordinates = manageRobot.nextRobotPosition;
                                stopTheRobot = manageRobot.isLost;
                                dangerCoordinates = manageRobot.getDangerCoordinates;
                            }

                            if (currentOrientation == "W")
                            {
                                var manageRobot =
                                    nextPosition.GetNewCoordinates(initialRobotPositionOnScreen, robotPositionInMarthSurface, SurfaceDimensions.MinimumXAxis, dangerCoordinates);
                                newCoordinates = manageRobot.nextRobotPosition;
                                stopTheRobot = manageRobot.isLost;
                                dangerCoordinates = manageRobot.getDangerCoordinates;
                            }

                            if (currentOrientation == "S")
                            {
                                var manageRobot =
                                    nextPosition.GetNewCoordinates(initialRobotPositionOnScreen, robotPositionInMarthSurface, SurfaceDimensions.MinimumYAxis, dangerCoordinates);
                                newCoordinates = manageRobot.nextRobotPosition;
                                stopTheRobot = manageRobot.isLost;
                                dangerCoordinates = manageRobot.getDangerCoordinates;
                            }

                            actualPosition = newCoordinates;

                            break;
                    }
                    
                    if (stopTheRobot == true)
                    {
                       

                        result = $"X: {previousRobotPositionInMarthSurface.XPosition}," +
                          $" Y: {previousRobotPositionInMarthSurface.YPosition}, Orientation: {robotState.orientation} LOST !";
                        return result;
                    }

                }
                if (stopTheRobot == false)
                {
                

                    result = $"X: {robotPositionInMarthSurface.XPosition}," +
                                      $" Y: {robotPositionInMarthSurface.YPosition}, Orientation: {robotState.orientation} ";
                    return result;
                }
             
                return result;
            }
            #endregion

            #region Runnin when comes from Program
            if (!isLaunchedFromTest)
            {
                Console.Clear();
                Console.Title = "rOBOt";
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(Tittle.MartianRobot);
                Thread.Sleep(50);
                Console.ResetColor();
                Console.CursorVisible = false;
                string result = "";


                if (robotPositionInMarthSurface == null && instructions == null)
                {
                    robotInitial = questionary.RobotPositionAndCommands();
                }
                else
                {
                    robotInitial.RobotPositionInMarthSurface = robotPositionInMarthSurface;
                    robotInitial.InitialRobotPositionOnScreen = initialRobotPositionOnScreen;
                    robotInitial.Instructions = instructions;
                }

                stopTheRobot = false;
                robotPositionInMarthSurface = robotInitial.RobotPositionInMarthSurface;
                initialRobotPositionOnScreen = robotInitial.InitialRobotPositionOnScreen;

                string surface =
                    Draw.Surface(SurfaceDimensions.MinimumXAxis, SurfaceDimensions.MaximunXAxis, cursorPositionList);


                Console.Write(surface);

                cursorPositionList.Add(new Coordinates()
                {
                    XPosition = Console.CursorLeft,
                    YPosition = Console.CursorTop
                });

                var manageCursor =
                    Coordinates.GetPositionOnScreen(SurfaceDimensions.MaximunXAxis, robotPositionInMarthSurface, cursorPositionList);

                initialRobotPositionOnScreen.XPosition = manageCursor.XPositionOnScreen;
                initialRobotPositionOnScreen.YPosition = manageCursor.YPositionOnScreen;
                previousRobotPosition = initialRobotPositionOnScreen;

                Console.SetCursorPosition(initialRobotPositionOnScreen.XPosition, initialRobotPositionOnScreen.YPosition);

                var robotState = orientation.GetSymbolAndOrientation(robotInitial.Instructions[0], initialRobotPositionOnScreen.Orientation);
                var robotInitialPhoto = orientation.GetOrientationSymbol(initialRobotPositionOnScreen.Orientation);

                Console.Write(robotInitialPhoto);
                Thread.Sleep(300);

                Console.SetCursorPosition(initialRobotPositionOnScreen.XPosition, initialRobotPositionOnScreen.YPosition);
                Console.Write(" ");

                foreach (char command in robotInitial.Instructions)
                {
                    previousRobotPositionInMarthSurface = robotPositionInMarthSurface;
                    switch (command)
                    {
                        case 'L':

                            robotState = orientation.GetSymbolAndOrientation('L', initialRobotPositionOnScreen.Orientation);
                            initialRobotPositionOnScreen.Orientation = robotState.orientation;
                            newCoordinates.XPosition = initialRobotPositionOnScreen.XPosition;
                            newCoordinates.YPosition = initialRobotPositionOnScreen.YPosition;
                            actualPosition = newCoordinates;

                            break;
                        case 'R':

                            robotState = orientation.GetSymbolAndOrientation('R', initialRobotPositionOnScreen.Orientation);
                            initialRobotPositionOnScreen.Orientation = robotState.orientation;
                            newCoordinates.XPosition = initialRobotPositionOnScreen.XPosition;
                            newCoordinates.YPosition = initialRobotPositionOnScreen.YPosition;
                            actualPosition = newCoordinates;

                            break;
                        case 'F':

                            previousRobotPosition = (new Coordinates { XPosition = actualPosition.XPosition, YPosition = actualPosition.YPosition });

                            currentOrientation = initialRobotPositionOnScreen.Orientation;
                            nextPosition = motionFactory.MoveRobotByOrientation(currentOrientation);


                            if (currentOrientation == "N")
                            {
                                var manageRobot =
                                    nextPosition.GetNewCoordinates(initialRobotPositionOnScreen, robotPositionInMarthSurface, SurfaceDimensions.MaximunYAxis, dangerCoordinates);
                                newCoordinates = manageRobot.nextRobotPosition;
                                stopTheRobot = manageRobot.isLost;
                                dangerCoordinates = manageRobot.getDangerCoordinates;
                            }
                            if (currentOrientation == "E")
                            {
                                var manageRobot =
                                    nextPosition.GetNewCoordinates(initialRobotPositionOnScreen, robotPositionInMarthSurface, SurfaceDimensions.MaximunXAxis, dangerCoordinates);
                                newCoordinates = manageRobot.nextRobotPosition;
                                stopTheRobot = manageRobot.isLost;
                                dangerCoordinates = manageRobot.getDangerCoordinates;
                            }

                            if (currentOrientation == "W")
                            {
                                var manageRobot =
                                    nextPosition.GetNewCoordinates(initialRobotPositionOnScreen, robotPositionInMarthSurface, SurfaceDimensions.MinimumXAxis, dangerCoordinates);
                                newCoordinates = manageRobot.nextRobotPosition;
                                stopTheRobot = manageRobot.isLost;
                                dangerCoordinates = manageRobot.getDangerCoordinates;
                            }

                            if (currentOrientation == "S")
                            {
                                var manageRobot =
                                    nextPosition.GetNewCoordinates(initialRobotPositionOnScreen, robotPositionInMarthSurface, SurfaceDimensions.MinimumYAxis, dangerCoordinates);
                                newCoordinates = manageRobot.nextRobotPosition;
                                stopTheRobot = manageRobot.isLost;
                                dangerCoordinates = manageRobot.getDangerCoordinates;
                            }

                            actualPosition = newCoordinates;

                            break;
                    }

                    Console.SetCursorPosition(newCoordinates.XPosition, newCoordinates.YPosition);

                    if (stopTheRobot == true)
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

                        result = $"X: {previousRobotPositionInMarthSurface.XPosition}," +
                          $" Y: {previousRobotPositionInMarthSurface.YPosition}, Orientation: {robotState.orientation} LOST !";
                        return result;
                    }

                    if (stopTheRobot == false)
                    {
                        Console.Write(robotState.symbol);
                        Console.SetCursorPosition(previousRobotPosition.XPosition, previousRobotPosition.YPosition);

                        if (initialRobotPositionOnScreen.XPosition != previousRobotPosition.XPosition &&
                           initialRobotPositionOnScreen.YPosition != previousRobotPosition.YPosition)
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
                                      $" Y: {robotPositionInMarthSurface.YPosition}, Orientation: {robotState.orientation}");
                    Thread.Sleep(3000);

                    result = $"X: {robotPositionInMarthSurface.XPosition}," +
                                      $" Y: {robotPositionInMarthSurface.YPosition}, Orientation: {robotState.orientation}";
                    return result;
                }

                Console.ResetColor();
                return result;

            }
            #endregion

            return "";
        }        
    }
}