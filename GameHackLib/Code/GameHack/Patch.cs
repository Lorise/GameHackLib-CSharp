namespace GameHackLib.Code.GameHack
{
    public class Patch
    {
        protected long Address;
        protected byte[] Data;
        protected byte[] SaveData;

        protected Patch(long address, byte[] data)
        {
            Address = address;
            Data = data;
        }

        public void Patching()
        {
            var processMemory = ProcessMemory.Get();
            SaveData = processMemory.ReadBytes(Address, Data.Length);
            processMemory.WriteBytes(Address, Data);
        }

        public void Restore()
        {
            ProcessMemory.Get().WriteBytes(Address, SaveData);
        }
    }
}
