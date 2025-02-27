public class UIElementHandlerException : Exception
{
    public UIElementHandlerException(string message) : base(message) { }
    public UIElementHandlerException(string message, Exception innerException) : base(message, innerException) { }

}
public class UIDriverHandlerException : Exception
{
    public UIDriverHandlerException(string message) : base(message) { }
    public UIDriverHandlerException(string message, Exception innerException) : base(message, innerException) { }
}