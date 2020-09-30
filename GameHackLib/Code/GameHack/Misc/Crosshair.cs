using System.Drawing;
using System.Numerics;
using GameHackLib.Code.Form;

namespace GameHackLib.Code.GameHack.Misc
{
    public static class Crosshair
    {
        public static CrosshairOption Option { get; set; } = new CrosshairOption();

        public static void Draw()
        {
            ExternalWindow.Render.SetSolidColor(Option.Color);
            ExternalWindow.Render.StrokeThickness = Option.LineWidth;

            switch (Option.Type)
            {
                case CrosshairOption.CrosshairType.Cross:
                    ExternalWindow.Render.DrawLine(
                        new Vector2(ExternalWindow.ScreenSize.Width / 2F - Option.Size, ExternalWindow.ScreenSize.Height / 2F),
                        new Vector2(ExternalWindow.ScreenSize.Width / 2F + Option.Size, ExternalWindow.ScreenSize.Height / 2F));
                    ExternalWindow.Render.DrawLine(
                        new Vector2(ExternalWindow.ScreenSize.Width / 2F, ExternalWindow.ScreenSize.Height / 2F - Option.Size),
                        new Vector2(ExternalWindow.ScreenSize.Width / 2F, ExternalWindow.ScreenSize.Height / 2F + Option.Size));
                    break;

                case CrosshairOption.CrosshairType.Circle:
                    ExternalWindow.Render.DrawCircle(new Vector2(ExternalWindow.ScreenSize.Width / 2F, ExternalWindow.ScreenSize.Height / 2F), Option.Size);
                    break;

                case CrosshairOption.CrosshairType.Dot:
                    ExternalWindow.Render.DrawFillCircle(new Vector2(ExternalWindow.ScreenSize.Width / 2F, ExternalWindow.ScreenSize.Height / 2F), Option.Size);
                    break;
            }
        }
    }
}
