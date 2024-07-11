namespace ATMApp.Exceptions
{
    public class AccountNotFoundException : Exception
    {
        string msg;
        public AccountNotFoundException()
        {
            msg = "Account Not Found";
        }
        public override string Message => msg;
    }
}
