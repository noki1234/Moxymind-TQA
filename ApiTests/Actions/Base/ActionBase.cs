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
        Assert.True(response.IsSuccessful, response.ErrorException.Message);
    }
}