using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SmartBoardWebAPI.Business;
using SmartBoardWebAPI.Data.DTOs;
using SmartBoardWebAPI.Data.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartsectionWebAPI.Controllers
{
    /// <summary>
    /// sections informations
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class SectionController : ControllerBase
    {
        private readonly ISectionBusiness _sectionBusiness;

        public SectionController(ISectionBusiness sectionBusiness)
        {
            _sectionBusiness = sectionBusiness;
        }

        /// <summary>
        /// Get all sections
        /// </summary>
        /// <returns>List<SectionDTO></returns>
        [HttpGet("GetAllSections/")]
        public async Task<List<SectionDTO>> GetAllSections(bool filled)
        {
            return await _sectionBusiness.GetSectionsAsync(filled);
        }

        /// <summary>
        /// Get all sections by board id
        /// </summary>
        /// <returns>List<SectionModel></returns>
        [HttpGet("GetAllSectionsByBoardId/")]
        public async Task<List<SectionDTO>> GetAllSectionsByBoardId(long boardId, bool filled)
        {
            return await _sectionBusiness.GetSectionsByBoardIdAsync(boardId, filled);
        }

        /// <summary>
        /// Get all active sections
        /// </summary>
        /// <returns>List<SectionDTO></returns>
        [HttpGet("GetAllActiveSections/")]
        public async Task<List<SectionDTO>> GetAllActiveSections(bool filled)
        {
            return await _sectionBusiness.GetActiveSectionsAsync(filled);
        }

        /// <summary>
        /// Get all active sections by board id
        /// </summary>
        /// <returns>List<sectionModel></returns>
        [HttpGet("GetAllActiveSectionsByBoardId/")]
        public async Task<List<SectionDTO>> GetAllActivesectionsByBoardId(long boardId, bool filled)
        {
            return await _sectionBusiness.GetActiveSectionsByBoardIdAsync(boardId, filled);
        }

        /// <summary>
        /// Get section by id
        /// </summary>
        /// <returns>SectionDTO</returns>
        [HttpGet("GetSectionById/")]
        public async Task<SectionDTO> GetSectionById(long id, bool filled)
        {
            return await _sectionBusiness.GetSectionByIdAsync(id, filled);
        }
    }
}

