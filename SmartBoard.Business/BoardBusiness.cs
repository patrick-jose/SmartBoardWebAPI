using System;
using System.Text.Json;
using PublishMessages;
using SmartBoardWebAPI.Data.DTOs;
using SmartBoardWebAPI.Data.Models;
using SmartBoardWebAPI.Data.Repository;
using SmartBoardWebAPI.Utils;

namespace SmartBoardWebAPI.Business
{
    public class BoardBusiness : IBoardBusiness
    {
        private readonly ILogWriter _log;
        private readonly IBoardRepository _boardRepository;
        private readonly ISendService _sendService;

        public BoardBusiness(
            ILogWriter log,
            IBoardRepository boardRepository,
            ISendService sendService)
        {
            _log = log;
            _boardRepository = boardRepository;
            _sendService = sendService;
        }

        public async Task<List<BoardDTO>> GetActiveBoardsAsync()
        {
            try
            {
                var boardModelEnumerable = await _boardRepository.GetActiveBoardsAsync();

                var boardDTOList = new List<BoardDTO>();

                foreach (var boardModel in boardModelEnumerable)
                {
                    var itemDTO = new BoardDTO();

                    itemDTO = boardModel.ToDTO();

                    boardDTOList.Add(itemDTO);
                }

                return boardDTOList;
            }
            catch (Exception ex)
            {
                _log.LogWrite(ex.Message);
                throw ex;
            }
        }

        public async Task PostBoardAsync(BoardDTO board)
        {
            try
            {
                var json = JsonSerializer.Serialize<BoardDTO>(board);

                var header = new Header()
                {
                    Element = ElementEnum.BOARD,
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

        public async Task PutBoardAsync(BoardDTO board)
        {
            try
            {
                var json = JsonSerializer.Serialize<BoardDTO>(board);

                var header = new Header()
                {
                    Element = ElementEnum.BOARD,
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

