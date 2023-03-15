using System;
using SmartBoardWebAPI.Data.DTOs;
using SmartBoardWebAPI.Data.Repository;
using SmartBoardWebAPI.Utils;

namespace SmartBoardWebAPI.Business
{
    public class SectionBusiness : ISectionBusiness
    {
        private readonly ILogWriter _log;
        private readonly ISectionRepository _sectionRepository;
        private readonly IUserRepository _userRepository;

        public SectionBusiness(ILogWriter log, ISectionRepository sectionRepository, IUserRepository userRepository)
        {
            _log = log;
            _sectionRepository = sectionRepository;
            _userRepository = userRepository;
        }

        public async Task<List<SectionDTO>> GetActiveSectionsByBoardIdAsync(long sectionId, bool filled)
        {
            try
            {
                var sectionModelEnumerable = await _sectionRepository.GetActiveSectionsByBoardIdAsync(sectionId, filled);

                var sectionDTOList = new List<SectionDTO>();

                foreach (var sectionModel in sectionModelEnumerable)
                {
                    var itemDTO = new SectionDTO();

                    itemDTO = sectionModel.ToDTO(_userRepository, _sectionRepository);

                    sectionDTOList.Add(itemDTO);
                }

                return sectionDTOList;
            }
            catch (Exception ex)
            {
                _log.LogWrite(ex.Message);
                throw ex;
            }
        }

        public async Task<List<SectionDTO>> GetActiveSectionsAsync(bool filled)
        {
            try
            {
                var sectionModelEnumerable = await _sectionRepository.GetActiveSectionsAsync(filled);

                var sectionDTOList = new List<SectionDTO>();

                foreach (var sectionModel in sectionModelEnumerable)
                {
                    var itemDTO = new SectionDTO();

                    itemDTO = sectionModel.ToDTO(_userRepository, _sectionRepository);

                    sectionDTOList.Add(itemDTO);
                }

                return sectionDTOList;
            }
            catch (Exception ex)
            {
                _log.LogWrite(ex.Message);
                throw ex;
            }
        }

        public async Task<List<SectionDTO>> GetSectionsByBoardIdAsync(long sectionId, bool filled)
        {
            try
            {
                var sectionModelEnumerable = await _sectionRepository.GetSectionsByBoardIdAsync(sectionId, filled);

                var sectionDTOList = new List<SectionDTO>();

                foreach (var sectionModel in sectionModelEnumerable)
                {
                    var itemDTO = new SectionDTO();

                    itemDTO = sectionModel.ToDTO(_userRepository, _sectionRepository);

                    sectionDTOList.Add(itemDTO);
                }

                return sectionDTOList;
            }
            catch (Exception ex)
            {
                _log.LogWrite(ex.Message);
                throw ex;
            }
        }

        public async Task<List<SectionDTO>> GetSectionsAsync(bool filled)
        {
            try
            {
                var sectionModelEnumerable = await _sectionRepository.GetSectionsAsync(filled);

                var sectionDTOList = new List<SectionDTO>();

                foreach (var sectionModel in sectionModelEnumerable)
                {
                    var itemDTO = new SectionDTO();

                    itemDTO = sectionModel.ToDTO(_userRepository, _sectionRepository);

                    sectionDTOList.Add(itemDTO);
                }

                return sectionDTOList;
            }
            catch (Exception ex)
            {
                _log.LogWrite(ex.Message);
                throw ex;
            }
        }

        public async Task<SectionDTO> GetSectionByIdAsync(long id, bool filled)
        {
            try
            {
                var sectionModel = await _sectionRepository.GetSectionByIdAsync(id, filled);

                return sectionModel.ToDTO(_userRepository, _sectionRepository);
            }
            catch (Exception ex)
            {
                _log.LogWrite(ex.Message);
                throw ex;
            }
        }
    }
}

