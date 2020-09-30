using System.Numerics;
using GameHackLib.Code.Form;
using GameHackLib.Code.GameHack.Option;

namespace GameHackLib.Code.GameHack.ESPHack
{
    public static class Head
    {
        public static HeadOption Option = new HeadOption();

        public static void Draw(Matrix4x4 viewProj, Vector3 position, bool friendly)
        {
            if (friendly && Option.IsOnlyEnemyVisible)
                return;

            position.Z += 65;

            var v = new Vector3(position.X, position.Y, position.Z);

            if (v.WorldToScreen(viewProj, out var screenSpacePoint))
                ExternalWindow.Render.DrawFillCircle(screenSpacePoint, 3);
        }
    }
}
