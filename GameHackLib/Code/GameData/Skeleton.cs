using System.Numerics;

namespace GameHackLib.Code.GameData
{
    public class Skeleton
    {
        public Vector3 Head { get; set; }

        public Vector3 Neck { get; set; }

        public Vector3 LeftShoulder { get; set; }
        public Vector3 LeftElbow { get; set; }
        public Vector3 LeftHand { get; set; }

        public Vector3 RightShoulder { get; set; }
        public Vector3 RightElbow { get; set; }
        public Vector3 RightHand { get; set; }

        public Vector3 Spine1 { get; set; }
        public Vector3 Spine2 { get; set; }

        public Vector3 LeftKnee { get; set; }
        public Vector3 LeftFoot1 { get; set; }
        public Vector3 LeftFoot2 { get; set; }

        public Vector3 RightKnee { get; set; }
        public Vector3 RightFoot1 { get; set; }
        public Vector3 RightFoot2 { get; set; }
    }
}
