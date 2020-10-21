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
    }
}
