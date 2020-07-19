namespace RequestLoggerMiddleware
{
    public class RequestLoggerOptions
    {
        internal bool ShouldUseColor { get; private set; }

        public void EnableColor()
        {
            ShouldUseColor = true;
        }
    }
}