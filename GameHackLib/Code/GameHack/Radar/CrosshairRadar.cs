using System;
using System.Drawing;
using System.Numerics;
using GameHackLib.Code.Form;
using GameHackLib.Code.GameHack.Option;

namespace GameHackLib.Code.GameHack.Radar
{
    public static class CrosshairRadar
    {
        public static CrosshairRadarOption Option { get; set; } = new CrosshairRadarOption();

        public static void DrawPlayer(Vector3 playerPosition, Vector3 localPlayerPosition, Size windowSize, float localPlayerYaw, bool playerVisible, bool playerFiendly )
        {
            var centerScreen = new Vector2( windowSize.Width / 2F, windowSize.Height / 2F );

            var playerDistance = new Vector2(
                ( localPlayerPosition.X - playerPosition.X ) * Option.Scale,
                ( localPlayerPosition.Z - playerPosition.Z ) * Option.Scale );

            var playerDistanceFromCenterRadar = new Vector2(
                centerScreen.X + playerDistance.X,
                centerScreen.Y + playerDistance.Y );

            var playerRadarPosition = new Vector2(
                centerScreen.X + ( playerDistanceFromCenterRadar.X - centerScreen.X ) * ( float )Math.Cos( localPlayerYaw ) - ( playerDistanceFromCenterRadar.Y - centerScreen.Y ) * -( float )Math.Sin( localPlayerYaw ),
                centerScreen.Y + ( playerDistanceFromCenterRadar.X - centerScreen.X ) * -( float )Math.Sin( localPlayerYaw ) + ( playerDistanceFromCenterRadar.Y - centerScreen.Y ) * ( float )Math.Cos( localPlayerYaw ) );

            if( playerRadarPosition.X < 0 )
                playerRadarPosition.X = 0;

            if( playerRadarPosition.Y < 0 )
                playerRadarPosition.Y = 0;

            if( playerRadarPosition.X > windowSize.Width )
                playerRadarPosition.X = windowSize.Width;

            if( playerRadarPosition.Y > windowSize.Height )
                playerRadarPosition.Y = windowSize.Height;

            ExternalWindow.Render.SetSolidColor(playerVisible ?
                playerFiendly ? Option.FriendlyColor : Option.EnemyColor :
                playerFiendly ? Option.FriendlyOccludedColor : Option.EnemyOccludedColor);

            ExternalWindow.Render.StrokeThickness = Option.PlayerWidth;

            ExternalWindow.Render.DrawPixel( playerRadarPosition );
        }

        public static void DrawName( Vector3 playerPosition, Vector3 localPlayerPosition, Size windowSize, string playerName, float localPlayerYaw, bool playerVisible, bool playerFiendly )
        {
            var centerScreen = new Vector2( windowSize.Width / 2F, windowSize.Height / 2F );

            var playerDistance = new Vector2(
                ( localPlayerPosition.X - playerPosition.X ) * Option.Scale,
                ( localPlayerPosition.Z - playerPosition.Z ) * Option.Scale );

            var playerDistanceFromCenterRadar = new Vector2(
                centerScreen.X + playerDistance.X,
                centerScreen.Y + playerDistance.Y );

            var playerRadarPosition = new Vector2(
                centerScreen.X + ( playerDistanceFromCenterRadar.X - centerScreen.X ) * ( float )Math.Cos( localPlayerYaw ) - ( playerDistanceFromCenterRadar.Y - centerScreen.Y ) * -( float )Math.Sin( localPlayerYaw ),
                centerScreen.Y + ( playerDistanceFromCenterRadar.X - centerScreen.X ) * -( float )Math.Sin( localPlayerYaw ) + ( playerDistanceFromCenterRadar.Y - centerScreen.Y ) * ( float )Math.Cos( localPlayerYaw ) );

            if( playerRadarPosition.X < 0 )
                playerRadarPosition.X = 0;

            if( playerRadarPosition.Y < 0 )
                playerRadarPosition.Y = 0;

            if( playerRadarPosition.X > windowSize.Width )
                playerRadarPosition.X = windowSize.Width;

            if( playerRadarPosition.Y > windowSize.Height )
                playerRadarPosition.Y = windowSize.Height;

            ExternalWindow.Render.SetSolidColor(playerVisible ?
                playerFiendly ? Option.FriendlyColor : Option.EnemyColor :
                playerFiendly ? Option.FriendlyOccludedColor : Option.EnemyOccludedColor);

            ExternalWindow.Render.FontSize = Option.FontSize;
            ExternalWindow.Render.FontFamily = Option.FontFamily;

            ExternalWindow.Render.DrawText( playerRadarPosition, playerName );
        }
    }
}
