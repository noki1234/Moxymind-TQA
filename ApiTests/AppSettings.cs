namespace ApiTests;


public class RootConfig
{
    public Dictionary<string, AppSettings> Applications { get; set; }
    public string SelectedApp { get; set; }
}

public class AppSettings
{
    public string BaseUrl { get; set; }
    public string ApiKey { get; set; }
}