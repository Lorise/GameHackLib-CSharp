using System;
using System.Drawing;
using System.Numerics;
using GameHackLib.Code.Form;
using GameHackLib.Code.GameHack.Option;

namespace GameHackLib.Code.GameHack.Radar
{
    public static class Radar2D
    {
        public static Radar2DOption Option { get; set; } = new Radar2DOption();

        public static void Draw()
        {
            ExternalWindow.Render.SetSolidColor(Option.BackgroundColor);

            ExternalWindow.Render.DrawFillRectangle(Option.Position, Option.Position + new Vector2(Option.Size, Option.Size));

            ExternalWindow.Render.SetSolidColor(Option.BorderColor);
            ExternalWindow.Render.StrokeThickness = 1;

            ExternalWindow.Render.DrawRectangle(Option.Position, Option.Position + new Vector2(Option.Size, Option.Size));

            ExternalWindow.Render.DrawLine( new Vector2( Option.Position.X + Option.Size / 2F, Option.Position.Y ), new Vector2( Option.Position.X + Option.Size / 2F, Option.Position.Y + Option.Size ) );
            ExternalWindow.Render.DrawLine( new Vector2( Option.Position.X, Option.Position.Y + Option.Size / 2F ), new Vector2( Option.Position.X + Option.Size, Option.Position.Y + Option.Size / 2F ) );
        }

        public static void DrawPlayer(Vector3 playerPosition, Vector3 localPlayerPosition, Size windowSize, float localPlayerYaw, bool playerVisible, bool playerFiendly )
        {
            var centerRadar = new Vector2(
                Option.Position.X + Option.Size / 2,
                Option.Position.Y + Option.Size / 2);

            var playerDistance = new Vector2(
                (localPlayerPosition.X - playerPosition.X) / Option.Scale,
                (localPlayerPosition.Z - playerPosition.Z) / Option.Scale);

            var playerDistanceFromCenterRadar = new Vector2(
                centerRadar.X + playerDistance.X,
                centerRadar.Y + playerDistance.Y);

            var playerRadarPosition = new Vector2(
                centerRadar.X + (playerDistanceFromCenterRadar.X - centerRadar.X) * (float)Math.Cos(localPlayerYaw) - (playerDistanceFromCenterRadar.Y - centerRadar.Y) * -(float)Math.Sin(localPlayerYaw),
                centerRadar.Y + (playerDistanceFromCenterRadar.X - centerRadar.X) * -(float)Math.Sin(localPlayerYaw) + (playerDistanceFromCenterRadar.Y - centerRadar.Y) * (float)Math.Cos(localPlayerYaw));

            if (playerRadarPosition.X < Option.Position.X)
                playerRadarPosition.X = Option.Position.X;

            if (playerRadarPosition.Y < Option.Position.Y)
                playerRadarPosition.Y = Option.Position.Y;

            if (playerRadarPosition.X > Option.Position.X + Option.Size)
                playerRadarPosition.X = Option.Position.X + Option.Size;

            if (playerRadarPosition.Y > Option.Position.Y + Option.Size)
                playerRadarPosition.Y = Option.Position.Y + Option.Size;

            ExternalWindow.Render.SetSolidColor(playerVisible ?
                playerFiendly ? Option.FriendlyColor : Option.EnemyColor :
                playerFiendly ? Option.FriendlyOccludedColor : Option.EnemyOccludedColor);

            ExternalWindow.Render.StrokeThickness = Option.PlayerWidth;
            ExternalWindow.Render.DrawPixel( playerRadarPosition );
        }

        public static void DrawName( Vector3 playerPosition, Vector3 localPlayerPosition, Size windowSize, string playerName, float localPlayerYaw, bool playerVisible, bool playerFiendly )
        {
            var centerRadar = new Vector2(
                Option.Position.X + Option.Size / 2,
                Option.Position.Y + Option.Size / 2 );

            var playerDistance = new Vector2(
                ( localPlayerPosition.X - playerPosition.X ) / Option.Scale,
                ( localPlayerPosition.Z - playerPosition.Z ) / Option.Scale );

            var playerDistanceFromCenterRadar = new Vector2(
                centerRadar.X + playerDistance.X,
                centerRadar.Y + playerDistance.Y );

            var playerRadarPosition = new Vector2(
                centerRadar.X + ( playerDistanceFromCenterRadar.X - centerRadar.X ) * ( float )Math.Cos( localPlayerYaw ) - ( playerDistanceFromCenterRadar.Y - centerRadar.Y ) * -( float )Math.Sin( localPlayerYaw ),
                centerRadar.Y + ( playerDistanceFromCenterRadar.X - centerRadar.X ) * -( float )Math.Sin( localPlayerYaw ) + ( playerDistanceFromCenterRadar.Y - centerRadar.Y ) * ( float )Math.Cos( localPlayerYaw ) );

            if( playerRadarPosition.X < Option.Position.X )
                playerRadarPosition.X = Option.Position.X;

            if( playerRadarPosition.Y < Option.Position.Y )
                playerRadarPosition.Y = Option.Position.Y;

            if( playerRadarPosition.X > Option.Position.X + Option.Size )
                playerRadarPosition.X = Option.Position.X + Option.Size;

            if( playerRadarPosition.Y > Option.Position.Y + Option.Size )
                playerRadarPosition.Y = Option.Position.Y + Option.Size;

            ExternalWindow.Render.SetSolidColor(playerVisible ?
                playerFiendly ? Option.FriendlyColor : Option.EnemyColor :
                playerFiendly ? Option.FriendlyOccludedColor : Option.EnemyOccludedColor);

            ExternalWindow.Render.FontFamily = Option.FontFamily;
            ExternalWindow.Render.FontSize = Option.FontSize;

            ExternalWindow.Render.DrawText( playerRadarPosition, playerName );
        }
    }
}
