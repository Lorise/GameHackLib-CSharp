using System.Numerics;
using GameHackLib.Code.GameData;
using GameHackLib.Code.GameHack.Option;

namespace GameHackLib.Code.GameHack.ESPHack
{
    public static class ESP
    {
        public static ESPOption Option { get; } = new ESPOption();

        public static void Draw(BaseGame game)
        {
            foreach (var player in game.Players)
            {
                if (Option.Box2D)
                    Box.Draw2D(game.ViewMatrix, player.Position, 72, true, player.IsFriendly(game.LocalPlayer));

                if (Option.Box3D)
                    Box.Draw3D(game.ViewMatrix, player.BoundingBox, player.Position, player.Yaw, true, player.IsFriendly(game.LocalPlayer));

                if (Option.Health)
                    Health.Draw(game.ViewMatrix, player.Position, player.Health, 100, 72, true, player.IsFriendly(game.LocalPlayer));

                if (Option.Armor)
                    Armor.Draw(game.ViewMatrix, player.Position, player.Health, 100, 72, true, player.IsFriendly(game.LocalPlayer));

                if (Option.Name)
                    Name.Draw(game.ViewMatrix, player.Position, "Name", 72, true, player.IsFriendly(game.LocalPlayer));

                if (Option.Distance)
                    Distance.Draw(game.ViewMatrix, player.Position, Vector3.Distance(game.LocalPlayer.Position, player.Position), 72, true, player.IsFriendly(game.LocalPlayer));

                if(Option.Skeleton)
                    Bones.Draw(game.ViewMatrix, player.Skeleton, true, player.IsFriendly(game.LocalPlayer));

                if(Option.Head)
                    Head.Draw(game.ViewMatrix, player.Position, player.IsFriendly(game.LocalPlayer));

                //Bone.DrawHead(game.ViewMatrix, player.HeadPosition, player.IsFriendly(game.LocalPlayer));

                if (Option.Snapline)
                    SnapLine.Draw(game.ViewMatrix, player.Position, player.Visible, player.IsFriendly(game.LocalPlayer));
            }
        }
    }
}
