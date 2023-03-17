using SmartBoardWebAPI.Data.DTOs;
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

        /// <summary>
        /// Check login credentials
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="password"></param>
        /// <returns>bool</returns>
        Task<bool> CheckCredentialsAsync(UserDTO dto, string password);

        /// <summary>
        /// Get user details by name and password
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<UserModel> GetUserAsync(string name, string password);
    }
}