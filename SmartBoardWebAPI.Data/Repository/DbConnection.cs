using System;
using Npgsql;
using SmartBoardWebAPI.Utils;

namespace SmartBoardWebAPI.Data.Repository
{
    public class DbConnection
    {
        private const string CONNECTION_STRING = "Host=localhost:5432;Username=postgres;Password=postgrespw;Database=smartboarddb;Pooling=false;Timeout=300;CommandTimeout=300";
        public readonly NpgsqlConnection connection;
        private readonly ILogWriter _log;

        public DbConnection(ILogWriter log)
        {
            try
            {
                _log = log;
                connection = new NpgsqlConnection(CONNECTION_STRING);
                connection.Open();
            }
            catch (Exception ex)
            {
                _log.LogWrite(ex.Message);
                throw;
            }
        }

        public void CloseConnection()
        {
            this.connection.Close();
        }
    }
}

