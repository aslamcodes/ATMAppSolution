namespace ATMApp.Exceptions
{
    public class WithdrawalAmountExceedsException : Exception
    {
        string msg;
        public WithdrawalAmountExceedsException()
        {
            msg = "Withdrawal amount exceeds limit";
        }
        public override string Message => msg;
    }
}
