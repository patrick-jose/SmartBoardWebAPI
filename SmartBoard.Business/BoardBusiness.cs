using System;
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

        public BoardBusiness(ILogWriter log, IBoardRepository boardRepository)
        {
            _log = log;
            _boardRepository = boardRepository;
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

        public async Task<IEnumerable<BoardModel>> GetActiveBoardsModelAsync()
        {
            try
            {
                return await _boardRepository.GetActiveBoardsAsync();
            }
            catch (Exception ex)
            {
                _log.LogWrite(ex.Message);
                throw ex;
            }
        }
    }
}

