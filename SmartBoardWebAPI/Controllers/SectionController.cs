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
        public async Task<List<SectionDTO>> GetAllSections()
        {
            return await _sectionBusiness.GetSectionsAsync();
        }

        /// <summary>
        /// Get all sections by board id
        /// </summary>
        /// <returns>List<SectionModel></returns>
        [HttpGet("GetAllSectionsByBoardId/")]
        public async Task<List<SectionDTO>> GetAllSectionsByBoardId(long boardId)
        {
            return await _sectionBusiness.GetSectionsByBoardIdAsync(boardId);
        }

        /// <summary>
        /// Get all active sections
        /// </summary>
        /// <returns>List<SectionDTO></returns>
        [HttpGet("GetAllActiveSections/")]
        public async Task<List<SectionDTO>> GetAllActiveSections()
        {
            return await _sectionBusiness.GetActiveSectionsAsync();
        }

        /// <summary>
        /// Get all active sections by board id
        /// </summary>
        /// <returns>List<sectionModel></returns>
        [HttpGet("GetAllActiveSectionsByBoardId/")]
        public async Task<List<SectionDTO>> GetAllActivesectionsByBoardId(long boardId)
        {
            return await _sectionBusiness.GetActiveSectionsByBoardIdAsync(boardId);
        }

        /// <summary>
        /// Get section by id
        /// </summary>
        /// <returns>SectionDTO</returns>
        [HttpGet("GetSectionById/")]
        public async Task<SectionDTO> GetSectionById(long id)
        {
            return await _sectionBusiness.GetSectionByIdAsync(id);
        }

        /// <summary>
        /// update section
        /// </summary>
        /// <param name="section"></param>
        /// <returns></returns>
        [HttpPut()]
        public async Task<ActionResult> PutSection(SectionDTO section)
        {
            await _sectionBusiness.PutSectionAsync(section);

            return Ok();
        }

        /// <summary>
        /// Update multiple sections
        /// </summary>
        /// <param name="section"></param>
        /// <returns></returns>
        [HttpPut("Multiple/")]
        public async Task<ActionResult> PutSections(List<SectionDTO> section)
        {
            await _sectionBusiness.PutSectionsAsync(section);

            return Ok();
        }

        /// <summary>
        /// Insert new section
        /// </summary>
        /// <param name="section"></param>
        /// <returns></returns>
        [HttpPost()]
        public async Task<ActionResult> PostSection([FromBody]SectionDTO section)
        {
            await _sectionBusiness.PostSectionAsync(section);

            return Ok();
        }
    }
}

