using System.Windows.Media;

namespace GameHackLib.Code.GameHack.Option.Interface
{
    public interface IFriendlyEnemyColorHackOption
    {
        Color FriendlyColor { get; set; }
        Color FriendlyOccludedColor { get; set; }

        Color EnemyColor { get; set; }
        Color EnemyOccludedColor { get; set; }
    }
}
