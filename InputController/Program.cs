


namespace InputController
{

    internal sealed class Program
    {
        private static void Main(string[] args)
        {
            InputController.SendSingleToMouse(DWFlags.MOUSEEVENTF_LEFTDOWN);
            InputController.SendSingleToMouse(DWFlags.MOUSEEVENTF_LEFTUP);
            

        }
    }

}