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
    public async Task GetBoardsFilledAsyncTest()
    {
        _log = new LogWriter();
        _commentRepository = new CommentRepository(_log);
        _statusHistoryRepository = new StatusHistoryRepository(_log);
        _taskRepository = new TaskRepository(_log, _commentRepository, _statusHistoryRepository);
        _sectionRepository = new SectionRepository(_log, _taskRepository);
        _boardRepository = new BoardRepository(_log, _sectionRepository);

        var result = await _boardRepository.GetBoardsAsync(true);

        Assert.IsTrue(result.Any());
        Assert.IsTrue(result.First().Sections.Any());
    }

    [TestMethod]
    public async Task GetBoardsNotFilledAsyncTest()
    {
        _log = new LogWriter();
        _commentRepository = new CommentRepository(_log);
        _statusHistoryRepository = new StatusHistoryRepository(_log);
        _taskRepository = new TaskRepository(_log, _commentRepository, _statusHistoryRepository);
        _sectionRepository = new SectionRepository(_log, _taskRepository);
        _boardRepository = new BoardRepository(_log, _sectionRepository);

        var result = await _boardRepository.GetBoardsAsync(false);

        Assert.IsTrue(result.Any());
        Assert.IsNull(result.First().Sections);
    }

    [TestMethod]
    public async Task GetActiveBoardsFilledAsyncTest()
    {
        _log = new LogWriter();
        _commentRepository = new CommentRepository(_log);
        _statusHistoryRepository = new StatusHistoryRepository(_log);
        _taskRepository = new TaskRepository(_log, _commentRepository, _statusHistoryRepository);
        _sectionRepository = new SectionRepository(_log, _taskRepository);
        _boardRepository = new BoardRepository(_log, _sectionRepository);

        var result = await _boardRepository.GetActiveBoardsAsync(true);

        Assert.IsTrue(result.Any());
        Assert.IsTrue(result.First().Sections.Any());
    }

    [TestMethod]
    public async Task GetActiveBoardsNotFilledAsyncTest()
    {
        _log = new LogWriter();
        _commentRepository = new CommentRepository(_log);
        _statusHistoryRepository = new StatusHistoryRepository(_log);
        _taskRepository = new TaskRepository(_log, _commentRepository, _statusHistoryRepository);
        _sectionRepository = new SectionRepository(_log, _taskRepository);
        _boardRepository = new BoardRepository(_log, _sectionRepository);

        var result = await _boardRepository.GetActiveBoardsAsync(false);

        Assert.IsTrue(result.Any());
        Assert.IsNull(result.First().Sections);
    }
}
