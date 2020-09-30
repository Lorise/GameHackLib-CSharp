using System.Numerics;
using GameHackLib.Code.Form;

namespace GameHackLib.Code.GameHack.ESPHack
{
    public static class SnapLine
    {
        public static Option.SnapLinesOption Option { get; set; } = new Option.SnapLinesOption();

        public static void Draw(Matrix4x4 viewProj, Vector3 position, bool playerVisible, bool friendly)
        {
            if (friendly && Option.IsOnlyEnemyVisible)
                return;

            if (position.WorldToScreen(viewProj, out var screenSpacePoint))
            {
                ExternalWindow.Render.SetSolidColor(playerVisible ?
                    friendly ? Option.FriendlyColor : Option.EnemyColor :
                    friendly ? Option.FriendlyOccludedColor : Option.EnemyOccludedColor);

                ExternalWindow.Render.StrokeThickness = Option.LineWidth;

                switch (Option.Mode)
                {
                    case SnapLinesOption.SnapLineMode.Bottom:
                        ExternalWindow.Render.DrawLine(new Vector2(ExternalWindow.ScreenSize.Width / 2F, ExternalWindow.ScreenSize.Height), screenSpacePoint);
                        break;

                    case SnapLinesOption.SnapLineMode.Center:
                        ExternalWindow.Render.DrawLine(new Vector2(ExternalWindow.ScreenSize.Width / 2F, ExternalWindow.ScreenSize.Height / 2F), screenSpacePoint);
                        break;

                    case SnapLinesOption.SnapLineMode.Top:
                        ExternalWindow.Render.DrawLine(new Vector2(ExternalWindow.ScreenSize.Width / 2F, 0), screenSpacePoint);
                        break;
                }
            }
        }
    }
}
