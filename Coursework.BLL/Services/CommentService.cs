using Coursework.Entity.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Coursework.Entity.Entities;
using Coursework.Entity.Repositories;

namespace Coursework.BLL.Services
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CommentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void CreateComment(string userId, long flowerId, string text)
        {
            var account = _unitOfWork.UserRepository.Get(userId);
            var _comment = new Comment
            {
                UserId = userId,
                User = account,
                Text = text,
                FlowerId = flowerId,
                Time = DateTime.Now,
                Flower = _unitOfWork.FlowerRepository.Get(flowerId)
            };
            _unitOfWork.CommentRepository.Add(_comment);
            _unitOfWork.Save();
        }

        public IEnumerable<Comment> GetAllComments()
        {
            return _unitOfWork.CommentRepository.Get().ToList();
        }

        public IEnumerable<Comment> GetComments(long flowerId)
        {
            return _unitOfWork.CommentRepository.Get(x => x.FlowerId == flowerId).ToList();
        }
    }
}
