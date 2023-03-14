using System;
using Dapper;
using Npgsql;
using SmartBoardWebAPI.Data.Models;
using SmartBoardWebAPI.Utils;

namespace SmartBoardWebAPI.Data.Repository
{
    public class BoardRepository : IBoardRepository
    {
        private readonly ILogWriter _log;
        private readonly DbConnection _dbConnection;
        private readonly ISectionRepository _sectionRepository;
        private readonly ITaskRepository _taskRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly IStatusHistoryRepository _statusHistoryRepository;

        public BoardRepository(
            ILogWriter log,
            ISectionRepository sectionRepository,
            ITaskRepository taskRepository,
            ICommentRepository commentRepository,
            IStatusHistoryRepository statusHistoryRepository
        )
        {
            _log = log;
            _dbConnection = new DbConnection(_log);
            _sectionRepository = sectionRepository;
            _taskRepository = taskRepository;
            _commentRepository = commentRepository;
            _statusHistoryRepository = statusHistoryRepository;
        }

        public async Task<IEnumerable<BoardModel>> GetBoardsAsync()
        {
            try
            {
                string commandText = @$"select * from smartboard.board";

                var boards = await _dbConnection.connection.QueryAsync<BoardModel>(commandText);

                foreach (var board in boards)
                {
                    board.Sections = await _sectionRepository.GetSectionsByBoardIdAsync(board.Id);

                    foreach (var section in board.Sections)
                    {
                        section.Tasks = await _taskRepository.GetTasksBySectionIdAsync(section.Id);

                        foreach (var task in section.Tasks)
                        {
                            task.Comments = await _commentRepository.GetCommentsByTaskIdAsync(task.Id);
                            task.StatusHistory = await _statusHistoryRepository.GetStatusHistoryByTaskIdAsync(task.Id);
                        }
                    }
                }

                _dbConnection.CloseConnection();

                return boards;
            }
            catch (Exception ex)
            {
                _log.LogWrite(ex.Message);
                throw;
            }
        }

        public async Task<IEnumerable<BoardModel>> GetActiveBoardsAsync()
        {
            try
            {
                string commandText = @$"select * from smartboard.board b where b.active = true";

                var boards = await _dbConnection.connection.QueryAsync<BoardModel>(commandText);

                foreach (var board in boards)
                {
                    board.Sections = await _sectionRepository.GetActiveSectionsByBoardIdAsync(board.Id);

                    foreach (var section in board.Sections)
                    {
                        section.Tasks = await _taskRepository.GetActiveTasksBySectionIdAsync(section.Id);

                        foreach (var task in section.Tasks)
                        {
                            task.Comments = await _commentRepository.GetCommentsByTaskIdAsync(task.Id);
                            task.StatusHistory = await _statusHistoryRepository.GetStatusHistoryByTaskIdAsync(task.Id);
                        }
                    }
                }

                _dbConnection.CloseConnection();

                return boards;
            }
            catch (Exception ex)
            {
                _log.LogWrite(ex.Message);
                throw;
            }
        }
    }
}

