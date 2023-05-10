using System.Collections.Generic;

namespace TechnoTest.Contracts.Response;

public class ErrorApiResponse
{
    public int Status { get; }
    public string Title { get; }
    public string Error { get; }

    public ErrorApiResponse(int status, string title, string error)
    {
        Status = status;
        Title = title;
        Error = error;
    }
}