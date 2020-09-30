using System.Numerics;
using System.Windows.Media;
using GameHackLib.Code.Form;

namespace GameHackLib.Code.GameHack.ESPHack
{
    public static class Axis
    {
        //public static void Draw(Render2D render2D, Matrix viewProj, Size windowSize, Vector3 position)
        //{
        //    const int a = 50;

        //    if (position.WorldToScreen_z(viewProj, windowSize, out Vector2 v1) &&
        //       (position + Vector3.UnitX * a).WorldToScreen_z(viewProj, windowSize, out Vector2 v2) &&
        //       (position + Vector3.UnitY * a).WorldToScreen_z(viewProj, windowSize, out Vector2 v3) &&
        //       (position + Vector3.UnitZ * a).WorldToScreen_z(viewProj, windowSize, out Vector2 v4))
        //    {
        //        render2D.BrushColor = Color.Red;
        //        render2D.DrawLine(v1, v2);
        //        render2D.DrawText(v2, "X");

        //        render2D.BrushColor = Color.Green;
        //        render2D.DrawLine(v1, v3);
        //        render2D.DrawText(v3, "Y");

        //        render2D.BrushColor = Color.Blue;
        //        render2D.DrawLine(v1, v4);
        //        render2D.DrawText(v4, "Z");
        //    }
        //}

        public static void Draw(Matrix4x4 viewProj, Vector3 headPosition, float yaw)
        {
            const int a = 100;

            if (headPosition.WorldToScreen(viewProj, out var v1) &&
                (headPosition + Vector3.UnitY * a).RotateZ(yaw).WorldToScreen(viewProj, out var v2))
            {
                ExternalWindow.Render.SetSolidColor(Colors.Yellow);
                ExternalWindow.Render.DrawLine(v1, v2);
            }
        }
    }
}
