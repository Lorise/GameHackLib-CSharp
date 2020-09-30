using System.Windows.Media;
using GameHackLib.Code.GameHack.Option.Interface;

namespace GameHackLib.Code.GameHack.Option
{
    public class TextOption:
        IVisibleHackOption,
        IOnlyEnemyHackOption,
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

        #region IFontOption
        public string FontFamily { get; set; }
        public int FontSize { get; set; }
        #endregion

        public TextOption()
        {
            IsVisible = false;

            IsOnlyEnemyVisible = true;

            FriendlyColor = Color.FromArgb(255, 0, 114, 255);
            FriendlyOccludedColor = Color.FromArgb(255, 79, 158, 255);
            EnemyColor = Color.FromArgb(255, 255, 58, 0);
            EnemyOccludedColor = Color.FromArgb(255, 255, 210, 0);

            FontFamily = "Arial";
            FontSize = 12;
        }
    }
}
