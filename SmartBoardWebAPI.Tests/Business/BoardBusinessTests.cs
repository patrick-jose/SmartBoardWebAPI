using System.Reflection.Metadata;
using PublishMessages;
using SmartBoardWebAPI.Business;
using SmartBoardWebAPI.Data.DTOs;
using SmartBoardWebAPI.Data.Repository;
using SmartBoardWebAPI.Utils;

namespace SmartBoardWebAPI.Tests.Business;

[TestClass]
public class BoardBusinessTests
{
    private ILogWriter _log = new LogWriter();
    private IBoardBusiness _boardBusiness;
    private IBoardRepository _boardRepository;
    private ISectionRepository _sectionRepository;
    private ITaskRepository _taskRepository;
    private ICommentRepository _commentRepository;
    private IStatusHistoryRepository _statusHistoryRepository;
    private IUserRepository _userRepository;
    private ISendService _sendService;

    public void StartServices()
    {
        _log = new LogWriter();
        _commentRepository = new CommentRepository(_log);
        _statusHistoryRepository = new StatusHistoryRepository(_log);
        _taskRepository = new TaskRepository(_log);
        _sectionRepository = new SectionRepository(_log);
        _boardRepository = new BoardRepository(_log);
        _userRepository = new UserRepository(_log);
        _sendService = new SendService(_log);
        _boardBusiness = new BoardBusiness(_log, _boardRepository, _sendService);
    }

    [TestMethod]
    public async Task GetBoardsAsyncTest()
    {
        StartServices();

        var result = await _boardBusiness.GetActiveBoardsAsync();

        Assert.IsTrue(result.Any());
    }

    [TestMethod]
    public async Task PostBoardAsyncTests()
    {
        StartServices();

        var dto = new BoardDTO()
        {
            Name = "Teste integração WebAPI",
            Active = true
        };

        await _boardBusiness.PostBoardAsync(dto);
    }

    [TestMethod]
    public async Task PutBoardAsyncTests()
    {
        StartServices();

        var dto = new BoardDTO()
        {
            Id = 3,
            Name = "Teste integração update WebAPI",
            Active = false
        };

        await _boardBusiness.PutBoardAsync(dto);
    }
}
