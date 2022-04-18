namespace ExceptionTest.Exceptions;

public class NotNullException : RepositoryException
{
    public NotNullException(string message, Exception inner) : base(message, inner)
    {
    }
}