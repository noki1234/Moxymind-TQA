namespace ApiTests.Models.Request;

public class UserRequest
{
    public string Name { get; set; }
    public string Job { get; set; }

    public UserRequest(string name, string job)
    {
        Name = name;
        Job = job;
    }
}