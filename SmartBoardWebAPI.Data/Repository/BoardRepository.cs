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

        public BoardRepository(ILogWriter log)
        {
            _log = log;
            _dbConnection = new DbConnection(_log);
        }

        public async Task<IEnumerable<BoardModel>> GetBoardsAsync()
        {
            try
            {
                string commandText = @$"select * from smartboard.board";

                var boards = await _dbConnection.connection.QueryAsync<BoardModel>(commandText);

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

