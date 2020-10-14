using System;
using System.Reflection;

namespace GuideSmiths.Robots.Utils
{
    static class UnitTestDetector
    {
        private static bool _runningFromNUnit = false;
        static UnitTestDetector()
        {
            foreach (Assembly assem in AppDomain.CurrentDomain.GetAssemblies())
            {               

                if (assem.FullName.ToLowerInvariant().StartsWith("xunit.runner"))
                {
                    _runningFromNUnit = true;
                    break;
                }
            }
        }

        public static bool IsRunningFromNUnit
        {
            get { return _runningFromNUnit; }
        }
    }
}
