using System;
using Dapper;
using Npgsql;
using SmartBoardWebAPI.Data.Models;
using SmartBoardWebAPI.Utils;

namespace SmartBoardWebAPI.Data.Repository
{
    public class SectionRepository : ISectionRepository
    {
        private readonly ILogWriter _log;
        private readonly DbConnection _dbConnection;

        public SectionRepository(ILogWriter log)
        {
            _log = log;
            _dbConnection = new DbConnection(_log);           
        }

        public async Task<IEnumerable<SectionModel>> GetSectionsAsync()
        {
            try
            {
                string commandText = @$"select * from smartboard.section";

                var sections = await _dbConnection.connection.QueryAsync<SectionModel>(commandText);

                _dbConnection.CloseConnection();

                return sections;
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

                var sections = await _dbConnection.connection.QueryAsync<SectionModel>(commandText, queryArgs);

                _dbConnection.CloseConnection();

                return sections;
            }
            catch (Exception ex)
            {
                _log.LogWrite(ex.Message);
                throw;
            }
        }

        public async Task<IEnumerable<SectionModel>> GetActiveSectionsByBoardIdAsync(long boardId)
        {
            try
            {
                string commandText = @$"select * from smartboard.section s where s.boardid = @id and s.active = true";

                var queryArgs = new { id = boardId };

                var sections = await _dbConnection.connection.QueryAsync<SectionModel>(commandText, queryArgs);

                _dbConnection.CloseConnection();

                return sections;
            }
            catch (Exception ex)
            {
                _log.LogWrite(ex.Message);
                throw;
            }
        }

        public async Task<SectionModel> GetSectionByIdAsync(long id)
        {
            try
            {
                string commandText = @$"select * from smartboard.section s where s.id = @id";

                var queryArgs = new { id = id };

                var section = await _dbConnection.connection.QueryFirstOrDefaultAsync<SectionModel>(commandText, queryArgs);

                _dbConnection.CloseConnection();

                return section;
            }
            catch (Exception ex)
            {
                _log.LogWrite(ex.Message);
                throw;
            }
        }
    }
}

