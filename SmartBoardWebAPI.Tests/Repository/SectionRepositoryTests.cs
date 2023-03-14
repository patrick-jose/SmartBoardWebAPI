using System.Reflection.Metadata;
using SmartBoardWebAPI.Data.Repository;
using SmartBoardWebAPI.Utils;

namespace SmartBoardWebAPI.Tests.Repository;

[TestClass]
public class SectionRepositoryTests
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

    [TestMethod]
    public async Task GetSectionsByIdAsyncTest()
    {
        _log = new LogWriter();
        _sectionRepository = new SectionRepository(_log);

        var result = await _sectionRepository.GetSectionByIdAsync(2);

        Assert.IsNotNull(result);
    }
}
