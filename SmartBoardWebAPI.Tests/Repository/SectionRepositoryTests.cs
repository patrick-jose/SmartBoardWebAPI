using System.Linq;
using System.Reflection.Metadata;
using SmartBoardWebAPI.Data.Repository;
using SmartBoardWebAPI.Utils;

namespace SmartBoardWebAPI.Tests.Repository;

[TestClass]
public class SectionRepositoryTests
{
    private ISectionRepository _sectionRepository;
    private ITaskRepository _taskRepository;
    private ICommentRepository _commentRepository;
    private IStatusHistoryRepository _statusHistoryRepository;
    private ILogWriter _log;

    [TestMethod]
    public async Task GetSectionsFilledAsyncTest()
    {
        _log = new LogWriter();
        _commentRepository = new CommentRepository(_log);
        _statusHistoryRepository = new StatusHistoryRepository(_log);
        _taskRepository = new TaskRepository(_log, _commentRepository, _statusHistoryRepository);
        _sectionRepository = new SectionRepository(_log, _taskRepository);

        var result = await _sectionRepository.GetSectionsAsync(true);

        Assert.IsTrue(result.Any());
        Assert.IsTrue(result.First().Tasks.Any());
    }

    [TestMethod]
    public async Task GetSectionsFilledByBoardIdAsyncTest()
    {
        _log = new LogWriter();
        _commentRepository = new CommentRepository(_log);
        _statusHistoryRepository = new StatusHistoryRepository(_log);
        _taskRepository = new TaskRepository(_log, _commentRepository, _statusHistoryRepository);
        _sectionRepository = new SectionRepository(_log, _taskRepository);

        var result = await _sectionRepository.GetSectionsByBoardIdAsync(2, true);

        Assert.IsTrue(result.Any());
        Assert.IsTrue(result.First().Tasks.Any());
    }

    [TestMethod]
    public async Task GetSectionFilledByIdAsyncTest()
    {
        _log = new LogWriter();
        _commentRepository = new CommentRepository(_log);
        _statusHistoryRepository = new StatusHistoryRepository(_log);
        _taskRepository = new TaskRepository(_log, _commentRepository, _statusHistoryRepository);
        _sectionRepository = new SectionRepository(_log, _taskRepository);

        var result = await _sectionRepository.GetSectionByIdAsync(2, true);

        Assert.IsNotNull(result);
        Assert.IsTrue(result.Tasks.Any());
    }

    [TestMethod]
    public async Task GetSectionsNotFilledAsyncTest()
    {
        _log = new LogWriter();
        _commentRepository = new CommentRepository(_log);
        _statusHistoryRepository = new StatusHistoryRepository(_log);
        _taskRepository = new TaskRepository(_log, _commentRepository, _statusHistoryRepository);
        _sectionRepository = new SectionRepository(_log, _taskRepository);

        var result = await _sectionRepository.GetSectionsAsync(false);

        Assert.IsTrue(result.Any());
        Assert.IsNull(result.First().Tasks);
    }

    [TestMethod]
    public async Task GetSectionsNotFilledByBoardIdAsyncTest()
    {
        _log = new LogWriter();
        _commentRepository = new CommentRepository(_log);
        _statusHistoryRepository = new StatusHistoryRepository(_log);
        _taskRepository = new TaskRepository(_log, _commentRepository, _statusHistoryRepository);
        _sectionRepository = new SectionRepository(_log, _taskRepository);

        var result = await _sectionRepository.GetSectionsByBoardIdAsync(2, false);

        Assert.IsTrue(result.Any());
        Assert.IsNull(result.First().Tasks);
    }

    [TestMethod]
    public async Task GetSectionNotFilledByIdAsyncTest()
    {
        _log = new LogWriter();
        _commentRepository = new CommentRepository(_log);
        _statusHistoryRepository = new StatusHistoryRepository(_log);
        _taskRepository = new TaskRepository(_log, _commentRepository, _statusHistoryRepository);
        _sectionRepository = new SectionRepository(_log, _taskRepository);

        var result = await _sectionRepository.GetSectionByIdAsync(2, false);

        Assert.IsNotNull(result);
        Assert.IsNull(result.Tasks);
    }

    [TestMethod]
    public async Task GetActiveSectionsFilledByBoardIdAsyncTest()
    {
        _log = new LogWriter();
        _commentRepository = new CommentRepository(_log);
        _statusHistoryRepository = new StatusHistoryRepository(_log);
        _taskRepository = new TaskRepository(_log, _commentRepository, _statusHistoryRepository);
        _sectionRepository = new SectionRepository(_log, _taskRepository);

        var result = await _sectionRepository.GetActiveSectionsByBoardIdAsync(1, true);

        Assert.IsTrue(result.Any());
        Assert.IsTrue(result.Count() > 1);

    }

    [TestMethod]
    public async Task GetActiveSectionsNotFilledAsyncTest()
    {
        _log = new LogWriter();
        _commentRepository = new CommentRepository(_log);
        _statusHistoryRepository = new StatusHistoryRepository(_log);
        _taskRepository = new TaskRepository(_log, _commentRepository, _statusHistoryRepository);
        _sectionRepository = new SectionRepository(_log, _taskRepository);

        var result = await _sectionRepository.GetActiveSectionsAsync(false);

        Assert.IsTrue(result.Any());
        Assert.IsNull(result.First().Tasks);
    }

    [TestMethod]
    public async Task GetActiveSectionsNotFilledByBoardIdAsyncTest()
    {
        _log = new LogWriter();
        _commentRepository = new CommentRepository(_log);
        _statusHistoryRepository = new StatusHistoryRepository(_log);
        _taskRepository = new TaskRepository(_log, _commentRepository, _statusHistoryRepository);
        _sectionRepository = new SectionRepository(_log, _taskRepository);

        var result = await _sectionRepository.GetActiveSectionsByBoardIdAsync(2, false);

        Assert.IsTrue(result.Any());
        Assert.IsNull(result.First().Tasks);
    }
}
