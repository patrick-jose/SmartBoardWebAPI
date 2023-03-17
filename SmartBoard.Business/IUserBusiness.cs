using SmartBoardWebAPI.Data.DTOs;

namespace SmartBoardWebAPI.Business
{
    public interface IUserBusiness
    {
        /// <summary>
        /// Check username and password of user
        /// </summary>
        /// <param name="userDTO"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<bool> CheckCredentialsAsync(UserDTO userDTO, string password);

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns></returns>
        Task<List<UserDTO>> GetUsersAsync();

        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<UserDTO> GetUserByIdAsync(long id);

        /// <summary>
        /// Insert new user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task PostUserAsync(UserDTO user);

        /// <summary>
        /// Update user credential
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task PutUserAsync(UserDTO user);

        /// <summary>
        /// Get user details by name and password
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<UserDTO> GetUserAsync(string name, string password);
    }
}