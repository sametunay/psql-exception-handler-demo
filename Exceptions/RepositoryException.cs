namespace ExceptionTest.Exceptions;

public abstract class RepositoryException : Exception
{
    public RepositoryException(string message, Exception inner) : base(message, inner)
    {
        
    }

    public RepositoryException()
    {
    }
}