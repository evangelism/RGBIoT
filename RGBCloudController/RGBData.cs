using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RGBCloudController
{
    public static class RGBData
    {
        public static int R = 0;
        public static int G = 0;
        public static int B = 0;

        public static void Reset()
        {
            R = G = B = 0;
        }

        public static void Update(string s)
        {
            switch(s)
            {
                case "Red": R++; break;
                case "Green": G++; break;
                case "Blue": B++; break;
            }
        }

    }
}