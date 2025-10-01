using ApiTests.Models.Request;
using ApiTests.Models.Response;
using RestSharp;

namespace ApiTests.Actions;

public class UsersActions: ActionBase
{
    public UsersActions() : base("users")
    {}
    
    public async Task<ApiResponse<UserListResponse>> GetUsersList(int page)
    {
        var request = CreateRequest("", Method.Get);
        request.AddParameter("page", page);
        var response = await ApiClient.ExecuteAsync<UserListResponse>(request);
        VerifyResponseIsSuccessful(response.RestResponse);
        return response;
    }

    public async Task<ApiResponse<UserResponse>> CreateUser(UserRequest user)
    {
        var request = CreateRequest("", Method.Post);
        request.AddJsonBody(user);
        var response = await ApiClient.ExecuteAsync<UserResponse>(request);
        VerifyResponseIsSuccessful(response.RestResponse);
        return response;    
    }
} 