using System;
using Dapper;
using Npgsql;
using SmartBoardWebAPI.Data.Models;
using SmartBoardWebAPI.Utils;

namespace SmartBoardWebAPI.Data.Repository
{
    public class StatusHistoryRepository : IStatusHistoryRepository
    {
        private readonly ILogWriter _log;
        private readonly DbConnection _dbConnection;

        public StatusHistoryRepository(ILogWriter log)
        {
            _log = log;
            _dbConnection = new DbConnection(_log);
        }

        public async Task<IEnumerable<StatusHistoryModel>> GetStatusHistorysAsync()
        {
            try
            {
                string commandText = @$"select * from smartboard.statushistory sh
                                        order by sh.datemodified desc";

                var statusHistorys = await _dbConnection.connection.QueryAsync<StatusHistoryModel>(commandText);

                _dbConnection.CloseConnection();

                return statusHistorys;
            }
            catch (Exception ex)
            {
                _log.LogWrite(ex.Message);
                throw;
            }
        }

        public async Task<IEnumerable<StatusHistoryModel>> GetStatusHistoryByTaskIdAsync(long taskId)
        {
            try
            {
                string commandText = @$"select * from smartboard.statushistory sh
                                        where sh.taskid = @id
                                        order by sh.datemodified desc";

                var queryArgs = new { id = taskId };

                var statusHistory = await _dbConnection.connection.QueryAsync<StatusHistoryModel>(commandText, queryArgs);

                _dbConnection.CloseConnection();

                return statusHistory;
            }
            catch (Exception ex)
            {
                _log.LogWrite(ex.Message);
                throw;
            }
        }
    }
}

