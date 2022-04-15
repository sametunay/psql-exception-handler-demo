using System;

namespace ExceptionTest.Exceptions;

public class NotFoundException : RepositoryException
{
    public NotFoundException(string message, Exception inner) : base(message, inner)
    {
    }
}