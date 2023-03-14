using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmartBoardWebAPI.Business;
using SmartBoardWebAPI.Data.DTOs;
using SmartBoardWebAPI.Data.Models;
using SmartBoardWebAPI.Data.Repository;
using SmartBoardWebAPI.Utils;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartBoardWebAPI.Controllers
{
    /// <summary>
    /// Boards informations
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class BoardController : ControllerBase
    {
        private readonly IBoardRepository _boardRepository;
        private readonly IBoardBusiness _boardBusiness;
        private readonly ILogWriter _log;

        public BoardController(ILogWriter logger, IBoardRepository boardRepository, IBoardBusiness boardBusiness)
        {
            _log = logger;
            _boardRepository = boardRepository;
            _boardBusiness = boardBusiness;
        }

        /// <summary>
        /// Get all active completed boards
        /// </summary>
        /// <returns>List<BoardDTO></returns>
        [HttpGet("getAllActiveBoards/")]
        public async Task<List<BoardDTO>> GetAllActiveBoards()
        {
            return await _boardBusiness.GetActiveBoardsAsync();
        }

        /// <summary>
        /// Get all active completed boards
        /// </summary>
        /// <returns>List<BoardModel></returns>
        [HttpGet("getAllActiveBoardsModel/")]
        public async Task<IEnumerable<BoardModel>> GetAllActiveBoardsModel()
        {
            return await _boardBusiness.GetActiveBoardsModelAsync();
        }
    }
}

