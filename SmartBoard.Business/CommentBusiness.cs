using System;
using SmartBoardWebAPI.Data.DTOs;
using SmartBoardWebAPI.Data.Repository;
using SmartBoardWebAPI.Utils;

namespace SmartBoardWebAPI.Business
{
    public class CommentBusiness : ICommentBusiness
    {
        private readonly ILogWriter _log;
        private readonly ICommentRepository _commentRepository;
        private readonly IUserRepository _userRepository;

        public CommentBusiness(ILogWriter log, ICommentRepository commentRepository, IUserRepository userRepository)
        {
            _log = log;
            _commentRepository = commentRepository;
            _userRepository = userRepository;
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

                    itemDTO = await commentModel.ToDTO(_userRepository);

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
    }
}

