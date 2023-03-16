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
        public async Task<List<BoardDTO>> GetAllActiveBoards()
        {
            return await _boardBusiness.GetActiveBoardsAsync();
        }

        /// <summary>
        /// update board
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        [HttpPut()]
        public async Task<ActionResult> PutBoard(BoardDTO board)
        {
            await _boardBusiness.PutBoardAsync(board);

            return Ok();
        }

        /// <summary>
        /// Insert new board
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        [HttpPost()]
        public async Task<ActionResult> PostBoard([FromBody]BoardDTO board)
        {
            await _boardBusiness.PostBoardAsync(board);

            return Ok();
        }
    }
}

