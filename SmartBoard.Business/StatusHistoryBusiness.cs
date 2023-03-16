using System;
using PublishMessages;
using System.Text.Json;
using SmartBoardWebAPI.Data.DTOs;
using SmartBoardWebAPI.Data.Repository;
using SmartBoardWebAPI.Utils;

namespace SmartBoardWebAPI.Business
{
    public class StatusHistoryBusiness : IStatusHistoryBusiness
    {
        private readonly ILogWriter _log;
        private readonly IStatusHistoryRepository _statusHistoryRepository;
        private readonly ISendService _sendService;

        public StatusHistoryBusiness(ILogWriter log, IStatusHistoryRepository boardRepository, ISendService sendService)
        {
            _log = log;
            _statusHistoryRepository = boardRepository;
            _sendService = sendService;
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

                    itemDTO = await statusHistoryModel.ToDTO();

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

        public async Task PostStatusHistoryAsync(StatusHistoryDTO statusHistory)
        {
            try
            {
                var json = JsonSerializer.Serialize<StatusHistoryDTO>(statusHistory);

                var header = new Header()
                {
                    Element = ElementEnum.STATUSHISTORY,
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
    }
}

