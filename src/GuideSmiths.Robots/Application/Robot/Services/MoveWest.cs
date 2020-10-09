using System.Collections.Generic;
using static GuideSmiths.Robots.Application.Robot.Contracts.Motion;

namespace GuideSmiths.Robots.Application.Robot.Services
{
    public class MoveWest : MoveRobotForward
    {
        public override (Coordinates nextRobotPosition, bool isLost, List<Coordinates> getPoisonCoordinates)
            GetNewCoordinates(Coordinates nextRobotPosition, Coordinates coordinatesInMarthSurface, int westLimits, List<Coordinates> poisonCoordinates)
        {
            bool isLost = false;
            bool ignoreCommand = false;
            Coordinates coordinatesToAnalize = new Coordinates();
            Coordinates poisonedCoordinates = new Coordinates();
            coordinatesToAnalize.YPosition = coordinatesInMarthSurface.YPosition;
            coordinatesToAnalize.XPosition = coordinatesInMarthSurface.XPosition - 1;

            ignoreCommand = AnalizePosition.IsDangerPosition(coordinatesToAnalize, poisonCoordinates);

            if (!ignoreCommand)
            {
                if (coordinatesInMarthSurface.XPosition - 1 >= westLimits)
                {
                    nextRobotPosition.XPosition -= 1;
                    coordinatesInMarthSurface.XPosition -= 1;
                }
                else
                {
                    poisonedCoordinates.YPosition = coordinatesInMarthSurface.YPosition;
                    poisonedCoordinates.XPosition = coordinatesInMarthSurface.XPosition - 1;
                    poisonCoordinates.Add(poisonedCoordinates);
                    isLost = true;
                    return (nextRobotPosition, isLost, poisonCoordinates);
                }
            } 

            return (nextRobotPosition, isLost, poisonCoordinates);
        }
    }
}
