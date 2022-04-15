using System;

namespace ExceptionTest.Exceptions;

public class DuplicateValueException : RepositoryException
{
    public DuplicateValueException(string message, Exception inner) : base(message, inner)
    {
    }
}