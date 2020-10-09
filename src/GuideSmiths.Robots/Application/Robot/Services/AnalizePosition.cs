using System.Collections.Generic;

namespace GuideSmiths.Robots.Application.Robot.Services
{
    public class AnalizePosition
    {
        public static bool IsDangerPosition(Coordinates nextPosition, List<Coordinates> poisonCoordinates)
        {
            foreach(var position in poisonCoordinates)
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
