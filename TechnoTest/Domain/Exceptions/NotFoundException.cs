using System.Net;

namespace TechnoTest.Domain.Exceptions;

public class NotFoundException : StatusCodeException
{
    private new const HttpStatusCode StatusCode = HttpStatusCode.NotFound;
    private new const string Title = "The system can not retrieve the searched object";

    public NotFoundException(string message) : base(StatusCode, message, Title)
    {
    }
}