using FluentValidation;

namespace GuideSmiths.Robots.Application.Robot
{
    public class Coordinates
    {
        public int XPosition { get; set; }
        public int YPosition { get; set; }
        public string Orientation { get; set; }     
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
