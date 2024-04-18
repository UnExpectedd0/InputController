
using System.Runtime.InteropServices;




namespace InputController
{

    /// <summary>
    /// A controller class for operating mouse and keyboard inputs.
    /// </summary>
    public class InputController
    {
        [DllImport("user32.dll", CallingConvention = CallingConvention.Winapi)]
        private static extern uint SendInput(uint cInputs, LPInput[] inputs, int cbSize);

        /// <summary>
        /// Sends a single input to mouse and operates.
        /// </summary>
        /// <param name="_flags"></param>
        /// <returns></returns>
        public static uint SendOneToMouse(DWFlags _flags)
        {
            LPInput input = new LPInput(_flags);
            LPInput[] inputs = { input };
            
            return SendInput(1, inputs, Marshal.SizeOf(typeof(LPInput)));
        }
        /// <summary>
        /// Sends a single input to keyboard and operates.
        /// </summary>
        /// <param name="_virtualKeyCode"></param>
        /// <returns></returns>
        public static uint SendOneToKeyboard(KeyCode _virtualKeyCode)
        {
            LPInput input = new LPInput(_virtualKeyCode);
            LPInput[] inputs = { input };
            
            return SendInput(1, inputs, Marshal.SizeOf(typeof(LPInput)));
        }

        /// <summary>
        /// Sends the given inputs and operates all.
        /// </summary>
        /// <param name="_inputs"></param>
        /// <returns></returns>
        public static uint SendMultiple(params LPInput[] _inputs)
        {
            return SendInput((uint)_inputs.Length, _inputs, Marshal.SizeOf(typeof(LPInput)));
        }
        /// <summary>
        /// Writes the given text by pushing keys on keyboard.
        /// </summary>
        /// <param name="_text"></param>
        public static void Write(string _text)
        {
            List<LPInput> inputs = new List<LPInput>();

            /* 
            the code down there may look suspicius a bit so here is an explanation
            - If the character in _text is uppercase, we send the data bu pressing shift.
            Everything is normal until here

            - If the character in _text is lowercase, we first need to make it uppercase 
            and then send the data because; 
            'a'  =>  0x61  (the value of 0x61 as a virtual key is numpad 1)
            'A'  =>  0x41  (and this one is A/a)
            A/a doesnt matter from now on because it pushes the key, untill shift is not pressed, 
            it is gonna print lowercase.
             */

            for (int i = 0; i < _text.Length; i++)
            {
                if (char.IsUpper(_text[i]))
                {
                    inputs.Add(new LPInput(KeyCode.Shift));
                    inputs.Add(new LPInput((KeyCode)_text[i]));
                    inputs.Add(new LPInput(KeyCode.Shift, DWFlags.KEYEVENTF_KEYUP));
                }
                else
                {
                    inputs.Add(new LPInput((KeyCode)char.ToUpper(_text[i])));
                }
            }


            SendMultiple(inputs.ToArray());
        }

    }
}
