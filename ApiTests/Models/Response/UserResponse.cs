namespace ApiTests.Models.Response;

public class UserResponse
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string First_Name { get; set; }
    public string Last_Name { get; set; }
    public string Avatar { get; set; }
    public string Job { get; set; }
    public string Name { get; set; }
    public DateTime? CreatedAt { get; set; }
}