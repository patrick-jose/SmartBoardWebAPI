using System.Reflection.Metadata;
using PublishMessages;
using SmartBoardWebAPI.Business;
using SmartBoardWebAPI.Data.DTOs;
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
    private ISendService _sendService;

    public void StartServices()
    {
        _log = new LogWriter();
        _sendService = new SendService(_log);
        _statusHistoryRepository = new StatusHistoryRepository(_log);
        _commentRepository = new CommentRepository(_log);
        _taskRepository = new TaskRepository(_log);
        _sectionRepository = new SectionRepository(_log);
        _userRepository = new UserRepository(_log);
        _taskBusiness = new TaskBusiness(_log, _taskRepository, _sendService);
    }

    [TestMethod]
    public async Task GetTasksBySectionIdAsyncTest()
    {
        StartServices();

        var result = await _taskBusiness.GetTaskBySectionIdAsync(2);

        Assert.IsTrue(result.Any());
    }

    [TestMethod]
    public async Task GetTasksAsyncTest()
    {
        StartServices();

        var result = await _taskBusiness.GetTasksAsync();

        Assert.IsTrue(result.Any());
    }

    [TestMethod]
    public async Task GetActiveTasksBySectionIdAsyncTest()
    {
        StartServices();

        var result = await _taskBusiness.GetActiveTaskBySectionIdAsync(2);

        Assert.IsTrue(result.Any());
    }

    [TestMethod]
    public async Task GetActiveTasksAsyncTest()
    {
        StartServices();

        var result = await _taskBusiness.GetActiveTasksAsync();

        Assert.IsTrue(result.Any());
    }

    [TestMethod]
    public async Task GetTaskByIdAsyncTest()
    {
        StartServices();

        var result = await _taskBusiness.GetTaskByIdAsync(18);

        Assert.IsNotNull(result);
    }

    [TestMethod]
    public async Task SendInsertTaskTests()
    {
        StartServices();

        var dto = new TaskDTO()
        {
            Name = "Teste integração insert WebAPI",
            Active = true,
            Description = "Teste integração insert WebAPI",
            SectionId = 2,
            Blocked = false,
            AssigneeId = 1,
            Position = 7,
        };

        await _taskBusiness.PostTaskAsync(dto);
    }

    [TestMethod]
    public async Task SendUpdateTaskTests()
    {
        StartServices();

        var dto = new TaskDTO()
        {
            Id = 3,
            Name = "Teste integração update WebAPI",
            Active = true,
            Description = "Teste integração update WebAPI",
            SectionId = 2,
            Blocked = false,
            AssigneeId = 1,
            Position = 4,
        };

        await _taskBusiness.PutTaskAsync(dto);
    }

    [TestMethod]
    public async Task SendUpdateTasksTests()
    {
        StartServices();

        var dto1 = new TaskDTO()
        {
            Id = 31,
            Name = "Teste integração update WebAPI",
            Active = true,
            Description = "Teste integração update WebAPI",
            SectionId = 10,
            Blocked = false,
            AssigneeId = 1,
            Position = 1,
        };
        var dto2 = new TaskDTO()
        {
            Id = 32,
            Name = "Teste integração update WebAPI",
            Active = true,
            Description = "Teste integração update WebAPI",
            SectionId = 10,
            Blocked = false,
            AssigneeId = 1,
            Position = 2,
        };

        var list = new List<TaskDTO>();

        list.Add(dto1);
        list.Add(dto2);

        await _taskBusiness.PutTasksAsync(list);
    }
}
