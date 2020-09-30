namespace GameHackLib.Code
{
    public static class CSGOConstants
    {
        public static int PlayerWidth { get; }
        public static int PlayerHeight { get; }
        public static int TeamID_t { get; }
        public static int TeamID_ct { get; }
        public static int MaxHealth { get; }
        public static int MinHealth { get; }
        public static int MaxArmor { get; }
        public static int MinArmor { get; }

        static CSGOConstants()
        {
            PlayerWidth = 36;
            PlayerHeight = 72;
            TeamID_t = 2;
            TeamID_ct = 3;
            MaxHealth = 100;
            MinHealth = 0;
            MaxArmor = 100;
            MinArmor = 0;
        }
    }
}
