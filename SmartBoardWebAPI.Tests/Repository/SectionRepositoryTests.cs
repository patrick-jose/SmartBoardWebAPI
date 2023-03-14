using System.Reflection.Metadata;
using SmartBoardWebAPI.Data.Repository;
using SmartBoardWebAPI.Utils;

namespace SmartBoardWebAPI.Tests;

[TestClass]
public class SectionTests
{
    private ISectionRepository _sectionRepository;
    private ILogWriter _log;

    [TestMethod]
    public async Task GetSectionsAsyncTest()
    {
        _log = new LogWriter();
        _sectionRepository = new SectionRepository(_log);

        var result = await _sectionRepository.GetSectionsAsync();

        Assert.IsTrue(result.Any());
    }

    [TestMethod]
    public async Task GetSectionsByBoardIdAsyncTest()
    {
        _log = new LogWriter();
        _sectionRepository = new SectionRepository(_log);

        var result = await _sectionRepository.GetSectionsByBoardIdAsync(2);

        Assert.IsTrue(result.Any());
    }
}
