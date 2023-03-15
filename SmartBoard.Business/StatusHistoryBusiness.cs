using System;
using SmartBoardWebAPI.Data.DTOs;
using SmartBoardWebAPI.Data.Repository;
using SmartBoardWebAPI.Utils;

namespace SmartBoardWebAPI.Business
{
    public class StatusHistoryBusiness : IStatusHistoryBusiness
    {
        private readonly ILogWriter _log;
        private readonly IStatusHistoryRepository _statusHistoryRepository;
        private readonly ISectionRepository _sectionRepository;
        private readonly IUserRepository _userRepository;

        public StatusHistoryBusiness(ILogWriter log, IStatusHistoryRepository boardRepository, ISectionRepository sectionRepository, IUserRepository userRepository)
        {
            _log = log;
            _statusHistoryRepository = boardRepository;
            _userRepository = userRepository;
            _sectionRepository = sectionRepository;
        }

        public async Task<List<StatusHistoryDTO>> GetStatusHistoryByTaskIdAsync(long taskId)
        {
            try
            {
                var statusHistoryModelEnumerable = await _statusHistoryRepository.GetStatusHistoryByTaskIdAsync(taskId);

                var statusHistoryDTOList = new List<StatusHistoryDTO>();

                foreach (var statusHistoryModel in statusHistoryModelEnumerable)
                {
                    var itemDTO = new StatusHistoryDTO();

                    itemDTO = await statusHistoryModel.ToDTO(_userRepository, _sectionRepository);

                    statusHistoryDTOList.Add(itemDTO);
                }

                return statusHistoryDTOList;
            }
            catch (Exception ex)
            {
                _log.LogWrite(ex.Message);
                throw ex;
            }
        }
    }
}

