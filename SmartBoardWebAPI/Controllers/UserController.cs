using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmartBoardWebAPI.Business;
using SmartBoardWebAPI.Data.DTOs;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartUserWebAPI.Controllers
{
    /// <summary>
    /// Users informations
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
        /// Get all active completed users
        /// </summary>
        /// <returns>List<UserDTO></returns>
        [HttpGet("GetAllUsers/")]
        public async Task<List<UserDTO>> GetAllUsers()
        {
            return await _userBusiness.GetUsersAsync();
        }

        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("")]
        public async Task<UserDTO> GetUserById(long id)
        {
            return await _userBusiness.GetUserByIdAsync(id);
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

        /// <summary>
        /// Update user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut()]
        public async Task PutUser(UserDTO user)
        {
            await _userBusiness.PutUserAsync(user);
        }

        /// <summary>
        /// Insert new user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost()]
        public async Task PostUser([FromBody] UserDTO user)
        {
            await _userBusiness.PostUserAsync(user);
        }
    }
}

