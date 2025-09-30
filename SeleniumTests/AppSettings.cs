namespace SeleniumTests;

public class RootConfig
{
    public Dictionary<string, AppSettings> Applications { get; set; }
    public string SelectedApp { get; set; }
    public DriverSettings DriverSettings { get; set; }
}
public class AppSettings
{
    public string BaseUrl { get; set; }
    public string ApiKey { get; set; }
}

public class DriverSettings
{
    public string browserType { get; set; }
    public bool maximized { get; set; }
    public bool headless { get; set; }
    public int width { get; set; }
    public int height { get; set; }
    public int turnOnWait { get; set; }
    public int pageLoadTimeout { get; set; }
    public int browserStartupWait {get; set;}
    public int browserEndupWait {get; set;}
    public int elementInteractionDelay { get; set; }
    public bool enableSlowMode { get; set; }
}