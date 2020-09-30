using System.Numerics;
using GameHackLib.Code.Form;
using GameHackLib.Code.GameHack.Option;

namespace GameHackLib.Code.GameHack.ESPHack
{
    public class Text
    {
        public TextOption Option { get; set; } = new TextOption();

        public void Draw(Matrix4x4 viewProj, Vector3 position, string text, float playerHeight, bool playerVisible, bool friendly )
        {
            if (friendly && Option.IsOnlyEnemyVisible)
                return;

            if(new Vector3(position.X, position.Y + (playerHeight + playerHeight * 0.2F), position.Z).WorldToScreen( viewProj, out var screenSpacePoint ) )
            {
                ExternalWindow.Render.SetSolidColor(playerVisible ?
                    friendly ? Option.FriendlyColor : Option.EnemyColor :
                    friendly ? Option.FriendlyOccludedColor : Option.EnemyOccludedColor);

                ExternalWindow.Render.FontSize = Option.FontSize;
                ExternalWindow.Render.FontFamily = Option.FontFamily;

                ExternalWindow.Render.DrawText( new Vector2( screenSpacePoint.X, screenSpacePoint.Y - Option.FontSize / 2F ), text, true );
            }
        }
    }
}
