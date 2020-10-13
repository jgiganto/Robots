using FluentAssertions;
using GuideSmiths.Robots.Application.Robot.Factory;
using Xunit;
using static GuideSmiths.Robots.Application.Robot.Contracts.Motion;

namespace GuideSmiths.Robots.Test.UnitTest.Domain.Robot
{
    public class RobotShould
    {
        [Fact]
        public void When_recieve_order_to_move_to_north_YPosition_must_increase()
        {
            var a_initial_robot_position_with_north_orientation =
                Given.Any_initial_robot_position_with_north_orientation();
            var a_initial_robot_position_in_Marth_with_north_orientation =
                Given.Any_initial_robot_position_in_Marth_with_north_orientation();
            var a_Marth_surface =
                Given.Any_Marth_surface();
            var a_posion_coordinates_list =
                Given.Any_poison_coordinates_list();
            int YInitialPosition = a_initial_robot_position_in_Marth_with_north_orientation.YPosition;


            MotionFactory manageDirection = new MotionFactory();
            MoveRobotForward nextPosition;
            nextPosition = manageDirection.MoveRobotByOrientation(a_initial_robot_position_with_north_orientation.Orientation);
            var resultCoordinates = nextPosition.GetNewCoordinates(a_initial_robot_position_with_north_orientation,
                                           a_initial_robot_position_in_Marth_with_north_orientation,
                                           a_Marth_surface.MaximunYAxis,
                                           a_posion_coordinates_list
                                           ).getcoordinatesInMarthSurface.YPosition;


            resultCoordinates.Should().Be(YInitialPosition + 1);
        }
    }
}
