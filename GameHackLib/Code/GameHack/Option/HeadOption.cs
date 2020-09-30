using GameHackLib.Code.GameHack.ESPHack;
using GameHackLib.Code.GameHack.Option.Interface;

namespace GameHackLib.Code.GameHack.Option
{
    public class HeadOption:
        IVisibleHackOption,
        IOnlyEnemyHackOption
    {
        public bool IsVisible { get; set; }
        public bool IsOnlyEnemyVisible { get; set; }

        public HeadOption()
        {
            IsVisible = true;

            IsOnlyEnemyVisible = true;
        }
    }
}
