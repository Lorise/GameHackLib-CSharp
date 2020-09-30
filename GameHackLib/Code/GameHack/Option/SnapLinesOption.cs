using System.Windows.Media;
using GameHackLib.Code.GameHack.Option.Interface;

namespace GameHackLib.Code.GameHack.Option
{
    public partial class SnapLinesOption:
        IVisibleHackOption,
        IOnlyEnemyHackOption,
        IFriendlyEnemyColorHackOption,
        ILineWidthHackOption
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

        #region ILineWidthHackOption
        public int LineWidth { get; set; }
        #endregion

        public ESPHack.SnapLinesOption.SnapLineMode Mode { get; set; }

        public SnapLinesOption()
        {
            IsVisible = true;

            IsOnlyEnemyVisible = true;

            FriendlyColor = Color.FromArgb(255, 0, 114, 255);
            FriendlyOccludedColor = Color.FromArgb(255, 79, 158, 255 );
            EnemyColor = Color.FromArgb(255, 255, 255, 255);
            EnemyOccludedColor = Color.FromArgb(255, 255, 255, 255);

            LineWidth = 1;

            Mode = ESPHack.SnapLinesOption.SnapLineMode.Bottom;
        }
    }
}
