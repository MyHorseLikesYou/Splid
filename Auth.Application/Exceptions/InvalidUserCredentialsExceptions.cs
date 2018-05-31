using FluentValidation;
using FluentValidation.Results;
using System.Collections.Generic;

namespace Auth.Application.Exceptions
{
    public class InvalidUserCredentialsExceptions : ValidationException
    {
        public InvalidUserCredentialsExceptions(IEnumerable<ValidationFailure> errors)
            : base(errors)
        { }
    }
}
