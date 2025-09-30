using ApiTests.Models.Request;
using ApiTests.Models.Response;

namespace ApiTests.Contexts;

public class UsersContext
{
    public List<UserListResponse> ListUserListResponse { get; set; } = new List<UserListResponse>();
    public UserRequest UserRequest { get; set; }
    public UserListResponse UserListResponse { get; set; }
    public UserResponse UserResponse { get; set; }
}