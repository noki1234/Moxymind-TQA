namespace ApiTests.Models.Response;

public class UserListResponse
{
    public int Page { get; set; }
    public int Per_Page { get; set; }
    public int Total { get; set; }
    public int Total_Pages { get; set; }
    public List<UserResponse> Data { get; set; }
    public Support Support { get; set; }
}

public class Support
{
    public string Url { get; set; }
    public string Text { get; set; }
}