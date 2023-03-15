using System.Reflection.Metadata;
using SmartBoardWebAPI.Data.Repository;
using SmartBoardWebAPI.Utils;

namespace SmartBoardWebAPI.Tests.Repository;

[TestClass]
public class CommentRepositoryTests
{
    private ICommentRepository _commentRepository;
    private ILogWriter _log;

    [TestMethod]
    public async Task GetCommentsAsyncTest()
    {
        _log = new LogWriter();
        _commentRepository = new CommentRepository(_log);

        var result = await _commentRepository.GetCommentsAsync();

        Assert.IsTrue(result.Any());
    }

    [TestMethod]
    public async Task GetCommentsBySectionIdAsyncTest()
    {
        _log = new LogWriter();
        _commentRepository = new CommentRepository(_log);

        var result = await _commentRepository.GetCommentsByTaskIdAsync(2);

        Assert.IsTrue(result.Any());
    }
}
