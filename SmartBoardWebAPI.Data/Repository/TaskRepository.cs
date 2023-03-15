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
        private readonly ICommentRepository _commnentRepository;
        private readonly IStatusHistoryRepository _statusHistoryRepository;

        public TaskRepository(ILogWriter log, ICommentRepository commentRepository, IStatusHistoryRepository statusHistoryRepository)
        {
            _log = log;
            _dbConnection = new DbConnection(_log);
            _commnentRepository = commentRepository;
            _statusHistoryRepository = statusHistoryRepository;
        }

        public async Task<IEnumerable<TaskModel>> GetActiveTasksAsync(bool filled)
        {
            try
            {
                string commandText = @$"select * from smartboard.task t
                                        where t.active = true
                                        order by t.position asc";

                var tasks = await _dbConnection.connection.QueryAsync<TaskModel>(commandText);

                if (filled)
                {
                    foreach (var task in tasks)
                    {
                        task.Comments = await _commnentRepository.GetCommentsByTaskIdAsync(task.Id);
                        task.StatusHistory = await _statusHistoryRepository.GetStatusHistoryByTaskIdAsync(task.Id);
                    }
                }

                _dbConnection.CloseConnection();

                return tasks;
            }
            catch (Exception ex)
            {
                _log.LogWrite(ex.Message);
                throw;
            }
        }

        public async Task<IEnumerable<TaskModel>> GetActiveTasksBySectionIdAsync(long sectionId, bool filled)
        {
            try
            {
                string commandText = @$"select * from smartboard.task t
                                        where t.sectionid = @id
                                        and t.active = true
                                        order by t.position asc";

                var queryArgs = new { id = sectionId };

                var tasks = await _dbConnection.connection.QueryAsync<TaskModel>(commandText, queryArgs);

                if (filled)
                {
                    foreach (var task in tasks)
                    {
                        task.Comments = await _commnentRepository.GetCommentsByTaskIdAsync(task.Id);
                        task.StatusHistory = await _statusHistoryRepository.GetStatusHistoryByTaskIdAsync(task.Id);
                    }
                }

                _dbConnection.CloseConnection();

                return tasks;
            }
            catch (Exception ex)
            {
                _log.LogWrite(ex.Message);
                throw;
            }
        }

        public async Task<IEnumerable<TaskModel>> GetTasksBySectionIdAsync(long sectionId, bool filled)
        {
            try
            {
                string commandText = @$"select * from smartboard.task t
                                        where t.sectionid = @id
                                        order by t.position asc";

                var queryArgs = new { id = sectionId };

                var tasks = await _dbConnection.connection.QueryAsync<TaskModel>(commandText, queryArgs);

                if (filled)
                {
                    foreach (var task in tasks)
                    {
                        task.Comments = await _commnentRepository.GetCommentsByTaskIdAsync(task.Id);
                        task.StatusHistory = await _statusHistoryRepository.GetStatusHistoryByTaskIdAsync(task.Id);
                    }
                }

                _dbConnection.CloseConnection();

                return tasks;
            }
            catch (Exception ex)
            {
                _log.LogWrite(ex.Message);
                throw;
            }
        }

        public async Task<IEnumerable<TaskModel>> GetTasksAsync(bool filled)
        {
            try
            {
                string commandText = @$"select * from smartboard.task t
                                        order by t.position asc";

                var tasks = await _dbConnection.connection.QueryAsync<TaskModel>(commandText);

                if (filled)
                {
                    foreach (var task in tasks)
                    {
                        task.Comments = await _commnentRepository.GetCommentsByTaskIdAsync(task.Id);
                        task.StatusHistory = await _statusHistoryRepository.GetStatusHistoryByTaskIdAsync(task.Id);
                    }
                }

                _dbConnection.CloseConnection();

                return tasks;
            }
            catch (Exception ex)
            {
                _log.LogWrite(ex.Message);
                throw;
            }
        }

        public async Task<TaskModel> GetTaskByIdAsync(long id, bool filled)
        {
            try
            {
                string commandText = @$"select * from smartboard.task t
                                        where t.id = @id";

                var queryArgs = new { id };

                var task = await _dbConnection.connection.QueryFirstOrDefaultAsync<TaskModel>(commandText, queryArgs);

                if (filled)
                {
                    task.Comments = await _commnentRepository.GetCommentsByTaskIdAsync(task.Id);
                    task.StatusHistory = await _statusHistoryRepository.GetStatusHistoryByTaskIdAsync(task.Id);
                }

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

