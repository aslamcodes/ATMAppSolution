using System.Runtime.Serialization;

namespace ATMApp.Exceptions.Card
{
    [Serializable]
    internal class CardNotFound : Exception
    {
        public CardNotFound()
        {
        }

        public CardNotFound(string? message) : base(message)
        {
        }

        public CardNotFound(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected CardNotFound(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}