
using System.Runtime.InteropServices;

namespace InputController
{
    [StructLayout(LayoutKind.Sequential)]
    public struct MouseInput
    {
        public uint dx;
        public uint dy;
        public uint mouseData;
        public DWFlags dwFlags;
        public uint time;
        public IntPtr dwExtraInfo;
        
        public MouseInput
            (DWFlags _flags, uint _dx = 0, uint _dy = 0, uint _mouseData = 0, uint _time = 0)
        {
            dx = _dx;
            dy = _dy;
            mouseData = _mouseData;
            dwFlags = _flags;
            time = 0;
            dwExtraInfo = IntPtr.Zero;
        }
    }


    [StructLayout(LayoutKind.Sequential)]
    public struct KeyboardInput
    {
        public ushort wVk;
        public ushort wScan;
        public DWFlags dwFlags;
        public uint time;
        public IntPtr dwExtraInfo;

        public KeyboardInput(ushort _wVK, DWFlags _dwFlags, ushort _wScan = 0, uint _time = 0)
        {
            wVk = _wVK;
            wScan = _wScan;
            dwFlags = _dwFlags;
            time = 0;
            dwExtraInfo = IntPtr.Zero;
        }
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct InputUnion
    {
        [FieldOffset(0)] public MouseInput mi;
        [FieldOffset(0)] public KeyboardInput ki;
        
        public InputUnion(DWFlags _flags, uint _dx = 0, uint _dy = 0, uint _mouseData = 0, uint _time = 0)
        {
            ki = default;
            mi = new MouseInput(_flags, _dx: _dx, _dy: _dy, _mouseData: _mouseData, _time: _time);
        }
    }

    public struct LPInput
    {
        public DWType type;
        public InputUnion data;
    }

    public enum DWType : uint
    {
        INPUT_MOUSE = 0,
        INPUT_KEYBOARD = 1,
        INPUT_HARDWARE = 2,
    }

    public enum DWFlags : uint
    {
        MOUSEEVENTF_MOVE = 0x0001,
        MOUSEEVENTF_LEFTDOWN = 0x0002, 
        MOUSEEVENTF_LEFTUP = 0x0004,
        MOUSEEVENTF_RIGHTDOWN = 0x0008,
        MOUSEEVENTF_RIGHTUP = 0x0010,
        MOUSEEVENTF_MIDDLEDOWN = 0x0020,
        MOUSEEVENTF_MIDDLEUP = 0x0040,
        MOUSEEVENTF_XDOWN = 0x0080,
        MOUSEEVENTF_XUP = 0x0100,
        MOUSEEVENTF_WHEEL = 0x0800,
        MOUSEEVENTF_HWHEEL = 0x1000,
        MOUSEEVENTF_MOVE_NOCOALESCE = 0x2000,
        MOUSEEVENTF_VIRTUALDESK = 0x4000,
        MOUSEEVENTF_ABSOLUTE = 0x8000,
    }

}
