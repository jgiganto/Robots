using FluentValidation;
using System.Collections.Generic;

namespace GuideSmiths.Robots.Application.Robot.Contracts
{
    public class Motion
    {
        public abstract class MoveRobotForward
        {
            public abstract (Coordinates nextRobotPosition, bool isLost, List<Coordinates> getDangerCoordinates, Coordinates getcoordinatesInMarthSurface)
                GetNewCoordinates(Coordinates nextRobotPosition, Coordinates coordinatesInMarthSurface, int limits, List<Coordinates> dangerCoordinates);
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
