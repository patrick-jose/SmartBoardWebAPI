using System;
using PublishMessages;
using System.Text.Json;
using SmartBoardWebAPI.Data.DTOs;
using SmartBoardWebAPI.Data.Repository;
using SmartBoardWebAPI.Utils;
using static System.Collections.Specialized.BitVector32;

namespace SmartBoardWebAPI.Business
{
    public class SectionBusiness : ISectionBusiness
    {
        private readonly ILogWriter _log;
        private readonly ISectionRepository _sectionRepository;
        private readonly ISendService _sendService;

        public SectionBusiness(ILogWriter log, ISectionRepository sectionRepository, ISendService sendService)
        {
            _log = log;
            _sectionRepository = sectionRepository;
            _sendService = sendService;
        }

        public async Task<List<SectionDTO>> GetActiveSectionsByBoardIdAsync(long sectionId)
        {
            try
            {
                var sectionModelEnumerable = await _sectionRepository.GetActiveSectionsByBoardIdAsync(sectionId);

                var sectionDTOList = new List<SectionDTO>();

                foreach (var sectionModel in sectionModelEnumerable)
                {
                    var itemDTO = new SectionDTO();

                    itemDTO = sectionModel.ToDTO();

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

        public async Task<List<SectionDTO>> GetActiveSectionsAsync()
        {
            try
            {
                var sectionModelEnumerable = await _sectionRepository.GetActiveSectionsAsync();

                var sectionDTOList = new List<SectionDTO>();

                foreach (var sectionModel in sectionModelEnumerable)
                {
                    var itemDTO = new SectionDTO();

                    itemDTO = sectionModel.ToDTO();

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

        public async Task<List<SectionDTO>> GetSectionsByBoardIdAsync(long sectionId)
        {
            try
            {
                var sectionModelEnumerable = await _sectionRepository.GetSectionsByBoardIdAsync(sectionId);

                var sectionDTOList = new List<SectionDTO>();

                foreach (var sectionModel in sectionModelEnumerable)
                {
                    var itemDTO = new SectionDTO();

                    itemDTO = sectionModel.ToDTO();

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

        public async Task<List<SectionDTO>> GetSectionsAsync()
        {
            try
            {
                var sectionModelEnumerable = await _sectionRepository.GetSectionsAsync();

                var sectionDTOList = new List<SectionDTO>();

                foreach (var sectionModel in sectionModelEnumerable)
                {
                    var itemDTO = new SectionDTO();

                    itemDTO = sectionModel.ToDTO();

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

        public async Task<SectionDTO> GetSectionByIdAsync(long id)
        {
            try
            {
                var sectionModel = await _sectionRepository.GetSectionByIdAsync(id);

                return sectionModel.ToDTO();
            }
            catch (Exception ex)
            {
                _log.LogWrite(ex.Message);
                throw ex;
            }
        }

        public async Task PostSectionAsync(SectionDTO section)
        {
            try
            {
                var json = JsonSerializer.Serialize<SectionDTO>(section);

                var header = new Header()
                {
                    Element = ElementEnum.SECTION,
                    Multiple = false,
                    TransactionType = TransactionTypeEnum.INSERT
                };

                await _sendService.SendMessage(json, header);
            }
            catch (Exception ex)
            {
                _log.LogWrite(ex.Message);
                throw ex;
            }
        }

        public async Task PutSectionAsync(SectionDTO section)
        {
            try
            {
                var json = JsonSerializer.Serialize<SectionDTO>(section);

                var header = new Header()
                {
                    Element = ElementEnum.SECTION,
                    Multiple = false,
                    TransactionType = TransactionTypeEnum.UPDATE
                };

                await _sendService.SendMessage(json, header);
            }
            catch (Exception ex)
            {
                _log.LogWrite(ex.Message);
                throw ex;
            }
        }

        public async Task PutSectionsAsync(List<SectionDTO> sections)
        {
            try
            {
                var json = JsonSerializer.Serialize<List<SectionDTO>>(sections);

                var header = new Header()
                {
                    Element = ElementEnum.SECTION,
                    Multiple = true,
                    TransactionType = TransactionTypeEnum.UPDATE
                };

                await _sendService.SendMessage(json, header);
            }
            catch (Exception ex)
            {
                _log.LogWrite(ex.Message);
                throw ex;
            }
        }
    }
}

