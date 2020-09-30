using System.Windows.Media;
using GameHackLib.Code.GameHack.Option.Interface;

namespace GameHackLib.Code.GameHack.Option
{
    public class HealthOption:
        IVisibleHackOption,
        IOnlyEnemyHackOption,
        ILineWidthHackOption
    {
        #region IVisibleHackOption
        public bool IsVisible { get; set; }
        #endregion

        #region IOnlyEnemyHackOption
        public bool IsOnlyEnemyVisible { get; set; }
        #endregion

        #region ILineWidthHackOption
        public int LineWidth { get; set; }
        #endregion

        public Color BackgroundColor { get; set; }
        public Color ForegroundColor { get; set; }

        public HealthOption()
        {
            IsVisible = true;

            IsOnlyEnemyVisible = true;

            LineWidth = 3;

            BackgroundColor = Color.FromArgb(255, 151, 151, 151);
            ForegroundColor = Color.FromArgb(255, 35, 208, 59 );
        }
    }
}
