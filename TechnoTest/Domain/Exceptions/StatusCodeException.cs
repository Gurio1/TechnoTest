using System.Net;

namespace TechnoTest.Domain.Exceptions;

public abstract class StatusCodeException : Exception
{
    public HttpStatusCode StatusCode { get; }
    public string Title { get; }

    protected StatusCodeException(HttpStatusCode statusCode, string message, string title) : base(message)
    {
        StatusCode = statusCode;
        Title = title;
    }
}