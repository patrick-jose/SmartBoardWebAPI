using SmartBoardWebAPI.Data.DTOs;

namespace SmartBoardWebAPI.Business
{
    public interface IUserBusiness
    {
        Task<bool> CheckCredentialsAsync(UserDTO userDTO, string password);
        Task<List<UserDTO>> GetUsersAsync();
    }
}