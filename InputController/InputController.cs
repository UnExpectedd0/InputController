
using System.Runtime.InteropServices;




namespace InputController
{
    public class InputController
    {
        [DllImport("user32.dll", CallingConvention = CallingConvention.Winapi)]
        private static extern uint SendInput(uint cInputs, LPInput[] inputs, int cbSize);

        public static uint SendSingleToMouse(DWFlags _flags)
        {
            LPInput input = new LPInput()
            {
                type = DWType.INPUT_MOUSE,
                data = new InputUnion(_flags)
            };

            LPInput[] inputs = { input };
            
            return SendInput(1, inputs, Marshal.SizeOf(typeof(LPInput)));

        }

    }
}
