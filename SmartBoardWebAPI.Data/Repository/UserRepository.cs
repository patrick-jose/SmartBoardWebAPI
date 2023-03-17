using System;
using Dapper;
using Npgsql;
using SmartBoardWebAPI.Data.DTOs;
using SmartBoardWebAPI.Data.Models;
using SmartBoardWebAPI.Utils;

namespace SmartBoardWebAPI.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ILogWriter _log;
        private readonly DbConnection _dbConnection;

        public UserRepository(ILogWriter log)
        {
            _log = log;
            _dbConnection = new DbConnection(_log);
        }

        public async Task<IEnumerable<UserModel>> GetUsersAsync()
        {
            try
            {
                string commandText = @$"select * from smartboard.user";

                var users = await _dbConnection.connection.QueryAsync<UserModel>(commandText);

                _dbConnection.CloseConnection();

                return users;
            }
            catch (Exception ex)
            {
                _log.LogWrite(ex.Message);
                throw;
            }
        }

        public async Task<UserModel> GetUserAsync(string name, string password)
        {
            try
            {
                string commandText = @$"select * from smartboard.user u
                                        where u.name = @name
                                        and u.password = @password";

                var queryArgs = new { name = name, password = password };

                var user = await _dbConnection.connection.QueryFirstOrDefaultAsync<UserModel>(commandText, queryArgs);

                _dbConnection.CloseConnection();

                return user;
            }
            catch (Exception ex)
            {
                _log.LogWrite(ex.Message);
                throw;
            }
        }

        public async Task<UserModel> GetUserByIdAsync(long id)
        {
            try
            {
                string commandText = @$"select * from smartboard.user u
                                        where u.id = @id";

                var queryArgs = new { id };

                var user = await _dbConnection.connection.QueryFirstOrDefaultAsync<UserModel>(commandText, queryArgs);

                _dbConnection.CloseConnection();

                return user;
            }
            catch (Exception ex)
            {
                _log.LogWrite(ex.Message);
                throw;
            }
        }

        public async Task<bool> CheckCredentialsAsync(UserDTO dto, string password)
        {
            try
            {
                string commandText = @$"select * from smartboard.user u
                                        where u.name = @name
                                        and u.password = @password";

                var queryArgs = new { name = dto.Name, password };

                var user = await _dbConnection.connection.QueryFirstOrDefaultAsync<UserModel>(commandText, queryArgs);

                _dbConnection.CloseConnection();

                return (user != null);
            }
            catch (Exception ex)
            {
                _log.LogWrite(ex.Message);
                throw;
            }
        }
    }
}

