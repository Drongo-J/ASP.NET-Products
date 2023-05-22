namespace Products.Models
{
    public class SuccessMessage
    {
        public string Message { get; set; }

        public SuccessMessage(string message)
        {
            Message = message;
        }
    }
}
