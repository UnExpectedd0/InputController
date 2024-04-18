


namespace InputController
{

    internal sealed class Program
    {
        private static void Main(string[] args)
        {
            InputController.SendOneToMouse(DWFlags.MOUSEEVENTF_LEFTDOWN);
            InputController.SendOneToMouse(DWFlags.MOUSEEVENTF_LEFTUP);

            InputController.SendOneToKeyboard(KeyCode.B);


            Console.ReadLine();
        }
    }

}