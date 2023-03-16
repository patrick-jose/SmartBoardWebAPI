using SmartBoardWebAPI.Data.Models;

namespace SmartBoardWebAPI.Data.Repository
{
    public interface ISectionRepository
    {
        /// <summary>
        /// Get all sections registered in database
        /// </summary>
        /// <returns>IEnumerable<SectionModel></returns>
        Task<IEnumerable<SectionModel>> GetSectionsAsync();

        /// <summary>
        /// Get all active sections registered in database
        /// </summary>
        /// <returns>IEnumerable<SectionModel></returns>
        Task<IEnumerable<SectionModel>> GetActiveSectionsAsync();

        /// <summary>
        /// Get sections registered in database by board id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>IEnumerable<SectionModel></returns>
        Task<IEnumerable<SectionModel>> GetSectionsByBoardIdAsync(long id);

        /// <summary>
        /// Get active sections registered in database by boardId
        /// </summary>
        /// <param name="id"></param>
        /// <returns>IEnumerable<SectionModel></returns>
        Task<IEnumerable<SectionModel>> GetActiveSectionsByBoardIdAsync(long id);

        /// <summary>
        /// Get section registered in database by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>IEnumerable<SectionModel></returns>
        Task<SectionModel> GetSectionByIdAsync(long id);
    }
}