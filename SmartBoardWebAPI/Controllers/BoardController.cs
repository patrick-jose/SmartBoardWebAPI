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
        private readonly IBoardBusiness _boardBusiness;

        public BoardController(IBoardBusiness boardBusiness)
        {
            _boardBusiness = boardBusiness;
        }

        /// <summary>
        /// Get all active boards
        /// </summary>
        /// <param name="filled"></param>
        /// <returns>List<BoardDTO></returns>
        [HttpGet("GetAllActiveBoards/")]
        public async Task<List<BoardDTO>> GetAllActiveBoardsFilled(bool filled)
        {
            return await _boardBusiness.GetActiveBoardsAsync(filled);
        }

        /// <summary>
        /// Get all active boards
        /// </summary>
        /// <param name="filled"></param>
        /// <returns>List<BoardModel></returns>
        [HttpGet("GetAllActiveBoardsModel/")]
        public async Task<IEnumerable<BoardModel>> GetAllActiveBoardsModelFilled(bool filled)
        {
            return await _boardBusiness.GetActiveBoardsModelAsync(filled);
        }
    }
}

