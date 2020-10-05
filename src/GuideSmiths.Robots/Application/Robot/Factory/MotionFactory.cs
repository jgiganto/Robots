using GuideSmiths.Robots.Application.Robot.Services;
using System;
using System.Collections.Generic;
using static GuideSmiths.Robots.Application.Robot.Contracts.Motion;

namespace GuideSmiths.Robots.Application.Robot.Factory
{
    public class MotionFactory
    {
        private Dictionary<string, Func<MoveRobotForward>> _motionMapper;
        public MotionFactory()
        {
            _motionMapper = new Dictionary<string, Func<MoveRobotForward>>();
            _motionMapper.Add("E", () => { return new MoveEast(); });
            _motionMapper.Add("N", () => { return new MoveNorth(); });
            _motionMapper.Add("W", () => { return new MoveWest(); });
            _motionMapper.Add("S", () => { return new MoveSouth(); });
        }

        public MoveRobotForward MoveRobotByOrientation(string orientation)
        {
            return _motionMapper[orientation]();
        }
    }
}
