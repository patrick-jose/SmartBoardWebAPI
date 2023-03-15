﻿using System;
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
        private readonly IUserRepository _userRepository;
        private readonly ISectionRepository _sectionRepository;

        public BoardBusiness(ILogWriter log, IBoardRepository boardRepository, ISectionRepository sectionRepository, IUserRepository userRepository)
        {
            _log = log;
            _boardRepository = boardRepository;
            _sectionRepository = sectionRepository;
            _userRepository = userRepository;
        }

        public async Task<List<BoardDTO>> GetActiveBoardsAsync(bool filled)
        {
            try
            {
                var boardModelEnumerable = await _boardRepository.GetActiveBoardsAsync(filled);

                var boardDTOList = new List<BoardDTO>();

                foreach (var boardModel in boardModelEnumerable)
                {
                    var itemDTO = new BoardDTO();

                    itemDTO = boardModel.ToDTO(_userRepository, _sectionRepository);

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

        public async Task<IEnumerable<BoardModel>> GetActiveBoardsModelAsync(bool filled)
        {
            try
            {
                return await _boardRepository.GetActiveBoardsAsync(filled);
            }
            catch (Exception ex)
            {
                _log.LogWrite(ex.Message);
                throw ex;
            }
        }
    }
}

