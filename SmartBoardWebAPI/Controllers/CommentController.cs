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
    public class CommentController : ControllerBase
    {
        private readonly ICommentBusiness _commentBusiness;

        public CommentController(ICommentBusiness commentBusiness)
        {
            _commentBusiness = commentBusiness;
        }

        /// <summary>
        /// Get status history by task id
        /// </summary>
        /// <returns>ActionResult<List<CommentDTO>></returns>
        [HttpGet("GetCommentByTaskId/")]
        public async Task<ActionResult<List<CommentDTO>>> GetCommentsByTaskId(long taskId)
        {
            return Ok(await _commentBusiness.GetCommentsByTaskIdAsync(taskId));
        }

        /// <summary>
        /// Insert new comment
        /// </summary>
        /// <param name="comment"></param>
        /// <returns>ActionResult</returns>
        [HttpPost()]
        public async Task<ActionResult> PostCommentAsync(CommentDTO comment)
        {
            await _commentBusiness.PostCommentAsync(comment);

            return Ok();
        }
    }
}

