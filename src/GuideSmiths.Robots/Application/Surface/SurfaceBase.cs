using System;
using System.Collections.Generic;
using System.Text;

namespace GuideSmiths.Robots.Application.Surface
{
    public class SurfaceBase
    {        
        public int MaximunXAxis { get; set; }
        public int MaximunYAxis { get; set; }

        public readonly int MinimumXAxis = 0;
        public readonly int MinimumYAxis = 0;         
    }
}
