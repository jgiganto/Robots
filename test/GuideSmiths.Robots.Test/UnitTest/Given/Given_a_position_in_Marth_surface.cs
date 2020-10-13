using GuideSmiths.Robots.Application.Robot;

namespace GuideSmiths.Robots.Test.UnitTest.Domain.Robot
{
    public static partial class Given
    {
        public static Coordinates Any_initial_robot_position_in_Marth_with_north_orientation()
        {
            return new Coordinates { XPosition = 0, YPosition = 0, Orientation = "N" };
        }
    }
}
