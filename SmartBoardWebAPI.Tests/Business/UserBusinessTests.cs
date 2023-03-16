using System.Reflection.Metadata;
using PublishMessages;
using SmartBoardWebAPI.Business;
using SmartBoardWebAPI.Data.DTOs;
using SmartBoardWebAPI.Data.Repository;
using SmartBoardWebAPI.Utils;

namespace SmartBoardWebAPI.Tests.Business;

[TestClass]
public class UserBusinessTests
{
    private ILogWriter _log;
    private IUserBusiness _userBusiness;
    private IUserRepository _userRepository;
    private ISendService _sendService;

    public void StartServices()
    {
        _log = new LogWriter();
        _sendService = new SendService(_log);
        _userRepository = new UserRepository(_log);
        _userBusiness = new UserBusiness(_log, _userRepository, _sendService);
    }

    [TestMethod]
    public async Task GetBoardsAsyncTest()
    {
        StartServices();

        var result = await _userBusiness.GetUsersAsync();

        Assert.IsTrue(result.Any());
    }

    [TestMethod]
    public async Task CheckCredentialsSucessTest()
    {
        StartServices();

        var result = await _userBusiness.CheckCredentialsAsync(new UserDTO() { Id = 1 }, "patrickpw");

        Assert.IsNotNull(result);
        Assert.IsTrue(result);
    }

    [TestMethod]
    public async Task CheckCredentialsFailureTest()
    {
        StartServices();

        var result = await _userBusiness.CheckCredentialsAsync(new UserDTO() { Id = 1 }, "patrickpu");

        Assert.IsNotNull(result);
        Assert.IsFalse(result);
    }

    [TestMethod]
    public async Task SendInsertUserTests()
    {
        StartServices();

        var dto = new UserDTO()
        {
            Name = "Teste integração WebAPI",
            Password = "testepw"
        };

        await _userBusiness.PostUserAsync(dto);
    }

    [TestMethod]
    public async Task SendUpdateUserTests()
    {
        StartServices();

        var dto = new UserDTO()
        {
            Id = 3,
            Name = "Teste integração update WebAPI",
            Password = "testepw"
        };

        await _userBusiness.PutUserAsync(dto);
    }
}
