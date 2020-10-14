using FluentValidation;
using GuideSmiths.Robots.Application.Surface;
using System;
using System.Collections.Generic;

namespace GuideSmiths.Robots.Application.Robot
{
    public class Coordinates
    {
        public int XPosition { get; set; }
        public int YPosition { get; set; }
        public int XPositionOnScreen { get; set; }
        public int YPositionOnScreen { get; set; }
        public string Orientation { get; set; }

        public static Coordinates GetPositionOnScreen(int MaximunYAxis, Coordinates robotPositionInMarthSurface, List<Coordinates> cursorPositionList)
        {
            Coordinates cursorPosition = new Coordinates();

            int xLeft = cursorPositionList[0].XPosition + 1;
            int yUp = cursorPositionList[0].YPosition + MaximunYAxis;

            cursorPosition.XPositionOnScreen = xLeft + robotPositionInMarthSurface.XPosition;
            cursorPosition.YPositionOnScreen = yUp - robotPositionInMarthSurface.YPosition;

            return cursorPosition;
        }
 
    }

    public class CoordinatesValidator : AbstractValidator<Coordinates>
    {
        public CoordinatesValidator()
        {
            RuleFor(c => c.XPosition) 
              .NotEmpty()
              .NotNull()            
              .WithMessage("Position X required!");

            RuleFor(c => c.YPosition)
             .NotEmpty()
             .NotNull()             
             .WithMessage("Position Y required!");

            RuleFor(c => c.Orientation)
             .NotEmpty()
             .NotNull()
             .Matches("^(N|S|E|W)?$")
             .WithMessage(c => $"Orientation Error!,{c.Orientation} not valid orientation");
        }
    }

   
}
