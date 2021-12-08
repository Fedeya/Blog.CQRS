using FluentValidation.Results;

namespace Blog.Application.Common.Exceptions;

public class ValidationException : Exception
{
    public ValidationException() : base("One or more validation failures have occurred.")
    {
        Errors = new Dictionary<string, string[]>();
    }

    public ValidationException(IEnumerable<ValidationFailure> failures)
        : this()
    {
        Errors = failures
            .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
            .ToDictionary(failuresGroup => failuresGroup.Key, failuresGroup => failuresGroup.ToArray());
    }

    public IDictionary<string, string[]> Errors { get; }
}