using ApiTests.Actions;
using ApiTests.Contexts;
using ApiTests.Models.Request;
using ApiTests.Models.Response;

namespace ApiTests.Executors;

public class UsersExecutor
{
  private readonly UsersActions _usersActions;
  private readonly UsersContext _usersContext;
  private readonly LastResponseContext _lastResponseContext;

  public UsersExecutor(UsersContext usersContext, LastResponseContext lastResponseContext) 
  {
    _usersActions = new UsersActions();
    _usersContext = usersContext;
    _lastResponseContext = lastResponseContext;
  }

  public async Task CreateUser(UserRequest userRequest)
  {
    var response = await _usersActions.CreateUser(userRequest);
    _lastResponseContext.LastResponse = response.RestResponse;
    _lastResponseContext.LastResponseTime = response.ResponseTime;
    
    if (response.RestResponse.IsSuccessful && response.RestResponse.Data != null)
    {
      _usersContext.UserResponse = response.RestResponse.Data;
    }
  }
  
  public async Task GetUsersList(int page)
  {
    var response = await _usersActions.GetUsersList(page);
    _lastResponseContext.LastResponse = response.RestResponse;
    _lastResponseContext.LastResponseTime = response.ResponseTime;
    
    if (response.RestResponse.IsSuccessful)
    {
      _usersContext.ListUserListResponse.Add(response.RestResponse.Data); 
      _usersContext.UserListResponse = response.RestResponse.Data;
    }
  }
    
    
    
}