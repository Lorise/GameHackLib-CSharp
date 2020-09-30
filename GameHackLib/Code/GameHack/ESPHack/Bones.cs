using System.Numerics;
using GameHackLib.Code.Form;
using GameHackLib.Code.GameHack.Option;

namespace GameHackLib.Code.GameHack.ESPHack
{
    public static class Bones
    {
        public static BoneOption Option { get; set; } = new BoneOption();

        public static void Draw(Matrix4x4 viewProj, GameData.Skeleton skeleton, bool playerVisible, bool friendly)
        {
            if (friendly && Option.IsOnlyEnemyVisible)
                return;

            if (skeleton.Head.WorldToScreen(viewProj, out var head) &&
                skeleton.Neck.WorldToScreen(viewProj, out var neck) &&
                skeleton.LeftShoulder.WorldToScreen(viewProj, out var leftShoulder) &&
                skeleton.LeftElbow.WorldToScreen(viewProj, out var leftElbow) &&
                skeleton.LeftHand.WorldToScreen(viewProj, out var leftHand) &&
                skeleton.RightShoulder.WorldToScreen(viewProj, out var rightShoulder) &&
                skeleton.RightElbow.WorldToScreen(viewProj, out var rightElbow) &&
                skeleton.RightHand.WorldToScreen(viewProj, out var rightHand) &&
                skeleton.Spine1.WorldToScreen(viewProj, out var spine1) &&
                skeleton.Spine2.WorldToScreen(viewProj, out var spine2) &&
                skeleton.LeftKnee.WorldToScreen(viewProj, out var leftKnee) &&
                skeleton.LeftFoot1.WorldToScreen(viewProj, out var leftFoot1) &&
                skeleton.LeftFoot2.WorldToScreen(viewProj, out var leftFoot2) &&
                skeleton.RightKnee.WorldToScreen(viewProj, out var rightKnee) &&
                skeleton.RightFoot1.WorldToScreen(viewProj, out var rightFoot1) &&
                skeleton.RightFoot2.WorldToScreen(viewProj, out var rightFoot2))
            {
                ExternalWindow.Render.SetSolidColor(playerVisible ?
                    friendly ? Option.FriendlyColor : Option.EnemyColor :
                    friendly ? Option.FriendlyOccludedColor : Option.EnemyOccludedColor);

                ExternalWindow.Render.StrokeThickness = Option.LineWidth;

                ExternalWindow.Render.DrawLine(head, neck);

                ExternalWindow.Render.DrawLine(neck, leftShoulder);
                ExternalWindow.Render.DrawLine(leftShoulder, leftElbow);
                ExternalWindow.Render.DrawLine(leftElbow, leftHand);

                ExternalWindow.Render.DrawLine(neck, rightShoulder);
                ExternalWindow.Render.DrawLine(rightShoulder, rightElbow);
                ExternalWindow.Render.DrawLine(rightElbow, rightHand);

                ExternalWindow.Render.DrawLine(neck, spine1);
                ExternalWindow.Render.DrawLine(spine1, spine2);

                ExternalWindow.Render.DrawLine(spine2, leftKnee);
                ExternalWindow.Render.DrawLine(leftKnee, leftFoot1);
                ExternalWindow.Render.DrawLine(leftFoot1, leftFoot2);

                ExternalWindow.Render.DrawLine(spine2, rightKnee);
                ExternalWindow.Render.DrawLine(rightKnee, rightFoot1);
                ExternalWindow.Render.DrawLine(rightFoot1, rightFoot2);
            }
        }
    }
}
