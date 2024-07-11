namespace ATMApp.Exceptions
{
    public class CardAlreadyExistException :Exception
    {
        string msg;
        public CardAlreadyExistException()
        {
            msg = "Card Already Exist";
        }
        public override string Message => msg;
    }
}
