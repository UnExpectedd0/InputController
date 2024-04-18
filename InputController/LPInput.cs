
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
    }


    [StructLayout(LayoutKind.Sequential)]
    public struct KeyboardInput
    {
        public KeyCode wVk;
        public ushort wScan;
        public DWFlags dwFlags;
        public uint time;
        public IntPtr dwExtraInfo;
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct InputUnion
    {
        [FieldOffset(0)] public MouseInput mi;
        [FieldOffset(0)] public KeyboardInput ki;
    }

    public struct LPInput
    {
        public DWType type;
        public InputUnion data;

        public LPInput(DWFlags _mouseFlags, uint _dx = 0, uint _dy = 0, uint _mouseData = 0, uint _time = 0)
        {
            this.type = DWType.INPUT_MOUSE;
            this.data = new InputUnion()
            {
                mi = new MouseInput()
                {
                    dx = _dx,
                    dy = _dy,
                    mouseData = _mouseData,
                    dwFlags = _mouseFlags,
                    time = _time,
                    dwExtraInfo = IntPtr.Zero
                }
            };

        }

        public LPInput(KeyCode _virtualKeyCode, DWFlags _dwFlags = default, ushort _wScan = 0, uint _time = 0)
        {
            this.type = DWType.INPUT_KEYBOARD;
            this.data = new InputUnion()
            {
                ki = new KeyboardInput()
                {
                    wVk = _virtualKeyCode,
                    wScan = _wScan,
                    dwFlags = _dwFlags,
                    time = _time,
                    dwExtraInfo = IntPtr.Zero
                }
            };
        }

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
        KEYEVENTF_EXTENDEDKEY = 0x0001,
        KEYEVENTF_KEYUP = 0x0002,
        KEYEVENTF_UNICODE = 0x0004,
        KEYEVENTF_SCANCODE = 0x0008,

    }

    public enum KeyCode : ushort
    {
        A = 0x41,
        B = 0x42,
        C = 0x43,
        D = 0x44,
        E = 0x45,
        F = 0x46,
        G = 0x47,
        H = 0x48,
        I = 0x49,
        J = 0x4A,
        K = 0x4B,
        L = 0x4C,
        M = 0x4D,
        N = 0x4E,
        O = 0x4F,
        P = 0x50,
        Q = 0x51,
        R = 0x52,
        S = 0x53,
        T = 0x54,
        U = 0x55,
        V = 0x56,
        W = 0x57,
        X = 0x58,
        Y = 0x59,
        Z = 0x5A,
        _0 = 0x30,
        _1 = 0x31,
        _2 = 0x32,
        _3 = 0x33,
        _4 = 0x34,
        _5 = 0x35,
        _6 = 0x36,
        _7 = 0x37,
        _8 = 0x38,
        _9 = 0x39,
        Enter = 0x0D,
        Shift = 0x10,
        Control = 0x11,
        Alt = 0x12,
        Space = 0x20,
        Escape = 0x1B,
        Backspace = 0x08,
        Tab = 0x09,
        F1 = 0x70,
        F2 = 0x71,
        F3 = 0x72,
        F4 = 0x73,
        F5 = 0x74,
        F6 = 0x75,
        F7 = 0x76,
        F8 = 0x77,
        F9 = 0x78,
        F10 = 0x79,
        F11 = 0x7A,
        F12 = 0x7B,

    }

}
