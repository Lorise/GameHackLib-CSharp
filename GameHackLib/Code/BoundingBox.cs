using System;
using System.Globalization;
using System.Numerics;

namespace GameHackLib.Code
{
    public struct BoundingBox
    {
        public Vector3 Min { get; }
        public Vector3 Max { get; }

        public BoundingBox(Vector3 min, Vector3 max)
        {
            Min = min;
            Max = max;
        }

        public override string ToString() => $"Min: {Min.ToString()} Max: {Max.ToString()}";
    }
}
