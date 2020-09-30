using System.Numerics;

namespace GameHackLib.Code.GameHack.ESPHack
{
    public static class Distance
    {
        public static Text Text { get; set; } = new Text();

        public static void Draw( Matrix4x4 viewProj, Vector3 position, float distance, float playerHeight, bool playerVisible, bool friendly )
        {
            Text.Draw(viewProj, position, distance.ToString(), playerHeight, playerVisible, friendly );
        }
    }
}
