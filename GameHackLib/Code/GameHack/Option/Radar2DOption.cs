using System.Numerics;
using System.Windows.Media;
using GameHackLib.Code.GameHack.Option.Interface;

namespace GameHackLib.Code.GameHack.Option
{
    public class Radar2DOption:
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

        #region IVisibleNameHackOption
        public bool IsVisibleName { get; set; }
        #endregion

        #region IFriendlyEnemyColorHackOption
        public Color FriendlyColor { get; set; }
        public Color EnemyColor { get; set; }
        public Color FriendlyOccludedColor { get; set; }
        public Color EnemyOccludedColor { get; set; }
        #endregion

        #region IFontOption
        public string FontFamily { get; set; }
        public int FontSize { get; set; }
        #endregion

        public Color BackgroundColor { get; set; }
        public Color BorderColor { get; set; }
        public Vector2 Position { get; set; }
        public float Size { get; set; }
        public float Scale { get; set; }
        public int PlayerWidth { get; set; }

        public Radar2DOption()
        {
            IsVisible = true;

            IsOnlyEnemyVisible = true;

            IsVisibleName = false;

            FriendlyColor = Color.FromArgb(255, 0, 114, 255);
            EnemyColor = Color.FromArgb(255, 255, 58, 0);
            FriendlyOccludedColor = Color.FromArgb(255, 79, 158, 255);
            EnemyOccludedColor = Color.FromArgb(255, 255, 210, 0);

            FontFamily = "Arial";
            FontSize = 10;

            BackgroundColor = Colors.Gray;
            BorderColor = Colors.DarkGray;
            Position = new Vector2( 860, 0 );
            Size = 200;
            Scale = 20f;
            PlayerWidth = 3;
        }
    }
}