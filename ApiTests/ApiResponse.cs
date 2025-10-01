using RestSharp;

namespace ApiTests;

public interface IApiResponse<T>
{
    public RestResponse<T> RestResponse { get; set; }
    public long ResponseTime { get; set; }
}

public class ApiResponse<T>: IApiResponse<T>
{
    public ApiResponse(RestResponse<T> restResponse, long elapsedMs)
    {
        RestResponse = restResponse;
        ResponseTime = elapsedMs;
    }
    
    public RestResponse<T> RestResponse { get; set; }
    public long ResponseTime { get; set; }
}