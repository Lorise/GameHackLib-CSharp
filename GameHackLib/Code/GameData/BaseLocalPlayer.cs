using System;
using System.Numerics;

namespace GameHackLib.Code.GameData
{
    public abstract class BaseLocalPlayer
    {
        public Vector3 Position { get; protected set; }
        public Vector3 HeadPosition { get; protected set; }
        public Int32 TeamID { get; protected set; }

        public abstract void Read(int dwLocalPlayer);
    }
}
