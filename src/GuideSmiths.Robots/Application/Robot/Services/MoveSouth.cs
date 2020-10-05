using static GuideSmiths.Robots.Application.Robot.Contracts.Motion;

namespace GuideSmiths.Robots.Application.Robot.Services
{
    public class MoveSouth : MoveRobotForward
    {
        public override Coordinates GetNewCoordinates(Coordinates nextRobotPosition, Coordinates coordinatesInMarthSurface, string orientation)
        {
            nextRobotPosition.YPosition += 1;
            coordinatesInMarthSurface.YPosition -= 1;
            return nextRobotPosition;
        }
    }
}
