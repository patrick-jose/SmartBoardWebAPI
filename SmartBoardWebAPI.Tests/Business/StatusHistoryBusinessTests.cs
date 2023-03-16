using System.Reflection.Metadata;
using PublishMessages;
using SmartBoardWebAPI.Business;
using SmartBoardWebAPI.Data.DTOs;
using SmartBoardWebAPI.Data.Repository;
using SmartBoardWebAPI.Utils;

namespace SmartBoardWebAPI.Tests.Business;

[TestClass]
public class StatusHistoryBusinessTests
{
    private ILogWriter _log;
    private IStatusHistoryBusiness _statusHistoryBusiness;
    private IStatusHistoryRepository _statusHistoryRepository;
    private ISectionRepository _sectionRepository;
    private IUserRepository _userRepository;
    private ITaskRepository _taskRepository;
    private ISendService _sendService;

    public void StartServices()
    {
        _log = new LogWriter();
        _sendService = new SendService(_log);
        _statusHistoryRepository = new StatusHistoryRepository(_log);
        _sectionRepository = new SectionRepository(_log);
        _userRepository = new UserRepository(_log);
        _statusHistoryBusiness = new StatusHistoryBusiness(_log, _statusHistoryRepository, _sendService);
    }

    [TestMethod]
    public async Task GetStatusHistorysByTaskIdAsyncTest()
    {
        StartServices();

        var result = await _statusHistoryBusiness.GetStatusHistoryByTaskIdAsync(5);

        Assert.IsTrue(result.Any());
    }

    [TestMethod]
    public async Task PostStatusHistoryAsyncTests()
    {
        StartServices();

        var dto = new StatusHistoryDTO()
        {
            TaskId = 34,
            DateModified = DateTime.Now,
            PreviousSectionId = 8,
            ActualSectionId = 9,
            UserId = 2
        };

        await _statusHistoryBusiness.PostStatusHistoryAsync(dto);
    }
}
