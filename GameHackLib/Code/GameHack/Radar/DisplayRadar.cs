using System;
using System.Drawing;
using System.Numerics;
using GameHackLib.Code.Form;
using GameHackLib.Code.GameHack.Option;

namespace GameHackLib.Code.GameHack.Radar
{
    public class DisplayRadar
    {
        public static DisplayRadarOption Option { get; set; } = new DisplayRadarOption();

        public static void DrawPlayer( Vector3 playerPosition, Vector3 localPlayerPosition, Size windowSize, float localPlayerYaw, bool playerVisible, bool playerFiendly )
        {
            var centerScreen = new Vector2( windowSize.Width / 2F, windowSize.Height / 2F );

            var playerDistance = new Vector2(
                ( localPlayerPosition.X - playerPosition.X ) * 2,
                ( localPlayerPosition.Z - playerPosition.Z ) * 2 );

            var playerDistanceFromCenterRadar = new Vector2(
                centerScreen.X + playerDistance.X,
                centerScreen.Y + playerDistance.Y );

            var playerRadarPosition = new Vector2(
                centerScreen.X + ( playerDistanceFromCenterRadar.X - centerScreen.X ) * ( float )Math.Cos( localPlayerYaw ) - ( playerDistanceFromCenterRadar.Y - centerScreen.Y ) * -( float )Math.Sin( localPlayerYaw ),
                centerScreen.Y + ( playerDistanceFromCenterRadar.X - centerScreen.X ) * -( float )Math.Sin( localPlayerYaw ) + ( playerDistanceFromCenterRadar.Y - centerScreen.Y ) * ( float )Math.Cos( localPlayerYaw ) );

            if( playerRadarPosition.X < 0 + 10 )
                playerRadarPosition.X = 0 + 10;

            if( playerRadarPosition.Y < 0 + 10 )
                playerRadarPosition.Y = 0 + 10;

            if( playerRadarPosition.X > windowSize.Width - 10 )
                playerRadarPosition.X = windowSize.Width - 10;

            if( playerRadarPosition.Y > windowSize.Height - 10 )
                playerRadarPosition.Y = windowSize.Height - 10;

            ExternalWindow.Render.SetSolidColor(playerVisible ?
                playerFiendly ? Option.FriendlyColor : Option.EnemyColor :
                playerFiendly ? Option.FriendlyOccludedColor : Option.EnemyOccludedColor);

            ExternalWindow.Render.StrokeThickness = Option.PlayerWidth;

            ExternalWindow.Render.DrawFillRectangle(playerRadarPosition, playerRadarPosition + new Vector2(10, 10));
        }
    }
}
