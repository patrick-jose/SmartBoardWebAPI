using System;
using Dapper;
using Npgsql;
using SmartBoardWebAPI.Data.Models;
using SmartBoardWebAPI.Utils;

namespace SmartBoardWebAPI.Data.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ILogWriter _log;
        private readonly DbConnection _dbConnection;

        public CommentRepository(ILogWriter log)
        {
            _log = log;
            _dbConnection = new DbConnection(_log);
        }

        public async Task<IEnumerable<CommentModel>> GetCommentsAsync()
        {
            try
            {
                string commandText = @$"select * from smartboard.comment c
                                        order by c.datecreation desc";

                var comments = await _dbConnection.connection.QueryAsync<CommentModel>(commandText);

                _dbConnection.CloseConnection();

                return comments;
            }
            catch (Exception ex)
            {
                _log.LogWrite(ex.Message);
                throw;
            }
        }

        public async Task<IEnumerable<CommentModel>> GetCommentsByTaskIdAsync(long taskId)
        {
            try
            {
                string commandText = @$"select * from smartboard.comment c
                                        where c.taskid = @id
                                    order by c.datecreation desc";

                var queryArgs = new { id = taskId };

                var comments = await _dbConnection.connection.QueryAsync<CommentModel>(commandText, queryArgs);

                _dbConnection.CloseConnection();

                return comments;
            }
            catch (Exception ex)
            {
                _log.LogWrite(ex.Message);
                throw;
            }
        }
    }
}

