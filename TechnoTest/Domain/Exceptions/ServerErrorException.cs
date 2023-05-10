using System.Net;

namespace TechnoTest.Domain.Exceptions;

public class ServerErrorException : StatusCodeException
{
    private new const HttpStatusCode StatusCode = HttpStatusCode.InternalServerError;
    private new const string Title = "Server error";

    public ServerErrorException(string message) : base(StatusCode, message, Title)
    {
    }
}