namespace ExceptionTest.Exceptions;

public class InvalidReferenceException : RepositoryException
{
    public InvalidReferenceException(string message, Exception inner) : base(message, inner)
    {
    }
}