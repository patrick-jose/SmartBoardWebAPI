using SmartBoardWebAPI.Data.Models;

namespace SmartBoardWebAPI.Data.Repository
{
    public interface ISectionRepository
    {
        Task<IEnumerable<SectionModel>> GetSectionsAsync();
        Task<IEnumerable<SectionModel>> GetSectionsByBoardIdAsync(long id);
    }
}