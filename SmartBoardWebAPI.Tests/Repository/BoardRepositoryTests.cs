using System.Reflection.Metadata;
using SmartBoardWebAPI.Data.Repository;
using SmartBoardWebAPI.Utils;

namespace SmartBoardWebAPI.Tests.Repository;

[TestClass]
public class BoardRepositoryTests
{
    private IBoardRepository _boardRepository;
    private ILogWriter _log;

    private void StarServices()
    {
        _log = new LogWriter();
        _boardRepository = new BoardRepository(_log);
    }

    [TestMethod]
    public async Task GetBoardsAsyncTest()
    {
        StarServices();

        var result = await _boardRepository.GetBoardsAsync();

        Assert.IsTrue(result.Any());
    }

    [TestMethod]
    public async Task GetActiveBoardsAsyncTest()
    {
        StarServices();

        var result = await _boardRepository.GetActiveBoardsAsync();

        Assert.IsTrue(result.Any());
    }
}
