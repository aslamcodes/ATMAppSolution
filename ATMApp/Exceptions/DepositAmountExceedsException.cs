namespace ATMApp.Exceptions
{
    public class DepositAmountExceedsException :Exception
    {
        string msg;
        public DepositAmountExceedsException()
        {
            msg = "Deposit amount exceeds limit";
        }
        public override string Message => msg;
    }
}
