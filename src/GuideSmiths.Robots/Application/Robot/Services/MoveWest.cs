using static GuideSmiths.Robots.Application.Robot.Contracts.Motion;

namespace GuideSmiths.Robots.Application.Robot.Services
{
    public class MoveWest : MoveRobotForward
    {
        public override Coordinates GetNewCoordinates(Coordinates nextRobotPosition, Coordinates coordinatesInMarthSurface, string orientation)
        {
            nextRobotPosition.XPosition -= 1;
            coordinatesInMarthSurface.XPosition -= 1;
            return nextRobotPosition;
        }
    }
}
