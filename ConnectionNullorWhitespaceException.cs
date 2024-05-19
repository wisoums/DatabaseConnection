namespace DatabaseConnection;

public class ConnectionNullorWhitespaceException: Exception
{
    public ConnectionNullorWhitespaceException() { }

    public ConnectionNullorWhitespaceException(string message)
        : base(message) { }
    
}