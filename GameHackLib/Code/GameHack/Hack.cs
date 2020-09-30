using System.Collections.Generic;
using GameHackLib.Code.Form;
using GameHackLib.Code.GameData;
using GameHackLib.Code.GameHack.ESPHack;

namespace GameHackLib.Code.GameHack
{
    public class Hack
    {
        public static void Run(BaseGame game)
        {
            game.Read();

            ExternalWindow.Render.Clear();

            ESP.Draw(game);
            Aimbot.Aimbot.Run(game);
        }

        private static readonly List<Patch> Patches = new List<Patch>();

        public static void AddPatch(Patch patch) => Patches.Add(patch);

        public static void PatchAll()
        {
            foreach (var patch in Patches)
                patch.Patching();
        }
    }
}
