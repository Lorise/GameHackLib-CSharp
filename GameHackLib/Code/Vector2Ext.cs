using System;
using System.Numerics;

namespace GameHackLib.Code
{
    static class Vector2Ext
    {
        public static Vector2 Round(this Vector2 vector2, int digits)
        {
            return new Vector2(
                (float) Math.Round(vector2.X, digits),
                (float) Math.Round(vector2.Y, digits));
        }
    }
}
