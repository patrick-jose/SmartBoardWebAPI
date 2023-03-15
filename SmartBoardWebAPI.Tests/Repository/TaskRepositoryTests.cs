using System.Reflection.Metadata;
using SmartBoardWebAPI.Data.Repository;
using SmartBoardWebAPI.Utils;

namespace SmartBoardWebAPI.Tests.Repository;

[TestClass]
public class TaskRepositoryTests
{
    private ITaskRepository _taskRepository;
    private ICommentRepository _commentRepository;
    private IStatusHistoryRepository _statusHistoryRepository;
    private ILogWriter _log;

    [TestMethod]
    public async Task GetTasksFilledAsyncTest()
    {
        _log = new LogWriter();
        _commentRepository = new CommentRepository(_log);
        _statusHistoryRepository = new StatusHistoryRepository(_log);
        _taskRepository = new TaskRepository(_log, _commentRepository, _statusHistoryRepository);

        var result = await _taskRepository.GetTasksAsync(true);

        Assert.IsTrue(result.Any());
        Assert.IsTrue(result.First().Comments.Any());
        Assert.IsTrue(result.First().StatusHistory.Any());
    }

    [TestMethod]
    public async Task GetTasksFilledBySectionIdAsyncTest()
    {
        _log = new LogWriter();
        _commentRepository = new CommentRepository(_log);
        _statusHistoryRepository = new StatusHistoryRepository(_log);
        _taskRepository = new TaskRepository(_log, _commentRepository, _statusHistoryRepository);

        var result = await _taskRepository.GetTasksBySectionIdAsync(2, true);

        Assert.IsTrue(result.Any());
        Assert.IsTrue(result.First().Comments.Any());
        Assert.IsTrue(result.First().StatusHistory.Any());
    }

    [TestMethod]
    public async Task GetTasksNotFilledAsyncTest()
    {
        _log = new LogWriter();
        _commentRepository = new CommentRepository(_log);
        _statusHistoryRepository = new StatusHistoryRepository(_log);
        _taskRepository = new TaskRepository(_log, _commentRepository, _statusHistoryRepository);

        var result = await _taskRepository.GetTasksAsync(false);

        Assert.IsTrue(result.Any());
        Assert.IsNull(result.First().Comments);
        Assert.IsNull(result.First().StatusHistory);
    }

    [TestMethod]
    public async Task GetTasksNotFilledBySectionIdAsyncTest()
    {
        _log = new LogWriter();
        _commentRepository = new CommentRepository(_log);
        _statusHistoryRepository = new StatusHistoryRepository(_log);
        _taskRepository = new TaskRepository(_log, _commentRepository, _statusHistoryRepository);

        var result = await _taskRepository.GetTasksBySectionIdAsync(2, false);

        Assert.IsTrue(result.Any());
        Assert.IsNull(result.First().Comments);
        Assert.IsNull(result.First().StatusHistory);
    }

    [TestMethod]
    public async Task GetActiveTasksFilledAsyncTest()
    {
        _log = new LogWriter();
        _commentRepository = new CommentRepository(_log);
        _statusHistoryRepository = new StatusHistoryRepository(_log);
        _taskRepository = new TaskRepository(_log, _commentRepository, _statusHistoryRepository);

        var result = await _taskRepository.GetActiveTasksAsync(true);

        Assert.IsTrue(result.Any());
        Assert.IsTrue(result.First().Comments.Any());
        Assert.IsTrue(result.First().StatusHistory.Any());
    }

    [TestMethod]
    public async Task GetActiveTasksFilledBySectionIdAsyncTest()
    {
        _log = new LogWriter();
        _commentRepository = new CommentRepository(_log);
        _statusHistoryRepository = new StatusHistoryRepository(_log);
        _taskRepository = new TaskRepository(_log, _commentRepository, _statusHistoryRepository);

        var result = await _taskRepository.GetActiveTasksBySectionIdAsync(2, true);

        Assert.IsTrue(result.Any());
        Assert.IsTrue(result.First().Comments.Any());
        Assert.IsTrue(result.First().StatusHistory.Any());
    }

    [TestMethod]
    public async Task GetActiveTasksNotFilledAsyncTest()
    {
        _log = new LogWriter();
        _commentRepository = new CommentRepository(_log);
        _statusHistoryRepository = new StatusHistoryRepository(_log);
        _taskRepository = new TaskRepository(_log, _commentRepository, _statusHistoryRepository);

        var result = await _taskRepository.GetActiveTasksAsync(false);

        Assert.IsTrue(result.Any());
        Assert.IsNull(result.First().Comments);
        Assert.IsNull(result.First().StatusHistory);
    }

    [TestMethod]
    public async Task GetActiveTasksNotFilledBySectionIdAsyncTest()
    {
        _log = new LogWriter();
        _commentRepository = new CommentRepository(_log);
        _statusHistoryRepository = new StatusHistoryRepository(_log);
        _taskRepository = new TaskRepository(_log, _commentRepository, _statusHistoryRepository);

        var result = await _taskRepository.GetActiveTasksBySectionIdAsync(2, false);

        Assert.IsTrue(result.Any());
        Assert.IsNull(result.First().Comments);
        Assert.IsNull(result.First().StatusHistory);
    }

    [TestMethod]
    public async Task GetTaskNotFilledByIdAsyncTest()
    {
        _log = new LogWriter();
        _commentRepository = new CommentRepository(_log);
        _statusHistoryRepository = new StatusHistoryRepository(_log);
        _taskRepository = new TaskRepository(_log, _commentRepository, _statusHistoryRepository);

        var result = await _taskRepository.GetTaskByIdAsync(2, false);

        Assert.IsNotNull(result);
        Assert.IsNull(result.Comments);
        Assert.IsNull(result.StatusHistory);
    }

    [TestMethod]
    public async Task GetTaskFilledByIdAsyncTest()
    {
        _log = new LogWriter();
        _commentRepository = new CommentRepository(_log);
        _statusHistoryRepository = new StatusHistoryRepository(_log);
        _taskRepository = new TaskRepository(_log, _commentRepository, _statusHistoryRepository);

        var result = await _taskRepository.GetTaskByIdAsync(18, true);

        Assert.IsNotNull(result);
        Assert.IsTrue(result.Comments.Any());
        Assert.IsTrue(result.StatusHistory.Any());
    }
}
