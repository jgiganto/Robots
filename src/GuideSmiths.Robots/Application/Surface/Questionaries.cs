using FluentValidation;
using GuideSmiths.Robots.Application.Robot;
using GuideSmiths.Robots.Application.Robot.Contracts;
using GuideSmiths.Robots.Application.Utils;
using System;
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
            Line.Clean();
            Console.Write("Enter a value for the Y: ");
            surfaceDimensions.MaximunYAxis = Convert.ToInt32(Console.ReadLine());
            Line.Clean();

            return surfaceDimensions;
        }      
        
        public (Coordinates robotPositionInMarthSurface, Coordinates initialRobotPosition, string instructions) RobotPositionAndCommands()
        {
            CoordinatesValidator coordinatesValidator = new CoordinatesValidator();
            MotionValidator motionValidator = new MotionValidator();
            Console.CursorVisible = true;
            Coordinates initialRobotPosition = new Coordinates();
            Coordinates robotPositionInMarthSurface = new Coordinates();
            Motion commands = new Motion();

            Console.WriteLine("Now, initial coordinates of the robot and It´s orientation (N, S, E, W): ");
            Line.BlankLine();


            while (true)
            {
                int left = Console.CursorLeft;
                int top = Console.CursorTop;
                try
                {
                    Line.BlankLine();
                    Console.Write("Enter the X: ");
                    robotPositionInMarthSurface.XPosition = Convert.ToInt32(Console.ReadLine());
                    Line.Clean();
                    Console.Write("Enter the Y: ");
                    robotPositionInMarthSurface.YPosition = Convert.ToInt32(Console.ReadLine());
                    Line.Clean();
                    Console.Write("Enter the Orientation of Robot(N, S, E, W): ");
                    initialRobotPosition.Orientation = Console.ReadLine().ToUpper();

                    coordinatesValidator.Validate(initialRobotPosition, options => options.IncludeProperties("Orientation"));


                    Line.Clean();

                    if (!coordinatesValidator.Validate(initialRobotPosition).IsValid)
                    {                         
                        var errors = coordinatesValidator.Validate(robotPositionInMarthSurface).Errors;
                        foreach (var error in errors)
                        {
                            Console.WriteLine($"Error! : {error} ");
                            Thread.Sleep(2000);
                            throw new Exception();
                        }
                    }
                   

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Write numbers! error");
                    Thread.Sleep(1000);
                    Line.Clean();
                    Console.SetCursorPosition(left, top);
                }
                break;
            }


            Console.Write("Give the instructions for the Robot (L/R/F): ");
            commands.Instructions = Console.ReadLine().ToUpper();

            if (!motionValidator.Validate(commands).IsValid) {
                var errors = motionValidator.Validate(commands).Errors;
                foreach (var error in errors)
                {
                    Console.WriteLine($"Error!: {error} ");
                    Thread.Sleep(1000);                    
                }     
            }


            Thread.Sleep(10);
            Console.CursorVisible = false;
            return (robotPositionInMarthSurface, initialRobotPosition, commands.Instructions);
        }
    }
}

/*       if (!validateCoordinates.Validate(robotPositionInMarthSurface).IsValid)
            {
                Console.WriteLine(validateCoordinates.Validate(robotPositionInMarthSurface).Errors.FirstOrDefault());
            }
*/

