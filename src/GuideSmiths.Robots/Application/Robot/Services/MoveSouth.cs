using static GuideSmiths.Robots.Application.Robot.Contracts.Motion;

namespace GuideSmiths.Robots.Application.Robot.Services
{
    public class MoveSouth : MoveRobotForward
    {
        public override (Coordinates nextRobotPosition, bool isLost) GetNewCoordinates(Coordinates nextRobotPosition, Coordinates coordinatesInMarthSurface, int southLimits)
        {
            bool isLost = false;

            if (coordinatesInMarthSurface.YPosition - 1 >= southLimits)
            {
                nextRobotPosition.YPosition += 1;
                coordinatesInMarthSurface.YPosition -= 1;
            }
            else
            {
                isLost = true;
                return (nextRobotPosition, isLost);
            }

            return (nextRobotPosition, isLost);
        }
    }
}
 