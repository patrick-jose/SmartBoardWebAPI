using System.Reflection.Metadata;
using SmartBoardWebAPI.Data.Repository;
using SmartBoardWebAPI.Utils;

namespace SmartBoardWebAPI.Tests.Repository;

[TestClass]
public class StatusHistoryRepositoryTests
{
    private IStatusHistoryRepository _statusHistoryRepository;
    private ILogWriter _log;

    private void StartServices()
    {
        _log = new LogWriter();
        _statusHistoryRepository = new StatusHistoryRepository(_log);
    }

    [TestMethod]
    public async Task GetStatusHistorysAsyncTest()
    {
        StartServices();

        var result = await _statusHistoryRepository.GetStatusHistorysAsync();

        Assert.IsTrue(result.Any());
    }

    [TestMethod]
    public async Task GetStatusHistorysBySectionIdAsyncTest()
    {
        StartServices();

        var result = await _statusHistoryRepository.GetStatusHistoryByTaskIdAsync(6);

        Assert.IsTrue(result.Any());
    }
}
