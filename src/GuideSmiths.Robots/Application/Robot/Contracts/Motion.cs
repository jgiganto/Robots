using FluentValidation;

namespace GuideSmiths.Robots.Application.Robot.Contracts
{
    public class Motion
    {
        public abstract class MoveRobotForward
        {
            public abstract (Coordinates nextRobotPosition, bool isLost) GetNewCoordinates(Coordinates nextRobotPosition, Coordinates coordinatesInMarthSurface, int limits);
        } 

        public string Instructions { get; set; }

        public class MotionValidator : AbstractValidator<Motion>
        {
            public MotionValidator()
            {
                RuleFor(i => i.Instructions)
                .NotEmpty()
                .NotNull()
                .Matches("^[\\s\\dLRF]{1,100}$")
                .WithMessage(i => $"Instructions Error!,{i.Instructions} not valid Instruction.Max 100.");               
            }
        }

    }
}
