using System.Reflection.Metadata;
using SmartBoardWebAPI.Business;
using SmartBoardWebAPI.Data.Repository;
using SmartBoardWebAPI.Utils;

namespace SmartBoardWebAPI.Tests.Business;

[TestClass]
public class TaskBusinessTests
{
    private ILogWriter _log;
    private ITaskBusiness _taskBusiness;
    private ITaskRepository _taskRepository;
    private IStatusHistoryRepository _statusHistoryRepository;
    private ICommentRepository _commentRepository;
    private ISectionRepository _sectionRepository;
    private IUserRepository _userRepository;

    [TestMethod]
    public async Task GetTasksFilledBySectionIdAsyncTest()
    {
        _log = new LogWriter();
        _statusHistoryRepository = new StatusHistoryRepository(_log);
        _commentRepository = new CommentRepository(_log);
        _taskRepository = new TaskRepository(_log, _commentRepository, _statusHistoryRepository);
        _sectionRepository = new SectionRepository(_log, _taskRepository);
        _userRepository = new UserRepository(_log);
        _taskBusiness = new TaskBusiness(_log, _taskRepository, _userRepository, _sectionRepository);

        var result = await _taskBusiness.GetTaskBySectionIdAsync(2, true);

        Assert.IsTrue(result.Any());
        Assert.IsTrue(result.First().Comments.Any());
        Assert.IsTrue(result.First().StatusHistory.Any());
    }

    [TestMethod]
    public async Task GetTasksFilledAsyncTest()
    {
        _log = new LogWriter();
        _statusHistoryRepository = new StatusHistoryRepository(_log);
        _commentRepository = new CommentRepository(_log);
        _taskRepository = new TaskRepository(_log, _commentRepository, _statusHistoryRepository);
        _sectionRepository = new SectionRepository(_log, _taskRepository);
        _userRepository = new UserRepository(_log);
        _taskBusiness = new TaskBusiness(_log, _taskRepository, _userRepository, _sectionRepository);

        var result = await _taskBusiness.GetTasksAsync(true);

        Assert.IsTrue(result.Any());
        Assert.IsTrue(result.First().Comments.Any());
        Assert.IsTrue(result.First().StatusHistory.Any());
    }

    [TestMethod]
    public async Task GetTasksNotFilledBySectionIdAsyncTest()
    {
        _log = new LogWriter();
        _statusHistoryRepository = new StatusHistoryRepository(_log);
        _commentRepository = new CommentRepository(_log);
        _taskRepository = new TaskRepository(_log, _commentRepository, _statusHistoryRepository);
        _sectionRepository = new SectionRepository(_log, _taskRepository);
        _userRepository = new UserRepository(_log);
        _taskBusiness = new TaskBusiness(_log, _taskRepository, _userRepository, _sectionRepository);

        var result = await _taskBusiness.GetTaskBySectionIdAsync(1, false);

        Assert.IsTrue(result.Any());
        Assert.IsTrue(result.First().Comments.Count() == 0);
        Assert.IsTrue(result.First().StatusHistory.Count() == 0);
    }

    [TestMethod]
    public async Task GetTasksNotFilledAsyncTest()
    {
        _log = new LogWriter();
        _statusHistoryRepository = new StatusHistoryRepository(_log);
        _commentRepository = new CommentRepository(_log);
        _taskRepository = new TaskRepository(_log, _commentRepository, _statusHistoryRepository);
        _sectionRepository = new SectionRepository(_log, _taskRepository);
        _userRepository = new UserRepository(_log);
        _taskBusiness = new TaskBusiness(_log, _taskRepository, _userRepository, _sectionRepository);

        var result = await _taskBusiness.GetTasksAsync(false);

        Assert.IsTrue(result.Any());
        Assert.IsTrue(result.First().Comments.Count() == 0);
        Assert.IsTrue(result.First().StatusHistory.Count() == 0);
    }

    [TestMethod]
    public async Task GetActiveTasksFilledBySectionIdAsyncTest()
    {
        _log = new LogWriter();
        _statusHistoryRepository = new StatusHistoryRepository(_log);
        _commentRepository = new CommentRepository(_log);
        _taskRepository = new TaskRepository(_log, _commentRepository, _statusHistoryRepository);
        _sectionRepository = new SectionRepository(_log, _taskRepository);
        _userRepository = new UserRepository(_log);
        _taskBusiness = new TaskBusiness(_log, _taskRepository, _userRepository, _sectionRepository);

        var result = await _taskBusiness.GetActiveTaskBySectionIdAsync(2, true);

        Assert.IsTrue(result.Any());
        Assert.IsTrue(result.First().Comments.Any());
        Assert.IsTrue(result.First().StatusHistory.Any());
    }

