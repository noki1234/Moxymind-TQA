using System.Net;
using RestSharp;

namespace ApiTests.Actions;

public abstract class ActionBase
{
    private string _pathUrl;

    protected ActionBase(string pathUrl)
    {
        _pathUrl = pathUrl; 
    }
    
    protected RestRequest CreateRequest(string resource, Method method, DataFormat requestFormat = DataFormat.Json)
    {
        var request = new RestRequest
        {
            Resource = resource.Any()?  $"{_pathUrl}/{resource}" : _pathUrl,
            RequestFormat = requestFormat,
            Method = method
        };
        return request;
    }
    
    protected void VerifyResponseIsSuccessful(RestResponse response)
    {
        var errorMessage = response.ErrorException?.Message ?? 
                           response.ErrorMessage ?? 
                           $"HTTP {(int)response.StatusCode} {response.StatusCode}: {response.Content}";

        Assert.True(response.IsSuccessful, errorMessage);
    }
}