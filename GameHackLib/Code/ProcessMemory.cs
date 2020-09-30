using System;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using GameHackLib.Code.Win;

namespace GameHackLib.Code
{
    public class ProcessMemory
    {
        private static ProcessMemory _instance;
        public static ProcessMemory Get() => _instance ?? (_instance = new ProcessMemory());

        private IntPtr _hProcess;
        public Process Process { get; private set; }

        private ProcessMemory() { }

        ~ProcessMemory() => WinAPI.CloseHandle(_hProcess);

        public bool OpenProcess(string processName)
        {
            var processes = Process.GetProcessesByName(processName);

            if (processes.Length == 0)
                return false;

            Process = processes.First();

            _hProcess = WinAPI.OpenProcess(WinAPI.ProcessAccessFlags.All, false, Process.Id);
            
            return _hProcess != new IntPtr(0);
        }

        public bool IsRunProcess()
        {
            if (Process == null)
                return false;

            var processes = Process.GetProcessesByName(Process.ProcessName);

            if (processes.Length == 0)
                return false;

            return true;
        }

        #region Read
        public byte ReadByte(long address) => ReadBytes(address, sizeof(byte)).First();

        public byte[] ReadBytes(long address, int count)
        {
            var bytes = new byte[count];

            //UInt32 oldProtect;
            //WinAPI.VirtualProtectEx(_hProcess, (IntPtr)address, (uint)count, WinAPI.PAGE_EXECUTE_READWRITE, out oldProtect);

            IntPtr read;
            WinAPI.ReadProcessMemory(_hProcess, (IntPtr)address, bytes, count, out read);

            //WinAPI.VirtualProtectEx(_hProcess, (IntPtr)address, (uint)count, oldProtect, out oldProtect);

            return bytes;
        }

        public bool ReadBool(long address) => BitConverter.ToBoolean(ReadBytes(address, sizeof(bool)), 0);

        public Int16 ReadInt16(long address) => BitConverter.ToInt16(ReadBytes(address, sizeof(Int16)), 0);

        public Int32 ReadInt32(long address) => BitConverter.ToInt32(ReadBytes(address, sizeof(Int32)), 0);

        public Int64 ReadInt64(long address) => BitConverter.ToInt64(ReadBytes(address, sizeof(Int64)), 0);

        public UInt16 ReadUInt16(long address) => BitConverter.ToUInt16(ReadBytes(address, sizeof(UInt16)), 0);

        public UInt32 ReadUInt32(long address) => BitConverter.ToUInt32(ReadBytes(address, sizeof(UInt32)), 0);

        public UInt64 ReadUInt64(long address) => BitConverter.ToUInt64(ReadBytes(address, sizeof(UInt64)), 0);

        public float ReadFloat(long address) => BitConverter.ToSingle(ReadBytes(address, sizeof(float)), 0);

        public double ReadDouble(long address) => BitConverter.ToDouble(ReadBytes(address, sizeof(double)), 0);

        public char ReadAsciiChar(long address) => Encoding.ASCII.GetString(ReadBytes(address, sizeof(byte))).First();

        public char ReadUnicodeChar(long address) => BitConverter.ToChar(ReadBytes(address, sizeof(char)), 0);

        public string ReadAsciiString(long address, Int32 length) => Encoding.ASCII.GetString(ReadBytes(address, length));

        public string ReadUnicodeString(long address, Int32 length) => Encoding.Unicode.GetString(ReadBytes(address, length * 2));

        public Vector2 ReadVector2(long address)
        {
            return new Vector2(
                ReadFloat(address + 0 * sizeof(float)),
                ReadFloat(address + 1 * sizeof(float)));
        }

        public Vector3 ReadVector3(long address)
        {
            return new Vector3(
                ReadFloat(address + 0 * sizeof(float)),
                ReadFloat(address + 1 * sizeof(float)),
                ReadFloat(address + 2 * sizeof(float)));
        }

        public Vector4 ReadVector4(long address)
        {
            return new Vector4(
                ReadFloat(address + 0 * sizeof(float)),
                ReadFloat(address + 1 * sizeof(float)),
                ReadFloat(address + 2 * sizeof(float)),
                ReadFloat(address + 3 * sizeof(float)));
        }

        public Matrix4x4 ReadMatrix(long address)
        {
            return new Matrix4x4(
                ReadFloat(address + 0 * sizeof(float)),
                ReadFloat(address + 1 * sizeof(float)),
                ReadFloat(address + 2 * sizeof(float)),
                ReadFloat(address + 3 * sizeof(float)),
                ReadFloat(address + 4 * sizeof(float)),
                ReadFloat(address + 5 * sizeof(float)),
                ReadFloat(address + 6 * sizeof(float)),
                ReadFloat(address + 7 * sizeof(float)),
                ReadFloat(address + 8 * sizeof(float)),
                ReadFloat(address + 9 * sizeof(float)),
                ReadFloat(address + 10 * sizeof(float)),
                ReadFloat(address + 11 * sizeof(float)),
                ReadFloat(address + 12 * sizeof(float)),
                ReadFloat(address + 13 * sizeof(float)),
                ReadFloat(address + 14 * sizeof(float)),
                ReadFloat(address + 15 * sizeof(float))
            );
        }

