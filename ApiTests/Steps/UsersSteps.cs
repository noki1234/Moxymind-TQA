using ApiTests.Contexts;
using ApiTests.Executors;
using ApiTests.Models.Request;
using Reqnroll;

namespace ApiTests.Steps;

[Binding]
public class UsersSteps
{
    private readonly UsersExecutor _usersExecutor;
    private readonly UsersContext _usersContext;

    public UsersSteps(UsersContext usersContext, LastResponseContext lastResponseContext)
    {
        _usersContext =  usersContext;
        _usersExecutor = new UsersExecutor(usersContext, lastResponseContext);
    }

    [When(@"I create user with values: name-'(.*)' job-'(.*)'")]
    public async Task WhenICreateUserWithValues(string name, string job)
    {
        var request = new UserRequest(name, job);
        await _usersExecutor.CreateUser(request);
    }

    [When(@"I retrieve users from page-'(.*)'")]
    public async Task RetrieveUserList(int page)
    {
       await _usersExecutor.GetUsersList(page);
    }

    [Then(@"I see users list values: page-'(.*)' perPage-'(.*)' total-'(.*)' totalPages-'(.*)'")]
    public void ThenISeeUsersListValues(int page, int perPage, int total, int totalPages)
    {
        Assert.That(_usersContext.UserListResponse.Page, Is.EqualTo(page));
        Assert.That(_usersContext.UserListResponse.Per_Page, Is.EqualTo(perPage));
        Assert.That(_usersContext.UserListResponse.Total, Is.EqualTo(total));
        Assert.That(_usersContext.UserListResponse.Total_Pages, Is.EqualTo(totalPages));
    }

    [Then(@"I see user in list on position-'(.*)' has values: id-'(.*)' email-'(.*)' firstname-'(.*)' lastname-'(.*)' avatar-'(.*)'")]
    public void TheISeeUserInListValues(int position, int id, string email, string firstname, string lastname, string avatar)
    {
        var user = _usersContext.UserListResponse.Data[position - 1];
        Assert.That(user, Is.Not.Null);
        Assert.That(user.Id, Is.EqualTo(id));
        Assert.That(user.Email, Is.EqualTo(email));
        Assert.That(user.First_Name, Is.EqualTo(firstname));
        Assert.That(user.Last_Name, Is.EqualTo(lastname));
        Assert.That(user.Avatar, Is.EqualTo(avatar));
    }

    [Then(@"I see created user values: name-'(.*)' job-'(.*)' createdAt-'(.*)'")]
    public void ThenISeeCreatedUserValues(string name, string job, DateTime createdAt)
    {
        Assert.That(_usersContext.UserResponse.Id, Is.Not.EqualTo(0).And.Not.Null);
        Assert.That(_usersContext.UserResponse.Name, Is.EqualTo(name));
        Assert.That(_usersContext.UserResponse.Job, Is.EqualTo(job));
        Assert.That(_usersContext.UserResponse.CreatedAt?.ToString("yyyy-MM-dd HH:mm"), Is.EqualTo(createdAt.ToString("yyyy-MM-dd HH:mm")));
    }
    
    [Then(@"I see user list contains usersCount-'(.*)' per page")]
    public void ThenISeeUserListCountUsersPerPage(int usersCount)
    {
        Assert.That(_usersContext.UserListResponse.Per_Page, Is.EqualTo(usersCount));
        Assert.That(_usersContext.UserListResponse.Data.Count, Is.EqualTo(usersCount));
    }
    
    [Then(@"I see count of all received users match with total count")]
    public void ThenIseeAllUsersCountMatchWithTotalCount()
    {
        var dataTotalCount = _usersContext.ListUserListResponse.Sum(x => x.Data.Count);
        Assert.That(_usersContext.UserListResponse.Total, Is.EqualTo(dataTotalCount));
    }
}
    
