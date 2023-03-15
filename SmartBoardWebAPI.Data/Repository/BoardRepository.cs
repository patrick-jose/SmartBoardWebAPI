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

        public BoardRepository(ILogWriter log, ISectionRepository sectionRepository)
        {
            _log = log;
            _dbConnection = new DbConnection(_log);
            _sectionRepository = sectionRepository;
        }

        public async Task<IEnumerable<BoardModel>> GetBoardsAsync(bool filled)
        {
            try
            {
                string commandText = @$"select * from smartboard.board";

                var boards = await _dbConnection.connection.QueryAsync<BoardModel>(commandText);

                if (filled)
                { 
                    foreach (var board in boards)
                        board.Sections = await _sectionRepository.GetSectionsByBoardIdAsync(board.Id, filled);
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

        public async Task<IEnumerable<BoardModel>> GetActiveBoardsAsync(bool filled)
        {
            try
            {
                string commandText = @$"select * from smartboard.board b where b.active = true";

                var boards = await _dbConnection.connection.QueryAsync<BoardModel>(commandText);

                if (filled)
                {
                    foreach (var board in boards)
                        board.Sections = await _sectionRepository.GetActiveSectionsByBoardIdAsync(board.Id, filled);
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

