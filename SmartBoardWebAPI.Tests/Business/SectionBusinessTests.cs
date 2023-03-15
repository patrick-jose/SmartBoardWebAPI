using System.Reflection.Metadata;
using SmartBoardWebAPI.Business;
using SmartBoardWebAPI.Data.Repository;
using SmartBoardWebAPI.Utils;

namespace SmartBoardWebAPI.Tests.Business;

[TestClass]
public class SectionBusinessTests
{
    private ILogWriter _log;
    private ISectionBusiness _sectionBusiness;
    private ISectionRepository _sectionRepository;
    private IStatusHistoryRepository _statusHistoryRepository;
    private ICommentRepository _commentRepository;
    private ITaskRepository _taskRepository;
    private IUserRepository _userRepository;

    [TestMethod]
    public async Task GetSectionsFilledByBoardIdAsyncTest()
    {
        _log = new LogWriter();
        _statusHistoryRepository = new StatusHistoryRepository(_log);
        _commentRepository = new CommentRepository(_log);
        _taskRepository = new TaskRepository(_log, _commentRepository, _statusHistoryRepository);
        _sectionRepository = new SectionRepository(_log, _taskRepository);
        _userRepository = new UserRepository(_log);
        _sectionBusiness = new SectionBusiness(_log, _sectionRepository, _userRepository);

        var result = await _sectionBusiness.GetSectionsByBoardIdAsync(2, true);

        Assert.IsTrue(result.Any());
        Assert.IsTrue(result.First().Tasks.Any());
    }

    [TestMethod]
    public async Task GetSectionsFilledAsyncTest()
    {
        _log = new LogWriter();
        _statusHistoryRepository = new StatusHistoryRepository(_log);
        _commentRepository = new CommentRepository(_log);
        _taskRepository = new TaskRepository(_log, _commentRepository, _statusHistoryRepository);
        _sectionRepository = new SectionRepository(_log, _taskRepository);
        _userRepository = new UserRepository(_log);
        _sectionBusiness = new SectionBusiness(_log, _sectionRepository, _userRepository);

        var result = await _sectionBusiness.GetSectionsAsync(true);

        Assert.IsTrue(result.Any());
        Assert.IsTrue(result.First().Tasks.Any());
    }

    [TestMethod]
    public async Task GetSectionsNotFilledByBoardIdAsyncTest()
    {
        _log = new LogWriter();
        _statusHistoryRepository = new StatusHistoryRepository(_log);
        _commentRepository = new CommentRepository(_log);
        _taskRepository = new TaskRepository(_log, _commentRepository, _statusHistoryRepository);
        _sectionRepository = new SectionRepository(_log, _taskRepository);
        _userRepository = new UserRepository(_log);
        _sectionBusiness = new SectionBusiness(_log, _sectionRepository, _userRepository);

        var result = await _sectionBusiness.GetSectionsByBoardIdAsync(1, false);

        Assert.IsTrue(result.Any());
        Assert.IsTrue(result.First().Tasks.Count() == 0);
    }

    [TestMethod]
    public async Task GetSectionsNotFilledAsyncTest()
    {
        _log = new LogWriter();
        _statusHistoryRepository = new StatusHistoryRepository(_log);
        _commentRepository = new CommentRepository(_log);
        _taskRepository = new TaskRepository(_log, _commentRepository, _statusHistoryRepository);
        _sectionRepository = new SectionRepository(_log, _taskRepository);
        _userRepository = new UserRepository(_log);
        _sectionBusiness = new SectionBusiness(_log, _sectionRepository, _userRepository);

        var result = await _sectionBusiness.GetSectionsAsync(false);

        Assert.IsTrue(result.Any());
        Assert.IsTrue(result.First().Tasks.Count() == 0);
    }

