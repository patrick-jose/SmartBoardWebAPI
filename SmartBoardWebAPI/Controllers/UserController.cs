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
    public class UserController : ControllerBase
    {
        private readonly IUserBusiness _userBusiness;

        public UserController(IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }

        /// <summary>
        /// Get all active completed boards
        /// </summary>
        /// <returns>List<BoardDTO></returns>
        [HttpGet("GetAllUsers/")]
        public async Task<List<UserDTO>> GetAllUsers()
        {
            return await _userBusiness.GetUsersAsync();
        }

        /// <summary>
        /// Check login credentials
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="password"></param>
        /// <returns>bool</returns>
        [HttpGet("CheckCredentials/")]
        public async Task<bool> CheckCredentials(long userId, string password)
        {
            return await _userBusiness.CheckCredentialsAsync(new UserDTO() { Id = userId }, password);
        }
    }
}

