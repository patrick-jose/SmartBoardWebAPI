using System;
using Dapper;
using Npgsql;
using SmartBoardWebAPI.Data.Models;
using SmartBoardWebAPI.Utils;

namespace SmartBoardWebAPI.Data.Repository
{
    public class BoardRepository : IBoardRepository
    {
        private const string CONNECTION_STRING = "Host=localhost:5432;" +
                   "Username=postgres;" +
                   "Password=postgrespw;" +
                   "Database=smartboarddb";

        private readonly NpgsqlConnection connection;
        private readonly ILogWriter _log;

        public BoardRepository(ILogWriter log)
        {
            connection = new NpgsqlConnection(CONNECTION_STRING);
            connection.Open();
            _log = log;
        }

        public async Task<IEnumerable<BoardModel>> GetBoardsAsync()
        {
            try
            {
                string commandText = @$"select * from smartboard.board";

                return await connection.QueryAsync<BoardModel>(commandText);
            }
            catch (Exception ex)
            {
                _log.LogWrite(ex.Message);
                throw;
            }
        }
    }
}