        private byte[] data;
        public ProcessMemory Read(long address, int size)
        {
            data = ReadBytes(address, size);
            return _instance;
        }
        #endregion

        #region Write
        public void WriteByte(long address, byte b) => WriteBytes(address, new[] { b });

        public void WriteBytes(long address, byte[] bytes)
        {
            UInt32 oldProtect;
            WinAPI.VirtualProtectEx(_hProcess, (IntPtr)address, (UIntPtr) bytes.Length, WinAPI.PAGE_EXECUTE_READWRITE, out oldProtect);

            IntPtr write;
            WinAPI.WriteProcessMemory(_hProcess, (IntPtr)address, bytes, bytes.Length, out write);

            WinAPI.VirtualProtectEx(_hProcess, (IntPtr)address, (UIntPtr) bytes.Length, oldProtect, out oldProtect);
        }

        public void WriteBool(long address, bool b) => WriteBytes(address, BitConverter.GetBytes(b));

        public void WriteInt16(long address, Int16 i16) => WriteBytes(address, BitConverter.GetBytes(i16));

        public void WriteInt32(long address, Int32 i32) => WriteBytes(address, BitConverter.GetBytes(i32));

        public void WriteInt64(long address, Int64 i64) => WriteBytes(address, BitConverter.GetBytes(i64));

        public void WriteUInt16(long address, UInt16 ui16) => WriteBytes(address, BitConverter.GetBytes(ui16));

        public void WriteUInt32(long address, UInt32 ui32) => WriteBytes(address, BitConverter.GetBytes(ui32));

        public void WriteUInt64(long address, UInt64 ui64) => WriteBytes(address, BitConverter.GetBytes(ui64));

        public void WriteFloat(long address, float f) => WriteBytes(address, BitConverter.GetBytes(f));

        public void WriteDouble(long address, double d) => WriteBytes(address, BitConverter.GetBytes(d));

        public void WriteAsciiChar(long address, char ch) => WriteBytes(address, Encoding.ASCII.GetBytes(new[] { ch }));

        public void WriteUnicodeChar(long address, char ch) => WriteBytes(address, BitConverter.GetBytes(ch));

        public void WriteAsciiString(long address, string str) => WriteBytes(address, Encoding.ASCII.GetBytes(str));

        public void WriteUnicodeString(long address, string str) => WriteBytes(address, Encoding.Unicode.GetBytes(str));

        public void WriteVector2(long address, Vector2 vector2)
        {
            WriteFloat(address + 0 * sizeof(float), vector2.X);
            WriteFloat(address + 1 * sizeof(float), vector2.Y);
        }

        public void WriteVector3(long address, Vector3 vector3)
        {
            WriteFloat(address + 0 * sizeof(float), vector3.X);
            WriteFloat(address + 1 * sizeof(float), vector3.Y);
            WriteFloat(address + 2 * sizeof(float), vector3.Z);
        }

        public void WriteVector4(long address, Vector4 vector4)
        {
            WriteFloat(address + 0 * sizeof(float), vector4.X);
            WriteFloat(address + 1 * sizeof(float), vector4.Y);
            WriteFloat(address + 2 * sizeof(float), vector4.Z);
            WriteFloat(address + 3 * sizeof(float), vector4.W);
        }

        public void WriteMatrix(long address, Matrix4x4 matrix)
        {
            WriteFloat(address + 0 * sizeof(float), matrix.M11);
            WriteFloat(address + 1 * sizeof(float), matrix.M12);
            WriteFloat(address + 2 * sizeof(float), matrix.M13);
            WriteFloat(address + 3 * sizeof(float), matrix.M14);
            WriteFloat(address + 4 * sizeof(float), matrix.M21);
            WriteFloat(address + 5 * sizeof(float), matrix.M22);
            WriteFloat(address + 6 * sizeof(float), matrix.M23);
            WriteFloat(address + 7 * sizeof(float), matrix.M24);
            WriteFloat(address + 8 * sizeof(float), matrix.M31);
            WriteFloat(address + 9 * sizeof(float), matrix.M32);
            WriteFloat(address + 10 * sizeof(float), matrix.M33);
            WriteFloat(address + 11 * sizeof(float), matrix.M34);
            WriteFloat(address + 12 * sizeof(float), matrix.M41);
            WriteFloat(address + 13 * sizeof(float), matrix.M42);
            WriteFloat(address + 14 * sizeof(float), matrix.M43);
            WriteFloat(address + 15 * sizeof(float), matrix.M44);
        }
        #endregion

        public long GetDllAddress(string dllName)
        {
            foreach (ProcessModule module in Process.Modules)
            {
                if (module.ModuleName == dllName)
                    return module.BaseAddress.ToInt64();
            }

            return 0;
        }

        public int GetDllSize(string dllName)
        {
            foreach (ProcessModule module in Process.Modules)
            {
                if (module.ModuleName == dllName)
                    return module.ModuleMemorySize;
            }

            return 0;
        }
        
        public bool IsValid(int address) => (uint)address >= 0x10000 && (uint)address < 0xFFF00000;
        public bool IsValid(long address) => address >= 0x10000 && address < 0x000F000000000000;
    }
}