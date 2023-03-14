using System.Reflection.Metadata;
using SmartBoardWebAPI.Data.Repository;
using SmartBoardWebAPI.Utils;

namespace SmartBoardWebAPI.Tests.Repository;

[TestClass]
public class TaskRepositoryTests
{
    private ITaskRepository _taskRepository;
    private ILogWriter _log;

    [TestMethod]
    public async Task GetTasksAsyncTest()
    {
        _log = new LogWriter();
        _taskRepository = new TaskRepository(_log);

        var result = await _taskRepository.GetTasksAsync();

        Assert.IsTrue(result.Any());
    }

    [TestMethod]
    public async Task GetTasksBySectionIdAsyncTest()
    {
        _log = new LogWriter();
        _taskRepository = new TaskRepository(_log);

        var result = await _taskRepository.GetTasksBySectionIdAsync(2);

        Assert.IsTrue(result.Any());
    }
}
