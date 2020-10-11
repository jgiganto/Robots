using GuideSmiths.Robots.Application.Surface;

namespace GuideSmiths.Robots.Test.UnitTest.Domain.Robot
{
    public static partial class Given
    {
        public static SurfaceBase Any_Marth_surface()
        {
            return new SurfaceBase { MaximunXAxis = 5, MaximunYAxis = 3 };
        } 
    }
}
