using System.Reflection.Metadata;
using SmartBoardWebAPI.Data.DTOs;
using SmartBoardWebAPI.Data.Repository;
using SmartBoardWebAPI.Utils;

namespace SmartBoardWebAPI.Tests.Repository;

[TestClass]
public class UserRepositoryTests
{
    private IUserRepository _userRepository;
    private ILogWriter _log;

    [TestMethod]
    public async Task GetUsersAsyncTest()
    {
        _log = new LogWriter();
        _userRepository = new UserRepository(_log);

        var result = await _userRepository.GetUsersAsync();

        Assert.IsTrue(result.Any());
    }

    [TestMethod]
    public async Task GetUsersByIdAsyncTestResturnNothing()
    {
        _log = new LogWriter();
        _userRepository = new UserRepository(_log);

        var result = await _userRepository.GetUserByIdAsync(3);

        Assert.IsNull(result);
    }

    [TestMethod]
    public async Task GetUsersByIdAsyncTest()
    {
        _log = new LogWriter();
        _userRepository = new UserRepository(_log);

        var result = await _userRepository.GetUserByIdAsync(2);

        Assert.IsNotNull(result);
    }

    [TestMethod]
    public async Task CheckCredentialsSucessTest()
    {
        _log = new LogWriter();
        _userRepository = new UserRepository(_log);

        var result = await _userRepository.CheckCredentialsAsync(new UserDTO() { Id = 1 }, "patrickpw");

        Assert.IsNotNull(result);
        Assert.IsTrue(result);
    }

    [TestMethod]
    public async Task CheckCredentialsFailureTest()
    {
        _log = new LogWriter();
        _userRepository = new UserRepository(_log);

        var result = await _userRepository.CheckCredentialsAsync(new UserDTO() { Id = 1 }, "patrickpu");

        Assert.IsNotNull(result);
        Assert.IsFalse(result);
    }
}
