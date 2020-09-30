using System.Windows.Media;
using GameHackLib.Code.GameHack.Option.Interface;

namespace GameHackLib.Code.GameHack.Misc
{
    public class CrosshairOption:
        IVisibleHackOption,
        IColorHackOption,
        ILineWidthHackOption
    {
        public enum CrosshairType { Cross, Circle, Dot }

        #region IVisibleHackOption
        public bool IsVisible { get; set; }
        #endregion

        #region IColorHackOption
        public Color Color { get; set; }
        #endregion

        #region ILineWidthHackOption
        public int LineWidth { get; set; }
        #endregion

        public float Size { get; set; }
        public CrosshairType Type { get; set; }

        public CrosshairOption()
        {
            IsVisible = true;

            LineWidth = 1;

            Color = Color.FromArgb(255, 0, 54, 255 );

            Size = 10;
            Type = CrosshairType.Circle;
        }
    }
}
