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
        private readonly ITaskRepository _taskRepository;

        public SectionRepository(ILogWriter log, ITaskRepository taskRepository)
        {
            _log = log;
            _dbConnection = new DbConnection(_log);
            _taskRepository = taskRepository;
        }

        public async Task<IEnumerable<SectionModel>> GetSectionsAsync(bool filled)
        {
            try
            {
                string commandText = @$"select * from smartboard.section s
                                        order by s.position asc";

                var sections = await _dbConnection.connection.QueryAsync<SectionModel>(commandText);

                if (filled)
                {
                    foreach (var section in sections)
                        section.Tasks = await _taskRepository.GetActiveTasksBySectionIdAsync(section.Id, filled);
                }

                _dbConnection.CloseConnection();

                return sections;
            }
            catch (Exception ex)
            {
                _log.LogWrite(ex.Message);
                throw;
            }
        }

        public async Task<IEnumerable<SectionModel>> GetActiveSectionsAsync(bool filled)
        {
            try
            {
                string commandText = @$"select * from smartboard.section s
                                        where s.active = true
                                        order by s.position asc";

                var sections = await _dbConnection.connection.QueryAsync<SectionModel>(commandText);

                if (filled)
                {
                    foreach (var section in sections)
                        section.Tasks = await _taskRepository.GetActiveTasksBySectionIdAsync(section.Id, filled);
                }

                _dbConnection.CloseConnection();

                return sections;
            }
            catch (Exception ex)
            {
                _log.LogWrite(ex.Message);
                throw;
            }
        }

        public async Task<IEnumerable<SectionModel>> GetSectionsByBoardIdAsync(long boardId, bool filled)
        {
            try
            {
                string commandText = @$"select * from smartboard.section s
                                        where s.boardid = @id
                                        order by s.position asc";

                var queryArgs = new { id = boardId };

                var sections = await _dbConnection.connection.QueryAsync<SectionModel>(commandText, queryArgs);

                if (filled)
                {
                    foreach (var section in sections)
                        section.Tasks = await _taskRepository.GetActiveTasksBySectionIdAsync(section.Id, filled);
                }

                _dbConnection.CloseConnection();

                return sections;
            }
            catch (Exception ex)
            {
                _log.LogWrite(ex.Message);
                throw;
            }
        }

        public async Task<IEnumerable<SectionModel>> GetActiveSectionsByBoardIdAsync(long boardId, bool filled)
        {
            try
            {
                string commandText = @$"select * from smartboard.section s
                                        where s.boardid = @id
                                        and s.active = true
                                        order by s.position asc";

                var queryArgs = new { id = boardId };

                var sections = await _dbConnection.connection.QueryAsync<SectionModel>(commandText, queryArgs);

                if (filled)
                {
                    foreach (var section in sections)
                        section.Tasks = await _taskRepository.GetActiveTasksBySectionIdAsync(section.Id, filled);
                }

                _dbConnection.CloseConnection();

                return sections;
            }
            catch (Exception ex)
            {
                _log.LogWrite(ex.Message);
                throw;
            }
        }

        public async Task<SectionModel> GetSectionByIdAsync(long id, bool filled)
        {
            try
            {
                string commandText = @$"select * from smartboard.section s
                                        where s.id = @id";

                var queryArgs = new { id };

                var section = await _dbConnection.connection.QueryFirstOrDefaultAsync<SectionModel>(commandText);

                if (filled)
                    section.Tasks = await _taskRepository.GetActiveTasksBySectionIdAsync(section.Id, filled);

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

