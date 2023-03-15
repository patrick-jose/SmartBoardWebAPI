using System.Reflection.Metadata;
using SmartBoardWebAPI.Business;
using SmartBoardWebAPI.Data.Repository;
using SmartBoardWebAPI.Utils;

namespace SmartBoardWebAPI.Tests.Business;

[TestClass]
public class CommentBusinessTests
{
    private ILogWriter _log;
    private ICommentBusiness _commentBusiness;
    private ICommentRepository _commentRepository;
    private IUserRepository _userRepository;

    [TestMethod]
    public async Task GetCommentsByTaskIdAsyncTest()
    {
        _log = new LogWriter();
        _commentRepository = new CommentRepository(_log);
        _userRepository = new UserRepository(_log);
        _commentBusiness = new CommentBusiness(_log, _commentRepository, _userRepository);

        var result = await _commentBusiness.GetCommentsByTaskIdAsync(5);

        Assert.IsTrue(result.Any());
    }
}