    [TestMethod]
    public async Task GetActiveTasksFilledAsyncTest()
    {
        _log = new LogWriter();
        _statusHistoryRepository = new StatusHistoryRepository(_log);
        _commentRepository = new CommentRepository(_log);
        _taskRepository = new TaskRepository(_log, _commentRepository, _statusHistoryRepository);
        _sectionRepository = new SectionRepository(_log, _taskRepository);
        _userRepository = new UserRepository(_log);
        _taskBusiness = new TaskBusiness(_log, _taskRepository, _userRepository, _sectionRepository);

        var result = await _taskBusiness.GetActiveTasksAsync(true);

        Assert.IsTrue(result.Any());
        Assert.IsTrue(result.First().Comments.Any());
        Assert.IsTrue(result.First().StatusHistory.Any());
    }

    [TestMethod]
    public async Task GetActiveTasksNotFilledBySectionIdAsyncTest()
    {
        _log = new LogWriter();
        _statusHistoryRepository = new StatusHistoryRepository(_log);
        _commentRepository = new CommentRepository(_log);
        _taskRepository = new TaskRepository(_log, _commentRepository, _statusHistoryRepository);
        _sectionRepository = new SectionRepository(_log, _taskRepository);
        _userRepository = new UserRepository(_log);
        _taskBusiness = new TaskBusiness(_log, _taskRepository, _userRepository, _sectionRepository);

        var result = await _taskBusiness.GetActiveTaskBySectionIdAsync(1, false);

        Assert.IsTrue(result.Any());
        Assert.IsTrue(result.First().Comments.Count() == 0);
        Assert.IsTrue(result.First().StatusHistory.Count() == 0);
    }

    [TestMethod]
    public async Task GetActiveTasksNotFilledAsyncTest()
    {
        _log = new LogWriter();
        _statusHistoryRepository = new StatusHistoryRepository(_log);
        _commentRepository = new CommentRepository(_log);
        _taskRepository = new TaskRepository(_log, _commentRepository, _statusHistoryRepository);
        _sectionRepository = new SectionRepository(_log, _taskRepository);
        _userRepository = new UserRepository(_log);
        _taskBusiness = new TaskBusiness(_log, _taskRepository, _userRepository, _sectionRepository);

        var result = await _taskBusiness.GetActiveTasksAsync(false);

        Assert.IsTrue(result.Any());
        Assert.IsTrue(result.First().Comments.Count() == 0);
        Assert.IsTrue(result.First().StatusHistory.Count() == 0);
    }

    [TestMethod]
    public async Task GetTaskNotFilledByIdAsyncTest()
    {
        _log = new LogWriter();
        _statusHistoryRepository = new StatusHistoryRepository(_log);
        _commentRepository = new CommentRepository(_log);
        _taskRepository = new TaskRepository(_log, _commentRepository, _statusHistoryRepository);
        _sectionRepository = new SectionRepository(_log, _taskRepository);
        _userRepository = new UserRepository(_log);
        _taskBusiness = new TaskBusiness(_log, _taskRepository, _userRepository, _sectionRepository);

        var result = await _taskBusiness.GetTaskByIdAsync(2, false);

        Assert.IsNotNull(result);
        Assert.IsTrue(result.Comments.Count() == 0);
        Assert.IsTrue(result.StatusHistory.Count() == 0);
    }

    [TestMethod]
    public async Task GetTaskFilledByIdAsyncTest()
    {
        _log = new LogWriter();
        _statusHistoryRepository = new StatusHistoryRepository(_log);
        _commentRepository = new CommentRepository(_log);
        _taskRepository = new TaskRepository(_log, _commentRepository, _statusHistoryRepository);
        _sectionRepository = new SectionRepository(_log, _taskRepository);
        _userRepository = new UserRepository(_log);
        _taskBusiness = new TaskBusiness(_log, _taskRepository, _userRepository, _sectionRepository);

        var result = await _taskBusiness.GetTaskByIdAsync(18, true);

        Assert.IsNotNull(result);
        Assert.IsTrue(result.Comments.Any());
        Assert.IsTrue(result.StatusHistory.Any());
    }
}
