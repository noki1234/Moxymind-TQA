using System.Net;
using ApiTests.Contexts;
using Newtonsoft.Json.Linq;
using Reqnroll;

namespace ApiTests.Steps;

[Binding]
public class CommonSteps
{
    private readonly LastResponseContext _lastResponseContext;
    
    public CommonSteps(LastResponseContext lastResponseContext)
    {
        _lastResponseContext = lastResponseContext;
    }

    [Then(@"I see response value-'(.*)' is dataType-'(.*)'")]
    public void ThenISeeResponseValueIsType(string value, string dataType)
    {
        var responseBody = _lastResponseContext.LastResponse.Content;
        JObject json = JObject.Parse(responseBody);
        var token = json.SelectToken(value);
        Assert.NotNull(token);

        switch (dataType.ToLower())
        {
            case "string":
                Assert.That(token.Type, Is.EqualTo(JTokenType.String));
                break;
            case "int":
            case "integer":
                Assert.That(token.Type, Is.EqualTo(JTokenType.Integer));
                break;
            case "array":
                Assert.That(token.Type, Is.EqualTo(JTokenType.Array));
                break;
            case "object":
                Assert.That(token.Type, Is.EqualTo(JTokenType.Object));
                break;
            case "boolean":
                Assert.That(token.Type, Is.EqualTo(JTokenType.Boolean));
                break;
            case "date":
                Assert.That(token.Type, Is.EqualTo(JTokenType.Date));
                break;
            default:
                Assert.Fail($"Unsupported type: {dataType}");
                break;
        }
    }
    
    [Then(@"I see last response status code is '(.*)'")]
    public void ThenISeeLastResponseStatusCodeIs(HttpStatusCode statusCode)
    {
        Assert.That(_lastResponseContext.LastResponse.StatusCode, Is.EqualTo(statusCode));
    }
    
    [Then(@"I see last response time is under '(.*)'")]
    public void ThenISeeLastResponseTimeIs(long milliseconds)
    {
        Assert.That(_lastResponseContext.LastResponseTime, Is.LessThanOrEqualTo(milliseconds));
    }
    
    
}