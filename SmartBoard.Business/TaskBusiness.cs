using System;
using PublishMessages;
using System.Text.Json;
using SmartBoardWebAPI.Data.DTOs;
using SmartBoardWebAPI.Data.Repository;
using SmartBoardWebAPI.Utils;
using System.Threading.Tasks;

namespace SmartBoardWebAPI.Business
{
    public class TaskBusiness : ITaskBusiness
    {
        private readonly ILogWriter _log;
        private readonly ITaskRepository _taskRepository;
        private readonly ISendService _sendService;

        public TaskBusiness(ILogWriter log, ITaskRepository taskRepository, ISendService sendService)
        {
            _log = log;
            _taskRepository = taskRepository;
            _sendService = sendService;
        }

        public async Task<List<TaskDTO>> GetActiveTaskBySectionIdAsync(long sectionId)
        {
            try
            {
                var taskModelEnumerable = await _taskRepository.GetActiveTasksBySectionIdAsync(sectionId);

                var taskDTOList = new List<TaskDTO>();

                foreach (var taskModel in taskModelEnumerable)
                {
                    var itemDTO = new TaskDTO();

                    itemDTO = await taskModel.ToDTO();

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

        public async Task<List<TaskDTO>> GetActiveTasksAsync()
        {
            try
            {
                var taskModelEnumerable = await _taskRepository.GetActiveTasksAsync();

                var taskDTOList = new List<TaskDTO>();

                foreach (var taskModel in taskModelEnumerable)
                {
                    var itemDTO = new TaskDTO();

                    itemDTO = await taskModel.ToDTO();

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

        public async Task<List<TaskDTO>> GetTaskBySectionIdAsync(long sectionId)
        {
            try
            {
                var taskModelEnumerable = await _taskRepository.GetTasksBySectionIdAsync(sectionId);

                var taskDTOList = new List<TaskDTO>();

                foreach (var taskModel in taskModelEnumerable)
                {
                    var itemDTO = new TaskDTO();

                    itemDTO = await taskModel.ToDTO();

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

        public async Task<List<TaskDTO>> GetTasksAsync()
        {
            try
            {
                var taskModelEnumerable = await _taskRepository.GetTasksAsync();

                var taskDTOList = new List<TaskDTO>();

                foreach (var taskModel in taskModelEnumerable)
                {
                    var itemDTO = new TaskDTO();

                    itemDTO = await taskModel.ToDTO();

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

        public async Task<TaskDTO> GetTaskByIdAsync(long id)
        {
            try
            {
                var taskModel = await _taskRepository.GetTaskByIdAsync(id);

                return await taskModel.ToDTO();
            }
            catch (Exception ex)
            {
                _log.LogWrite(ex.Message);
                throw ex;
            }
        }

        public async Task PostTaskAsync(TaskDTO task)
        {
            try
            {
                var json = JsonSerializer.Serialize<TaskDTO>(task);

                var header = new Header()
                {
                    Element = ElementEnum.TASK,
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

        public async Task PutTaskAsync(TaskDTO task)
        {
            try
            {
                var json = JsonSerializer.Serialize<TaskDTO>(task);

                var header = new Header()
                {
                    Element = ElementEnum.TASK,
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

        public async Task PutTasksAsync(List<TaskDTO> tasks)
        {
            try
            {
                var json = JsonSerializer.Serialize<List<TaskDTO>>(tasks);

                var header = new Header()
                {
                    Element = ElementEnum.TASK,
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

