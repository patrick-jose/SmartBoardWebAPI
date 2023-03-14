using SmartBoardWebAPI.Data.Models;

namespace SmartBoardWebAPI.Data.Repository
{
    public interface IUserRepository
    {
        /// <summary>
        /// Get user detail by userId
        /// </summary>
        /// <param name="id"></param>
        /// <returns>UserModel</returns>
        Task<UserModel> GetUserByIdAsync(long id);

        /// <summary>
        /// Get all user details registered in database
        /// </summary>
        /// <returns>IEnumerable<UserModel></returns>
        Task<IEnumerable<UserModel>> GetUsersAsync();
    }
}