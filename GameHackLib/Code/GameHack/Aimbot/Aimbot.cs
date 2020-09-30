using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Media;
using GameHackLib.Code.Form;
using GameHackLib.Code.GameData;
using GameHackLib.Code.Win;

namespace GameHackLib.Code.GameHack.Aimbot
{
    public static class Aimbot
    {
        public static AimbotOption Option { get; } = new AimbotOption();

        public static void Run(BaseGame game)
        {
            if (Option.IsEnable)
                Calculate(game);

            if (Option.DrawFov)
                Draw(game);
        }

        private static BasePlayer GetPlayerFov(BaseGame game)
        {
            var players = game.EnemyPlayers;

            players.Sort((player1, player2) =>
            {
                player1.Skeleton.Head.WorldToScreen(game.ViewMatrix, out var v1);
                player2.Skeleton.Head.WorldToScreen(game.ViewMatrix, out var v2);

                var d1 = Vector2.Distance(v1, ExternalWindow.WindowCenter);
                var d2 = Vector2.Distance(v2, ExternalWindow.WindowCenter);

                return Comparer.Default.Compare(d1, d2);
            });

            return players.FirstOrDefault();
        }

        private static DateTime _lastFire = DateTime.Now;
        private static readonly TimeSpan RapidTime = TimeSpan.FromMilliseconds(300);
        private static BasePlayer _aimPlayer;
        private static void Calculate(BaseGame game)
        {
            if(!Option.IsEnable)
                return;

            _aimPlayer = GetPlayerFov(game);
            if (_aimPlayer == null)
                return;

            _aimPlayer.HeadPosition.WorldToScreen(game.ViewMatrix, out var v1);
            if (Option.Fov == 0 ||
                Vector2.Distance(v1, ExternalWindow.WindowCenter) < Option.Fov)
            {
               if (Convert.ToBoolean(WinAPI.GetKeyState(WinAPI.VirtualKeyStates.VK_SHIFT) & 0x8000))
                //if(Control.MouseButtons == MouseButtons.Left)
                {
                    if (DateTime.Now - _lastFire > RapidTime)
                    {
                        var aimViewAngle = CalculateAngle(game.LocalPlayer.HeadPosition, _aimPlayer.HeadPosition);
                        var backupViewAngles = game.ViewAngles;
                        WriteViewAngles(game, aimViewAngle);
                        Fire();
                        ThreadPool.QueueUserWorkItem((state =>
                        {
                            Thread.Sleep(15);
                            WriteViewAngles(game, backupViewAngles);
                        }));
                    }
                }
            }
        }

        private static void Draw(BaseGame game)
        {
            if (Option.DrawFov)
            {
                ExternalWindow.Render.SetSolidColor(Colors.Blue);
                ExternalWindow.Render.StrokeThickness = 1;
                ExternalWindow.Render.DrawCircle(ExternalWindow.WindowCenter, (float) Option.Fov);
            }

            if (_aimPlayer != null)
            {
                _aimPlayer.HeadPosition.WorldToScreen(game.ViewMatrix, out var v1);
                ExternalWindow.Render.SetSolidColor(Colors.Green);
                ExternalWindow.Render.DrawFillCircle(v1, 3);
            }
        }

        private static void WriteViewAngles(BaseGame game, Vector2 angles)
        {
            if (float.IsNaN(angles.X) || float.IsNaN(angles.Y))
                return;

            ProcessMemory.Get().WriteVector2(game.ViewAnglesAddress, angles);
        }

        private static void Fire()
        {
            WinAPI.mouse_event(WinAPI.MOUSEEVENTF_LEFTDOWN | WinAPI.MOUSEEVENTF_LEFTUP, Cursor.Position.X, Cursor.Position.Y, 0, UIntPtr.Zero);
            _lastFire = DateTime.Now;
        }

        private static Vector2 CalculateAngle(Vector3 localPlayer, Vector3 player)
        {
            var delta = localPlayer - player;
            var hyp = Math.Sqrt(Math.Pow(delta.X, 2) + Math.Pow(delta.Y, 2));

            var angle = new Vector2(
                (float)Math.Asin(delta.Z / hyp) * 57.295779513082f,
                (float)Math.Atan(delta.Y / delta.X) * 57.295779513082f);

            if (delta.X >= 0.0)
                angle.Y += 180.0f;

            return angle;
        }

        private static Vector2 NormalizeAngles(Vector2 viewAngle)
        {
            if (viewAngle.X > 89.0f && viewAngle.X <= 180.0f)
                viewAngle.X = 89.0f;

            while (viewAngle.X > 180f)
                viewAngle.X -= 360f;

            while (viewAngle.X < -89.0f)
                viewAngle.X = -89.0f;

            while (viewAngle.Y > 180f)
                viewAngle.Y -= 360f;

            while (viewAngle.Y < -180f)
                viewAngle.Y += 360f;

            return viewAngle;
        }

        private static Vector2 Normalize(Vector2 viewAngles)
        {
            viewAngles.Y -= 90;
            viewAngles.Y *= -1;

            if (viewAngles.Y < 0)
                viewAngles.Y += 360;

            viewAngles.X = ConvertToRadians(viewAngles.X);
            viewAngles.Y = ConvertToRadians(viewAngles.Y);

            return viewAngles;
        }

        private static Vector2 Denormalize(Vector2 viewAngles)
        {
            viewAngles.X = ConvertRadiansToDegrees(viewAngles.X);
            viewAngles.Y = ConvertRadiansToDegrees(viewAngles.Y);

            viewAngles.Y -= 90;
            viewAngles.Y *= -1;

            if (viewAngles.Y < -180)
                viewAngles.Y += 360;

            return viewAngles;
        }

        private static float ConvertRadiansToDegrees(double radians) => (float)(180 / Math.PI * radians);
        private static float ConvertToRadians(double angle) => (float)(Math.PI / 180 * angle);
    }
}