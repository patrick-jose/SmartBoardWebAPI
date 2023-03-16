using System.Linq;
using System.Reflection.Metadata;
using SmartBoardWebAPI.Data.Repository;
using SmartBoardWebAPI.Utils;

namespace SmartBoardWebAPI.Tests.Repository;

[TestClass]
public class SectionRepositoryTests
{
    private ISectionRepository _sectionRepository;
    private ILogWriter _log;

    private void StartServices()
    {
        _log = new LogWriter();
        _sectionRepository = new SectionRepository(_log);
    }

    [TestMethod]
    public async Task GetSectionsAsyncTest()
    {
        StartServices();

        var result = await _sectionRepository.GetSectionsAsync();

        Assert.IsTrue(result.Any());
    }

    [TestMethod]
    public async Task GetSectionsByBoardIdAsyncTest()
    {
        StartServices();

        var result = await _sectionRepository.GetSectionsByBoardIdAsync(2);

        Assert.IsTrue(result.Any());
    }

    [TestMethod]
    public async Task GetSectionByIdAsyncTest()
    {
        StartServices();

        var result = await _sectionRepository.GetSectionByIdAsync(2);

        Assert.IsNotNull(result);
    }

    [TestMethod]
    public async Task GetActiveSectionsByBoardIdAsyncTest()
    {
        StartServices();

        var result = await _sectionRepository.GetActiveSectionsByBoardIdAsync(1);

        Assert.IsTrue(result.Any());
        Assert.IsTrue(result.Count() > 1);

    }
}
