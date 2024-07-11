namespace ATMApp.Models
{
    public class ErrorModel
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public ErrorModel(string message, int statusCode)
        {
            StatusCode = statusCode;
            Message = message;
        }

    }
}
