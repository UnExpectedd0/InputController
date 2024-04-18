


namespace InputController
{

    internal sealed class Program
    {
        private static void Main(string[] args)
        {
            InputController.SendOneToMouse(DWFlags.MOUSEEVENTF_LEFTDOWN);
            InputController.SendOneToMouse(DWFlags.MOUSEEVENTF_LEFTUP);

            InputController.SendOneToKeyboard(KeyCode.A);

            LPInput[] inputs =
            {
                new LPInput(KeyCode.B),
                new LPInput(KeyCode.C),
                new LPInput(DWFlags.MOUSEEVENTF_LEFTDOWN),
                new LPInput(DWFlags.MOUSEEVENTF_LEFTUP),
                
            };

            InputController.SendMultiple(inputs);

            Console.ReadLine();
        }
    }

}