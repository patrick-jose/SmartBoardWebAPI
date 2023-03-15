using System.Reflection.Metadata;
using SmartBoardWebAPI.Business;
using SmartBoardWebAPI.Data.Repository;
using SmartBoardWebAPI.Utils;

namespace SmartBoardWebAPI.Tests.Business;

[TestClass]
public class BoardBusinessTests
{
    private ILogWriter _log;
    private IBoardBusiness _boardBusiness;
    private IBoardRepository _boardRepository;
    private ISectionRepository _sectionRepository;
    private ITaskRepository _taskRepository;
    private ICommentRepository _commentRepository;
    private IStatusHistoryRepository _statusHistoryRepository;
    private IUserRepository _userRepository;

    [TestMethod]
    public async Task GetBoardsFilledAsyncTest()
    {
        _log = new LogWriter();
        _commentRepository = new CommentRepository(_log);
        _statusHistoryRepository = new StatusHistoryRepository(_log);
        _taskRepository = new TaskRepository(_log, _commentRepository, _statusHistoryRepository);
        _sectionRepository = new SectionRepository(_log, _taskRepository);
        _boardRepository = new BoardRepository(_log, _sectionRepository);
        _userRepository = new UserRepository(_log);
        _boardBusiness = new BoardBusiness(_log, _boardRepository, _sectionRepository, _userRepository);

        var result = await _boardBusiness.GetActiveBoardsAsync(true);

        Assert.IsTrue(result.Any());
        Assert.IsTrue(result.First().Sections.Any());
        Assert.IsTrue(result.First().Sections.First().Tasks.Any());
    }

    [TestMethod]
    public async Task GetBoardsModelFilledAsyncTest()
    {
        _log = new LogWriter();
        _commentRepository = new CommentRepository(_log);
        _statusHistoryRepository = new StatusHistoryRepository(_log);
        _taskRepository = new TaskRepository(_log, _commentRepository, _statusHistoryRepository);
        _sectionRepository = new SectionRepository(_log, _taskRepository);
        _boardRepository = new BoardRepository(_log, _sectionRepository);
        _userRepository = new UserRepository(_log);
        _boardBusiness = new BoardBusiness(_log, _boardRepository, _sectionRepository, _userRepository);

        var result = await _boardBusiness.GetActiveBoardsModelAsync(true);
        Assert.IsTrue(result.Any());
        Assert.IsTrue(result.First().Sections.Any());
        Assert.IsTrue(result.First().Sections.First().Tasks.Any());
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
        _userRepository = new UserRepository(_log);
        _boardBusiness = new BoardBusiness(_log, _boardRepository, _sectionRepository, _userRepository);

        var result = await _boardBusiness.GetActiveBoardsAsync(false);

        Assert.IsTrue(result.Any());
        Assert.IsTrue(result.First().Sections.Count() == 0);
    }

    [TestMethod]
    public async Task GetBoardsModelNotFilledAsyncTest()
    {
        _log = new LogWriter();
        _commentRepository = new CommentRepository(_log);
        _statusHistoryRepository = new StatusHistoryRepository(_log);
        _taskRepository = new TaskRepository(_log, _commentRepository, _statusHistoryRepository);
        _sectionRepository = new SectionRepository(_log, _taskRepository);
        _boardRepository = new BoardRepository(_log, _sectionRepository);
        _userRepository = new UserRepository(_log);
        _boardBusiness = new BoardBusiness(_log, _boardRepository, _sectionRepository, _userRepository);

        var result = await _boardBusiness.GetActiveBoardsModelAsync(false);

        Assert.IsTrue(result.Any());
        Assert.IsNull(result.First().Sections);
    }
}