    [TestMethod]
    public async Task GetActiveSectionsFilledByBoardIdAsyncTest()
    {
        _log = new LogWriter();
        _statusHistoryRepository = new StatusHistoryRepository(_log);
        _commentRepository = new CommentRepository(_log);
        _taskRepository = new TaskRepository(_log, _commentRepository, _statusHistoryRepository);
        _sectionRepository = new SectionRepository(_log, _taskRepository);
        _userRepository = new UserRepository(_log);
        _sectionBusiness = new SectionBusiness(_log, _sectionRepository, _userRepository);

        var result = await _sectionBusiness.GetActiveSectionsByBoardIdAsync(2, true);

        Assert.IsTrue(result.Any());
        Assert.IsTrue(result.First().Tasks.Any());
    }

    [TestMethod]
    public async Task GetActiveSectionsFilledAsyncTest()
    {
        _log = new LogWriter();
        _statusHistoryRepository = new StatusHistoryRepository(_log);
        _commentRepository = new CommentRepository(_log);
        _taskRepository = new TaskRepository(_log, _commentRepository, _statusHistoryRepository);
        _sectionRepository = new SectionRepository(_log, _taskRepository);
        _userRepository = new UserRepository(_log);
        _sectionBusiness = new SectionBusiness(_log, _sectionRepository, _userRepository);

        var result = await _sectionBusiness.GetActiveSectionsAsync(true);

        Assert.IsTrue(result.Any());
        Assert.IsTrue(result.First().Tasks.Any());
    }

    [TestMethod]
    public async Task GetActiveSectionsNotFilledBySectionIdAsyncTest()
    {
        _log = new LogWriter();
        _statusHistoryRepository = new StatusHistoryRepository(_log);
        _commentRepository = new CommentRepository(_log);
        _taskRepository = new TaskRepository(_log, _commentRepository, _statusHistoryRepository);
        _sectionRepository = new SectionRepository(_log, _taskRepository);
        _userRepository = new UserRepository(_log);
        _sectionBusiness = new SectionBusiness(_log, _sectionRepository, _userRepository);

        var result = await _sectionBusiness.GetActiveSectionsByBoardIdAsync(1, false);

        Assert.IsTrue(result.Any());
        Assert.IsTrue(result.First().Tasks.Count() == 0);
    }

    [TestMethod]
    public async Task GetActiveSectionsNotFilledAsyncTest()
    {
        _log = new LogWriter();
        _statusHistoryRepository = new StatusHistoryRepository(_log);
        _commentRepository = new CommentRepository(_log);
        _taskRepository = new TaskRepository(_log, _commentRepository, _statusHistoryRepository);
        _sectionRepository = new SectionRepository(_log, _taskRepository);
        _userRepository = new UserRepository(_log);
        _sectionBusiness = new SectionBusiness(_log, _sectionRepository, _userRepository);

        var result = await _sectionBusiness.GetActiveSectionsAsync(false);

        Assert.IsTrue(result.Any());
        Assert.IsTrue(result.First().Tasks.Count() == 0);
    }

    [TestMethod]
    public async Task GetSectionNotFilledByIdAsyncTest()
    {
        _log = new LogWriter();
        _statusHistoryRepository = new StatusHistoryRepository(_log);
        _commentRepository = new CommentRepository(_log);
        _taskRepository = new TaskRepository(_log, _commentRepository, _statusHistoryRepository);
        _sectionRepository = new SectionRepository(_log, _taskRepository);
        _userRepository = new UserRepository(_log);
        _sectionBusiness = new SectionBusiness(_log, _sectionRepository, _userRepository);

        var result = await _sectionBusiness.GetSectionByIdAsync(2, false);

        Assert.IsNotNull(result);
        Assert.IsTrue(result.Tasks.Count() == 0);
    }

    [TestMethod]
    public async Task GetSectionFilledByIdAsyncTest()
    {
        _log = new LogWriter();
        _statusHistoryRepository = new StatusHistoryRepository(_log);
        _commentRepository = new CommentRepository(_log);
        _taskRepository = new TaskRepository(_log, _commentRepository, _statusHistoryRepository);
        _sectionRepository = new SectionRepository(_log, _taskRepository);
        _userRepository = new UserRepository(_log);
        _sectionBusiness = new SectionBusiness(_log, _sectionRepository, _userRepository);

        var result = await _sectionBusiness.GetSectionByIdAsync(18, true);

        Assert.IsNotNull(result);
        Assert.IsTrue(result.Tasks.Any());
    }
}
