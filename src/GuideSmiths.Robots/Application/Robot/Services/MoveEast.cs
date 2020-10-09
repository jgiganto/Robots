using System.Collections.Generic;
using static GuideSmiths.Robots.Application.Robot.Contracts.Motion;

namespace GuideSmiths.Robots.Application.Robot.Services
{
    public class MoveEast : MoveRobotForward
    {
        public override (Coordinates nextRobotPosition, bool isLost, List<Coordinates> getPoisonCoordinates)
            GetNewCoordinates(Coordinates nextRobotPosition, Coordinates coordinatesInMarthSurface, int eastLimits, List<Coordinates> poisonCoordinates)
        {
            bool isLost = false;
            bool ignoreCommand = false;
            Coordinates coordinatesToAnalize = new Coordinates();
            Coordinates poisonedCoordinates = new Coordinates();

            coordinatesToAnalize.YPosition = coordinatesInMarthSurface.YPosition;
            coordinatesToAnalize.XPosition = coordinatesInMarthSurface.XPosition + 1;

            ignoreCommand = AnalizePosition.IsDangerPosition(coordinatesToAnalize, poisonCoordinates);

            if (!ignoreCommand)
            {
                if (coordinatesInMarthSurface.XPosition + 1 <= eastLimits)
                {
                    nextRobotPosition.XPosition += 1;
                    coordinatesInMarthSurface.XPosition += 1;
                }
                else
                {
                    poisonedCoordinates.XPosition = coordinatesInMarthSurface.XPosition + 1;
                    poisonedCoordinates.YPosition = coordinatesInMarthSurface.YPosition;
                    poisonCoordinates.Add(poisonedCoordinates);
                    isLost = true;
                    return (nextRobotPosition, isLost, poisonCoordinates);
                }
            }                

            return (nextRobotPosition, isLost, poisonCoordinates);
        }
    }
}
