using SmartBoardWebAPI.Data.DTOs;

namespace SmartBoardWebAPI.Business
{
    public interface ISectionBusiness
    {
        /// <summary>
        /// Get active sections by board id
        /// </summary>
        /// <param name="sectionId"></param>
        /// <param name="filled"></param>
        /// <returns>List<SectionDTO></returns>
        Task<List<SectionDTO>> GetActiveSectionsByBoardIdAsync(long sectionId, bool filled);

        /// <summary>
        /// Get all active sections
        /// </summary>
        /// <param name="filled"></param>
        /// <returns>List<SectionDTO></returns>
        Task<List<SectionDTO>> GetActiveSectionsAsync(bool filled);

        /// <summary>
        /// Get sections by board id
        /// </summary>
        /// <param name="sectionId"></param>
        /// <param name="filled"></param>
        /// <returns></returns>
        Task<List<SectionDTO>> GetSectionsByBoardIdAsync(long sectionId, bool filled);

        /// <summary>
        /// Get section by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="filled"></param>
        /// <returns>SectionDTO</returns>
        Task<SectionDTO> GetSectionByIdAsync(long id, bool filled);

        /// <summary>
        /// Get all sections
        /// </summary>
        /// <param name="filled"></param>
        /// <returns>List<SectionDTO></returns>
        Task<List<SectionDTO>> GetSectionsAsync(bool filled);
    }
}