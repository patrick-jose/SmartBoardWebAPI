using SmartBoardWebAPI.Data.DTOs;

namespace SmartBoardWebAPI.Business
{
    public interface ISectionBusiness
    {
        /// <summary>
        /// Get active sections by board id
        /// </summary>
        /// <param name="sectionId"></param>
        /// <returns>List<SectionDTO></returns>
        Task<List<SectionDTO>> GetActiveSectionsByBoardIdAsync(long sectionId);

        /// <summary>
        /// Get all active sections
        /// </summary>
        /// <returns>List<SectionDTO></returns>
        Task<List<SectionDTO>> GetActiveSectionsAsync();

        /// <summary>
        /// Get sections by board id
        /// </summary>
        /// <param name="sectionId"></param>
        /// <returns></returns>
        Task<List<SectionDTO>> GetSectionsByBoardIdAsync(long sectionId);

        /// <summary>
        /// Get section by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>SectionDTO</returns>
        Task<SectionDTO> GetSectionByIdAsync(long id);

        /// <summary>
        /// Get all sections
        /// </summary>
        /// <returns>List<SectionDTO></returns>
        Task<List<SectionDTO>> GetSectionsAsync();

        /// <summary>
        /// Insert new section
        /// </summary>
        /// <param name="section"></param>
        /// <returns></returns>
        Task PostSectionAsync(SectionDTO section);

        /// <summary>
        /// Update a section
        /// </summary>
        /// <param name="section"></param>
        /// <returns></returns>
        Task PutSectionAsync(SectionDTO section);

        /// <summary>
        /// Update multiple sections
        /// </summary>
        /// <param name="sections"></param>
        /// <returns></returns>
        Task PutSectionsAsync(List<SectionDTO> sections);
    }
}