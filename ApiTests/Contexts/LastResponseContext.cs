using RestSharp;

namespace ApiTests.Contexts;

public class LastResponseContext
{
    public RestResponse LastResponse { get; set; }
    public long LastResponseTime { get; set; }
}