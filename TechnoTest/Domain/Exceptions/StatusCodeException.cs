using System.Net;

namespace TechnoTest.Domain.Exceptions;

public class StatusCodeException : Exception
{
    public HttpStatusCode StatusCode { get; }

    public StatusCodeException(HttpStatusCode statusCode, string message) : base(message)
    {
        StatusCode = statusCode;
    }
}