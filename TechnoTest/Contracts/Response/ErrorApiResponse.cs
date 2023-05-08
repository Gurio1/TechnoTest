using System.Collections.Generic;

namespace TechnoTest.Contracts.Response;

public class ErrorApiResponse
{
    public int Status { get; set; }
    public string TraceId { get; set; }
    public List<string> Errors { get; init; } = new();
}