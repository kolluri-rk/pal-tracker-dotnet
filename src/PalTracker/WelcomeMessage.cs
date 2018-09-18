namespace PalTracker
{
    public class WelcomeMessage
    {
        public string Message { get; private set; }

        public WelcomeMessage(string message)
        {
            Message = message;
        }
    }
}