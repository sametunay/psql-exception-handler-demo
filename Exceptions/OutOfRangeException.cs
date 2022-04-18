namespace ExceptionTest.Exceptions;

public class OutOfRangeException : RepositoryException
{
    public OutOfRangeException(string message, Exception inner) : base(message, inner)
    {
    }
}