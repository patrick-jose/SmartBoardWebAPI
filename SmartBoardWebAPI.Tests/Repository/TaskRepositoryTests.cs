using System.Reflection.Metadata;
using SmartBoardWebAPI.Data.Repository;
using SmartBoardWebAPI.Utils;

namespace SmartBoardWebAPI.Tests.Repository;

[TestClass]
public class TaskRepositoryTests
{
    private ITaskRepository _taskRepository;
    private ILogWriter _log;

    private void StartServices()
    {
        _log = new LogWriter();
        _taskRepository = new TaskRepository(_log);
    }

    [TestMethod]
    public async Task GetTasksAsyncTest()
    {
        StartServices();

        var result = await _taskRepository.GetTasksAsync();

        Assert.IsTrue(result.Any());
    }

    [TestMethod]
    public async Task GetTasksBySectionIdAsyncTest()
    {
        StartServices();

        var result = await _taskRepository.GetTasksBySectionIdAsync(2);

        Assert.IsTrue(result.Any());
    }

    [TestMethod]
    public async Task GetActiveTasksAsyncTest()
    {
        StartServices();

        var result = await _taskRepository.GetActiveTasksAsync();

        Assert.IsTrue(result.Any());
    }

    [TestMethod]
    public async Task GetActiveTasksBySectionIdAsyncTest()
    {
        StartServices();

        var result = await _taskRepository.GetActiveTasksBySectionIdAsync(2);

        Assert.IsTrue(result.Any());
    }

    [TestMethod]
    public async Task GetTaskByIdAsyncTest()
    {
        StartServices();

        var result = await _taskRepository.GetTaskByIdAsync(18);

        Assert.IsNotNull(result);
    }
}
