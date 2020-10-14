using GuideSmiths.Robots.Application.Robot;

namespace GuideSmiths.Robots.Robot.Domain
{
    public class RobotInitial
    {        
        public RobotInitial()
        {
            RobotPositionInMarthSurface = new Coordinates();
            InitialRobotPositionOnScreen = new Coordinates();
        }
        public Coordinates RobotPositionInMarthSurface;
        public Coordinates InitialRobotPositionOnScreen;
        public string Instructions { get;  set; }
    }
}
