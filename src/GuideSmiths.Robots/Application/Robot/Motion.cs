namespace GuideSmiths.Robots.Application.Robot
{
    public class Motion
    {
        public Coordinates MoveRobotForward(Coordinates nextRobotPosition,Coordinates coordinatesInMarthSurface, string orientation)
        {
            switch (orientation)
            {
                case "E":
                    nextRobotPosition.XPosition += 1;
                    coordinatesInMarthSurface.XPosition += 1;
                    return nextRobotPosition;
                case "N":
                    nextRobotPosition.YPosition -= 1;
                    coordinatesInMarthSurface.YPosition += 1;
                    return nextRobotPosition;
                case "W":
                    nextRobotPosition.XPosition -= 1;
                    coordinatesInMarthSurface.XPosition -= 1;
                    return nextRobotPosition;
                case "S":
                    nextRobotPosition.YPosition += 1;
                    coordinatesInMarthSurface.YPosition -= 1;
                    return nextRobotPosition;
                default:
                    break;
            }

            return nextRobotPosition;
        }
    }
}
