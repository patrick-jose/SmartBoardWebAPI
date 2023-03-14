using System.Reflection.Metadata;
using SmartBoardWebAPI.Data.Repository;
using SmartBoardWebAPI.Utils;

namespace SmartBoardWebAPI.Tests;

[TestClass]
public class CommentTests
{
    private ICommentRepository _taskRepository;
    private ILogWriter _log;

    [TestMethod]
    public async Task GetCommentsAsyncTest()
    {
        _log = new LogWriter();
        _taskRepository = new CommentRepository(_log);

        var result = await _taskRepository.GetCommentsAsync();

        Assert.IsTrue(result.Any());
    }

    [TestMethod]
    public async Task GetCommentsBySectionIdAsyncTest()
    {
        _log = new LogWriter();
        _taskRepository = new CommentRepository(_log);

        var result = await _taskRepository.GetCommentsByTaskIdAsync(2);

        Assert.IsTrue(result.Any());
    }
}
