using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace GameHackLib.Code.GameData
{
    public abstract class BaseGame
    {
        public Matrix4x4 ViewMatrix { get; protected set; }
        public long ViewAnglesAddress { get; protected set; }
        public Vector2 ViewAngles { get; protected set; }
        public BaseLocalPlayer LocalPlayer { get; protected set; }
        public List<BasePlayer> Players { get; } = new List<BasePlayer>();
        public int MaxPlayers { get; protected set; }

        protected BaseGame(BaseLocalPlayer baseLocalPlayer)
        {
            LocalPlayer = baseLocalPlayer;
        }

        public List<BasePlayer> EnemyPlayers
        {
            get
            {
                if (LocalPlayer == null)
                    return new List<BasePlayer>();

                return Players.FindAll(player => player.TeamID != LocalPlayer.TeamID).ToList();
            }
        }

        public List<BasePlayer> FriendlyPlayers
        {
            get
            {
                if (LocalPlayer == null)
                    return new List<BasePlayer>();

                return Players.FindAll(player => player.TeamID == LocalPlayer.TeamID).ToList();
            }
        }

        public abstract void Read();
    }
}
