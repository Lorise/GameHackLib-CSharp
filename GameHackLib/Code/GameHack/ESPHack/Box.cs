using System.Numerics;
using GameHackLib.Code.Form;
using GameHackLib.Code.GameHack.Option;

namespace GameHackLib.Code.GameHack.ESPHack
{
    public static class Box
    {
        public static Box2DOption Option { get; set; } = new Box2DOption();

        public static void Draw2D(Matrix4x4 viewProj, Vector3 position, int playerHeight, bool playerVisible, bool friendly)
        {
            if (friendly && Option.IsOnlyEnemyVisible)
                return;

            if (position.WorldToScreen(viewProj, out var p1) &&
                new Vector3(position.X, position.Y, position.Z + playerHeight).WorldToScreen(viewProj, out var p2))
            {
                var w = (p1.Y - p2.Y) / 4;

                var leftDown = new Vector2(p1.X - w, p1.Y);
                var rightDown = new Vector2(p1.X + w, p1.Y);
                var leftUp = new Vector2(p2.X - w, p2.Y);
                var rightUp = new Vector2(p2.X + w, p2.Y);

                ExternalWindow.Render.SetSolidColor(playerVisible ? friendly ? Option.FriendlyColor : Option.EnemyColor : friendly ? Option.FriendlyOccludedColor : Option.EnemyOccludedColor);

                ExternalWindow.Render.StrokeThickness = Option.LineWidth;

                ExternalWindow.Render.DrawLine(leftDown, rightDown);
                ExternalWindow.Render.DrawLine(rightDown, rightUp);
                ExternalWindow.Render.DrawLine(rightUp, leftUp);
                ExternalWindow.Render.DrawLine(leftUp, leftDown);
            }
        }

        public static void Draw3D(Matrix4x4 viewProj, BoundingBox boundingBox, Vector3 position, double yaw, bool playerVisible, bool friendly)
        {
            if (friendly && Option.IsOnlyEnemyVisible)
                return;

            var p1 = new Vector3(boundingBox.Min.X, boundingBox.Min.Y, boundingBox.Min.Z).RotateZ(yaw) + position;
            var p2 = new Vector3(boundingBox.Max.X, boundingBox.Min.Y, boundingBox.Min.Z).RotateZ(yaw) + position;
            var p3 = new Vector3(boundingBox.Min.X, boundingBox.Max.Y, boundingBox.Min.Z).RotateZ(yaw) + position;
            var p4 = new Vector3(boundingBox.Max.X, boundingBox.Max.Y, boundingBox.Min.Z).RotateZ(yaw) + position;
            var p5 = new Vector3(boundingBox.Min.X, boundingBox.Min.Y, boundingBox.Max.Z).RotateZ(yaw) + position;
            var p6 = new Vector3(boundingBox.Max.X, boundingBox.Min.Y, boundingBox.Max.Z).RotateZ(yaw) + position;
            var p7 = new Vector3(boundingBox.Min.X, boundingBox.Max.Y, boundingBox.Max.Z).RotateZ(yaw) + position;
            var p8 = new Vector3(boundingBox.Max.X, boundingBox.Max.Y, boundingBox.Max.Z).RotateZ(yaw) + position;

            if (p1.WorldToScreen(viewProj, out var v1) &&
                p2.WorldToScreen(viewProj, out var v2) &&
                p3.WorldToScreen(viewProj, out var v3) &&
                p4.WorldToScreen(viewProj, out var v4) &&
                p5.WorldToScreen(viewProj, out var v5) &&
                p6.WorldToScreen(viewProj, out var v6) &&
                p7.WorldToScreen(viewProj, out var v7) &&
                p8.WorldToScreen(viewProj, out var v8))
            {
                ExternalWindow.Render.SetSolidColor(playerVisible ? friendly ? Option.FriendlyColor : Option.EnemyColor : friendly ? Option.FriendlyOccludedColor : Option.EnemyOccludedColor);

                ExternalWindow.Render.StrokeThickness = Option.LineWidth;

                ExternalWindow.Render.DrawLine(v1, v2);
                ExternalWindow.Render.DrawLine(v3, v4);
                ExternalWindow.Render.DrawLine(v1, v3);
                ExternalWindow.Render.DrawLine(v2, v4);

                ExternalWindow.Render.DrawLine(v5, v6);
                ExternalWindow.Render.DrawLine(v7, v8);
                ExternalWindow.Render.DrawLine(v5, v7);
                ExternalWindow.Render.DrawLine(v6, v8);

                ExternalWindow.Render.DrawLine(v1, v5);
                ExternalWindow.Render.DrawLine(v2, v6);
                ExternalWindow.Render.DrawLine(v3, v7);
                ExternalWindow.Render.DrawLine(v4, v8);
            }
        }
    }
}
