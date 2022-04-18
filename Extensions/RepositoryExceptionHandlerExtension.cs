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

        if (exceptionType == typeof(DbUpdateException))
        {
            return innerExceptionType switch
            {
                Type _ when innerExceptionType == typeof(PostgresException) =>  PostgresExceptionHandle(exception?.InnerException as PostgresException),
                _=> new UnexpectedRepositoryException(exception?.InnerException)
            };
        }

        return new UnexpectedRepositoryException(exception);
    }

    public static RepositoryException PostgresExceptionHandle(PostgresException psqlException)
    {
        return psqlException.SqlState switch
        {
            PostgresErrorCodes.UniqueViolation => new DuplicateValueException("duplicate value exception.", psqlException),
            PostgresErrorCodes.ForeignKeyViolation => new InvalidReferenceException("x reference invalid.", psqlException),
            PostgresErrorCodes.NotNullViolation => new NotNullException("not null message", psqlException),
            PostgresErrorCodes.NumericValueOutOfRange or PostgresErrorCodes.StringDataRightTruncation => new OutOfRangeException("out of range string or numeric value.", psqlException),
            _ => new UnexpectedRepositoryException(psqlException)
        };
    }
}