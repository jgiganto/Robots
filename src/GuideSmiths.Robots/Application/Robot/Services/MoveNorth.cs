using System.Collections.Generic;
using static GuideSmiths.Robots.Application.Robot.Contracts.Motion;

namespace GuideSmiths.Robots.Application.Robot.Services
{
    public class MoveNorth : MoveRobotForward
    {
        public override (Coordinates nextRobotPosition, bool isLost, List<Coordinates> getPoisonCoordinates)
            GetNewCoordinates(Coordinates nextRobotPosition, Coordinates coordinatesInMarthSurface, int northLimits, List<Coordinates> poisonCoordinates)
        {
            bool isLost = false;
            bool ignoreCommand = false;
            Coordinates coordinatesToAnalize = new Coordinates();
            Coordinates poisonedCoordinates = new Coordinates();
            coordinatesToAnalize.YPosition = coordinatesInMarthSurface.YPosition + 1;
            coordinatesToAnalize.XPosition = coordinatesInMarthSurface.XPosition;
           
            ignoreCommand = AnalizePosition.IsDangerPosition(coordinatesToAnalize, poisonCoordinates);

            if (!ignoreCommand)
            {
                if ((coordinatesInMarthSurface.YPosition + 1 <= northLimits))
                {
                    nextRobotPosition.YPosition -= 1;
                    coordinatesInMarthSurface.YPosition += 1;

                }
                else
                {
                    poisonedCoordinates.YPosition = coordinatesInMarthSurface.YPosition + 1;
                    poisonedCoordinates.XPosition = coordinatesInMarthSurface.XPosition;
                    poisonCoordinates.Add(poisonedCoordinates);
                    isLost = true;
                    return (nextRobotPosition, isLost, poisonCoordinates);
                }
            }

            return (nextRobotPosition, isLost, poisonCoordinates); 
        }
    }
}
