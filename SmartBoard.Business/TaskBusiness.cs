using System;
using SmartBoardWebAPI.Data.DTOs;
using SmartBoardWebAPI.Data.Repository;
using SmartBoardWebAPI.Utils;

namespace SmartBoardWebAPI.Business
{
    public class TaskBusiness : ITaskBusiness
    {
        private readonly ILogWriter _log;
        private readonly ITaskRepository _taskRepository;
        private readonly IUserRepository _userRepository;
        private readonly ISectionRepository _sectionRepository;

        public TaskBusiness(ILogWriter log, ITaskRepository taskRepository, IUserRepository userRepository, ISectionRepository sectionRepository)
        { 
            _log = log;
            _taskRepository = taskRepository;
            _userRepository = userRepository;
            _sectionRepository = sectionRepository;
        }

        public async Task<List<TaskDTO>> GetActiveTaskBySectionIdAsync(long sectionId, bool filled)
        {
            try
            {
                var taskModelEnumerable = await _taskRepository.GetActiveTasksBySectionIdAsync(sectionId, filled);

                var taskDTOList = new List<TaskDTO>();

                foreach (var taskModel in taskModelEnumerable)
                {
                    var itemDTO = new TaskDTO();

                    itemDTO = await taskModel.ToDTO(_userRepository, _sectionRepository);

                    taskDTOList.Add(itemDTO);
                }

                return taskDTOList;
            }
            catch (Exception ex)
            {
                _log.LogWrite(ex.Message);
                throw ex;
            }
        }

        public async Task<List<TaskDTO>> GetActiveTasksAsync(bool filled)
        {
            try
            {
                var taskModelEnumerable = await _taskRepository.GetActiveTasksAsync(filled);

                var taskDTOList = new List<TaskDTO>();

                foreach (var taskModel in taskModelEnumerable)
                {
                    var itemDTO = new TaskDTO();

                    itemDTO = await taskModel.ToDTO(_userRepository, _sectionRepository);

                    taskDTOList.Add(itemDTO);
                }

                return taskDTOList;
            }
            catch (Exception ex)
            {
                _log.LogWrite(ex.Message);
                throw ex;
            }
        }

        public async Task<List<TaskDTO>> GetTaskBySectionIdAsync(long sectionId, bool filled)
        {
            try
            {
                var taskModelEnumerable = await _taskRepository.GetTasksBySectionIdAsync(sectionId, filled);

                var taskDTOList = new List<TaskDTO>();

                foreach (var taskModel in taskModelEnumerable)
                {
                    var itemDTO = new TaskDTO();

                    itemDTO = await taskModel.ToDTO(_userRepository, _sectionRepository);

                    taskDTOList.Add(itemDTO);
                }

                return taskDTOList;
            }
            catch (Exception ex)
            {
                _log.LogWrite(ex.Message);
                throw ex;
            }
        }

        public async Task<List<TaskDTO>> GetTasksAsync(bool filled)
        {
            try
            {
                var taskModelEnumerable = await _taskRepository.GetTasksAsync(filled);

                var taskDTOList = new List<TaskDTO>();

                foreach (var taskModel in taskModelEnumerable)
                {
                    var itemDTO = new TaskDTO();

                    itemDTO = await taskModel.ToDTO(_userRepository, _sectionRepository);

                    taskDTOList.Add(itemDTO);
                }

                return taskDTOList;
            }
            catch (Exception ex)
            {
                _log.LogWrite(ex.Message);
                throw ex;
            }
        }

        public async Task<TaskDTO> GetTaskByIdAsync(long id, bool filled)
        {
            try
            {
                var taskModel = await _taskRepository.GetTaskByIdAsync(id, filled);

                return await taskModel.ToDTO(_userRepository, _sectionRepository);
            }
            catch (Exception ex)
            {
                _log.LogWrite(ex.Message);
                throw ex;
            }
        }
    }
}

