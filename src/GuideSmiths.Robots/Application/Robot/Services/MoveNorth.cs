using static GuideSmiths.Robots.Application.Robot.Contracts.Motion;

namespace GuideSmiths.Robots.Application.Robot.Services
{
    public class MoveNorth : MoveRobotForward
    {
        public override (Coordinates nextRobotPosition, bool isLost) GetNewCoordinates(Coordinates nextRobotPosition, Coordinates coordinatesInMarthSurface, int northLimits)
        {
            bool isLost = false;
            if(coordinatesInMarthSurface.YPosition + 1 <= northLimits)
            {
                nextRobotPosition.YPosition -= 1;
                coordinatesInMarthSurface.YPosition += 1;
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
