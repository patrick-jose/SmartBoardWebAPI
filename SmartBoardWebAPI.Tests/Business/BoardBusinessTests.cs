using System.Reflection.Metadata;
using SmartBoardWebAPI.Business;
using SmartBoardWebAPI.Data.Repository;
using SmartBoardWebAPI.Utils;

namespace SmartBoardWebAPI.Tests.Business;

[TestClass]
public class BoardBusinessTests
{
    private ILogWriter _log;
    private IBoardBusiness _boardBusiness;
    private IBoardRepository _boardRepository;
    private ISectionRepository _sectionRepository;
    private ITaskRepository _taskRepository;
    private ICommentRepository _commentRepository;
    private IStatusHistoryRepository _statusHistoryRepository;

    [TestMethod]
    public async Task GetBoardsAsyncTest()
    {
        _log = new LogWriter();
        _sectionRepository = new SectionRepository(_log);
        _taskRepository = new TaskRepository(_log);
        _commentRepository = new CommentRepository(_log);
        _statusHistoryRepository = new StatusHistoryRepository(_log);
        _boardRepository = new BoardRepository(_log, _sectionRepository, _taskRepository, _commentRepository, _statusHistoryRepository);
        _boardBusiness = new BoardBusiness(_log, _boardRepository);

        var result = await _boardBusiness.GetActiveBoardsAsync();

        Assert.IsTrue(result.Any());
    }
}
