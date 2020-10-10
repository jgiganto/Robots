using GuideSmiths.Robots.Application.Robot;
using GuideSmiths.Robots.Application.Robot.Factory;
using System;
using Xunit;

namespace GuideSmiths.Robots.Test.UnitTest.Robot
{
    public class RobotShould
    {
        [Fact]
        public void When_recieve_order_to_move_to_north_YPosition_must_increase()
        {
            MotionFactory motionFactory = new MotionFactory();
            Coordinates givenPosition = new Coordinates();            
            givenPosition.XPosition = 0;
            givenPosition.YPosition = 0;
            givenPosition.Orientation = "N";

            var nextPosition = motionFactory.MoveRobotByOrientation(givenPosition.Orientation);

            nextPosition.GetNewCoordinates()
        }
    }
}
