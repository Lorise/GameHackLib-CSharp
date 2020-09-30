using System.Numerics;
using GameHackLib.Code.Form;
using GameHackLib.Code.GameHack.Option;

namespace GameHackLib.Code.GameHack.ESPHack
{
    public static class Armor
    {
        public static ArmorOption Option { get; set; } = new ArmorOption();

        public static void Draw(Matrix4x4 viewProj, Vector3 position, float health, float maxHealth, float playerHeight, bool playerVisible, bool friendly)
        {
            if (friendly && Option.IsOnlyEnemyVisible)
                return;

            if (position.WorldToScreen(viewProj, out var v1) &&
                new Vector3(position.X, position.Y, position.Z + playerHeight).WorldToScreen(viewProj, out var v2))
            {
                var offset = (v1.Y - v2.Y) / 4 + Option.LineWidth;
                var w = v1.X - v2.X;
                var h = v1.Y - v2.Y;
                var k = health / maxHealth;

                ExternalWindow.Render.StrokeThickness = Option.LineWidth;

                ExternalWindow.Render.SetSolidColor(Option.BackgroundColor);
                ExternalWindow.Render.DrawLine(new Vector2(v1.X + offset, v1.Y), new Vector2(v2.X + offset, v2.Y));

                ExternalWindow.Render.SetSolidColor(Option.ForegroundColor);
                ExternalWindow.Render.DrawLine(new Vector2(v1.X + offset, v1.Y), new Vector2(v1.X + offset - w * k, v1.Y - h * k));
            }
        }
    }
}
