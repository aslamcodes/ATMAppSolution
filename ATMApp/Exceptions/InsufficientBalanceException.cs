namespace ATMApp.Exceptions
{
    public class InsufficientBalanceException :Exception
    {
        string msg;
        public InsufficientBalanceException()
        {
            msg = "Balance is insufficient";
        }
        public override string Message => msg;
    }
}
