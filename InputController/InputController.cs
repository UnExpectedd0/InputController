
using System.Runtime.InteropServices;




namespace InputController
{
    public class InputController
    {
        [DllImport("user32.dll", CallingConvention = CallingConvention.Winapi)]
        private static extern uint SendInput(uint cInputs, LPInput[] inputs, int cbSize);

        public static uint SendOneToMouse(DWFlags _flags)
        {
            LPInput input = new LPInput()
            {
                type = DWType.INPUT_MOUSE,
                data = new InputUnion(_flags)
            };

            LPInput[] inputs = { input };
            
            return SendInput(1, inputs, Marshal.SizeOf(typeof(LPInput)));
        }

        public static uint SendOneToKeyboard(KeyCode _virtualKeyCode)
        {
            LPInput input = new LPInput()
            {
                type = DWType.INPUT_KEYBOARD,
                data = new InputUnion(_virtualKeyCode)
            };

            LPInput[] inputs = { input };
            
            return SendInput(1, inputs, Marshal.SizeOf(typeof(LPInput)));
        }

        public static uint SendMultiple(params LPInput[] _inputs)
        {
            return SendInput((uint)_inputs.Length, _inputs, Marshal.SizeOf(typeof(LPInput)));
        }
        

    }
}
