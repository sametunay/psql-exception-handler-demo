using ExceptionTest.Exceptions;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace ExceptionTest.Extensions;

public static class RepositoryExceptionHandlerExtension
{
    public static RepositoryException Handle(this Exception exception)
    {
        var exceptionType = exception.GetType();
        var innerExceptionType = exception.InnerException?.GetType();

        if (exceptionType.Equals(typeof(DbUpdateException)) && innerExceptionType.Equals(typeof(PostgresException)))
        {
            var psqlException = exception.InnerException as PostgresException;
            
            return psqlException.SqlState switch
            {
                PostgresErrorCodes.UniqueViolation => new DuplicateValueException("duplicate value exception.", psqlException),
                PostgresErrorCodes.ForeignKeyViolation => new NotFoundException("x not found.", psqlException),
                _ => new UnexpectedRepositoryException(psqlException)
            };
        }

        return new UnexpectedRepositoryException(exception);
    }
}