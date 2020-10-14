using System.Collections.Generic;
using static GuideSmiths.Robots.Application.Robot.Contracts.Motion;

namespace GuideSmiths.Robots.Application.Robot.Services
{
    public class MoveSouth : MoveRobotForward
    {
        public override (Coordinates nextRobotPosition, bool isLost, List<Coordinates> getDangerCoordinates, Coordinates getcoordinatesInMarthSurface)
            GetNewCoordinates(Coordinates nextRobotPosition, Coordinates coordinatesInMarthSurface, int southLimits, List<Coordinates> dangerCoordinates)
        {
            bool isLost = false;
            bool ignoreCommand = false;
            Coordinates coordinatesToAnalize = new Coordinates();
            Coordinates dangeredCoordinates = new Coordinates();
            coordinatesToAnalize.YPosition = coordinatesInMarthSurface.YPosition - 1;
            coordinatesToAnalize.XPosition = coordinatesInMarthSurface.XPosition;

            ignoreCommand = AnalizePosition.IsDangerPosition(coordinatesToAnalize, dangerCoordinates);

            if (!ignoreCommand)
            {
                if (coordinatesInMarthSurface.YPosition - 1 >= southLimits)
                {
                    nextRobotPosition.YPosition += 1;
                    coordinatesInMarthSurface.YPosition -= 1;
                }
                else
                {
                    dangeredCoordinates.YPosition = coordinatesInMarthSurface.YPosition - 1;
                    dangeredCoordinates.XPosition = coordinatesInMarthSurface.XPosition;
                    dangerCoordinates.Add(dangeredCoordinates);
                    isLost = true;
                    return (nextRobotPosition, isLost, dangerCoordinates, coordinatesInMarthSurface);
                }
            }       

            return (nextRobotPosition, isLost, dangerCoordinates, coordinatesInMarthSurface);
        }
    }
}
 