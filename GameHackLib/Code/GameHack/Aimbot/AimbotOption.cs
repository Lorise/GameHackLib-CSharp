namespace GameHackLib.Code.GameHack.Aimbot
{
    public class AimbotOption
    {
        public bool IsEnable { get; set; }
        public double Fov { get; set; }
        public bool DrawFov;
        public float MaxDistance { get; set; }
        public PlayerSort PlayerSort { get; set; }

        public AimbotOption()
        {
            IsEnable = true;
            Fov = 8.0;
            DrawFov = true;
            MaxDistance = 1000;
            PlayerSort = PlayerSort.Fov;
        }
    }
}
