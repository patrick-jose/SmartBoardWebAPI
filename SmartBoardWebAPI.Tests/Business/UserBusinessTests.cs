using System.Reflection.Metadata;
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

    [TestMethod]
    public async Task GetBoardsAsyncTest()
    {
        _log = new LogWriter();
        _userRepository = new UserRepository(_log);
        _userBusiness = new UserBusiness(_log, _userRepository);

        var result = await _userBusiness.GetUsersAsync();

        Assert.IsTrue(result.Any());
    }

    [TestMethod]
    public async Task CheckCredentialsSucessTest()
    {
        _log = new LogWriter();
        _userRepository = new UserRepository(_log);
        _userBusiness = new UserBusiness(_log, _userRepository);

        var result = await _userBusiness.CheckCredentialsAsync(new UserDTO() { Id = 1 }, "patrickpw");

        Assert.IsNotNull(result);
        Assert.IsTrue(result);
    }

    [TestMethod]
    public async Task CheckCredentialsFailureTest()
    {
        _log = new LogWriter();
        _userRepository = new UserRepository(_log);
        _userBusiness = new UserBusiness(_log, _userRepository);

        var result = await _userBusiness.CheckCredentialsAsync(new UserDTO() { Id = 1 }, "patrickpu");

        Assert.IsNotNull(result);
        Assert.IsFalse(result);
    }
}
