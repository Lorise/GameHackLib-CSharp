using System.Numerics;

namespace GameHackLib.Code.GameHack.ESPHack
{
    class Name
    {
        public static Text Text { get; set; } = new Text();

        public static void Draw(Matrix4x4 viewProj, Vector3 position, string name, float playerHeight, bool playerVisible, bool friendly)
        {
            Text.Draw(viewProj, position, name, playerHeight, playerVisible, friendly);
        }
    }
}
