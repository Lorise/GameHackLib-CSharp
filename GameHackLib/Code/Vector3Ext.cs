using System;
using System.Numerics;
using System.Windows.Forms;
using GameHackLib.Code.Form;

namespace GameHackLib.Code
{
    static class Vector3Ext
    {
        public static Vector3 RotateX(this Vector3 vector3, double angle)
        {
            return new Vector3(
                vector3.X,
                vector3.Y * (float)System.Math.Cos(angle) - vector3.Z * (float)System.Math.Sin(angle),
                vector3.Y * (float)System.Math.Sin(angle) + vector3.Z * (float)System.Math.Cos(angle));
        }

        public static Vector3 RotateY(this Vector3 vector3, double angle)
        {
            return new Vector3(
                vector3.Z * (float)System.Math.Sin(angle) + vector3.X * (float)System.Math.Cos(angle),
                vector3.Y,
                vector3.Z * (float)System.Math.Cos(angle) - vector3.X * (float)System.Math.Sin(angle));
        }

        public static Vector3 RotateZ(this Vector3 vector3, double angle)
        {
            return new Vector3(
                vector3.X * (float)System.Math.Cos(angle) - vector3.Y * (float)System.Math.Sin(angle),
                vector3.X * (float)System.Math.Sin(angle) + vector3.Y * (float)System.Math.Cos(angle),
                vector3.Z);
        }

        public static bool WorldToScreen(this Vector3 position, Matrix4x4 viewProj, out Vector2 screenPosition, bool upZ = true)
        {
            return upZ ? WorldToScreenZ(position, viewProj, out screenPosition) : WorldToScreenY(position, viewProj, out screenPosition);
        }

        private static bool WorldToScreenY(this Vector3 position, Matrix4x4 viewProj, out Vector2 screenPosition)
        {
            screenPosition = Vector2.Zero;

            var w = viewProj.M14 * position.X + viewProj.M24 * position.Y + (viewProj.M34 * position.Z + viewProj.M44);

            if (w < 0.01f)
                return false;

            var x = viewProj.M11 * position.X + viewProj.M21 * position.Y + (viewProj.M31 * position.Z + viewProj.M41);
            var y = viewProj.M12 * position.X + viewProj.M22 * position.Y + (viewProj.M32 * position.Z + viewProj.M42);

            screenPosition.X = ExternalWindow.ScreenSize.Width / 2F + ExternalWindow.ScreenSize.Width / 2F * x / w;
            screenPosition.Y = ExternalWindow.ScreenSize.Height / 2F - ExternalWindow.ScreenSize.Height / 2F * y / w;

            return true;
        }

        private static bool WorldToScreenZ(this Vector3 position, Matrix4x4 viewProj, out Vector2 screenPosition)
        {
            var w = viewProj.M41 * position.X + viewProj.M42 * position.Y + viewProj.M43 * position.Z + viewProj.M44;

            if (w > 0.01f)
            {
                var v = new Vector2(
                    viewProj.M11 * position.X + viewProj.M12 * position.Y + viewProj.M13 * position.Z + viewProj.M14,
                    viewProj.M21 * position.X + viewProj.M22 * position.Y + viewProj.M23 * position.Z + viewProj.M24);

                v /= w;

                screenPosition = new Vector2(
                    ExternalWindow.ScreenSize.Width / 2f + (0.5f * v.X * ExternalWindow.ScreenSize.Width + 0.5f),
                    ExternalWindow.ScreenSize.Height / 2f - (0.5f * v.Y * ExternalWindow.ScreenSize.Height + 0.5f));

                if (!float.IsNegativeInfinity(screenPosition.X) &&
                    !float.IsPositiveInfinity(screenPosition.X) &&
                    !float.IsNegativeInfinity(screenPosition.Y) &&
                    !float.IsPositiveInfinity(screenPosition.Y) &&
                    !float.IsNaN(screenPosition.X) &&
                    !float.IsNaN(screenPosition.Y))
                    return true;

                screenPosition = Vector2.Zero;
                return false;
            }

            screenPosition = Vector2.Zero;
            return false;
        }
    }
}
