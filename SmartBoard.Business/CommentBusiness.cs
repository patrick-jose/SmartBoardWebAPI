using System;
using System.Text.Json;
using PublishMessages;
using SmartBoardWebAPI.Data.DTOs;
using SmartBoardWebAPI.Data.Repository;
using SmartBoardWebAPI.Utils;

namespace SmartBoardWebAPI.Business
{
    public class CommentBusiness : ICommentBusiness
    {
        private readonly ILogWriter _log;
        private readonly ICommentRepository _commentRepository;
        private readonly ISendService _sendService;

        public CommentBusiness(ILogWriter log, ICommentRepository commentRepository, ISendService sendService)
        {
            _log = log;
            _commentRepository = commentRepository;
            _sendService = sendService;
        }

        public async Task<List<CommentDTO>> GetCommentsByTaskIdAsync(long taskId)
        {
            try
            {
                var commentModelEnumerable = await _commentRepository.GetCommentsByTaskIdAsync(taskId);

                var commentDTOList = new List<CommentDTO>();

                foreach (var commentModel in commentModelEnumerable)
                {
                    var itemDTO = new CommentDTO();

                    itemDTO = await commentModel.ToDTO();

                    commentDTOList.Add(itemDTO);
                }

                return commentDTOList;
            }
            catch (Exception ex)
            {
                _log.LogWrite(ex.Message);
                throw ex;
            }
        }

        public async Task PostCommentAsync(CommentDTO comment)
        {
            try
            {
                var json = JsonSerializer.Serialize<CommentDTO>(comment);

                var header = new Header()
                {
                    Element = ElementEnum.COMMENT,
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
    }
}

