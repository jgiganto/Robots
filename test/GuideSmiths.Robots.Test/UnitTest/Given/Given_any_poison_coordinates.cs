using GuideSmiths.Robots.Application.Robot;
using System.Collections.Generic;

namespace GuideSmiths.Robots.Test.UnitTest.Domain.Robot
{
    public static partial class Given
    {
        public static List<Coordinates> Any_poison_coordinates_list()
        {
            return new List<Coordinates> {
                new Coordinates { XPosition = 3, YPosition = 4 },
                new Coordinates { XPosition = 4, YPosition = 4 }
            };
        }
    }
}
