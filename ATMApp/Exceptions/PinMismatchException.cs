namespace ATMApp.Exceptions
{
    public class PinMismatchException :Exception
    {
        string msg;
        public PinMismatchException()
        {
            msg = "Pin Mis Matching";
        }
        public override string Message => msg;
    }
}
