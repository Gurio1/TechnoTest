using System.Net;

namespace TechnoTest.Domain.Exceptions;

public class BadRequestException : StatusCodeException
{
    private new const HttpStatusCode StatusCode = HttpStatusCode.BadRequest;
    private new const string Title = "One or more validation errors occured";

    public BadRequestException(string message) : base(StatusCode, message, Title)
    {
    }
}