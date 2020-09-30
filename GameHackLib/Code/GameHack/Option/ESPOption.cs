namespace GameHackLib.Code.GameHack.Option
{
    public class ESPOption
    {
        private bool box2D;
        public bool Box2D
        {
            get => box2D;
            set
            {
                if (value)
                    box2D = false;
                box2D = value;
            }
        }

        private bool _box3D;
        public bool Box3D
        {
            get => _box3D;
            set
            {
                if (value)
                    Box2D = false;
                _box3D = value;
            }
        }
        public bool Health { get; set; }
        public bool Armor { get; set; }
        public bool Name { get; set; }
        public bool Distance { get; set; }
        public bool Skeleton { get; set; }
        public bool Snapline { get; set; }
        public bool Head { get; set; }

        public ESPOption()
        {
            Box2D = true;
            Box3D = false;
            Health = true;
            Armor = false;
            Name = false;
            Distance = false;
            Skeleton = false;
            Snapline = true;
            Head = true;
        }
    }
}
