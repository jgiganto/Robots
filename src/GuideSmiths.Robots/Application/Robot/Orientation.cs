using System;

namespace GuideSmiths.Robots.Application.Robot
{
    public class Orientation
    {
        public string robotE = "►";
        public string robotN = "▲";
        public string robotW = "◄";
        public string robotS = "▼";

        public string GetOrientationSymbol(string orientation)
        {
            switch (orientation)
            {
                case "E":
                    return robotE;
                case "N":
                    return robotN;
                case "W":
                    return robotW;
                case "S":
                    return robotS;
                default:
                    break; 
            }
            return "Err";           
        }

        public string CalculateOrientation(string command, string actualOrientation)
        {
            string[] positions = new string[] { "N", "E", "S", "W" };

            int indexPosition = Array.IndexOf(positions, actualOrientation);


            switch (command)
            {
                case "L":
                     if(indexPosition == 0)
                     {
                        indexPosition = 3;
                        break;
                     }
                     indexPosition -= 1;
                    break;
                case "F":
                    if (indexPosition == 3)
                    {
                        indexPosition = 0;
                        break;
                    }
                    indexPosition += 1;
                    break;                    
            }

            return GetOrientationSymbol(positions[indexPosition]);

        }
    }
}
