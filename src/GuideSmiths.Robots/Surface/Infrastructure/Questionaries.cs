using FluentValidation;
using FluentValidation.Results;
using GuideSmiths.Robots.Application.Robot;
using GuideSmiths.Robots.Application.Robot.Contracts;
using GuideSmiths.Robots.Application.Utils;
using GuideSmiths.Robots.Robot.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using static GuideSmiths.Robots.Application.Robot.Contracts.Motion;

namespace GuideSmiths.Robots.Application.Surface
{
    public class Questionaries
    {
        public SurfaceBase DefineSurface()
        {
            SurfaceBase surfaceDimensions = new SurfaceBase();
            Console.Write("Enter a value for the X: ");
            surfaceDimensions.MaximunXAxis = Convert.ToInt32(Console.ReadLine());
            LinesCleaner.Clean();
            Console.Write("Enter a value for the Y: ");
            surfaceDimensions.MaximunYAxis = Convert.ToInt32(Console.ReadLine());
            LinesCleaner.Clean();

            return surfaceDimensions;
        }      
        
        //public (Coordinates robotPositionInMarthSurface, Coordinates initialRobotPositionOnScreen, string instructions) RobotPositionAndCommands()
        public RobotInitial RobotPositionAndCommands()
        {
            CoordinatesValidator coordinatesValidator = new CoordinatesValidator();
            MotionValidator motionValidator = new MotionValidator();
            Console.CursorVisible = true;
            Coordinates initialRobotPositionOnScreen = new Coordinates();
            Coordinates robotPositionInMarthSurface = new Coordinates();
            Motion commands = new Motion();

            RobotInitial robotInitial = new RobotInitial();

            Console.WriteLine("Now, initial coordinates of the robot and It´s orientation (N, S, E, W): ");
            LinesCleaner.BlankLine();

            int left = Console.CursorLeft;
            int top = Console.CursorTop;
            while (true)
            {
                left = Console.CursorLeft;
                top = Console.CursorTop;

                try
                {
                    LinesCleaner.BlankLine();
                    Console.Write("Enter the X: ");
                    //robotPositionInMarthSurface.XPosition = Convert.ToInt32(Console.ReadLine());
                    robotInitial.RobotPositionInMarthSurface.XPosition = 9;
                    robotInitial.RobotPositionInMarthSurface.XPosition = Convert.ToInt32(Console.ReadLine());
                    LinesCleaner.Clean();
                    Console.Write("Enter the Y: ");
                    robotInitial.RobotPositionInMarthSurface.YPosition = Convert.ToInt32(Console.ReadLine());
                    LinesCleaner.Clean();
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine($"Write numbers! error");
                    Thread.Sleep(1000);
                    LinesCleaner.Clean();
                    LinesCleaner.Clean();
                    Console.SetCursorPosition(left, top);
                   
                }               
            }

            while (true)
            {
                left = Console.CursorLeft;
                top = Console.CursorTop;
                try
                {
                    Console.Write("Enter the Orientation of Robot(N, S, E, W): ");
                    //initialRobotPositionOnScreen.Orientation = Console.ReadLine().ToUpper();
                    robotInitial.InitialRobotPositionOnScreen.Orientation = Console.ReadLine().ToUpper();
                    LinesCleaner.Clean();
                    Console.SetCursorPosition(left, top);

                    IList<ValidationFailure> orientationErrors =
                        coordinatesValidator.Validate(robotInitial.InitialRobotPositionOnScreen, options => options.IncludeProperties("Orientation")).Errors;
                    if (orientationErrors.Any())
                    {
                        foreach (var error in orientationErrors)
                        {
                            Console.WriteLine($"Error!: {error}");
                            Thread.Sleep(2000);
                            LinesCleaner.Clean();
                            LinesCleaner.Clean();
                            Console.SetCursorPosition(left, top);
                        }
                        throw new Exception("Please (N, S, E, W):");
                    }
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                    Thread.Sleep(1000);
                    LinesCleaner.Clean();
                    LinesCleaner.Clean();
                    Console.SetCursorPosition(left, top);
                }
            }

            while (true)
            {
                left = Console.CursorLeft;
                top = Console.CursorTop;

                try
                {
                    Console.Write("Give the instructions for the Robot (L/R/F): ");                  
                    commands.Instructions = Console.ReadLine().ToUpper();
                    robotInitial.Instructions = commands.Instructions;
                    LinesCleaner.Clean();
                    Console.SetCursorPosition(left, top);

                    IList<ValidationFailure> motionErrors =
                        motionValidator.Validate(commands).Errors;

                    if (motionErrors.Any())
                    {
                        foreach (var error in motionErrors)
                        {
                            Console.WriteLine($"Error!: {error} ");
                            Thread.Sleep(2000);
                            LinesCleaner.Clean();
                            LinesCleaner.Clean();
                            Console.SetCursorPosition(left, top);
                        }
                        throw new Exception("Please (L/R/F):");
                    }
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                    Thread.Sleep(1000);
                    LinesCleaner.Clean();
                    LinesCleaner.Clean();
                    Console.SetCursorPosition(left, top);
                } 
            }                

            Thread.Sleep(10);
            Console.CursorVisible = false;
            return robotInitial;
        }
    }
}

