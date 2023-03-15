namespace SmartBoardWebAPI.Data.Repository
{
    public interface IDbConnection
    {
        void CloseConnection();
        DbConnection GetConnection();
    }
}