using System;

namespace ExceptionTest.Exceptions;

public class UnexpectedRepositoryException : RepositoryException
{
    public UnexpectedRepositoryException(string message, Exception inner) : base(message, inner)
    {
    }
    public UnexpectedRepositoryException(Exception inner) : base("An unexpected repository error has occurred.", inner)
    {
    }
}