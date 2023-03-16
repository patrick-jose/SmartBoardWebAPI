using System;
using Dapper;
using Npgsql;
using SmartBoardWebAPI.Data.Models;
using SmartBoardWebAPI.Utils;
using static System.Collections.Specialized.BitVector32;

namespace SmartBoardWebAPI.Data.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ILogWriter _log;
        private readonly DbConnection _dbConnection;

        public TaskRepository(ILogWriter log)
        {
            _log = log;
            _dbConnection = new DbConnection(_log);
        }

        public async Task<IEnumerable<TaskModel>> GetActiveTasksAsync()
        {
            try
            {
                string commandText = @$"select * from smartboard.task t
                                        where t.active = true
                                        order by t.position asc";

                var tasks = await _dbConnection.connection.QueryAsync<TaskModel>(commandText);

                _dbConnection.CloseConnection();

                return tasks;
            }
            catch (Exception ex)
            {
                _log.LogWrite(ex.Message);
                throw;
            }
        }

        public async Task<IEnumerable<TaskModel>> GetActiveTasksBySectionIdAsync(long sectionId)
        {
            try
            {
                string commandText = @$"select * from smartboard.task t
                                        where t.sectionid = @id
                                        and t.active = true
                                        order by t.position asc";

                var queryArgs = new { id = sectionId };

                var tasks = await _dbConnection.connection.QueryAsync<TaskModel>(commandText, queryArgs);

                _dbConnection.CloseConnection();

                return tasks;
            }
            catch (Exception ex)
            {
                _log.LogWrite(ex.Message);
                throw;
            }
        }

        public async Task<IEnumerable<TaskModel>> GetTasksBySectionIdAsync(long sectionId)
        {
            try
            {
                string commandText = @$"select * from smartboard.task t
                                        where t.sectionid = @id
                                        order by t.position asc";

                var queryArgs = new { id = sectionId };

                var tasks = await _dbConnection.connection.QueryAsync<TaskModel>(commandText, queryArgs);

                _dbConnection.CloseConnection();

                return tasks;
            }
            catch (Exception ex)
            {
                _log.LogWrite(ex.Message);
                throw;
            }
        }

        public async Task<IEnumerable<TaskModel>> GetTasksAsync()
        {
            try
            {
                string commandText = @$"select * from smartboard.task t
                                        order by t.position asc";

                var tasks = await _dbConnection.connection.QueryAsync<TaskModel>(commandText);

                _dbConnection.CloseConnection();

                return tasks;
            }
            catch (Exception ex)
            {
                _log.LogWrite(ex.Message);
                throw;
            }
        }

        public async Task<TaskModel> GetTaskByIdAsync(long id)
        {
            try
            {
                string commandText = @$"select * from smartboard.task t
                                        where t.id = @id";

                var queryArgs = new { id };

                var task = await _dbConnection.connection.QueryFirstOrDefaultAsync<TaskModel>(commandText, queryArgs);

                _dbConnection.CloseConnection();

                return task;
            }
            catch (Exception ex)
            {
                _log.LogWrite(ex.Message);
                throw;
            }
        }
    }
}

