using System.Reflection.Metadata;
using PublishMessages;
using SmartBoardWebAPI.Business;
using SmartBoardWebAPI.Data.DTOs;
using SmartBoardWebAPI.Data.Repository;
using SmartBoardWebAPI.Utils;

namespace SmartBoardWebAPI.Tests.Business;

[TestClass]
public class SectionBusinessTests
{
    private ILogWriter _log;
    private ISectionBusiness _sectionBusiness;
    private ISectionRepository _sectionRepository;
    private IStatusHistoryRepository _statusHistoryRepository;
    private ICommentRepository _commentRepository;
    private ITaskRepository _taskRepository;
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
        _sectionBusiness = new SectionBusiness(_log, _sectionRepository, _sendService);
    }

    [TestMethod]
    public async Task GetSectionsByBoardIdAsyncTest()
    {
        StartServices();

        var result = await _sectionBusiness.GetSectionsByBoardIdAsync(2);

        Assert.IsTrue(result.Any());
    }

    [TestMethod]
    public async Task GetSectionsAsyncTest()
    {
        StartServices();

        var result = await _sectionBusiness.GetSectionsAsync();

        Assert.IsTrue(result.Any());
    }

    [TestMethod]
    public async Task GetActiveSectionsByBoardIdAsyncTest()
    {
        StartServices();

        var result = await _sectionBusiness.GetActiveSectionsByBoardIdAsync(2);

        Assert.IsTrue(result.Any());
    }

    [TestMethod]
    public async Task GetActiveSectionsAsyncTest()
    {
        StartServices();

        var result = await _sectionBusiness.GetActiveSectionsAsync();

        Assert.IsTrue(result.Any());
    }

    [TestMethod]
    public async Task GetSectionByIdAsyncTest()
    {
        StartServices();

        var result = await _sectionBusiness.GetSectionByIdAsync(18);

        Assert.IsNotNull(result);
    }

    [TestMethod]
    public async Task PostSectionAsyncTests()
    {
        StartServices();

        var dto = new SectionDTO()
        {
            Name = "Teste integração WebAPI",
            Active = true,
            Position = 1,
            BoardId = 1
        };

        await _sectionBusiness.PostSectionAsync(dto);
    }

    [TestMethod]
    public async Task PutSectionAsyncTests()
    {
        StartServices();

        var dto = new SectionDTO()
        {
            Id = 3,
            Name = "Teste integração update WebAPI",
            Active = false
        };

        await _sectionBusiness.PutSectionAsync(dto);
    }

    [TestMethod]
    public async Task PutSectionsAsyncTests()
    {
        StartServices();

        var dto1 = new SectionDTO()
        {
            Id = 11,
            Name = "Teste integração update WebAPI",
            Active = true,
            Position = 1,
            BoardId = 3
        };
        var dto2 = new SectionDTO()
        {
            Id = 12,
            Name = "Teste integração update WebAPI",
            Active = true,
            Position = 2,
            BoardId = 3
        };

        var list = new List<SectionDTO>();

        list.Add(dto1);
        list.Add(dto2);

        await _sectionBusiness.PutSectionsAsync(list);
    }
}
