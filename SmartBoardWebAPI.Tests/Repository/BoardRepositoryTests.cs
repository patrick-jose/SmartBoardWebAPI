using System.Reflection.Metadata;
using SmartBoardWebAPI.Data.Repository;
using SmartBoardWebAPI.Utils;

namespace SmartBoardWebAPI.Tests.Repository;

[TestClass]
public class BoardRepositoryTests
{
    private IBoardRepository _boardRepository;
    private ISectionRepository _sectionRepository;
    private ITaskRepository _taskRepository;
    private ICommentRepository _commentRepository;
    private IStatusHistoryRepository _statusHistoryRepository;
    private ILogWriter _log;

    [TestMethod]
    public async Task GetBoardsAsyncTest()
    {
        _log = new LogWriter();
        _sectionRepository = new SectionRepository(_log);
        _taskRepository = new TaskRepository(_log);
        _commentRepository = new CommentRepository(_log);
        _statusHistoryRepository = new StatusHistoryRepository(_log);
        _boardRepository = new BoardRepository(_log, _sectionRepository, _taskRepository, _commentRepository, _statusHistoryRepository);

        var result = await _boardRepository.GetBoardsAsync();

        Assert.IsTrue(result.Any());
        Assert.IsTrue(result.First().Sections.Any());
        Assert.IsTrue(result.First().Sections.First().Tasks.Any());
        Assert.IsTrue(result.First().Sections.First().Tasks.First().Comments.Any());
        Assert.IsTrue(result.First().Sections.ToList()[2].Tasks.First().StatusHistory.Any());
    }
}
