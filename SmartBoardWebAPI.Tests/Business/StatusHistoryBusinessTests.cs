using System.Reflection.Metadata;
using SmartBoardWebAPI.Business;
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

    [TestMethod]
    public async Task GetStatusHistorysByTaskIdAsyncTest()
    {
        _log = new LogWriter();
        _statusHistoryRepository = new StatusHistoryRepository(_log);
        _sectionRepository = new SectionRepository(_log, _taskRepository);
        _userRepository = new UserRepository(_log);
        _statusHistoryBusiness = new StatusHistoryBusiness(_log, _statusHistoryRepository, _sectionRepository, _userRepository);

        var result = await _statusHistoryBusiness.GetStatusHistoryByTaskIdAsync(5);

        Assert.IsTrue(result.Any());
    }
}
