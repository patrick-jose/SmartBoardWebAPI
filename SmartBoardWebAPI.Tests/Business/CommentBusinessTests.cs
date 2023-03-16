using System.Reflection.Metadata;
using PublishMessages;
using SmartBoardWebAPI.Business;
using SmartBoardWebAPI.Data.DTOs;
using SmartBoardWebAPI.Data.Repository;
using SmartBoardWebAPI.Utils;

namespace SmartBoardWebAPI.Tests.Business;

[TestClass]
public class CommentBusinessTests
{
    private ILogWriter _log;
    private ICommentBusiness _commentBusiness;
    private ICommentRepository _commentRepository;
    private IUserRepository _userRepository;
    private ISendService _sendService;

    public void StartServices()
    {
        _log = new LogWriter();
        _commentRepository = new CommentRepository(_log);
        _userRepository = new UserRepository(_log);
        _sendService = new SendService(_log);
        _commentBusiness = new CommentBusiness(_log, _commentRepository, _sendService);       
    }

    [TestMethod]
    public async Task GetCommentsByTaskIdAsyncTest()
    {
        StartServices();

        var result = await _commentBusiness.GetCommentsByTaskIdAsync(5);

        Assert.IsTrue(result.Any());
    }

    [TestMethod]
    public async Task PostBoardAsyncTests()
    {
        StartServices();

        var dto = new CommentDTO()
        {
            Content = "Teste inserção webapi",
            DateCreation = DateTime.Now,
            TaskId = 24,
            WriterId = 2
        };

        await _commentBusiness.PostCommentAsync(dto);
    }
}
