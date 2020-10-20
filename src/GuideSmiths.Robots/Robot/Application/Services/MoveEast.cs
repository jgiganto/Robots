using System.Collections.Generic;
using static GuideSmiths.Robots.Application.Robot.Contracts.Motion;

namespace GuideSmiths.Robots.Application.Robot.Services
{
    public class MoveEast : MoveRobotForward
    {
        public override (Coordinates nextRobotPosition, bool isLost, List<Coordinates> getDangerCoordinates, Coordinates getcoordinatesInMarthSurface)
            GetNewCoordinates(Coordinates nextRobotPosition, Coordinates coordinatesInMarthSurface, int eastLimits, List<Coordinates> dangerCoordinates)
        {
            bool isLost = false;
            bool ignoreCommand = false;
            Coordinates coordinatesToAnalize = new Coordinates();
            Coordinates dangeredCoordinates = new Coordinates();

            coordinatesToAnalize.YPosition = coordinatesInMarthSurface.YPosition;
            coordinatesToAnalize.XPosition = coordinatesInMarthSurface.XPosition + 1;

            ignoreCommand = AnalizePosition.IsDangerPosition(coordinatesToAnalize, dangerCoordinates);

            if (!ignoreCommand)
            {
                if (coordinatesInMarthSurface.XPosition + 1 <= eastLimits)
                {
                    nextRobotPosition.XPosition += 1;
                    coordinatesInMarthSurface.XPosition += 1;
                }
                else
                {
                    dangeredCoordinates.XPosition = coordinatesInMarthSurface.XPosition + 1;
                    dangeredCoordinates.YPosition = coordinatesInMarthSurface.YPosition;
                    dangerCoordinates.Add(dangeredCoordinates);
                    isLost = true;
                    return (nextRobotPosition, isLost, dangerCoordinates, coordinatesInMarthSurface);
                }
            }                

            return (nextRobotPosition, isLost, dangerCoordinates, coordinatesInMarthSurface);
        }
    }
}
