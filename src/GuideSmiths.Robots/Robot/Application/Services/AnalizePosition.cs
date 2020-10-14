using System.Collections.Generic;

namespace GuideSmiths.Robots.Application.Robot.Services
{
    public class AnalizePosition
    {
        public static bool IsDangerPosition(Coordinates nextPosition, List<Coordinates> dangerCoordinates)
        {
            foreach(var position in dangerCoordinates)
            {
                if(nextPosition.XPosition == position.XPosition &&
                   nextPosition.YPosition == position.YPosition)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
