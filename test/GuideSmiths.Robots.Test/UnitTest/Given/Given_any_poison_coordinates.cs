using GuideSmiths.Robots.Application.Robot;
using System.Collections.Generic;

namespace GuideSmiths.Robots.Test.UnitTest.Domain.Robot
{
    public static partial class Given
    {
        public static List<Coordinates> Any_danger_coordinates_list()
        {
            return new List<Coordinates> {
                new Coordinates { XPosition = 3, YPosition = 4 }
            };
        }

        public static List<Coordinates> Any_Empty_danger_coordinates_list()
        {
            return new List<Coordinates> {                
            };
        }
    }
}
