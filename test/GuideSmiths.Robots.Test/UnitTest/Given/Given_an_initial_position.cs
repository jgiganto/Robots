using GuideSmiths.Robots.Application.Robot;

namespace GuideSmiths.Robots.Test.UnitTest.Domain.Robot
{
    public static partial class Given
    {
        public static Coordinates Any_initial_robot_position_with_north_orientation()
        {
            return new Coordinates { XPosition = 0, YPosition = 0, Orientation = "N" };
        }
        public static Coordinates An_example_input_robot_position_with_north_orientation()//the sample #2
        {
            return new Coordinates { XPosition = 3, YPosition = 2, Orientation = "N" };
        }
        public static Coordinates An_example_input_robot_position_with_west_orientation_3()//the sample #3
        {
            return new Coordinates { XPosition = 0, YPosition = 3, Orientation = "W" };
        }
        public static Coordinates A_cursor_position()//the sample #2
        {
            return new Coordinates { XPosition = 24, YPosition = 13, Orientation = "N" };
        }
        public static Coordinates A_cursor_position_3()//the sample #3
        {
            return new Coordinates { XPosition = 21, YPosition = 12, Orientation = "W" };
        }
       
    }
}
