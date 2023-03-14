using SmartBoardWebAPI.Data.DTOs;

namespace SmartBoardWebAPI.Business
{
    public interface IUserBusiness
    {
        Task<List<UserDTO>> GetUsersAsync();
    }
}