using TechnoTest.Domain.Exceptions;

namespace TechnoTest.Domain.Models;

public sealed class Result<TValue> where TValue : class
{
    private readonly TValue _value;
    private readonly StatusCodeException _exception;

    public bool IsSuccessful { get; } = true;

    public Result(TValue value)
    {
        _value = value;
    }

    public Result(StatusCodeException exception)
    {
        _exception = exception;
        IsSuccessful = false;
    }

    public TValue GetValue()
    {
        if (IsSuccessful)
        {
            return _value;
        }

        throw new InvalidOperationException("Cannot retrieve value when the result is not successful.");
    }

    public StatusCodeException GetException()
    {
        if (!IsSuccessful)
        {
            return _exception;
        }

        throw new InvalidOperationException("There is no exception associated with a successful result.");
    }
}