using System;
using System.Text.Json;
using PublishMessages;
using SmartBoardWebAPI.Data.DTOs;
using SmartBoardWebAPI.Data.Repository;
using SmartBoardWebAPI.Utils;

namespace SmartBoardWebAPI.Business
{
    public class UserBusiness : IUserBusiness
    {
        private readonly ILogWriter _log;
        private readonly IUserRepository _userRepository;
        private readonly ISendService _sendService;

        public UserBusiness(ILogWriter log, IUserRepository boardRepository, ISendService sendService)
        {
            _log = log;
            _userRepository = boardRepository;
            _sendService = sendService;
        }

        public async Task<bool> CheckCredentialsAsync(UserDTO userDTO, string password)
        {
            try
            {
                return await _userRepository.CheckCredentialsAsync(userDTO, password);
            }
            catch (Exception ex)
            {
                _log.LogWrite(ex.Message);
                throw ex;
            }
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

        public async Task<UserDTO> GetUserAsync(string name, string password)
        {
            try
            {
                var userModel = await _userRepository.GetUserAsync(name, password);

                return userModel.ToDTO();
            }
            catch (Exception ex)
            {
                _log.LogWrite(ex.Message);
                throw ex;
            }
        }

        public async Task<UserDTO> GetUserByIdAsync(long id)
        {
            try
            {
                var userModel = await _userRepository.GetUserByIdAsync(id);

                return userModel.ToDTO();
            }
            catch (Exception ex)
            {
                _log.LogWrite(ex.Message);
                throw ex;
            }
        }

        public async Task PostUserAsync(UserDTO user)
        {
            try
            {
                var json = JsonSerializer.Serialize<UserDTO>(user);

                var header = new Header()
                {
                    Element = ElementEnum.USER,
                    Multiple = false,
                    TransactionType = TransactionTypeEnum.INSERT
                };

                await _sendService.SendMessage(json, header);
            }
            catch (Exception ex)
            {
                _log.LogWrite(ex.Message);
                throw ex;
            }
        }

        public async Task PutUserAsync(UserDTO user)
        {
            try
            {
                var json = JsonSerializer.Serialize<UserDTO>(user);

                var header = new Header()
                {
                    Element = ElementEnum.USER,
                    Multiple = false,
                    TransactionType = TransactionTypeEnum.UPDATE
                };

                await _sendService.SendMessage(json, header);
            }
            catch (Exception ex)
            {
                _log.LogWrite(ex.Message);
                throw ex;
            }
        }
    }
}

