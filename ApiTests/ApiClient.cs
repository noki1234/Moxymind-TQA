using RestSharp;

namespace ApiTests;
using System.Text.Json;

public static class ApiClient
{
    private static AppSettings _actualAppSettings;

    static ApiClient()
    {
        LoadAppSettings();
    }

    private static void LoadAppSettings()
    {
        var projectDir = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
        var jsonText = File.ReadAllTextAsync($"{projectDir}/appsettings.json");
        var config = JsonSerializer.Deserialize<RootConfig>(jsonText.Result);

        _actualAppSettings = config.Applications[config.SelectedApp];
    }

    public static async Task<ApiResponse<T>> ExecuteAsync<T>(RestRequest request)
    {
        var client = new RestClient(_actualAppSettings.BaseUrl);

        request.AddHeader("x-api-key", _actualAppSettings.ApiKey);
        
        var stopwatch = System.Diagnostics.Stopwatch.StartNew();
        var restResponse = await client.ExecuteAsync<T>(request);
        stopwatch.Stop();

        return new ApiResponse<T>(restResponse, stopwatch.ElapsedMilliseconds);
    }

    public static ApiResponse<T> Execute<T>(RestRequest request)
    {
        var client = new RestClient(_actualAppSettings.BaseUrl);

        request.AddHeader("x-api-key", _actualAppSettings.ApiKey);
        var stopwatch = System.Diagnostics.Stopwatch.StartNew();
        var restResponse = client.Execute<T>(request);  
        stopwatch.Stop();

        return new ApiResponse<T>(restResponse, stopwatch.ElapsedMilliseconds);
    }

}