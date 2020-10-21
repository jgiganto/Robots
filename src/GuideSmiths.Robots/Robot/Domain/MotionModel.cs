using FluentValidation;

namespace GuideSmiths.Robots.Robot.Domain
{
    public class MotionModel
    {
        public string Instructions { get; set; }

        public class MotionValidator : AbstractValidator<MotionModel>
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
