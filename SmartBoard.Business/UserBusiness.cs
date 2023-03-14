using System;
using SmartBoardWebAPI.Data.DTOs;
using SmartBoardWebAPI.Data.Repository;
using SmartBoardWebAPI.Utils;

namespace SmartBoardWebAPI.Business
{
    public class UserBusiness : IUserBusiness
    {
        private readonly ILogWriter _log;
        private readonly IUserRepository _userRepository;

        public UserBusiness(ILogWriter log, IUserRepository boardRepository)
        {
            _log = log;
            _userRepository = boardRepository;
        }

        public async Task<List<UserDTO>> GetUsersAsync()
        {
            try
            {
                var userModelEnumerable = await _userRepository.GetUsersAsync();

                var userDTOList = new List<UserDTO>();

                foreach (var userModel in userModelEnumerable)
                {
                    var itemDTO = new UserDTO();

                    itemDTO = userModel.ToDTO();

                    userDTOList.Add(itemDTO);
                }

                return userDTOList;
            }
            catch (Exception ex)
            {
                _log.LogWrite(ex.Message);
                throw ex;
            }
        }
    }
}

