using static GuideSmiths.Robots.Application.Robot.Contracts.Motion;

namespace GuideSmiths.Robots.Application.Robot.Services
{
    public class MoveEast : MoveRobotForward
    {
        public override (Coordinates nextRobotPosition, bool isLost) GetNewCoordinates(Coordinates nextRobotPosition, Coordinates coordinatesInMarthSurface, int eastLimits)
        {
            bool isLost = false;             

            if (coordinatesInMarthSurface.XPosition + 1 <= eastLimits)
            {
                nextRobotPosition.XPosition += 1;
                coordinatesInMarthSurface.XPosition += 1;
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
