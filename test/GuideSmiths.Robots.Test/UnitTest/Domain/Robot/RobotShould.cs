using FluentAssertions;
using GuideSmiths.Robots.Application.Robot.Factory;
using GuideSmiths.Robots.Application.Surface;
using Xunit;
using static GuideSmiths.Robots.Application.Robot.Contracts.Motion;

namespace GuideSmiths.Robots.Test.UnitTest.Domain.Robot
{
    public class RobotShould
    {
        [Fact]
        public void When_recieve_order_to_move_to_north_YPosition_must_increase()//similar for the others coordinates
        {
            var a_initial_robot_position_with_north_orientation =
                Given.Any_initial_robot_position_with_north_orientation();
            var a_initial_robot_position_in_Marth_with_north_orientation =
                Given.Any_initial_robot_position_in_Marth_with_north_orientation();
            var a_Marth_surface =
                Given.Any_Marth_surface();
            var a_danger_coordinates_list =
                Given.Any_danger_coordinates_list();
            int YInitialPosition = a_initial_robot_position_in_Marth_with_north_orientation.YPosition;


            MotionFactory manageDirection = new MotionFactory();
            MoveRobotForward nextPosition;
            nextPosition = manageDirection.MoveRobotByOrientation(a_initial_robot_position_with_north_orientation.Orientation);
            var resultCoordinates = nextPosition.GetNewCoordinates(a_initial_robot_position_with_north_orientation,
                                           a_initial_robot_position_in_Marth_with_north_orientation,
                                           a_Marth_surface.MaximunYAxis,
                                           a_danger_coordinates_list
                                           ).getcoordinatesInMarthSurface.YPosition;


            resultCoordinates.Should().Be(YInitialPosition + 1);
        }

        [Fact]
        public void When_robot_falls_out_of_surface_limits_should_print_position_Orientation_and_Lost_word()
        {
            var an_example_input_robot_position_with_north_orientation 
                = Given.An_example_input_robot_position_with_north_orientation();
            var a_cursor_position
                = Given.A_cursor_position();
            var a_Marth_surface =
              Given.Any_Marth_surface();
            var a_empty_danger_coordinates_list =
               Given.Any_Empty_danger_coordinates_list();
            var a_2nd_eg_instructions = Given.Given_an_instructions();
             

            DrawGame game = new DrawGame();
            var result = game.Paint(a_Marth_surface,
                                    a_empty_danger_coordinates_list,
                                    an_example_input_robot_position_with_north_orientation,
                                    a_cursor_position,
                                    a_2nd_eg_instructions
                                    );


            result.Should().Be("X: 3, Y: 3, Orientation: N LOST !");
        }

        [Fact]
        public void When_robot_get_danger_position_must_to_ignore_command_and_continue()
        {
            var example_input_robot_position_with_west_orientation_3
                = Given.An_example_input_robot_position_with_west_orientation_3();
            var a_cursor_position
                = Given.A_cursor_position_3();
            var a_Marth_surface =
              Given.Any_Marth_surface();
            var a_danger_coordinates_list =
               Given.Any_danger_coordinates_list();
            var a_3nd_eg_instructions = Given.Given_an_instructions_3();

            DrawGame game = new DrawGame();
            var result = game.Paint(a_Marth_surface,
                                    a_danger_coordinates_list,
                                    example_input_robot_position_with_west_orientation_3,
                                    a_cursor_position,
                                    a_3nd_eg_instructions
                                    );

            result.Should().Be("X: 2, Y: 3, Orientation: S ");
        }
    }
}
