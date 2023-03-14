using System;
using Dapper;
using Npgsql;
using SmartBoardWebAPI.Data.Models;
using SmartBoardWebAPI.Utils;

namespace SmartBoardWebAPI.Data.Repository
{
    public class SectionRepository : ISectionRepository
    {
        private const string CONNECTION_STRING = "Host=localhost:5432;" +
                   "Username=postgres;" +
                   "Password=postgrespw;" +
                   "Database=smartboarddb";

        private readonly NpgsqlConnection connection;
        private readonly ILogWriter _log;

        public SectionRepository(ILogWriter log)
        {
            connection = new NpgsqlConnection(CONNECTION_STRING);
            connection.Open();
            _log = log;
        }

        public async Task<IEnumerable<SectionModel>> GetSectionsAsync()
        {
            try
            {
                string commandText = @$"select * from smartboard.section";

                return await connection.QueryAsync<SectionModel>(commandText);
            }
            catch (Exception ex)
            {
                _log.LogWrite(ex.Message);
                throw;
            }
        }

        public async Task<IEnumerable<SectionModel>> GetSectionsByBoardIdAsync(long boardId)
        {
            try
            {
                string commandText = @$"select * from smartboard.section s where s.boardid = @id";

                var queryArgs = new { id = boardId };

                return await connection.QueryAsync<SectionModel>(commandText, queryArgs);
            }
            catch (Exception ex)
            {
                _log.LogWrite(ex.Message);
                throw;
            }
        }
    }
}

