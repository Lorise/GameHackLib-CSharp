using System.Numerics;

namespace GameHackLib.Code.GameData
{
    public abstract class BasePlayer
    {
        public Vector3 Position { get; protected set; }

        public Vector3 HeadPosition => new Vector3(Skeleton.Head.X, Skeleton.Head.Y, Skeleton.Head.Z + 3);
        public float Height => Vector3.Distance(Position, Skeleton.Head);
        public float Width => Vector3.Distance(Skeleton.LeftHand, Skeleton.RightHand);
        public float Yaw { get; protected set; }
        public float Pitch { get; protected set; }
        public int TeamID { get; protected set; }
        public int Health { get; protected set; }
        public int Armor { get; protected set; }
        public Skeleton Skeleton { get; } = new Skeleton();
        public BoundingBox BoundingBox => new BoundingBox(
            new Vector3(-Width / 2, -Width / 2, 0), 
            new Vector3(Width / 2, Width / 2, Height));

        public bool Visible { get; protected set; }

        public abstract void Read(int dwPlayer);

        public abstract bool IsValid();

        protected abstract void ReadSkeleton_t(int m_dwBoneMatrix);

        protected abstract void ReadSkeleton_ct(int m_dwBoneMatrix);

        protected Vector3 ReadBone(int m_dwBoneMatrix, int boneID, int boneSize)
        {
            var processMemory = ProcessMemory.Get();

            var m = processMemory.ReadMatrix(m_dwBoneMatrix + boneID * boneSize);
            return new Vector3(m.M31, m.M32, m.M33);
        }

        public bool IsFriendly(BaseLocalPlayer localPlayer)
        {
            return TeamID == localPlayer.TeamID;
        }
    }
}
