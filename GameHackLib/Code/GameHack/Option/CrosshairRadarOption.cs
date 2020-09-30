using System.Windows.Media;
using GameHackLib.Code.GameHack.Option.Interface;

namespace GameHackLib.Code.GameHack.Option
{
    public class CrosshairRadarOption:
        IVisibleHackOption,
        IOnlyEnemyHackOption,
        IVisibleNameHackOption,
        IFriendlyEnemyColorHackOption,
        IFontOption
    {
        #region IVisibleHackOption
        public bool IsVisible { get; set; }
        #endregion


        #region IOnlyEnemyHackOption
        public bool IsOnlyEnemyVisible { get; set; }
        #endregion

        #region IFriendlyEnemyColorHackOption
        public Color FriendlyColor { get; set; }
        public Color FriendlyOccludedColor { get; set; }
        public Color EnemyColor { get; set; }
        public Color EnemyOccludedColor { get; set; }
        #endregion

        #region IVisibleNameHackOption
        public bool IsVisibleName { get; set; } = false;
        #endregion

        #region IFontOption
        public int FontSize { get; set; }
        public string FontFamily { get; set; }
        #endregion

        public float Scale { get; set; } = 1;
        public int PlayerWidth { get; set; } = 3;

        public CrosshairRadarOption()
        {
            IsVisible = false;

            IsOnlyEnemyVisible = true;

            FriendlyColor = Color.FromArgb(255, 0, 114, 255);
            FriendlyOccludedColor = Color.FromArgb(255, 79, 158, 255);
            EnemyColor = Color.FromArgb(255, 255, 58, 0);
            EnemyOccludedColor = Color.FromArgb(255, 255, 210, 0);

            FontSize = 10;
            FontFamily = "Arial";
        }
    }
}
